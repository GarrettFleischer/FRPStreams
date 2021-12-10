#nullable enable
namespace FRPStreams.Core
{
    using System;
    using Abstract;

    public class CellSink<T> : Cell<T>
    {
        public CellSink(T initialValue, Func<T, T, bool>? compare = null)
            : base(initialValue, null, compare) { }

        /// <summary>
        ///     Used as an entry point for interface with I/O.
        ///     Must be called from within a Transaction.Run(...) block
        /// </summary>
        /// <param name="value">The value to hold</param>
        /// <exception cref="InvalidOperationException">Thrown when not in a transaction</exception>
        public new void Hold(T value)
        {
            if (!InTransaction)
            {
                throw new InvalidOperationException("Cannot hold when not in a transaction");
            }

            base.Hold(value);
        }
    }
}