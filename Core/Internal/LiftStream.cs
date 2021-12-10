#nullable enable
namespace FRPStreams.Core.Internal
{
    using System;
    using System.Threading.Tasks;
    using Abstract;

    internal class LiftStream<T1, T2, T> : Stream<T>
    {
        private readonly Func<T1, T2, T> _join;
        private readonly Stream<T1> _s1;
        private readonly Stream<T2> _s2;

        public LiftStream(
            Stream<T1> s1,
            Stream<T2> s2,
            Func<T1, T2, T> join)
            : base(join(s1.PendingValue, s2.PendingValue))
        {
            _s1 = s1;
            _s2 = s2;
            _join = join;
        }

        internal override async Task UpdateValue()
        {
            await _s1.UpdateValue();
            await _s2.UpdateValue();
            Hold(_join(_s1.PendingValue, _s2.PendingValue));
        }
    }

    internal class LiftStream<T1, T2, T3, T> : Stream<T>
    {
        private readonly Func<T1, T2, T3, T> _join;
        private readonly Stream<T1> _s1;
        private readonly Stream<T2> _s2;
        private readonly Stream<T3> _s3;

        public LiftStream(
            Stream<T1> s1,
            Stream<T2> s2,
            Stream<T3> s3,
            Func<T1, T2, T3, T> join)
            : base(join(s1.PendingValue, s2.PendingValue, s3.PendingValue))
        {
            _s1 = s1;
            _s2 = s2;
            _s3 = s3;
            _join = join;
        }

        internal override async Task UpdateValue()
        {
            await _s1.UpdateValue();
            await _s2.UpdateValue();
            await _s3.UpdateValue();
            Hold(_join(_s1.PendingValue, _s2.PendingValue, _s3.PendingValue));
        }
    }
}