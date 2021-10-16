using DigitalBilling.Core.ValueObjects;

namespace DigitalBilling.Core.Entities {
    public class Product : BaseEntity {
        public string Name { get; set; }
        public Amount UnitPrice { get; set; }
    }
}