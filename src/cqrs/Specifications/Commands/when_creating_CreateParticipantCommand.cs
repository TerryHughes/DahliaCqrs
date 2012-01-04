namespace Dahlia.Commands
{
    using System;
    using Machine.Specifications;

    public class when_creating_CreateParticipantCommand
    {
        Establish context =()=>
        {
            firstName = "firstName";
            lastName = "lastName";
            dateRecieved = new DateTime(2011, 03, 23);
        };

        Because of =()=> command = new CreateParticipantCommand(firstName, lastName, dateRecieved);

        It should_not_alter_the_first_name =()=> command.FirstName.ShouldEqual(firstName);

        It should_not_alter_the_last_name =()=> command.LastName.ShouldEqual(lastName);

        It should_not_alter_the_date_recieved =()=> command.DateRecieved.ShouldEqual(dateRecieved);

        static string firstName;
        static string lastName;
        static DateTime dateRecieved;
        static CreateParticipantCommand command;
    }
}
