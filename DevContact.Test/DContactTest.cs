using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevConatct;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
//using Moq;
using Xunit;

namespace DevContact.Test
{

    public class DContactTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public DContactTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Get_All()
        {
            // Act
            var response = await _client.GetAsync("/api/Developer/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Domain.Entities.DevContact>>(responseString);
            contacts.Count().Should().Be(2);
        }

        [Fact]
        public async Task Get_One()
        {
            // Act
            var response = await _client.GetAsync("/api/Developer/Get/pJRu1YD4ukuSCaJt46a6vA");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Domain.Entities.DevContact>>(responseString);
            contacts.Count().Should().Be(1);
        }
        [Fact]
        public async Task Get_Cat()
        {
            // Act
            var response = await _client.GetAsync("/api/Developer/GetCat/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Domain.Entities.DevContact>>(responseString);
            contacts.Count().Should().Be(1);
        }
    }
}
