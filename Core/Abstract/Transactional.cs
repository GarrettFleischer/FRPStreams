#nullable enable
namespace FRPStreams.Core.Abstract
{
    using System.Threading.Tasks;

    public abstract class Transactional
    {
        protected bool InTransaction { get; private set; }

        internal void StartTransaction()
        {
            InTransaction = true;
        }

        internal void EndTransaction()
        {
            InTransaction = false;
        }

        internal abstract Task UpdateValue();

        internal abstract void NotifyListeners();
    }
}