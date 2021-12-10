#nullable enable
namespace FRPStreams.Core.Internal
{
    using System;
    using System.Threading.Tasks;
    using Abstract;

    internal class MapCell<T, TFrom> : Cell<T>
    {
        private readonly Stream<TFrom> _dependency;
        private readonly Func<TFrom, T> _map;

        public MapCell(Stream<TFrom> dependency, Func<TFrom, T> map, Func<T, T, bool>? compare = null)
            : base(map(dependency.PendingValue), compare: compare)
        {
            _dependency = dependency;
            _map = map;
        }

        internal override async Task UpdateValue()
        {
            await _dependency.UpdateValue();
            Hold(_map(_dependency.PendingValue));
        }
    }
}