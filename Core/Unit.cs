#nullable enable
namespace FRPStreams.Core
{
    using System;

    /// <summary>
    ///     Equivalent to a "null" value to be used in <see cref="StreamSink{Unit}" />
    /// </summary>
    public class Unit : IEquatable<Unit>
    {
        // ReSharper disable once InconsistentNaming
        public static Unit UNIT { get; } = new Unit();

        private Unit() { }

        public bool Equals(Unit other)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Unit other && Equals(other);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}