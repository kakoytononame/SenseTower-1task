using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SenseWebApi1.Context;
using SenseWebApi1.Features.EventFeature.CreateEvent;
using SenseWebApi1.Services;

namespace Event.XUnitTest.EventValidationTest;

public class EventCreateValidatorTest
{
    [Fact]

    public async void EventCreateValidationTest()
    {
        var testObj = new EventCreateCommand()
        {
            EventName = "Event-1",
            Description = "Какое то мероприятие 1",
            Beginning = DateTime.Parse("2023-03-13T17:10:17.5776731+03:00"),
            End = DateTime.Parse("2023-03-13T20:10:17.5776731+03:00"),
            AreaId = Guid.Parse("ec747803-890d-4ce4-8958-64cfea4e77a7"),
            ImageId = Guid.Parse("bda59f4e-c60b-411b-87e5-61a73125979b"),
            IsHavePlaces = true
        };
         ILogger<HttpService> logger=new Logger<HttpService>(new LoggerFactory());
        IHttpContextAccessor contextAccessor=new HttpContextAccessor();
        IHttpService httpService =new HttpService(contextAccessor,logger);
        var validator = new EventCreateValidator(new AreaContext(httpService), new ImageContext(httpService));
        var validationResult=await validator.ValidateAsync(testObj);
        if (!validationResult.IsValid)
        {
            Assert.Fail("Ошибка валидации");
        }
    }
}