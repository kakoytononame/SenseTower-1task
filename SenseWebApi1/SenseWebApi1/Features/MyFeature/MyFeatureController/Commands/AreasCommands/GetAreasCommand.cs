using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands
{
    public class GetAreasCommand:IRequest<List<AreaDto>>
    {
        public Guid AreaId { get; set; }
        public string? Name { get; set; }
    }
}
