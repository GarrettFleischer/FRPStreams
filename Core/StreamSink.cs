#nullable enable
namespace FRPStreams.Core
{
    using System;
    using Abstract;

    public class StreamSink<T> : Stream<T>
    {
        public StreamSink(T initialValue)
            : base(initialValue) { }

        /// <summary>
        ///     Used as an entry point for interface with I/O where the state does not need to be accessed.
        ///     Must be called from within a Transaction.Run(...) block
        /// </summary>
        /// <param name="value">The value to push into this stream.</param>
        /// <exception cref="InvalidOperationException">Thrown when not in a transaction.</exception>
        public void Push(T value)
        {
            if (!InTransaction)
            {
                throw new InvalidOperationException("Cannot push when not in a transaction");
            }

            Hold(value);
        }
    }
}