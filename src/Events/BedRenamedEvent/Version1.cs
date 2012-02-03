namespace Dahlia.Events.BedRenamedEvent
{
    [Serializable]
    public class Version1 : Event
    {
        public string Name { get; set; }
    }
}
