using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using DevConatct;
using DevContact.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace DevContact.Test
{
    public class FleetTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public FleetTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task Add_One()
        {
            // Act
           var car = new Car
            {
                Ownername = "Curator Uche",
                Registration = "LG-6765-IKJ",               
                Type = 2
            };
            var response = await _client.PostAsJsonAsync("/api/Fleet/", car);
            response.EnsureSuccessStatusCode();

            // Assert
            var @equals = response.StatusCode.Equals(200);
        }
        [Fact]
        public async Task Get_All()
        {
            // Act
            var response = await _client.GetAsync("/api/Fleet/");
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
            var response = await _client.GetAsync("/api/Fleet/Get/GVl8AVPcd0O-afbr8zKUCQ");
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
            var response = await _client.GetAsync("/api/Fleet/GetCat/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Domain.Entities.DevContact>>(responseString);
            contacts.Count().Should().Be(1);
        }
        [Fact]
        public async Task Update_One()
        {
            // Act
            var car = new Car
            {
                Id= "GVl8AVPcd0O-afbr8zKUCQ",
                Ownername = "Curator Uche",
                Registration = "LG-6765-IKJ",
                Type = 2
            };
            var response = await _client.PutAsJsonAsync("/api/Fleet/", car);
            response.EnsureSuccessStatusCode();

            // Assert
            var @equals = response.StatusCode.Equals(200);
        }
        [Fact]
        public async Task Delete_One()
        {
            // Act
            var response = await _client.GetAsync("/api/Fleet/Remove/GVl8AVPcd0O-afbr8zKUCQ");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Domain.Entities.DevContact>>(responseString);
            contacts.Count().Should().Be(1);
        }
    }
}
