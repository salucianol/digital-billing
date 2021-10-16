using DigitalBilling.Core.Entities;
using DigitalBilling.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.UnitTests.FakesImplementation {
    internal class FakeInvoiceRepository
            : IInvoiceRepository {
        public ICollection<Invoice> GetAll() {
            throw new NotImplementedException();
        }

        public ICollection<Invoice> GetByDate(DateTime date) {
            throw new NotImplementedException();
        }

        public Invoice GetById(Guid id) {
            throw new NotImplementedException();
        }

        public void Persist(Invoice entity) {
            throw new NotImplementedException();
        }

        public void Remove(Invoice entity) {
            throw new NotImplementedException();
        }
    }
}
