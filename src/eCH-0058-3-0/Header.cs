// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Meldungsrahmen (eCH-0058)
///     Der Meldungskopf enthält die für das Dispatching nötigen Informationen.
/// </summary>
[Serializable]
[JsonObject("header")]
[XmlRoot(ElementName = "header", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/3")]
public class Header
{
    private const string SenderIdNullValidateExceptionMessage = "SenderId is not valid! SenderId is required";

    private const string DeclarationLocalReferenceValidateExceptionMessage =
        "DeclarationLocalReference is not valid! DeclarationLocalReference  has max Length of 100";

    private const string MessageIdNullValidateExceptionMessage = "MessageId is not valid! MessageId is required";

    private const string MessageIdValidateExceptionMessage =
        "MessageId is not valid! MessageId  has max Length of 36";

    private const string ReferenceMessageIdValidateExceptionMessage =
        "ReferenceMessageId is not valid! ReferenceMessageId  has max Length of 36";

    private const string BusinessProcessIdValidateExceptionMessage =
        "BusinessProcessId is not valid! BusinessProcessId  has max Length of 128";

    private const string OurBusinessReferenceIdValidateExceptionMessage =
        "OurBusinessReferenceId is not valid! OurBusinessReferenceId  has max Length of 50";

    private const string YourBusinessReferenceIdValidateExceptionMessage =
        "YourBusinessReferenceId is not valid! YourBusinessReferenceId  has max Length of 50";

    private const string UniqueIdBusinessTransactionValidateExceptionMessage =
        "UniqueIdBusinessTransaction is not valid! UniqueIdBusinessTransaction  has max Length of 50";

    private const string MessageTypeNullValidateExceptionMessage =
        "MessageType is not valid! MessageType is required";

    private const string MessageTypeValidateExceptionMessage =
        "MessageType is not valid! MessageType  has max Length of 36";

    private const string SubMessageTypeValidateExceptionMessage =
        "SubMessageType is not valid! SubMessageType  has max Length of 36";

    private const string SendingApplicationNullValidateExceptionMessage =
        "SendingApplication is not valid! SendingApplication is required";

    private const string SubjectValidateExceptionMessage = "Subject is not valid! Subject  has max Length of 100";
    private const string CommentValidateExceptionMessage = "Comment is not valid! Comment  has max Length of 250";
    private const string ActionNullValidateExceptionMessage = "Action is not valid! Action is required";
    private const string ActionValidateExceptionMessage = "Action is not valid! Action  has max Length of 2";
    private string _action;
    private string _businessProcessId;
    private string _comment;
    private string _declarationLocalReference;
    private string _messageId;
    private string _messageType;
    private string _ourBusinessReferenceId;
    private string _referenceMessageId;

    private string _senderId;
    private SendingApplication _sendingApplication;
    private string _subject;
    private string _subMessageType;
    private string _uniqueIdBusinessTransaction;
    private string _yourBusinessReferenceId;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Header()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/3");
    }

    [JsonProperty("senderId")]
    [XmlElement(ElementName = "senderId")]
    public string SenderId
    {
        get => _senderId;
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
        get => _declarationLocalReference;
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
        get => _messageId;
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
        get => _referenceMessageId;
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
        get => _businessProcessId;
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
        get => _ourBusinessReferenceId;
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
        get => _yourBusinessReferenceId;
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
        get => _uniqueIdBusinessTransaction;
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
        get => _messageType;
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
        get => _subMessageType;
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
        get => _sendingApplication;
        set => _sendingApplication =
            value ?? throw new XmlSchemaValidationException(SendingApplicationNullValidateExceptionMessage);
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
        get => _subject;
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
        get => _comment;
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
        get => _action;
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

    [JsonProperty("attachment")]
    [XmlElement(ElementName = "attachment")]
    public List<object> Attachments { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AttachmentsSpecified => Attachments != null && Attachments.Any();

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

    [JsonProperty("namedMetaData")]
    [XmlElement(ElementName = "namedMetaData")]
    public List<NamedMetaData> NamedMetaDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NamedMetaDatasSpecified => false;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte, sind aber mit default Paramentern hinterlegt.
    /// </summary>
    /// <param name="senderId">Field is reqired.</param>
    /// <param name="messageType">Field is reqired.</param>
    /// <param name="sendingApplication">Field is reqired.</param>
    /// <param name="messageDate">Field is reqired.</param>
    /// <param name="action">Field is reqired.</param>
    /// <param name="originalSenderId">Field can be null.</param>
    /// <param name="declarationLocalReference">Field can be null.</param>
    /// <param name="recipientIds">Field can be null.</param>
    /// <param name="messageId">Field can be null.</param>
    /// <param name="referenceMessageId">Field can be null.</param>
    /// <param name="businessProcessId">Field can be null.</param>
    /// <param name="ourBusinessReferenceId">Field can be null.</param>
    /// <param name="yourBusinessReferenceId">Field can be null.</param>
    /// <param name="uniqueIdBusinessTransaction">Field can be null.</param>
    /// <param name="subMessageType">Field can be null.</param>
    /// <param name="partialDelivery">Field can be null.</param>
    /// <param name="subject">Field can be null.</param>
    /// <param name="comment">Field can be null.</param>
    /// <param name="initialMessageDate">Field can be null.</param>
    /// <param name="eventDate">Field can be null.</param>
    /// <param name="modificationDate">Field can be null.</param>
    /// <param name="attachment">Field can be null.</param>
    /// <param name="testDeliveryFlag">Field is reqired.</param>
    /// <param name="responseExpected">Field can be null.</param>
    /// <param name="businessCaseClosed">Field can be null.</param>
    /// <param name="extension">Field can be null.</param>
    /// <param name="namedMetaData">Field can be null.</param>
    /// <returns>Header.</returns>
    public static Header Create(string senderId, string messageType, SendingApplication sendingApplication,
        DateTime messageDate,
        string action,
        string originalSenderId = null, string declarationLocalReference = null, List<string> recipientIds = null,
        string messageId = null, string referenceMessageId = null, string businessProcessId = null,
        string ourBusinessReferenceId = null,
        string yourBusinessReferenceId = null, string uniqueIdBusinessTransaction = null,
        string subMessageType = null,
        PartialDelivery partialDelivery = null, string subject = null, string comment = null,
        DateTime? initialMessageDate = null,
        DateTime? eventDate = null, DateTime? modificationDate = null, List<object> attachment = null,
        bool testDeliveryFlag = false,
        bool? responseExpected = null, bool? businessCaseClosed = null,
        object extension = null, List<NamedMetaData> namedMetaData = null)
    {
        return new Header
        {
            SenderId = senderId,
            OriginalSenderId = originalSenderId,
            DeclarationLocalReference = declarationLocalReference,
            RecipientIds = recipientIds,
            MessageId = messageId,
            ReferenceMessageId = referenceMessageId,
            BusinessProcessId = businessProcessId,
            OurBusinessReferenceId = ourBusinessReferenceId,
            YourBusinessReferenceId = yourBusinessReferenceId,
            UniqueIdBusinessTransaction = uniqueIdBusinessTransaction,
            MessageType = messageType,
            SubMessageType = subMessageType,
            SendingApplication = sendingApplication,
            PartialDelivery = partialDelivery,
            Subject = subject,
            Comment = comment,
            MessageDate = messageDate,
            InitialMessageDate = initialMessageDate,
            EventDate = eventDate,
            ModificationDate = modificationDate,
            Action = action,
            Attachments = attachment,
            TestDeliveryFlag = testDeliveryFlag,
            ResponseExpected = responseExpected,
            BusinessCaseClosed = businessCaseClosed,
            NamedMetaDatas = namedMetaData,
            Extension = extension
        };
    }
}
