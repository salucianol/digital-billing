namespace DigitalBilling.Core.Entities {
    public class Tax : BaseEntity {
        public string Name { get; set; }
        public float Rate { get; set; }
        public RateType RateType { get; set; }
    }
}