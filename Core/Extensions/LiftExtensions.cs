#nullable enable
namespace FRPStreams.Core.Extensions
{
    using System;
    using Abstract;
    using Internal;

    public static partial class StreamExtensions
    {
        /// <summary>
        ///     Given two Streams, return a new value based on their values.
        /// </summary>
        /// <returns>The result of <paramref name="lift" /></returns>
        public static Stream<TJoin> Lift<T1, T2, TJoin>(this Stream<T1> s1, Stream<T2> s2,
            Func<T1, T2, TJoin> lift)
        {
            return new LiftStream<T1, T2, TJoin>(s1, s2, lift);
        }

        /// <summary>
        ///     Given three Streams, return a new value based on their values.
        /// </summary>
        /// <returns>The result of <paramref name="lift" /></returns>
        public static Stream<TJoin> Lift<T1, T2, T3, TJoin>(this Stream<T1> s1, Stream<T2> s2, Stream<T3> s3,
            Func<T1, T2, T3, TJoin> lift)
        {
            return new LiftStream<T1, T2, T3, TJoin>(s1, s2, s3, lift);
        }
    }
}