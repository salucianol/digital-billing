using DigitalBilling.Core.ApplicationExceptions;
using System;

namespace DigitalBilling.Core.ValueObjects {
    public class Amount {
        private decimal _value;
        public decimal Value {
            get {
                return _value;
            }
            set {
                if (value < 0) {
                    throw new NegativeAmountException($"The amount must be greater or equal to 0.", value);
                }
                _value = value;
            }
        }

        private Amount(decimal value) {
            Value = value;
        }

        override public string ToString() {
            return Value.ToString();
        }

        override public bool Equals(object value1) {
            if (value1 == null) {
                return false;
            }

            Amount value2 = (Amount)value1;

            if (this != value2) {
                return false;
            }

            return true;
        }

        override public int GetHashCode() {
            throw new NotImplementedException();
        }

        public static bool operator ==(Amount value1, Amount value2) {
            return value1.Value == value2.Value;
        }

        public static bool operator !=(Amount value1, Amount value2) {
            return value1.Value != value2.Value;
        }

        public static implicit operator Amount(decimal value) {
            return new Amount(value);
        }

        public static decimal operator +(decimal value1, Amount value2) {
            return value1 + value2.Value;
        }

        public static decimal operator +(Amount value1, decimal value2) {
            return value1.Value + value2;
        }

        public static Amount operator +(Amount value1, Amount value2) {
            return new Amount(value1.Value + value2.Value);
        }

        public static decimal operator *(decimal value1, Amount value2) {
            return value1 * value2.Value;
        }

        public static decimal operator *(Amount value1, decimal value2) {
            return value1.Value * value2;
        }
    }
}
