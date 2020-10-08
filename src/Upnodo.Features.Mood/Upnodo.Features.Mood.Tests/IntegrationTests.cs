using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Upnodo.Features.Mood.Tests.Models;
using Upnodo.Features.Mood.Tests.Models.Common;

namespace Upnodo.Features.Mood.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public async Task Test_Test()
        {
            // Arrange
            var factory = new WebApplicationFactory<Api.Program>();
            var client = factory.CreateClient();
            
            var moodRecordExpected = new MoodRecord
            {
                Guid = Guid.Parse("f4b5a275-629e-4f71-a87d-8543a5611463"),
                Mood = 0,
                UserId = "Test"
            };
            
            // Act
            var response = await client.GetAsync("/api/mood/Test");
            
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GetMoodRecordsByUserGuid>(content);

            // Assert 
            Assert.IsTrue(response.IsSuccessStatusCode);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Value);

            var moodRecordResult = result.Value.First();
            
            Assert.AreEqual(moodRecordExpected.Guid, moodRecordResult.Guid);
            Assert.AreEqual(moodRecordExpected.Mood, moodRecordResult.Mood);
            Assert.AreEqual(moodRecordExpected.UserId, moodRecordResult.UserId);
        }
    }
}