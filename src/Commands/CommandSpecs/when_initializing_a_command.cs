namespace Dahlia.Commands.CommandSpecs
{
    using System;
    using Machine.Specifications;
    using Framework;

    public class when_initializing_a_command
    {
        Establish context =()=>
        {
            guid = Guid.NewGuid();
            SystemGuid.FromNowOnReturn(guid);
        };

        Because of =()=> command = new TestCommand();

        It should_set_its_Id =()=> command.Id.ShouldEqual(guid);

        Cleanup after =()=> SystemGuid.FromNowOnGenerateNew();

        static Guid guid;
        static Command command;

        private class TestCommand : Command
        {
        }
    }
}
