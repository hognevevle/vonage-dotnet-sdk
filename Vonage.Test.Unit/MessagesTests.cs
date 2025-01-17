﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vonage.Messages;
using Vonage.Messages.Messenger;
using Vonage.Messages.Mms;
using Vonage.Messages.Sms;
using Vonage.Messages.Viber;
using Vonage.Messages.WhatsApp;
using Vonage.Request;
using Xunit;

namespace Vonage.Test.Unit
{
    public class MessagesTests : TestBase
    {
        // SMS

        [Fact]
        public async Task SendSmsAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new SmsRequest
            {
                To = "441234567890",
                From = "015417543010",
                Text = "This is a test",
                ClientRef = "abcdefg"
            };
            
            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendSmsAsyncReturnsInvalidCredentials()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new SmsRequest
            {
                To = "441234567890",
                From = "015417543010",
                Text = "This is a test",
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest, HttpStatusCode.Unauthorized);
            var client = new VonageClient(creds);

            var exception =
                await Assert.ThrowsAsync<VonageHttpRequestException>(async () =>
                    await client.MessagesClient.SendAsync(request));

            Assert.NotNull(exception);
            Assert.Equal(expectedResponse, exception.Json);
        }


        // MMS

        [Fact]
        public async Task SendMmsImageAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MmsImageRequest
            {
                To = "441234567890",
                From = "015417543010",
                Image = new Attachment
                {
                    Url = "https://test.com/image.png"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendMmsVcardAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MmsVcardRequest
            {
                To = "441234567890",
                From = "015417543010",
                Vcard = new Attachment
                {
                    Url = "https://test.com/contact.vcf"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendMmsAudioAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MmsAudioRequest
            {
                To = "441234567890",
                From = "015417543010",
                Audio = new CaptionedAttachment
                {
                    Url = "https://test.com/me.mp3",
                    Caption = "Sounds I make"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendMmsVideoAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MmsVideoRequest
            {
                To = "441234567890",
                From = "015417543010",
                Video = new CaptionedAttachment
                {
                    Url = "https://test.com/image.mp4",
                    Caption = "A video of me"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        // WhatsApp

        [Fact]
        public async Task SendWhatsAppTextAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppTextRequest
            {
                To = "441234567890",
                From = "015417543010",
                Text = "Hello mum",
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppImageAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppImageRequest
            {
                To = "441234567890",
                From = "015417543010",
                Image = new CaptionedAttachment
                {
                    Url = "https://test.com/image.png",
                    Caption = "Testing image caption"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppAudioAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppAudioRequest
            {
                To = "441234567890",
                From = "015417543010",
                Audio = new Attachment
                {
                    Url = "https://test.com/voice.mp3"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppVideoAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppVideoRequest
            {
                To = "441234567890",
                From = "015417543010",
                Video = new CaptionedAttachment
                {
                    Url = "https://test.com/me.mp4",
                    Caption = "Me at the zoo"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppFileAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppFileRequest
            {
                To = "441234567890",
                From = "015417543010",
                File = new CaptionedAttachment
                {
                    Url = "https://test.com/me.txt",
                    Caption = "Me"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppTemplateAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppTemplateRequest
            {
                To = "441234567890",
                From = "015417543010",
                Template = new MessageTemplate
                {
                    Name = "Amazing template",
                    Parameters = new List<object>
                    {
                        new {@default = "Vonage Verification"},
                        new {@default = "64873"},
                        new {@default = "10"}
                    }
                },
                ClientRef = "abcdefg",
                WhatsApp = new MessageWhatsApp
                {
                    Policy = "deterministic",
                    Locale = "en-GB"
                }
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }

        [Fact]
        public async Task SendWhatsAppCustomAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new WhatsAppCustomRequest
            {
                To = "441234567890",
                From = "015417543010",
                ClientRef = "abcdefg",
                Custom = new
                {
                    type = "template",
                    template = new
                    {
                        something = "whatsapp:hsm:technology:nexmo",
                        name = "parcel_location"
                    }
                }
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        // Messenger
        
        [Fact]
        public async Task SendMessengerTextAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MessengerTextRequest()
            {
                To = "441234567890",
                From = "015417543010",
                Text = "Hello mum",
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        [Fact]
        public async Task SendMessengerImageAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MessengerImageRequest
            {
                To = "441234567890",
                From = "015417543010",
                Image = new Attachment
                {
                    Url = "https://test.com/image.png"
                },
                ClientRef = "abcdefg"
            };

            var credentials = Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(credentials);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        [Fact]
        public async Task SendMessengerAudioAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MessengerAudioRequest
            {
                To = "441234567890",
                From = "015417543010",
                Audio = new Attachment
                {
                    Url = "https://test.com/voice.mp3"
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        [Fact]
        public async Task SendMessengerVideoAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MessengerVideoRequest
            {
                To = "441234567890",
                From = "015417543010",
                Video = new Attachment
                {
                    Url = "https://test.com/me.mp4",
                },
                ClientRef = "abcdefg"
            };

            var creds = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(creds);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        [Fact]
        public async Task SendMessengerFileAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new MessengerFileRequest
            {
                To = "441234567890",
                From = "015417543010",
                File = new Attachment
                {
                    Url = "https://test.com/me.txt"
                },
                ClientRef = "abcdefg"
            };

            var credentials = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(credentials);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        // Viber
        
        [Fact]
        public async Task SendViberTextAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new ViberTextRequest
            {
                To = "441234567890",
                From = "015417543010",
                Text = "Hello mum",
                ClientRef = "abcdefg"
            };

            var credentials = Request.Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(credentials);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
        
        [Fact]
        public async Task SendViberImageAsyncReturnsOk()
        {
            string expectedUri = $"{ApiUrl}/v1/messages";
            string expectedResponse = GetResponseJson();
            string expectedRequest = GetRequestJson();

            var request = new ViberImageRequest
            {
                To = "441234567890",
                From = "015417543010",
                Image = new Attachment
                {
                    Url = "https://test.com/image.png"
                },
                ClientRef = "abcdefg"
            };

            var credentials = Credentials.FromAppIdAndPrivateKey(AppId, PrivateKey);
            Setup(expectedUri, expectedResponse, expectedRequest);
            var client = new VonageClient(credentials);

            var response = await client.MessagesClient.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(new Guid("aaaaaaaa-bbbb-cccc-dddd-0123456789ab"), response.MessageUuid);
        }
    }
}
