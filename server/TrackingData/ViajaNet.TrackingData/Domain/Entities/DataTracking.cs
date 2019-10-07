using System;
namespace ViajaNet.TrackingData.Domain.Entities
{
    public class DataTracking
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string PageName { get; set; }
        public string Browser { get; set; }
        public string PageParameters { get; set; }

        public DataTracking(string ip, string pageName, string browser, string pageParameters)
        {
            this.IP = ip;
            this.PageName = pageName;
            this.Browser = browser;
            this.PageParameters = pageParameters;
        }
        public DataTracking() { }
    }
}
