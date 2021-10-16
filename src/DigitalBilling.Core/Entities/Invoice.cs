using DigitalBilling.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.Core.Entities {
    public class Invoice : BaseEntity {
        public string ClientIdentifier { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public DateTime Date { get; set; }
        public Amount Amount { get; set; }
        public Amount Taxes { get; set; }
        public Amount Total { get; set; }
    }
}
