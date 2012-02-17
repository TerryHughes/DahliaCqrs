namespace Dahlia.Testing.Extensions.ActionExtensionSpecs
{
    using System;
    using System.Threading;
    using Machine.Specifications;

    public class when_executing_in_the_middle_of
    {
        Establish context =()=>
        {
            fastAction = () =>
            {
                Thread.Sleep(10);

                executed = DateTime.Now.Ticks;
            };

            slowAction = () =>
            {
                started = DateTime.Now.Ticks;

                Thread.Sleep(20);

                ended = DateTime.Now.Ticks;
            };
        };

        Because of =()=> fastAction.ExecuteInTheMiddleOf(new ThreadStart(slowAction));

        It should_execute_in_the_middle =()=>
        {
            started.ShouldBeLessThan(executed);
            executed.ShouldBeLessThan(ended);
        };

        static Action fastAction;
        static Action slowAction;
        static long started;
        static long executed;
        static long ended;
    }
}
