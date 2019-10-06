using Microsoft.Extensions.Options;
using Moq;
using RabbitMQ.Client;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Infrastructure.Queue;
using ViajaNet.TrackingData.Infrastructure.Queue.Helper;
using Xunit;

namespace ViajaNet.Tests.Infrastructure.Queue.Helper
{
    public class RabbitMQHelperTests
    {
        private readonly IQueue _queue;
        private readonly Mock<IOptions<RabbitMQConfiguration>> _config;

        public RabbitMQHelperTests()
        {
            _config = new Mock<IOptions<RabbitMQConfiguration>>();
            //Os dados aqui contidos devem ficar em um arquivo de config nos testes
            //Para fins de redução de complexidade foram colocados aqui
            _config.SetupGet(x => x.Value.QueueName).Returns("");
            _config.SetupGet(x => x.Value.HostName).Returns("");
            _config.SetupGet(x => x.Value.Port).Returns("");
            _config.SetupGet(x => x.Value.UserName).Returns("");
            _config.SetupGet(x => x.Value.Password).Returns("");
            _queue = new RabbitMQHelper(_config.Object);
        }

        [Fact]
        public void GetConnectionFactory_Success()
        {
            // Arrange
            ConnectionFactory factory;

            // Act
            //factory = _obj.GetConnectionFactory();

            // Assert
            Assert.True(factory != null);
        }
    }
}
