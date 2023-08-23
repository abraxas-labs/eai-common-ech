// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventMoveIn.
/// </summary>
[Serializable]
[JsonObject("eventMoveIn")]
[XmlRoot(ElementName = "eventMoveIn", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventMoveIn
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MoveInPersonNullValidateExceptionMessage = "MoveInPerson is not valid! MoveInPerson is required";
    private const string HasMainResidenceNullValidateExceptionMessage = "HasMainResidence is not valid! HasMainResidence is required";
    private const string HasSecondaryResidenceNullValidateExceptionMessage = "HasSecondaryResidence is not valid! HasSecondaryResidence is required";
    private const string HasOtherResidenceNullValidateExceptionMessage = "HasOtherResidence is not valid! HasOtherResidence is required";

    private BaseDeliveryRestrictedMoveInPersonType _moveInPerson;

    public EventMoveIn()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="moveInPerson">Field is required.</param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMoveIn Create(BaseDeliveryRestrictedMoveInPersonType moveInPerson, HasMainResidenceMoveIn hasMainResidence, object extension = null)
    {
        if (hasMainResidence == null)
        {
            throw new XmlSchemaValidationException(HasMainResidenceNullValidateExceptionMessage);
        }
        return new EventMoveIn()
        {
            MoveInPerson = moveInPerson,
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
    /// <param name="moveInPerson">Field is required.</param>
    /// <param name="hasSecondaryResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMoveIn Create(BaseDeliveryRestrictedMoveInPersonType moveInPerson, HasSecondaryResidenceMoveIn hasSecondaryResidence, object extension = null)
    {
        if (hasSecondaryResidence == null)
        {
            throw new XmlSchemaValidationException(HasSecondaryResidenceNullValidateExceptionMessage);
        }
        return new EventMoveIn()
        {
            MoveInPerson = moveInPerson,
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
    /// <param name="moveInPerson">Field is required.</param>
    /// <param name="hasOtherResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMoveIn Create(BaseDeliveryRestrictedMoveInPersonType moveInPerson, ReportingMunicipalityRestrictedMoveIn hasOtherResidence, object extension = null)
    {
        if (hasOtherResidence == null)
        {
            throw new XmlSchemaValidationException(HasOtherResidenceNullValidateExceptionMessage);
        }
        return new EventMoveIn()
        {
            MoveInPerson = moveInPerson,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence,
            Extension = extension
        };
    }

    [JsonProperty("moveInPerson")]
    [XmlElement(ElementName = "moveInPerson")]
    public BaseDeliveryRestrictedMoveInPersonType MoveInPerson
    {
        get { return _moveInPerson; }

        set
        {
            _moveInPerson = value ?? throw new XmlSchemaValidationException(MoveInPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence")]
    public HasMainResidenceMoveIn HasMainResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence")]
    public HasSecondaryResidenceMoveIn HasSecondaryResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence")]
    public ReportingMunicipalityRestrictedMoveIn HasOtherResidence { get; set; }

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
