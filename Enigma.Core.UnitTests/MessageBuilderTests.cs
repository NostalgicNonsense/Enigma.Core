using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Enigma.Core.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Enigma.Core.UnitTests
{
    public class MessageBuilderTests
    {
        [Test]
        public void MessageWrittenCorrectly()
        {
            var testObj = new TestObj
            {
                IntProperty = 1000,
                StringProperty = "Test"
            };
            var messageWrapper = new MessageWrapper(testObj);

            var messageWrapperAsJson = JsonConvert.SerializeObject(messageWrapper);

            var messageBuiltAsBytes = MessageBuilder.GetMessageWithHeader(testObj);

            var extractedMessage = ExtractMessageFromPacket(messageBuiltAsBytes);

            Assert.True(JToken.DeepEquals(JToken.Parse(messageWrapperAsJson), JToken.Parse(extractedMessage)));
        }

        private static string ExtractMessageFromPacket(byte[] array)
        {
            return Encoding.UTF8.GetString(array, sizeof(int), array.Length - sizeof(int));
        }
    }
}
