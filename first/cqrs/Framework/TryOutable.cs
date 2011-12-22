namespace Dahlia.Framework
{
    public class TryOutable<T>
    {
        private readonly bool succeeded;
        private readonly T value;

        public bool Failed
        {
            get { return !succeeded; }
        }

        public bool Succeeded
        {
            get { return succeeded; }
        }

        public T Value
        {
            get { return value; }
        }

        public TryOutable(bool succeeded, T value)
        {
            this.succeeded = succeeded;
            this.value = value;
        }
    }
}
