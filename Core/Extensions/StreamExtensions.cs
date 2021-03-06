#nullable enable
namespace FRPStreams.Core
{
    using System;
    using Abstract;

    public static partial class StreamExtensions
    {
        public static Cell<T> Hold<T>(this Stream<T> stream, Func<T, T, bool>? compare = null)
        {
            return new Cell<T>(stream.PendingValue, stream, compare);
        }
    }
}