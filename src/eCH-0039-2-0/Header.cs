// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0058_3_0;
using Newtonsoft.Json;

namespace eCH_0039_2_0;

[Serializable]
[JsonObject("header")]
[XmlType(TypeName = "headerType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public class Header
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string SenderIdNullValidateExceptionMessage = "SenderId is not valid! SenderId is required";
    private const string DeclarationLocalReferenceValidateExceptionMessage = "DeclarationLocalReference is not valid! DeclarationLocalReference has max length of 100";
    private const string MessageIdNullValidateExceptionMessage = "MessageId is not valid! MessageId is required";
    private const string MessageIdValidateExceptionMessage = "MessageId is not valid! MessageId has max length of 36";
    private const string ReferenceMessageIdValidateExceptionMessage = "ReferenceMessageId is not valid! ReferenceMessageId has max length of 36";
    private const string BusinessProcessIdValidateExceptionMessage = "BusinessProcessId is not valid! BusinessProcessId has max length of 128";
    private const string OurBusinessReferenceIdValidateExceptionMessage = "OurBusinessReferenceId is not valid! OurBusinessReferenceId has max lLength of 50";
    private const string YourBusinessReferenceIdValidateExceptionMessage = "YourBusinessReferenceId is not valid! YourBusinessReferenceId has max length of 50";
    private const string UniqueIdBusinessTransactionValidateExceptionMessage = "UniqueIdBusinessTransaction is not valid! UniqueIdBusinessTransaction has max length of 50";
    private const string MessageTypeNullValidateExceptionMessage = "MessageType is not valid! MessageType is required";
    private const string MessageTypeValidateExceptionMessage = "MessageType is not valid! MessageType has max length of 36";
    private const string SubMessageTypeValidateExceptionMessage = "SubMessageType is not valid! SubMessageType has max length of 36";
    private const string SendingApplicationNullValidateExceptionMessage = "SendingApplication is not valid! SendingApplication is required";
    private const string SubjectValidateExceptionMessage = "Subject is not valid! Subject has max length of 100";
    private const string CommentValidateExceptionMessage = "Comment is not valid! Comment has max length of 250";
    private const string ActionNullValidateExceptionMessage = "Action is not valid! Action is required";
    private const string ActionValidateExceptionMessage = "Action is not valid! Action has max length of 2";

    private string _senderId;
    private string _declarationLocalReference;
    private string _messageType;
    private SendingApplication _sendingApplication;
    private string _messageId;
    private string _referenceMessageId;
    private string _businessProcessId;
    private string _ourBusinessReferenceId;
    private string _yourBusinessReferenceId;
    private string _uniqueIdBusinessTransaction;
    private string _subMessageType;
    private string _subject;
    private string _comment;
    private string _action;

    public Header()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/2");
    }

    [JsonProperty("senderId")]
    [XmlElement(ElementName = "senderId")]
    public string SenderId
    {
        get { return _senderId; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(SenderIdNullValidateExceptionMessage);
            }
            _senderId = value;
        }
    }

    [JsonProperty("originalSenderId")]
    [XmlElement(ElementName = "originalSenderId")]
    public string OriginalSenderId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OriginalSenderIdSpecified => !string.IsNullOrEmpty(OriginalSenderId);

    [JsonProperty("declarationLocalReference")]
    [XmlElement(ElementName = "declarationLocalReference")]
    public string DeclarationLocalReference
    {
        get { return _declarationLocalReference; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(DeclarationLocalReferenceValidateExceptionMessage);
            }
            _declarationLocalReference = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeclarationLocalReferenceSpecified => !string.IsNullOrEmpty(DeclarationLocalReference);

    [JsonProperty("recipientId")]
    [XmlElement(ElementName = "recipientId")]
    public List<string> RecipientIds { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RecipientIdsSpecified => RecipientIds != null && RecipientIds.Any();

    [JsonProperty("messageId")]
    [XmlElement(ElementName = "messageId")]
    public string MessageId
    {
        get { return _messageId; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(MessageIdNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length > 36)
            {
                throw new XmlSchemaValidationException(MessageIdValidateExceptionMessage);
            }
            _messageId = value;
        }
    }

    [JsonProperty("referenceMessageId")]
    [XmlElement(ElementName = "referenceMessageId")]
    public string ReferenceMessageId
    {
        get { return _referenceMessageId; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 36)
            {
                throw new XmlSchemaValidationException(ReferenceMessageIdValidateExceptionMessage);
            }
            _referenceMessageId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReferenceMessageIdSpecified => !string.IsNullOrEmpty(ReferenceMessageId);

    [JsonProperty("businessProcessId")]
    [XmlElement(ElementName = "businessProcessId")]
    public string BusinessProcessId
    {
        get { return _businessProcessId; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 128)
            {
                throw new XmlSchemaValidationException(BusinessProcessIdValidateExceptionMessage);
            }
            _businessProcessId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BusinessProcessIdSpecified => !string.IsNullOrEmpty(BusinessProcessId);

    [JsonProperty("ourBusinessReferenceId")]
    [XmlElement(ElementName = "ourBusinessReferenceId")]
    public string OurBusinessReferenceId
    {
        get { return _ourBusinessReferenceId; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(OurBusinessReferenceIdValidateExceptionMessage);
            }
            _ourBusinessReferenceId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OurBusinessReferenceIdSpecified => !string.IsNullOrEmpty(OurBusinessReferenceId);

    [JsonProperty("yourBusinessReferenceId")]
    [XmlElement(ElementName = "yourBusinessReferenceId")]
    public string YourBusinessReferenceId
    {
        get { return _yourBusinessReferenceId; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(YourBusinessReferenceIdValidateExceptionMessage);
            }
            _yourBusinessReferenceId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool YourBusinessReferenceIdSpecified => !string.IsNullOrEmpty(YourBusinessReferenceId);

    [JsonProperty("uniqueIdBusinessTransaction")]
    [XmlElement(ElementName = "uniqueIdBusinessTransaction")]
    public string UniqueIdBusinessTransaction
    {
        get { return _uniqueIdBusinessTransaction; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(UniqueIdBusinessTransactionValidateExceptionMessage);
            }
            _uniqueIdBusinessTransaction = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool UniqueIdBusinessTransactionSpecified => !string.IsNullOrEmpty(UniqueIdBusinessTransaction);

    [JsonProperty("messageType")]
    [XmlElement(ElementName = "messageType")]
    public string MessageType
    {
        get { return _messageType; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(MessageTypeNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length > 36)
            {
                throw new XmlSchemaValidationException(MessageTypeValidateExceptionMessage);
            }
            _messageType = value;
        }
    }

    [JsonProperty("subMessageType")]
    [XmlElement(ElementName = "subMessageType")]
    public string SubMessageType
    {
        get { return _subMessageType; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 36)
            {
                throw new XmlSchemaValidationException(SubMessageTypeValidateExceptionMessage);
            }
            _subMessageType = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SubMessageTypeSpecified => !string.IsNullOrEmpty(SubMessageType);

    [JsonProperty("sendingApplication")]
    [XmlElement(ElementName = "sendingApplication")]
    public SendingApplication SendingApplication
    {
        get { return _sendingApplication; }

        set
        {
            _sendingApplication = value ?? throw new XmlSchemaValidationException(SendingApplicationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("partialDelivery")]
    [XmlElement(ElementName = "partialDelivery")]
    public PartialDelivery PartialDelivery { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartialDeliverySpecified => PartialDelivery != null;

    [JsonProperty("subject")]
    [XmlElement(ElementName = "subject")]
    public string Subject
    {
        get { return _subject; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(SubjectValidateExceptionMessage);
            }
            _subject = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SubjectSpecified => !string.IsNullOrEmpty(Subject);

    [JsonProperty("comment")]
    [XmlElement(ElementName = "comment")]
    public string Comment
    {
        get { return _comment; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 250)
            {
                throw new XmlSchemaValidationException(CommentValidateExceptionMessage);
            }
            _comment = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CommentSpecified => !string.IsNullOrEmpty(Comment);

    [JsonProperty("messageDate")]
    [XmlElement(DataType = "dateTime", ElementName = "messageDate")]
    public DateTime MessageDate { get; set; }

    [JsonProperty("initialMessageDate")]
    [XmlElement(DataType = "dateTime", ElementName = "initialMessageDate")]
    public DateTime? InitialMessageDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool InitialMessageDateSpecified => InitialMessageDate.HasValue;

    [JsonProperty("eventDate")]
    [XmlElement(DataType = "date", ElementName = "eventDate")]
    public DateTime? EventDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool EventDateSpecified => EventDate.HasValue;

    [JsonProperty("modificationDate")]
    [XmlElement(DataType = "date", ElementName = "modificationDate")]
    public DateTime? ModificationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ModificationDateSpecified => ModificationDate.HasValue;

    [JsonProperty("action")]
    [XmlElement(ElementName = "action")]
    public string Action
    {
        get { return _action; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ActionNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length > 2)
            {
                throw new XmlSchemaValidationException(ActionValidateExceptionMessage);
            }
            _action = value;
        }
    }

    [JsonProperty("testDeliveryFlag")]
    [XmlElement(ElementName = "testDeliveryFlag")]
    public bool TestDeliveryFlag { get; set; }

    [JsonProperty("responseExpected")]
    [XmlElement(ElementName = "responseExpected")]
    public bool? ResponseExpected { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResponseExpectedSpecified => ResponseExpected.HasValue;

    [JsonProperty("businessCaseClosed")]
    [XmlElement(ElementName = "businessCaseClosed")]
    public bool? BusinessCaseClosed { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BusinessCaseClosedSpecified => BusinessCaseClosed.HasValue;
}
