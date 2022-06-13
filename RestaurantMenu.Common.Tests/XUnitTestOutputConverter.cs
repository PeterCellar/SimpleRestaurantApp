using System.Text;
using Xunit.Abstractions;

namespace RestaurantMenu.Common.Tests
{
    public class XUnitTestOutputConverter : TextWriter
    {
        private readonly ITestOutputHelper _outputHelper;
        public XUnitTestOutputConverter(ITestOutputHelper outputHelper) => _outputHelper = outputHelper;
        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string? message) => _outputHelper.WriteLine(message);

        public override void WriteLine(string format, params object?[] args) => _outputHelper.WriteLine(format, args);

    }
}
