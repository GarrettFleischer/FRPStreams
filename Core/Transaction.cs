#nullable enable
namespace FRPStreams.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abstract;

    public static class Transaction
    {
        internal static List<Transactional> Transactionals { get; } = new List<Transactional>();

        /// <summary>
        /// Begin a transaction.
        /// This is where you can push values into <see cref="StreamSink{T}"/> and <see cref="CellSink{T}"/>.
        /// </summary>
        /// <param name="action"></param>
        public static async Task Run(Action action)
        {
            Transactionals.ForEach(t => t.StartTransaction());
            action();
            Transactionals.ForEach(t => t.EndTransaction());
            await ForceUpdateAll();
        }

        /// <summary>
        /// Manually trigger all cells to recalculate.
        /// </summary>
        public static async Task ForceUpdateAll()
        {
            await Task.WhenAll(Transactionals.Select(t => t.UpdateValue()).ToArray());
            Transactionals.ForEach(t => t.NotifyListeners());
        }
    }
}