// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventBirth.
/// </summary>
[Serializable]
[JsonObject("eventBirth")]
[XmlRoot(ElementName = "eventBirth", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventBirth
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string BirthPersonNullValidateExceptionMessage = "BirthPerson is not valid! BirthPerson is required";
    private const string HasMainResidenceNullValidateExceptionMessage = "HasMainResidence is not valid! HasMainResidence is required";
    private const string HasSecondaryResidenceNullValidateExceptionMessage = "HasSecondaryResidence is not valid! HasSecondaryResidence is required";
    private const string HasOtherResidenceNullValidateExceptionMessage = "HasOtherResidence is not valid! HasOtherResidence is required";

    private BirthPerson _birthPerson;

    public EventBirth()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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
        if (hasMainResidence == null)
        {
            throw new XmlSchemaValidationException(HasMainResidenceNullValidateExceptionMessage);
        }
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
        if (hasSecondaryResidence == null)
        {
            throw new XmlSchemaValidationException(HasSecondaryResidenceNullValidateExceptionMessage);
        }
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
        if (hasOtherResidence == null)
        {
            throw new XmlSchemaValidationException(HasOtherResidenceNullValidateExceptionMessage);
        }
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

        set
        {
            _birthPerson = value ?? throw new XmlSchemaValidationException(BirthPersonNullValidateExceptionMessage);
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

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
