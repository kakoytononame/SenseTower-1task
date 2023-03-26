namespace ImageAPI;

// ReSharper disable once InconsistentNaming
public class RMQOptions
{
#pragma warning disable CS8618
    public string HostName { get; set; }
    
    public int Port { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string VirtualHost { get; set; }
}