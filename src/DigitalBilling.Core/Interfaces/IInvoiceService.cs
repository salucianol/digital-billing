using DigitalBilling.Core.Entities;
using DigitalBilling.Core.ValueObjects;

namespace DigitalBilling.Core.Interfaces {
    public interface IInvoiceService {
        Amount ProcessInvoice(string _invoiceText);
        (Amount, Amount) CalculateAmounts(Invoice _invoice);
    }
}