using DigitalBilling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.Core.Interfaces {
    public interface IInvoiceRepository : IRepository<Invoice> {
        ICollection<Invoice> GetByDate(DateTime date);
    }
}
