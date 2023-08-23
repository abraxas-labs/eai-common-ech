// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventMarriage.
/// </summary>
[Serializable]
[JsonObject("eventPartnership")]
[XmlRoot(ElementName = "eventPartnership", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventPartnership
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PartnershipPersonNullValidateExceptionMessage = "PartnershipPerson is not valid! PartnershipPerson is required";

    private PersonIdentification _partnershipPerson;
    private MaritalInfoRestrictedMarriage _maritalInfo;

    public EventPartnership()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnershipPerson">Field is required.</param>
    /// <param name="maritalInfo">Field is optional.</param>
    /// <param name="partnershipRelationship">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventPartnership Create(PersonIdentification partnershipPerson, MaritalInfoRestrictedMarriage maritalInfo, MaritalRelationship partnershipRelationship = null, object extension = null)
    {
        return new EventPartnership()
        {
            PartnershipPerson = partnershipPerson,
            MaritalInfo = maritalInfo,
            PartnershipRelationship = partnershipRelationship,
            Extension = extension
        };
    }

    [JsonProperty("partnershipPerson")]
    [XmlElement(ElementName = "partnershipPerson")]
    public PersonIdentification PartnershipPerson
    {
        get { return _partnershipPerson; }

        set
        {
            _partnershipPerson = value ?? throw new XmlSchemaValidationException(PartnershipPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalInfo")]
    [XmlElement(ElementName = "maritalInfo")]
    public MaritalInfoRestrictedMarriage MaritalInfo
    {
        get { return _maritalInfo; }

        set
        {
            _maritalInfo = value ?? throw new XmlSchemaValidationException();
        }
    }

    [JsonProperty("partnershipRelationship")]
    [XmlElement(ElementName = "partnershipRelationship")]
    public MaritalRelationship PartnershipRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnershipRelationshipSpecified => PartnershipRelationship != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
