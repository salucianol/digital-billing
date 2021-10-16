using DigitalBilling.Core.Entities;

namespace DigitalBilling.Core.Interfaces {
    public interface IParserService {
        Invoice ParseText(string _text);
    }
}