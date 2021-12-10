#nullable enable
namespace FRPStreams.Core.Extensions
{
    using System;
    using Abstract;
    using Internal;

    public static partial class StreamExtensions
    {
        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<TLeft, TRight>> Merge<TLeft, TRight>(
            this Stream<TLeft> left, Stream<TRight> right)
        {
            return new LiftStream<TLeft, TRight, Tuple<TLeft, TRight>>(
                left, right,
                (l, r) => new Tuple<TLeft, TRight>(l, r));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3>> Merge<T1, T2, T3>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3)
        {
            return s1.Merge(s2).Merge(s3).Map(t =>
                new Tuple<T1, T2, T3>(t.Item1.Item1, t.Item1.Item2, t.Item2));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3, T4>> Merge<T1, T2, T3, T4>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3, Stream<T4> s4)
        {
            return s1.Merge(s2, s3).Merge(s4).Map(t =>
                new Tuple<T1, T2, T3, T4>(t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item2));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3, T4, T5>> Merge<T1, T2, T3, T4, T5>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3, Stream<T4> s4, Stream<T5> s5)
        {
            return s1.Merge(s2, s3, s4).Merge(s5).Map(t =>
                new Tuple<T1, T2, T3, T4, T5>(t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4, t.Item2));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3, T4, T5, T6>> Merge<T1, T2, T3, T4, T5, T6>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3, Stream<T4> s4, Stream<T5> s5, Stream<T6> s6)
        {
            return s1.Merge(s2, s3, s4, s5).Merge(s6).Map(t =>
                new Tuple<T1, T2, T3, T4, T5, T6>(
                    t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4, t.Item1.Item5, t.Item2));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3, T4, T5, T6, T7>> Merge<T1, T2, T3, T4, T5, T6, T7>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3, Stream<T4> s4, Stream<T5> s5, Stream<T6> s6,
            Stream<T7> s7)
        {
            return s1.Merge(s2, s3, s4, s5, s6).Merge(s7).Map(t =>
                new Tuple<T1, T2, T3, T4, T5, T6, T7>(
                    t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4, t.Item1.Item5, t.Item1.Item6, t.Item2));
        }

        /// <summary>
        /// Given Streams, return a Tuple of their values.
        /// </summary>
        /// <returns>A Tuple containing the values of the given Streams.</returns>
        public static Stream<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3, Stream<T4> s4, Stream<T5> s5, Stream<T6> s6,
            Stream<T7> s7, Stream<T8> s8)
        {
            return s1.Merge(s2, s3, s4, s5, s6, s7).Merge(s8).Map(t =>
                new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(
                    t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4, t.Item1.Item5, t.Item1.Item6,
                    t.Item1.Item7, t.Item2));
        }
    }
}