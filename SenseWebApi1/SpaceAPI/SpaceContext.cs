namespace SpaceAPI;

public class SpaceContext:ISpaceContext
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once InconsistentNaming
    public List<Space> _spaces;

    public SpaceContext()
    {
        _spaces = new List<Space>()
        {
            new Space()
            {
                Id = Guid.Parse("1f072c8c-b770-4cae-a587-d5e7bb2777ba")
            },
            new Space()
            {
                Id = Guid.Parse("558b3257-bb3d-4b40-a2bf-207c77d3149c")
            },
            new Space()
            {
                Id = Guid.Parse("8274dc1e-3ae6-472b-84f7-e7b740002ba2")
            }
        };
    }
    public List<Space> GetSpaces()
    {
        return _spaces;
    }

    public async Task DeleteSpaces(Guid spaceId)
    {
        var space = _spaces.FirstOrDefault(p => p.Id == spaceId)!;
        _spaces.Remove(space);
        await Task.CompletedTask;
    }
}