using SenseWebApi1.Features.EventFeature;
using static System.Net.Mime.MediaTypeNames;

namespace SenseWebApi1.Context
{
    public class AreaContext:IAreaContext
    {
        private List<Area> Areas = new List<Area>();
        public AreaContext() 
        {
            Areas.Add(new Area()
            {
                AreaId=Guid.Parse("aaf2c1b9-6372-44bc-b0e4-1251b914c2dd"),
                AreaName="Area 1"
            });
            Areas.Add(new Area()
            {
                AreaId = Guid.Parse("53eaf4f5-b005-4eb1-a030-96205cbd9a89"),
                AreaName = "Area 2"
            });
        }

       

        public bool IsHave(Guid id)
        {
            var area=Areas.FirstOrDefault(p => p.AreaId==id);
            return area != null;
        }
    }
}
