using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using System;
using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Entities;
using ViajaNet.TrackingData.Domain.Repository;
using ViajaNet.TrackingData.Infrastructure.Couchbase;

namespace ViajaNet.TrackingData.Infrastructure.Repository
{
    public class DataTrackingRepository : IDataTrackingRepository
    {
        private ICouchbaseConnection _couchbaseConnection;
        private static IBucket _bucket;
        public DataTrackingRepository(ICouchbaseConnection couchbaseConnection)
        {
            _couchbaseConnection = couchbaseConnection;
            _bucket = _couchbaseConnection.GetBucket();
        }
        public IList<DataTracking> Get(string ip, string pageName)
        {
            var queryRequest = new QueryRequest()
                                   .Statement("SELECT ip, pageName, browser, pageParameters FROM `ViajaNet` Where ip = $ip and  pageName = $pageName")
                                   .AddNamedParameter("$ip", ip)
                                   .AddNamedParameter("$pageName", pageName);

            return _bucket.Query<DataTracking>(queryRequest)?.Rows;
        }

        public void Save(DataTracking dataTracking)
        {
            var document = new Document<DataTracking>();
            document.Id = Guid.NewGuid().ToString();
            document.Content = dataTracking;

            _bucket.Upsert<DataTracking>(document);
        }
    }
}
