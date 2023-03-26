using System.Text;
using ImageAPI;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SpaceAPI;

// ReSharper disable once InconsistentNaming
public class RMQListener:BackgroundService
{
    private readonly IModel _channel;
    private readonly ISpaceContext _spaceContext;
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly IOptions<RMQOptions> _options;
    public RMQListener(ISpaceContext spaceContext,IOptions<RMQOptions> options)
    {
        _options = options;
        _spaceContext = spaceContext;
        var factory = new ConnectionFactory 
            { 
                HostName = _options.Value.HostName, 
                Port = _options.Value.Port,
                UserName = _options.Value.UserName,
                Password = _options.Value.Password,
                VirtualHost = _options.Value.VirtualHost
            };
        IConnection connection;
        while (true)
        {
            Thread.Sleep(5000);
            try
            {
                connection = factory.CreateConnection();
                break;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                
            }
        }
        _channel = connection.CreateModel();
        _channel.QueueDeclare("spaces",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        // ReSharper disable once UnusedParameter.Local
        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var spaceObj = JsonConvert.DeserializeObject<SpaceDto>(message)!;
            _spaceContext.DeleteSpaces(spaceObj.Id);
            SpaceDto deletedImage = new SpaceDto()
            {
                Id = spaceObj.Id,
                Type = spaceObj.Type
            };
            var json = JsonConvert.SerializeObject(deletedImage);
            var sendBody = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: "", routingKey: "events", body: sendBody);
        };
        _channel.BasicConsume(queue: "spaces", autoAck: true, consumer: consumer);
        
        return Task.CompletedTask;
    }
    
}