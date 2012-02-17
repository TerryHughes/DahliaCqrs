namespace Dahlia.Testing.Extensions.EnumerableExtensionSpecs
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Machine.Specifications;

    public class when_slowly_enumerating
    {
        Establish context =()=>
        {
            count = 10;
            delay = 10;
        };

        Because of =()=>
        {
            stopwatch = Stopwatch.StartNew();
            Enumerable.Range(0, count).SlowlyEnumerate(delay).ToList();
            stopwatch.Stop();
        };

        It should_have_been_enumerated_slowly =()=> (stopwatch.ElapsedMilliseconds >= count * delay).ShouldBeTrue();

        static int count;
        static int delay;
        static Stopwatch stopwatch;
    }
}
