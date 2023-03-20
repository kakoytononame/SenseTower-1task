using SenseWebApi1.Features.EventFeature;
using static System.Net.Mime.MediaTypeNames;

namespace SenseWebApi1.Context
{
    public class AreaContext:IAreaContext
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // ReSharper disable once InconsistentNaming
        private List<Area> Areas = new List<Area>();
        public AreaContext() 
        {
            Areas.Add(new Area()
            {
                AreaId=Guid.Parse("75d4e526-3cd6-4aa2-92f4-9e1ecc574f20"),
                AreaName="Area 1"
            });
            Areas.Add(new Area()
            {
                AreaId = Guid.Parse("ec747803-890d-4ce4-8958-64cfea4e77a7"),
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
