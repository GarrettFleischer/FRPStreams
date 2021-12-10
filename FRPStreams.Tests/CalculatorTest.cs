namespace FRPStreams.Tests
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;

    public class CalculatorTest
    {
        private readonly Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(23, 42, 65)]
        public async Task ShouldAddTwoNumbers(int a, int b, int expected)
        {
            await _calculator.SetValues(a, b);
            _calculator.Add.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(23, 42, -19)]
        public async Task ShouldSubtractTwoNumbers(int a, int b, int expected)
        {
            await _calculator.SetValues(a, b);
            _calculator.Subtract.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(23, 42, 966)]
        public async Task ShouldMultiplyTwoNumbers(int a, int b, int expected)
        {
            await _calculator.SetValues(a, b);
            _calculator.Multiply.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, null)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, null)]
        [InlineData(1, 1, 1)]
        [InlineData(42, 2, 21)]
        public async Task ShouldDivideTwoNumbers(int a, int b, int? expected)
        {
            await _calculator.SetValues(a, b);
            _calculator.Divide.Value.Should().Be(expected);
        }
    }
}