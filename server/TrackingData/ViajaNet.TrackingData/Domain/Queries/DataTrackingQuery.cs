using MediatR;
using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Queries
{
    public class DataTrackingQuery : IRequest<IList<DataTracking>>
    {
        public string IP { get; private set; }
        public string PageName { get; private set; }

        public DataTrackingQuery(string ip, string pageName)
        {
            this.IP = ip;
            this.PageName = pageName;
        }
    }
}
