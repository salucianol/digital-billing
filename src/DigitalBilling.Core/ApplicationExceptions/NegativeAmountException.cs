using System;
using System.Runtime.Serialization;

namespace DigitalBilling.Core.ApplicationExceptions {
    [Serializable]
    public class NegativeAmountException : Exception {
        private decimal value;

        public NegativeAmountException() {
        }

        public NegativeAmountException(string message, decimal value) : base(message) {
            this.value = value;
        }

        public NegativeAmountException(string message, Exception innerException) : base(message, innerException) {
        }

        protected NegativeAmountException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}