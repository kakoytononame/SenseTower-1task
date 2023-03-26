using Polly;
using Polly.Retry;
using SC.Internship.Common.ScResult;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.Services;
using JsonConvert = Newtonsoft.Json.JsonConvert;



namespace SenseWebApi1.Context
{
    public class ImageContext:IImageContext
    {
        private RetryPolicy _retryPolicy=Policy.Handle<Exception>().Retry(2);
        private readonly IHttpService _httpService;
        public ImageContext(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<bool> IsHave (Guid id)
        {
           
            var result = await _retryPolicy.Execute(()=> _httpService.GetImages(""));
            
            var images = JsonConvert.DeserializeObject<ScResult<List<Imagine>>>(result)!;
#pragma warning disable CS8602
            var image = images.Result.Find(p=>p.Id==id)!;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            return image != null;
           
        }
    }
}
