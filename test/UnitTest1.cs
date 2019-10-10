using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using api;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace test
{
    public class Tests
    {
        [Test]
        public async Task FailingTest()
        {
            var factory = new TestApiFactory();
            var client = factory.CreateClient();

            var result = await client.GetAsync("weatherforecast");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var jsonContent = await result.Content.ReadAsStringAsync();
            Assert.That(string.IsNullOrEmpty(jsonContent), Is.False);
        }

        [Test]
        public async Task PassingTest()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            var result = await client.GetAsync("weatherforecast");

            Assert.That(result.IsSuccessStatusCode);

            var jsonContent = await result.Content.ReadAsStringAsync();
            Assert.That(string.IsNullOrEmpty(jsonContent), Is.False);
        }
    }
}