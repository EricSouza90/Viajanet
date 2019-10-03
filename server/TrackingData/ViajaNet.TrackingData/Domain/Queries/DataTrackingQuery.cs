﻿using MediatR;
using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Queries
{
    public class DataTrackingQuery : IRequest<IList<DataTracking>>
    {
    }
}
