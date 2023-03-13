using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers
{
    public class AreaCheckCommandHandler : IRequestHandler<AreaCheckCommand, bool>
    {
        private readonly IAreaContext _areaContext;
        private readonly IMapper _mapper;
        public AreaCheckCommandHandler(IAreaContext areaContext,IMapper mapper)
        {
            _areaContext = areaContext;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AreaCheckCommand request, CancellationToken cancellationToken)
        {
            var areacheck = _mapper.Map<AreaCheckCommand, Area>(request);
            var result = _areaContext.IsHave(areacheck.AreaId);
            return result;
        }
    }
}
