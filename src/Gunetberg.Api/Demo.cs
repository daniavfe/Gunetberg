using Microsoft.Extensions.Logging;

namespace Gunetberg.Api
{
    public class Demo
    {
        private readonly ILogger<Demo> _logger;
        public readonly string _demo;

        public Demo(ILogger<Demo> logger, string demo)
        {  
            
            _demo = demo;
            _logger = logger;
            _logger.LogInformation($"Called from demo with value {demo}");

        }
    }
}
