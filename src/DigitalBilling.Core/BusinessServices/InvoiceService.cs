using DigitalBilling.Core.Entities;
using System;
using DigitalBilling.Core.Interfaces;
using DigitalBilling.Core.ValueObjects;

namespace DigitalBilling.Core.BusinessServices {
    public class InvoiceService : IInvoiceService {
        private readonly IParserService _parserService;
        private readonly IClientService _clientService;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IParserService _parserService,
                                IClientService _clientService,
                                IInvoiceRepository _invoiceRepository) {
            this._parserService = _parserService;
            this._clientService = _clientService;
            this._invoiceRepository = _invoiceRepository;
        }

        public Amount ProcessInvoice(string _invoiceText) {
            // Parse the invoice string to an Invoice object
            Invoice _invoice = _parserService.ParseText(_invoiceText);

            // Check whether the ClientIdentifier is valid or not
            _clientService.ValidateIdentifier(_invoice.ClientIdentifier);

            // Iterate through items to calculte the amount, taxes and total of invoice
            //      Check the calculates amounts before assigning to the invoice
            (Amount _taxes, Amount _amount) = CalculateAmounts(_invoice);
            _invoice.Total = _amount + _taxes;

            // Persist the invoice as a relational object in a database
            _invoiceRepository.Persist(_invoice);

            // Save the invoice to a file in specified location
            //_invoiceRepository.SaveToFile(_invoice);

            // Return the total of the invoice
            return _invoice.Total;
        }

        public (Amount, Amount) CalculateAmounts(Invoice _invoice) {
            decimal _taxes = 0, _amount = 0;
            foreach (Item _item in _invoice.Items) {
                decimal taxesItem = 0;
                foreach (Tax _tax in _item.Taxes) {
                    taxesItem += _tax.RateType == RateType.Percent ?
                                    Convert.ToDecimal(_tax.Rate / 100f) * _item.Price :
                                    Convert.ToDecimal(_tax.Rate) * _item.Price;
                }
                _taxes += taxesItem;
                _amount += _item.Price;
            }
            _invoice.Taxes = _taxes;
            _invoice.Amount = _amount;

            return (_taxes, _amount);
        }
    }
}
