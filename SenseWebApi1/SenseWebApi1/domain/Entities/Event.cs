namespace SenseWebApi1.domain.Entities
{
    public class Event
    {
        /// <summary>
        /// Id мероприятия
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Момент начала мероприятия
        /// </summary>
        public DateTime Beginning { get; set; }
        /// <summary>
        /// Момент конца мероприятия
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Название мероприятия
        /// </summary>
        public string ?EventName { get; set; }
        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string ?Description { get; set; }
        /// <summary>
        /// Id картинки
        /// </summary>
        public Guid ImageId { get; set; }

        public Guid AreaId { get; set; }

        public List<Ticket> Tickets { get; set; }

        public bool IsHaveFreePlaces { get; set; }
    }
}
