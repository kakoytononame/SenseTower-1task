using SenseWebApi1.domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SenseWebApi1.Stubs
{
    public class AreaContext:IAreaContext
    {
        private List<Area> Areas = new List<Area>();
        public AreaContext() 
        {
            Areas.Add(new Area()
            {
                AreaId=Guid.NewGuid(),
                AreaName="Area 1"
            });
            Areas.Add(new Area()
            {
                AreaId = Guid.NewGuid(),
                AreaName = "Area 2"
            });
        }

        public List<Area> GetAreas()
        {
            return Areas;
        }

        public bool IsHave(Guid id)
        {
            var area=Areas.Where(p=>p.AreaId==id).FirstOrDefault();
            return Areas.Contains(area);
        }
    }
}
