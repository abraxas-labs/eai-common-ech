// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_2_0;

[Serializable]
[JsonObject("messageGroup")]
[XmlType(TypeName = "messageGroupType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public class MessageGroup
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MessageGroupIdValidateExceptionMessage = "messageGroupId is not valid! messageGroupId cannot be null";
    private const string MessageGroupIdNonNegativeIntegerExceptionMessage = "messageGroupId is not valid! messageGroupId must be a positive number";
    private const string MessageTypeIdValidateExceptionMessage = "messageTypeId is not valid! messageTypeId cannot be null";
    private const string MessageTypeIdNonNegativeIntegerExceptionMessage = "messageTypeId is not valid! messageTypeId must be a positive number";

    private int? _messageGroupId;
    private int? _messageTypeId;

    public MessageGroup()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/2");
    }

    [JsonProperty("messageGroupId")]
    [XmlElement(ElementName = "messageGroupId")]
    public int? MessageGroupId
    {
        get => _messageGroupId;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(MessageGroupIdValidateExceptionMessage);
            }

            if (value < 0)
            {
                throw new XmlSchemaValidationException(MessageGroupIdNonNegativeIntegerExceptionMessage);
            }

            _messageGroupId = value;
        }
    }

    [JsonProperty("messageTypeId")]
    [XmlElement(ElementName = "messageTypeId")]
    public int? MessageTypeId
    {
        get => _messageTypeId;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(MessageTypeIdValidateExceptionMessage);
            }

            if (value < 0)
            {
                throw new XmlSchemaValidationException(MessageTypeIdNonNegativeIntegerExceptionMessage);
            }

            _messageTypeId = value;
        }
    }
}
