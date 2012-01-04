namespace Dahlia.Framework
{
    public class TryOutable<T>
    {
        readonly bool succeeded;
        readonly T value;

        public TryOutable(bool succeeded, T value)
        {
            this.succeeded = succeeded;
            this.value = value;
        }

        public bool Failed
        {
            get { return !Succeeded; }
        }

        public bool Succeeded
        {
            get { return succeeded; }
        }

        public T Value
        {
            get { return value; }
        }
    }
}
