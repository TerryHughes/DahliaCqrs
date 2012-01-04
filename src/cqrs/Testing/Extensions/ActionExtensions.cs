namespace System
{
    using System.Threading;

    public static class ActionExtensions
    {
        public static Action DelayExecution(this Action action, int millisecondsTimeout)
        {
            return () =>
            {
                Thread.Sleep(millisecondsTimeout);

                action();
            };
        }

        public static void ExecuteInTheMiddleOf(this Action action, ThreadStart start)
        {
            var thread = new Thread(start);
            thread.Start();

            action();

            thread.Join();
        }
    }
}
