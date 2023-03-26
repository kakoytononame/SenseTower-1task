namespace SpaceAPI;

public class SpaceDto
{
    public Guid Id { get; set; }
    public SpaceType Type { get; set; }
}
public enum SpaceType
{
    SpaceDeleteEvent=1
}