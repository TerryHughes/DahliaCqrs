namespace Dahlia.Framework.TryOutableSpecs
{
    using Machine.Specifications;

    public class when_creating
    {
        Establish context =()=>
        {
            succeeded = true;
            value = "value";
        };

        Because of =()=> @try = new TryOutable<string>(succeeded, value);

        It should_have_failed_be_the_opposite_of_succeeded =()=> @try.Failed.ShouldEqual(!succeeded);

        It should_not_alter_succeeded =()=> @try.Succeeded.ShouldEqual(succeeded);

        It should_not_alter_value =()=> @try.Value.ShouldEqual(value);

        static bool succeeded;
        static string value;
        static TryOutable<string> @try;
    }
}
