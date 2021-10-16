using DigitalBilling.Core.Entities;
using DigitalBilling.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.UnitTests.FakesImplementation {
    internal class FakeParserService : IParserService {
        public Invoice ParseText(string _text) {
            throw new NotImplementedException();
        }
    }
}
