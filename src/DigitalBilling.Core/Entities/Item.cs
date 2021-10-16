using DigitalBilling.Core.ValueObjects;
using System.Collections.Generic;

namespace DigitalBilling.Core.Entities {
    public class Item : BaseEntity {
        public Amount Price { get; set; }
        public short Quantity { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Tax> Taxes { get; set; }
    }
}