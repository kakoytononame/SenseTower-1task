using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
// ReSharper disable InconsistentNaming

namespace ImageAPI;

public class RMQListener:BackgroundService
{
    private readonly IModel _channel;
    private readonly IImageContext _imageContext;
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly IOptions<RMQOptions> _options;
    public RMQListener(IImageContext imageContext,IOptions<RMQOptions> options)
    {
        _options = options;
        _imageContext = imageContext;
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
        _channel.QueueDeclare("images",
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
            var imageObj = JsonConvert.DeserializeObject<ImageDto>(message)!;
            _imageContext.DeleteImage(imageObj.Id);
            var deletedImage = new ImageDto()
            {
                Id = imageObj.Id,
                Type = imageObj.Type
            };
            var json = JsonConvert.SerializeObject(deletedImage);
            var sendBody = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: "", routingKey: "events", body: sendBody);
        };
        _channel.BasicConsume(queue: "images", autoAck: true, consumer: consumer);
        
        return Task.CompletedTask;
    }
    
}