using System;
namespace ViajaNet.TrackingData.Domain.Entities
{
    public class DataTracking
    {
        public string IP { get; private set; }
        public string PageName { get; private set; }
        public string Browser { get; private set; }
        public string PageParameters { get; private set; }

        public DataTracking(string ip, string pageName, string browser, string pageParameters)
        {
            this.IP = ip;
            this.PageName = pageName;
            this.Browser = browser;
            this.PageParameters = pageParameters;
        }
    }
}
