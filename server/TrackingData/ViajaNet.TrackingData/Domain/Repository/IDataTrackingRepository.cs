using System;
using System.Collections.Generic;
using System.Text;

namespace ViajaNet.TrackingData.Domain.Repository
{
    public interface IDataTrackingRepository
    {
        void Save();
        void GetAll();
    }
}
