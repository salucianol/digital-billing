using DigitalBilling.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.UnitTests.FakesImplementation {
    internal class FakeClientService : IClientService {
        public bool ValidateIdentifier(string _identifier) {
            return true;
        }
    }
}
