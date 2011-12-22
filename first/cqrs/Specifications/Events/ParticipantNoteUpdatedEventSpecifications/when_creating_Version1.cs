namespace Dahlia.Events.ParticipantNoteUpdatedEventSpecifications
{
    using Dahlia.Events.ParticipantNoteUpdatedEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=> note = "note";

        Because of =()=> @event = new Version1(note);

        It should_not_alter_the_note =()=> @event.Note.ShouldEqual(note);

        static string note;
        static Version1 @event;
    }
}
