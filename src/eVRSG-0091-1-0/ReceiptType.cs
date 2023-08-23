using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eVRSG_0091_1_0
{
    [Serializable]
    [JsonObject("receipt")]
    [XmlRoot(ElementName = "receipt", IsNullable = false, Namespace = "http://xmlns.vrsg.ch/xmlns/eVRSG-0091/1")]
    public class ReceiptType
    {
        // TODO: Refactor, FieldValueChecker einbauen!

        private const string StatusCodeValidateExceptionMessage = "StatusCode is not valid! StatusCode must be minimum inclusive 100 and maximum inclusive 999";
        private const string StatusInfoValidateExceptionMessage = "StatusInfo is not valid! StatusInfo has maximum length of 255";
        private const string StatusInfoNullValidateExceptionMessage = "StatusInfo is not valid! MessageId is required";
        private const string MessageIdNullValidateExceptionMessage = "MessageId is not valid! MessageId is required";
        private const string MessageTypeValidateExceptionMessage = "MessageType is not valid! MessageType has maximum size of 2699999";
        private const string SenderIdValidateExceptionMessage = "SenderId is not valid! SenderId has to match the regex of (T?[1 - 9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";
        private const string RecipientIdValidateExceptionMessage = "RecipientId is not valid! RecipientId has to match the regex of (T?[1 - 9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";

        private int _statusCode;
        private string _messageId;
        private int _messageType;
        private string _statusInfo;
        
        [XmlNamespaceDeclarations]
        [JsonIgnore]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();
        

        public ReceiptType()
        {
            Xmlns.Add("eVRSG-0091", "http://xmlns.vrsg.ch/xmlns/eVRSG-0091/1");
        }
        

        [XmlAttribute(AttributeName = "version")]
        [JsonProperty("version")]
        public string Version { get { return "1.0"; } set { } }

        [XmlElement(ElementName = "eventDate")]
        [JsonProperty("eventDate")]
        public DateTime EventDate { get; set; }


        [XmlElement(ElementName = "statusCode")]
        [JsonProperty("statusCode")]
        public int StatusCode { get => _statusCode;
            set
            {
                if(value > 100 && value < 999)
                    throw new XmlSchemaValidationException(StatusCodeValidateExceptionMessage);

                _statusCode = value;
            }
        }


        [XmlElement(ElementName = "statusInfo")]
        [JsonProperty("statusInfo")]
        public string StatusInfo
        {
            get => _statusInfo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new XmlSchemaValidationException(StatusInfoNullValidateExceptionMessage);
                if (value.Length > 36)
                    throw new XmlSchemaValidationException(StatusInfoValidateExceptionMessage);
                _statusInfo = value;
            }
        }


        [XmlElement(ElementName = "messageId")]
        [JsonProperty("messageId")]
        public string MessageId
        {
            get => _messageId;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new XmlSchemaValidationException(MessageIdNullValidateExceptionMessage);
                
                _messageId = value;
            }
        }
        

        [XmlElement(ElementName = "messageType")]
        [JsonProperty("messageType")]
        public int MessageType
        {
            get => _messageType;
            set
            {
                if (value > 2699999)
                    throw new XmlSchemaValidationException(MessageTypeValidateExceptionMessage);
                _messageType = value;
            }
        }

        [XmlElement(ElementName = "messageClass")]
        [JsonProperty("messageClass")]
        public int MessageClass { get; set; }


        [XmlElement(ElementName = "senderId")]
        [JsonProperty("senderId")]
        public string SenderId { get; set; }

        [XmlElement(ElementName = "recipientId")]
        [JsonProperty("recipientId")]
        public string RecipientId { get; set; }


        [XmlElement(ElementName = "referenceFileName")]
        [JsonProperty("referenceFileName")]
        public string ReferenceFileName { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public bool ReferenceFileNameSpecified => !string.IsNullOrWhiteSpace(ReferenceFileName);
    }
}
