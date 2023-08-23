// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventBaseDelivery.
/// </summary>
[Serializable]
[JsonObject("eventBaseDelivery")]
[XmlRoot(ElementName = "eventBaseDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventBaseDelivery
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private BaseDeliveryPerson _baseDeliveryPerson;

    public EventBaseDelivery()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, HasMainResidenceBaseDelivery hasMainResidence, DateTime? baseDeliveryValidFrom = null, object extension = null)
    {
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            HasMainResidence = hasMainResidence,
            HasSecondaryResidence = null,
            HasOtherResidence = null,
            BaseDeliveryValidFrom = baseDeliveryValidFrom,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="hasSecondaryResidence">Field is required.</param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, HasSecondaryResidenceBaseDelivery hasSecondaryResidence, DateTime? baseDeliveryValidFrom = null, object extension = null)
    {
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            HasMainResidence = null,
            HasSecondaryResidence = hasSecondaryResidence,
            HasOtherResidence = null,
            BaseDeliveryValidFrom = baseDeliveryValidFrom,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveryPerson">Field is required.</param>
    /// <param name="hasOtherResidence">Field is required.</param>
    /// <param name="baseDeliveryValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBaseDelivery Create(BaseDeliveryPerson baseDeliveryPerson, ReportingMunicipalityRestrictedBaseSecondary hasOtherResidence, DateTime? baseDeliveryValidFrom = null, object extension = null)
    {
        return new EventBaseDelivery()
        {
            BaseDeliveryPerson = baseDeliveryPerson,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence,
            BaseDeliveryValidFrom = baseDeliveryValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("baseDeliveryPerson")]
    [XmlElement(ElementName = "baseDeliveryPerson")]
    public BaseDeliveryPerson BaseDeliveryPerson
    {
        get { return _baseDeliveryPerson; }
        set { _baseDeliveryPerson = value; }
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence")]
    public HasMainResidenceBaseDelivery HasMainResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence")]
    public HasSecondaryResidenceBaseDelivery HasSecondaryResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence")]
    public ReportingMunicipalityRestrictedBaseSecondary HasOtherResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasOtherResidence != null;

    [JsonProperty("baseDeliveryValidFrom")]
    [XmlElement(DataType = "date", ElementName = "baseDeliveryValidFrom")]
    public DateTime? BaseDeliveryValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BaseDeliveryValidFromSpecified => BaseDeliveryValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
