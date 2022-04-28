﻿using Xunit;
using Newtonsoft.Json;
using Vonage.Serialization;
using Vonage.Voice.Nccos;

namespace Vonage.Test.Unit
{    
    public class StreamActionTest
    {
        [Fact]
        public void TestStreamUrl()
        {
            //Arrange
            var expected = "{\"streamUrl\":[\"https://www.example.com/waiting.mp3\"],\"action\":\"stream\"}";
            var action = new StreamAction() { StreamUrl = new [] { "https://www.example.com/waiting.mp3" } };
            //Act
            var serialized = JsonConvert.SerializeObject(action, VonageSerialization.SerializerSettings);
            //Assert
            Assert.Equal(expected, serialized);
        }
    }
}
