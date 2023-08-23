// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eEK_0020_1_0;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("deliveryHeader")]
[XmlRoot(ElementName = "deliveryHeader", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class Header
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MessageDateNullValidateExceptionMessage = "MessageDate is not valid! MessageDate is required";
    private const string MessageDateValidateExceptionMessage = "MessageDate is not valid! MessageDate must be in format yyyy-MM-ddTHH:mm:ss.fff";
    private const string EventDateNullValidateExceptionMessage = "EventDate is not valid! EventDate is required";
    private const string EventDateValidateExceptionMessage = "EventDate is not valid! EventDate must be in format yyyy-MM-ddTHH:mm:ss.fff";
    private const string ApplicationNameNullValidateExceptionMessage = "ApplicationName is not valid! ApplicationName is required";
    private const string ApplicationNameValidateExceptionMessage = "ApplicationName is not valid! ApplicationName has min length of 1 and max length of 50";
    private const string OrganisationUnitBfsNrNullValidateExceptionMessage = "OrganisationUnitBfsNr is not valid! OrganisationUnitBfsNr is required";
    private const string ApplicationEventIdNullValidateExceptionMessage = "ApplicationEventId is not valid! ApplicationEventId is required";
    private const string ApplicationEventIdValidateExceptionMessage = "ApplicationEventId is not valid! ApplicationEventId has max length of 50";
    private const string MessageIdNullValidateExceptionMessage = "MessageId is not valid! MessageId is required";
    private const string MessageIdValidateExceptionMessage = "MessageId is not valid! MessageId has min length of 32 and max length of 36";
    private const string ReferenceMessageIdValidateExceptionMessage = "ReferenceMessageId is not valid! ReferenceMessageId has min length of 32 and max length of 36";
    private const string ActionNullValidateExceptionMessage = "Action is not valid! Action is required";
    private const string ActionValidateExceptionMessage = "Action is not valid! Action has min length of 1 and max length of 3";

    private DateTime _messageDate;
    private DateTime _eventDate;
    private string _applicationName;
    private string _organisationUnitBfsNr;
    private string _applicationEventId;
    private string _messageId;
    private string _action;
    private string _referenceMessageId;

    public Header()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="messageDate">Field is reqired.</param>
    /// <param name="eventDate">Field is reqired.</param>
    /// <param name="applicationName">Field is reqired.</param>
    /// <param name="organisationUnitBfsNr">Field is reqired.</param>
    /// <param name="applicationEventId">Field is reqired.</param>
    /// <param name="messageId">Field is reqired.</param>
    /// <param name="referenceMessageId">Field is optional.</param>
    /// <param name="partialDelivery">Field is optional.</param>
    /// <param name="action">Field is required.</param>
    /// <returns>Header.</returns>
    public static Header Create(string messageDate, string eventDate, string applicationName, string organisationUnitBfsNr, string applicationEventId, string messageId, string action, string referenceMessageId, PartialDelivery partialDelivery = null)
    {
        return new Header()
        {
            MessageDate = messageDate,
            EventDate = eventDate,
            ApplicationName = applicationName,
            OrganisationUnitBfsNr = organisationUnitBfsNr,
            ApplicationEventId = applicationEventId,
            MessageId = messageId,
            PartialDelivery = partialDelivery,
            Action = action
        };
    }

    [JsonProperty("messageDate", Required = Required.Always)]
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

    [JsonProperty("eventDate", Required = Required.Always)]
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

    [JsonProperty("applicationName", Required = Required.Always)]
    [XmlElement(ElementName = "applicationName")]
    public string ApplicationName
    {
        get { return _applicationName; }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ApplicationNameNullValidateExceptionMessage);
            }
            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(ApplicationNameValidateExceptionMessage);
            }
            _applicationName = value;
        }
    }

    [JsonProperty("organisationUnitBfsNr", Required = Required.Always)]
    [XmlElement(ElementName = "organisationUnitBfsNr")]
    public string OrganisationUnitBfsNr
    {
        get { return _organisationUnitBfsNr; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(OrganisationUnitBfsNrNullValidateExceptionMessage);
            }
            _organisationUnitBfsNr = value;
        }
    }

    [JsonProperty("applicationEventId")]
    [XmlElement(ElementName = "applicationEventId")]
    public string ApplicationEventId
    {
        get { return _applicationEventId; }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ApplicationEventIdNullValidateExceptionMessage);
            }
            if (value.Length > 50)
            {
                throw new XmlSchemaValidationException(ApplicationEventIdValidateExceptionMessage);
            }
            _applicationEventId = value;
        }
    }

    [JsonProperty("messageId", Required = Required.Always)]
    [XmlElement(ElementName = "messageId")]
    public string MessageId
    {
        get { return _messageId; }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(MessageIdNullValidateExceptionMessage);
            }
            if (value.Length < 32 || value.Length > 36)
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
            if (value != null && (value.Length < 32 || value.Length > 36))
            {
                throw new XmlSchemaValidationException(ReferenceMessageIdValidateExceptionMessage);
            }
            _referenceMessageId = value;
        }
    }

    [JsonProperty("partialDelivery")]
    [XmlElement(ElementName = "partialDelivery")]
    public PartialDelivery PartialDelivery { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartialDeliverySpecified => PartialDelivery != null;

    [JsonProperty("action", Required = Required.Always)]
    [XmlElement(ElementName = "action")]
    public string Action
    {
        get { return _action; }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ActionNullValidateExceptionMessage);
            }
            if (value.Length < 1 || value.Length > 3)
            {
                throw new XmlSchemaValidationException(ActionValidateExceptionMessage);
            }
            _action = value;
        }
    }
}
