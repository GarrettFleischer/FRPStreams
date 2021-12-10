#nullable enable
namespace FRPStreams.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;

    public class Cell<T> : Stream<T>
    {
        private readonly Func<T, T, bool>? _compare;
        private readonly Stream<T>? _dependency;
        private readonly List<Action<T>> _listeners = new List<Action<T>>();
        private bool _valueChanged;

        public T Value => PendingValue;

        internal Cell(T initialValue, Stream<T>? dependency = null, Func<T, T, bool>? compare = null)
            : base(initialValue)
        {
            _dependency = dependency;
            _compare = compare;
        }

        internal override async Task UpdateValue()
        {
            await Task.Run(async () =>
            {
                while (InTransaction) { }

                if (_dependency != null)
                {
                    await _dependency.UpdateValue();
                    Hold(_dependency.PendingValue);
                }
            });
        }


        internal override void NotifyListeners()
        {
            if (_valueChanged)
            {
                _valueChanged = false;

                _listeners.ForEach(l => { l.Invoke(PendingValue); });
            }
        }

        public void Listen(Action<T> listener)
        {
            _listeners.Add(listener);

            listener(PendingValue);
        }

        public void StopListening(Action<T> listener)
        {
            _listeners.Remove(listener);
        }

        protected override void Hold(T value)
        {
            if (_compare?.Invoke(value, PendingValue) ?? Equals(value, PendingValue))
            {
                return;
            }

            base.Hold(value);
            _valueChanged = true;
        }
    }
}