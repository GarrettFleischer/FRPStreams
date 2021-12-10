namespace FRPStreams.Tests
{
    using System.Threading.Tasks;
    using Core;

    public class Calculator
    {
        private readonly StreamSink<int> _a = new StreamSink<int>(0);
        private readonly StreamSink<int> _b = new StreamSink<int>(0);

        public Cell<int> Add { get; }
        public Cell<int> Subtract { get; }
        public Cell<int> Multiply { get; }
        public Cell<int?> Divide { get; }

        public Calculator()
        {
            Add = _a.Lift(_b, (a, b) => a + b).Hold();
            Subtract = _a.Lift(_b, (a, b) => a - b).Hold();
            Multiply = _a.Lift(_b, (a, b) => a * b).Hold();
            Divide = _a.Lift(_b, (a, b) => b == 0 ? (int?)null : a / b).Hold();
        }

        public async Task SetValues(int a, int b)
        {
            await Transaction.Run(() =>
            {
                _a.Push(a);
                _b.Push(b);
            });
        }
    }
}