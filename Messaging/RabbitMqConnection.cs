using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Campaign_Demo_Wahtsapp.Messaging
{
    public class RabbitMqConnection : IAsyncDisposable
    {
        private readonly IConnectionFactory _factory;
        private IConnection? _connection;
        private bool _disposed;
        public  RabbitMqConnection(IOptions<RabbitMqOptions> options)
        {
            _factory = new ConnectionFactory
            {
                HostName = options.Value.HostName,
                UserName = options.Value.UserName,
                Password = options.Value.Password,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
            };
        }
        public async Task<IChannel> CreateChannelAsync()
        {
            if(_connection == null || !_connection.IsOpen)
            {
                _connection = await _factory.CreateConnectionAsync();
            }
            return await _connection.CreateChannelAsync();
        }
        
        public async ValueTask DisposeAsync()
        {
            if (_disposed) return;
            if (_connection != null) {
                await _connection.CloseAsync();
                await _connection.DisposeAsync();
            }
            _disposed = true;
        }
    }
}
