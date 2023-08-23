// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eEK_0020_1_1;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class EventBaseDelivery
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string BaseDeliveryPersonNullValidateExceptionMessage = "BaseDeliveryPerson is not valid! BaseDeliveryPerson is required";
    private const string HasMainResidenceNullValidateExceptionMessage = "HasMainResidence is not valid! HasMainResidence is required";
    private const string HasSecondaryResidenceNullValidateExceptionMessage = "HasSecondaryResidence is not valid! HasSecondaryResidence is required";
    private const string HasOtherResidenceNullValidateExceptionMessage = "HasOtherResidence is not valid! HasOtherResidence is required";
    private const string Ech20EventNullValidateExceptionMessage = "Ech20Event is not valid! Ech20Event is required";

    private BaseDeliveryPerson _baseDeliveryPerson;
    private string _ech20Event;

    public EventBaseDelivery()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="ech20Event"></param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="oldBaseDeliveryPerson">Field is optional.</param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, string ech20Event, MainResidenceType hasMainResidence, BaseDeliveryPerson oldBaseDeliveryPerson = null, DateTime? baseDeliveryValidFrom = null)
    {
        if (hasMainResidence == null)
        {
            throw new XmlSchemaValidationException(HasMainResidenceNullValidateExceptionMessage);
        }
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            Ech20Event = ech20Event,
            HasMainResidence = hasMainResidence,
            HasSecondaryResidence = null,
            HasOtherResidence = null,
            BaseDeliveryValidFrom = baseDeliveryValidFrom
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="ech20Event"></param>
    /// <param name="hasSecondaryResidence">Field is required.</param>
    /// <param name="oldBaseDeliveryPerson"></param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, string ech20Event, SecondaryResidenceType hasSecondaryResidence, BaseDeliveryPerson oldBaseDeliveryPerson = null, DateTime? baseDeliveryValidFrom = null)
    {
        if (hasSecondaryResidence == null)
        {
            throw new XmlSchemaValidationException(HasSecondaryResidenceNullValidateExceptionMessage);
        }
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            Ech20Event = ech20Event,
            HasMainResidence = null,
            HasSecondaryResidence = hasSecondaryResidence,
            HasOtherResidence = null,
            BaseDeliveryValidFrom = baseDeliveryValidFrom
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="ech20Event"></param>
    /// <param name="hasOtherResidence">Field is required.</param>
    /// <param name="oldBaseDeliveryPerson"></param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, string ech20Event, OtherResidenceType hasOtherResidence, BaseDeliveryPerson oldBaseDeliveryPerson = null, DateTime? baseDeliveryValidFrom = null)
    {
        if (hasOtherResidence == null)
        {
            throw new XmlSchemaValidationException(HasOtherResidenceNullValidateExceptionMessage);
        }
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            Ech20Event = ech20Event,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence,
            BaseDeliveryValidFrom = baseDeliveryValidFrom
        };
    }

    [JsonProperty("baseDeliveryPerson")]
    [XmlElement(ElementName = "baseDeliveryPerson")]
    public BaseDeliveryPerson BaseDeliveryPerson
    {
        get { return _baseDeliveryPerson; }

        set
        {
            _baseDeliveryPerson = value ?? throw new XmlSchemaValidationException(BaseDeliveryPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("oldBaseDeliveryPerson")]
    [XmlElement(ElementName = "oldBaseDeliveryPerson")]
    public BaseDeliveryPerson OldBaseDeliveryPerson { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOldBaseDeliveryPerson => OldBaseDeliveryPerson != null;

    [JsonProperty("ech20Event")]
    [XmlElement("ech20Event")]
    public string Ech20Event
    {
        get { return _ech20Event; }

        set
        {
            _ech20Event = value ?? throw new XmlSchemaValidationException(Ech20EventNullValidateExceptionMessage);
        }
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence")]
    public MainResidenceType HasMainResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence")]
    public SecondaryResidenceType HasSecondaryResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence")]
    public OtherResidenceType HasOtherResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasOtherResidence != null;

    [JsonProperty("baseDeliveryValidFrom")]
    [XmlElement(DataType = "date", ElementName = "baseDeliveryValidFrom")]
    public DateTime? BaseDeliveryValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BaseDeliveryValidFromSpecified => BaseDeliveryValidFrom.HasValue;

    [JsonProperty("hasSwissFamilyMember")]
    [XmlIgnore]
    public bool? HasSwissFamilyMember { get; set; }
}
