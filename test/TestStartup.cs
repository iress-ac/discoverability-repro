using api;
using Microsoft.Extensions.Configuration;

namespace test
{
    // could override specific startup settings e.g. auth config
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
