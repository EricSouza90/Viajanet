using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using ViajaNet.TrackingData.Common;

namespace ViajaNet.TrackingData.Infrastructure.Couchbase
{
    public class CouchbaseConnection : ICouchbaseConnection
    {
        private readonly CouchbaseConfiguration _couchbaseConfiguration;
        public CouchbaseConnection(IOptions<CouchbaseConfiguration> options)
        {
            _couchbaseConfiguration = options.Value;
        }

        public IBucket GetBucket()
        {
            var config = new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(_couchbaseConfiguration.Server) }
            };

            //create the cluster and pass in the RBAC user
            var cluster = new Cluster(config);
            var credentials = new PasswordAuthenticator(_couchbaseConfiguration.Username, _couchbaseConfiguration.Password);
            cluster.Authenticate(credentials);

            //open the new bucket
            var bucket = cluster.OpenBucket(_couchbaseConfiguration.Bucket);
            var manager = bucket.CreateManager();
            manager.CreateN1qlPrimaryIndex(false);
            manager.CreateN1qlIndex("Idx_dataTracking", false, "IP", "PageName");
            return bucket;
        }
    }
}
