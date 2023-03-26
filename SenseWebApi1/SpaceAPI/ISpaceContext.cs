namespace SpaceAPI;

public interface ISpaceContext
{
    List<Space> GetSpaces();

    Task DeleteSpaces(Guid spaceId);
}