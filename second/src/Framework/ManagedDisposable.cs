namespace Dahlia.Framework
{
    using System;
    using System.Threading;

    /// <summary>
    /// A thread-safe implementation of the dispose pattern.
    /// </summary>
    /// <remarks>Adapted from http://blog.quantumbitdesigns.com/2008/07/22/a-thread-safe-idisposable-base-class/</remarks>
    public abstract class ManagedDisposable : IDisposable
    {
        const int undisposedValue = 0;
        const int disposedValue = 1;
        int currentDisposeStatus;

        protected ManagedDisposable()
        {
            currentDisposeStatus = undisposedValue;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            var originalDisposeStatus = UpdateStatusToDisposed();

            if (StatusIsDisposed(originalDisposeStatus))
                return;

            PerformDispose(disposing);
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (StatusIsDisposed(currentDisposeStatus))
                throw new ObjectDisposedException(GetType().FullName);
        }

        protected virtual void DisposeUnmanagedResources()
        {
        }

        protected abstract void DisposeManagedResources();

        static bool StatusIsDisposed(int status)
        {
            return status == disposedValue;
        }

        /// <summary>
        /// Updates currentDisposeStatus to disposedValue, if it isn't already, in a thread-safe manner.
        /// </summary>
        /// <returns>The original value of currentDisposeStatus (prior to any change).</returns>
        int UpdateStatusToDisposed()
        {
            return Interlocked.CompareExchange(ref currentDisposeStatus, disposedValue, undisposedValue);
        }

        void PerformDispose(bool disposing)
        {
            if (disposing)
                DisposeManagedResources();

            DisposeUnmanagedResources();
        }
    }
}
