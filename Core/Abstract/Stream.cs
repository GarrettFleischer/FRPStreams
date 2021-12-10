#nullable enable
namespace FRPStreams.Core.Abstract
{
    using System;
    using System.Threading.Tasks;

    public abstract class Stream<T> : Transactional, IDisposable
    {
        internal T PendingValue { get; private set; }

        protected Stream(T initialValue)
        {
            PendingValue = initialValue;

            Transaction.Transactionals.Add(this);
        }

        public void Dispose()
        {
            Transaction.Transactionals.Remove(this);
        }

        internal override async Task UpdateValue()
        {
            await Task.Run(() =>
            {
                while (InTransaction) { }
            });
        }

        internal override void NotifyListeners() { }

        protected virtual void Hold(T value)
        {
            PendingValue = value;
        }
    }
}