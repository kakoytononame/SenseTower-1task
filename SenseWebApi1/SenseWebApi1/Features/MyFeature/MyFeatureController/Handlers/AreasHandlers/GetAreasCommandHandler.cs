using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.Areas
{
    public class GetAreasCommandHandler : IRequestHandler<GetAreasCommand, List<AreaDto>>
    {
        private readonly IAreaContext _areaContext;
        private readonly IMapper _mapper;
        public GetAreasCommandHandler(IAreaContext areaContext,IMapper mapper)
        {
            _areaContext = areaContext;
            _mapper = mapper;
        }
        public async Task<List<AreaDto>> Handle(GetAreasCommand request, CancellationToken cancellationToken)
        {
            var mappingobject = _areaContext.GetAreas();
            List<AreaDto> result = new List<AreaDto>();
            foreach (var entity in mappingobject)
            {
                result.Add(_mapper.Map<Area, AreaDto>(entity));
            }

            return result;
        }
    }
}
