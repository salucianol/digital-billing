using DigitalBilling.Core.BusinessServices;
using DigitalBilling.Core.Entities;
using DigitalBilling.Core.Interfaces;
using DigitalBilling.Core.ValueObjects;
using DigitalBilling.Core.ApplicationExceptions;
using DigitalBilling.UnitTests.FakesImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DigitalBilling.UnitTests {
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class InvoiceTests {
        private readonly IInvoiceService invoiceService;

        public InvoiceTests() {
            invoiceService = new InvoiceService(new FakeParserService(),
                                                    new FakeClientService(),
                                                    new FakeInvoiceRepository());
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void CalculateAmountsWithPositiveAmounts() {
            // Act Action Assert
            Invoice invoice = new Invoice {
                ClientIdentifier = "",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Date = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                Id = Guid.NewGuid(),
                Items = new List<Item> {
                    new Item{
                        Id = new Guid(),
                        Price = 1M,
                        Taxes = new List<Tax> {
                            new Tax{
                                Name = "ITBIS",
                                Rate = 0.18f,
                                RateType = Core.RateType.Base
                            }
                        }
                    }
                }
            };

            (Amount taxes, Amount amount) = invoiceService.CalculateAmounts(invoice);

            Assert.AreEqual(0.18M, taxes);
            Assert.AreEqual(1, amount);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeAmountException))]
        public void CalculateAmountsWithNegativeAmounts() {
            // Act Action Assert
            Invoice invoice = new Invoice {
                ClientIdentifier = "",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Date = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                Id = Guid.NewGuid(),
                Items = new List<Item> {
                    new Item{
                        Id = new Guid(),
                        Price = -1M,
                        Taxes = new List<Tax> {
                            new Tax{
                                Name = "ITBIS",
                                Rate = 0.18f,
                                RateType = Core.RateType.Base
                            }
                        }
                    }
                }
            };

            (Amount taxes, Amount amount) = invoiceService.CalculateAmounts(invoice);
        }
    }
}
