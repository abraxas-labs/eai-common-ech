// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventBirth.
/// </summary>
[Serializable]
[JsonObject("eventBirth")]
[XmlRoot(ElementName = "eventBirth", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventBirth
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private BirthPerson _birthPerson;

    public EventBirth()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="birthPerson">Field is required.</param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBirth Create(BirthPerson birthPerson, MainResidenceType hasMainResidence, object extension = null)
    {
        return new EventBirth()
        {
            BirthPerson = birthPerson,
            HasMainResidence = hasMainResidence,
            HasSecondaryResidence = null,
            HasOtherResidence = null,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="birthPerson">Field is required.</param>
    /// <param name="hasSecondaryResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBirth Create(BirthPerson birthPerson, SecondaryResidenceType hasSecondaryResidence, object extension = null)
    {
        return new EventBirth()
        {
            BirthPerson = birthPerson,
            HasMainResidence = null,
            HasSecondaryResidence = hasSecondaryResidence,
            HasOtherResidence = null,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="birthPerson">Field is required.</param>
    /// <param name="hasOtherResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventBirth Create(BirthPerson birthPerson, OtherResidenceType hasOtherResidence, object extension = null)
    {
        return new EventBirth()
        {
            BirthPerson = birthPerson,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence,
            Extension = extension
        };
    }

    [JsonProperty("birthPerson")]
    [XmlElement(ElementName = "birthPerson")]
    public BirthPerson BirthPerson
    {
        get { return _birthPerson; }
        set { _birthPerson = value; }
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

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
