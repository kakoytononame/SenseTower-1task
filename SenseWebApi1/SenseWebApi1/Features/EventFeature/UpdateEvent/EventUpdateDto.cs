namespace SenseWebApi1.Features.EventFeature.UpdateEvent;

public class EventUpdateDto
{
    
    
    public DateTime Beginning { get; set; }

    public DateTime End { get; set; }

    public string? EventName { get; set; }

    public string? Description { get; set; }

    public Guid ImageId { get; set; }

    public Guid AreaId { get; set; }
    
    public bool IsHavePlaces { get; set; }
}