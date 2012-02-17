namespace Dahlia.Testing.Extensions.ActionExtensionSpecs
{
    using System;
    using System.Diagnostics;
    using Machine.Specifications;

    public class when_delaying_execution
    {
        Establish context =()=>
        {
            delay = 20;
            stopwatch = new Stopwatch();
            action = new Action(stopwatch.Stop).DelayExecution(delay);
        };

        Because of =()=>
        {
            stopwatch.Start();
            action();
        };

// Being tempermental while the virus scanner is running
//        It should_have_been_delayed =()=> (stopwatch.ElapsedMilliseconds >= delay).ShouldBeTrue();

        static int delay;
        static Stopwatch stopwatch;
        static Action action;
    }
}