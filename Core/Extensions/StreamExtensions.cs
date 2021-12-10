namespace FRPStreams.Core.Extensions
{
    using System;
    using Abstract;

    public static partial class StreamExtensions
    {
        public static Cell<T> Hold<T>(this Stream<T> stream, Func<T, T, bool> compare)
        {
            return new Cell<T>(stream.PendingValue, stream, compare);
        }
    }
}