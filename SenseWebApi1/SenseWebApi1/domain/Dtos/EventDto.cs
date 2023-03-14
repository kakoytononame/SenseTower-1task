namespace SenseWebApi1.domain.Dtos
{
    public class EventDto
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        /// <example>Men's basketball shoes</example>
        public Guid EventId { get; set; }

        public DateTime Beginning { get; set; }
        
        public DateTime End { get; set; }

        public string ?EventName { get; set; }

        public string ?Description { get; set; }

        public Guid ImageId { get; set; }

        public Guid AreaId { get; set; }
    }
}
