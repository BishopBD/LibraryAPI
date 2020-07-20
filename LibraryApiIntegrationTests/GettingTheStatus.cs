using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class GettingTheStatus : IClassFixture<WebTestFixture>
    {
        private HttpClient _client;

        public GettingTheStatus(WebTestFixture factory)
        {
            _client = factory.CreateClient();

        }

        [Fact]
        public async Task CorrectStatusCode()
        {
            var response = await _client.GetAsync("/status");

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task HasCorrectRepresentation()
        {
            var response = await _client.GetAsync("/status");
            var content = await response.Content.ReadAsAsync<GetStatusResponse>();

            Assert.Equal("Everything is golden!", content.message);
            Assert.Equal("Joe Schmidtly", content.checkedBy);
            Assert.Equal(new DateTime(1969, 4, 20, 23, 59, 59), content.whenLastChecked);
        }
    }


    public class GetStatusResponse
    {
        public string message { get; set; }
        public string checkedBy { get; set; }
        public DateTime whenLastChecked { get; set; }
    }

}
