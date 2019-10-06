using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.Web.Api.ViewModel
{
    public class DataTrackingViewModel
    {
        public string IP { get; set; }
        public string PageName { get; set; }
        public string Browser { get; set; }
        public string PageParameters { get; set; }

        public DataTracking Convert()
        {
            return new DataTracking(IP, PageName, Browser, PageName);
        }
    }
}
