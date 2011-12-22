namespace Dahlia.Framework
{
    /// <summary>
    /// A thread-safe implementation of the dispose pattern.
    /// </summary>
    /// <remarks>Adapted from http://blog.quantumbitdesigns.com/2008/07/22/a-thread-safe-idisposable-base-class/</remarks>
    public abstract class UnmanagedDisposable : ManagedDisposable
    {
        /// <summary>
        /// xxx
        /// </summary>

        // do not provide destructors in dervided types
        ~UnmanagedDisposable()
        {
            Dispose(false);
        }
    }
}
