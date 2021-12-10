#nullable enable
namespace FRPStreams.Core
{
    using System;
    using Abstract;
    using Internal;

    public static class CellExtensions
    {
        public static Cell<TMap> Map<T, TMap>(this Stream<T> stream, Func<T, TMap> map,
            Func<TMap, TMap, bool>? compare = null)
        {
            return new MapCell<TMap, T>(stream, map, compare);
        }
    }
}