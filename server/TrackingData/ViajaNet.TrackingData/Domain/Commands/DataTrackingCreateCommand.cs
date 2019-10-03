using MediatR;

namespace ViajaNet.TrackingData.Domain.Commands
{
    public class DataTrackingCreateCommand : INotification
    {
        public string IP { get; set; }
        public string PageName { get; set; }
        public string Browser { get; set; }
        public string PageParameters { get; set; }
    }
}
