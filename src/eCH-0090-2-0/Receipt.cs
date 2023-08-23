// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eCH_0090_2_0;

[Serializable]
[XmlRoot(ElementName = "receipt", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0090/2")]
public class Receipt
{
    [XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    private const string VersionValidateExceptionMessage = "Version is not valid! Version maust be 1.0";
    private const string StatusInfoNullExceptionMessage = "StatusInfo is not valid! StatusInfo is required";
    private const string StatusInfoValidateExceptionMessage = "StatusInfo is not valid! StatusInfo has maximum length of 255";
    private const string MessageIdNullExceptionMessage = "MessageId is not valid! MessageId is required";
    private const string MessageIdValidateExceptionMessage = "MessageId is not valid! MessageId has to match the regex ([a-zA-Z]|[0-9]|-){1,36}";
    private const string MessageTypeValidateExceptionMessage = "MessageType is not valid! MessageType must be between 0 and 2699999";
    private const string SenderIdNullExceptionMessage = "SenderId is not valid! SenderId is required";
    private const string SenderIdValidateExceptionMessage = "SenderId is not valid! SenderId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";
    private const string RecipientIdNullExceptionMessage = "RecipientId is not valid! RecipientId is required";
    private const string RecipientIdValidateExceptionMessage = "RecipientId is not valid! Eevery element of RecipientId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)";

    private string _statusInfo;
    private string _messageId;
    private int _messageType;
    private string _senderId;
    private string _recipientId;

    public Receipt()
    {
        Xmlns.Add("eCH-0090", "http://www.ech.ch/xmlns/eCH-0090/2");
    }

    public static Receipt Create()
    {
        return new Receipt()
        {
        };
    }

    [XmlAttribute(AttributeName = "version")]
    public string Version
    {
        get { return "2.0"; }

        set
        {
            if (string.IsNullOrEmpty(value) || value != "2.0")
            {
                throw new XmlSchemaValidationException(VersionValidateExceptionMessage);
            }
        }
    }

    [XmlElement(ElementName = "eventDate")]
    public DateTime EventDate { get; set; }

    [XmlElement(ElementName = "statusCode")]
    public int StatusCode { get; set; }

    [XmlElement(ElementName = "statusInfo")]
    public string StatusInfo
    {
        get { return _statusInfo; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(StatusInfoNullExceptionMessage);
            }
            if (value.Length > 255)
            {
                throw new XmlSchemaValidationException(StatusInfoValidateExceptionMessage);
            }
            _statusInfo = value;
        }
    }

    [XmlElement(ElementName = "messageId")]
    public string MessageId
    {
        get { return _messageId; }

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
    public int MessageType
    {
        get { return _messageType; }

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
    public int MessageClass { get; set; }

    [XmlElement(ElementName = "senderId")]
    public string SenderId
    {
        get { return _senderId; }

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
    public string RecipientId
    {
        get { return _recipientId; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(RecipientIdNullExceptionMessage);
            }
            if (!Regex.Match(value, @"T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
            {
                throw new XmlSchemaValidationException(RecipientIdValidateExceptionMessage);
            }
            _recipientId = value;
        }
    }
}
