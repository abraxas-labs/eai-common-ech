// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventMoveIn.
/// </summary>
[Serializable]
[JsonObject("eventMoveIn")]
[XmlRoot(ElementName = "eventMoveIn", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventMoveIn
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private BaseDeliveryRestrictedMoveInPersonType _moveInPerson;

    public EventMoveIn()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="moveInPerson">Field is required.</param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMoveIn Create(eCH_0020_3_0.BaseDeliveryRestrictedMoveInPersonType moveInPerson, eCH_0020_3_0.HasMainResidenceMoveIn hasMainResidence, object extension = null)
    {
        return new EventMoveIn()
        {
            MoveInPerson = Mapper.ECHtoECHf.GetBaseDeliveryRestrictedMoveInPersonType(moveInPerson),
            HasMainResidence = Mapper.ECHtoECHf.GetHasMainResidenceMoveIn(hasMainResidence),
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
    public static EventMoveIn Create(eCH_0020_3_0.BaseDeliveryRestrictedMoveInPersonType moveInPerson, eCH_0020_3_0.HasSecondaryResidenceMoveIn hasSecondaryResidence, object extension = null)
    {
        return new EventMoveIn()
        {
            MoveInPerson = Mapper.ECHtoECHf.GetBaseDeliveryRestrictedMoveInPersonType(moveInPerson),
            HasMainResidence = null,
            HasSecondaryResidence = Mapper.ECHtoECHf.GetHasSecondaryResidenceMoveIn(hasSecondaryResidence),
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
    public static EventMoveIn Create(eCH_0020_3_0.BaseDeliveryRestrictedMoveInPersonType moveInPerson, eCH_0020_3_0.ReportingMunicipalityRestrictedMoveIn hasOtherResidence, object extension = null)
    {
        return new EventMoveIn()
        {
            MoveInPerson = Mapper.ECHtoECHf.GetBaseDeliveryRestrictedMoveInPersonType(moveInPerson),
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = Mapper.ECHtoECHf.GetReportingMunicipalityRestrictedMoveIn(hasOtherResidence),
            Extension = extension
        };
    }

    [JsonProperty("moveInPerson")]
    [XmlElement(ElementName = "moveInPerson")]
    public BaseDeliveryRestrictedMoveInPersonType MoveInPerson
    {
        get { return _moveInPerson; }
        set { _moveInPerson = value; }
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
