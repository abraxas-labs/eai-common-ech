// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0090_1_0;

[Serializable]
[JsonObject("envelope")]
[XmlRoot(ElementName = "envelope", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0090/1")]
public class Envelope
{
    [XmlNamespaceDeclarations]
    [JsonIgnore]
    public XmlSerializerNamespaces Xmlns = new();

    private const string VersionValidateExceptionMessage = "Version is not valid! Version maust be 1.0";
    private const string MessageIdNullExceptionMessage = "MessageId is not valid! MessageId is required";
    private const string MessageIdValidateExceptionMessage = "MessageId is not valid! MessageId has to match the regex ([a-zA-Z]|[0-9]|-){1,36}";
    private const string MessageTypeValidateExceptionMessage = "MessageType is not valid! MessageType must be between 0 and 2699999";
    private const string ReferenceMessageIdValidateExceptionMessage = "ReferenceMessageId is not valid! ReferenceMessageId has to match the regex ([a-zA-Z]|[0-9]|-){1,36}";
    private const string SenderIdNullExceptionMessage = "SenderId is not valid! SenderId is required";
    private const string SenderIdValidateExceptionMessage = "SenderId is not valid! SenderId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";
    private const string RecipientIdNullExceptionMessage = "RecipientId is not valid! RecipientId is required";
    private const string RecipientIdValidateExceptionMessage = "RecipientId is not valid! Eevery element of RecipientId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";
    private const string MessageDateNullValidateExceptionMessage = "MessageDate is not valid! MessageDate is required";
    private const string MessageDateValidateExceptionMessage = "MessageDate is not valid! MessageDate is not a correct date";
    private const string EventDateNullValidateExceptionMessage = "EventDate is not valid! EventDate is required";
    private const string EventDateValidateExceptionMessage = "EventDate is not valid! EventDate is not a correct date";

    private string _messageId;
    private int _messageType;
    private string _senderId;
    private string[] _recipientId;
    private string _referenceMessageId;
    private DateTime _messageDate;
    private DateTime _eventDate;

    public Envelope()
    {
        Xmlns.Add("eCH-0090", "http://www.ech.ch/xmlns/eCH-0090/1");
    }

    [JsonProperty("version")]
    [XmlAttribute(AttributeName = "version")]
    public string Version
    {
        get { return "1.0"; }

        set
        {
            if (string.IsNullOrEmpty(value) || value != "1.0")
            {
                throw new XmlSchemaValidationException(VersionValidateExceptionMessage);
            }
        }
    }

    [XmlElement(ElementName = "messageId")]
    [JsonProperty(PropertyName = "messageId")]
    public string MessageId
    {
        get => _messageId;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(MessageIdNullExceptionMessage);
            }
            if (!Regex.Match(value, @"([a-zA-Z]|[0-9]|-){1,36}", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
            {
                throw new XmlSchemaValidationException(MessageIdValidateExceptionMessage);
            }
            _messageId = value;
        }
    }

    [XmlElement(ElementName = "messageType")]
    [JsonProperty(PropertyName = "messageType")]
    public int MessageType
    {
        get => _messageType;
        set
        {
            if (value < 0 || value > 2699999)
            {
                throw new XmlSchemaValidationException(MessageTypeValidateExceptionMessage);
            }
            _messageType = value;
        }
    }

    [XmlElement(ElementName = "messageClass")]
    [JsonProperty(PropertyName = "messageClass")]
    public int MessageClass { get; set; }

    [XmlElement(ElementName = "referenceMessageId")]
    [JsonProperty(PropertyName = "referenceMessageId")]
    public string ReferenceMessageId
    {
        get => _referenceMessageId;
        set
        {
            if (value != null && !Regex.Match(value, @"([a-zA-Z]|[0-9]|-){1,36}", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
            {
                throw new XmlSchemaValidationException(ReferenceMessageIdValidateExceptionMessage);
            }
            _referenceMessageId = value;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool ReferenceMessageIdSpecified => ReferenceMessageId != null;

    [XmlElement(ElementName = "senderId")]
    [JsonProperty(PropertyName = "senderId")]
    public string SenderId
    {
        get => _senderId;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(SenderIdNullExceptionMessage);
            }
            if (!Regex.Match(value, @"T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
            {
                throw new XmlSchemaValidationException(SenderIdValidateExceptionMessage);
            }
            _senderId = value;
        }
    }

    [XmlElement(ElementName = "recipientId")]
    [JsonProperty(PropertyName = "recipientId")]
    public string[] RecipientId
    {
        get => _recipientId;
        set
        {
            if (value == null || !value.Any())
            {
                throw new XmlSchemaValidationException(RecipientIdNullExceptionMessage);
            }

            if (value.Any(s => string.IsNullOrEmpty(s) || !Regex.Match(s, @"T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success))
            {
                throw new XmlSchemaValidationException(RecipientIdValidateExceptionMessage);
            }
            _recipientId = value;
        }
    }

    [JsonProperty("eventDate")]
    [XmlElement(ElementName = "eventDate")]
    public string EventDate
    {
        get
        {
            return _eventDate.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(EventDateNullValidateExceptionMessage);
            }

            if (!DateTime.TryParse(value, out _eventDate))
            {
                throw new XmlSchemaValidationException(EventDateValidateExceptionMessage);
            }
        }
    }

    [JsonProperty("messageDate")]
    [XmlElement(ElementName = "messageDate")]
    public string MessageDate
    {
        get
        {
            return _messageDate.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(MessageDateNullValidateExceptionMessage);
            }

            if (!DateTime.TryParse(value, out _messageDate))
            {
                throw new XmlSchemaValidationException(MessageDateValidateExceptionMessage);
            }
        }
    }

    [XmlElement(ElementName = "loopback")]
    [JsonProperty(PropertyName = "loopback", NullValueHandling = NullValueHandling.Ignore)]
    public EnvelopeTypeLoopback Loopback { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool LoopbackSpecified => Loopback != null;

    [XmlElement("testData")]
    [JsonProperty(PropertyName = "testData", NullValueHandling = NullValueHandling.Ignore)]
    public List<NameValuePair> TestData { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool TestDataSpecified => TestData != null && TestData.Any();
}
