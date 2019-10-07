using Couchbase.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViajaNet.TrackingData.Infrastructure.Couchbase
{
    public interface ICouchbaseConnection
    {
        IBucket GetBucket();
    }
}
