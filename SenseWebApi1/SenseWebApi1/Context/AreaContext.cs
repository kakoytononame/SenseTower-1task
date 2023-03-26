using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using SC.Internship.Common.ScResult;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.Services;


namespace SenseWebApi1.Context
{
    public class AreaContext:IAreaContext
    {
        private readonly RetryPolicy _retryPolicy=Policy.Handle<Exception>().Retry(2);
        private readonly IHttpService _httpService;
        public AreaContext(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<bool> IsHave(Guid id)
        {
            
            var result = await _retryPolicy.Execute(()=>_httpService.GetSpaces("")) ;
            //var imagesArray = JArray.Parse(result).ToObject<List<Area>>();
            var areas = JsonConvert.DeserializeObject<ScResult<List<Area>>>(result)!;
#pragma warning disable CS8604
            var area=areas.Result.FirstOrDefault(p => p.Id==id);
            return area != null;
            
        }
    }
}
