using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vonage.Messages.Messenger
{
    public class MessengerRequestData
    {
        /// <summary>
        /// The use of different category tags enables the business to send messages for
        /// different use cases. For Facebook Messenger they need to comply with their
        /// Messaging Types policy. Vonage maps our category to their messaging_type.
        /// If message_tag is used, then an additional tag for that type is mandatory.
        /// By default Vonage sends the response category to Facebook Messenger.
        /// </summary>
        [JsonProperty("category")]
        [DefaultValue(99)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessengerMessageCategory? Category { get; set; }
        
        /// <summary>
        /// A tag describing the type and relevance of the 1:1 communication between your app and the
        /// end user. A full list of available tags is available
        /// <a href="https://developers.facebook.com/docs/messenger-platform/send-messages/message-tags">here</a>
        /// </summary>
        [JsonProperty("tag")]
        public MessengerTagType? Tag { get; set; }
    }
}