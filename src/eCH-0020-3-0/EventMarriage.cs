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
[JsonObject("eventMarriage")]
[XmlRoot(ElementName = "eventMarriage", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventMarriage
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MarriagePersonNullValidateExceptionMessage = "MarriagePerson is not valid! MarriagePerson is required";

    private PersonIdentification _marriagePerson;
    private MaritalInfoRestrictedMarriage _maritalInfo;

    public EventMarriage()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="marriagePerson">Field is required.</param>
    /// <param name="maritalInfo">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventMarriage Create(PersonIdentification marriagePerson, MaritalInfoRestrictedMarriage maritalInfo, MaritalRelationship maritalRelationship = null, object extension = null)
    {
        return new EventMarriage()
        {
            MarriagePerson = marriagePerson,
            MaritalInfo = maritalInfo,
            MaritalRelationship = maritalRelationship,
            Extension = extension
        };
    }

    [JsonProperty("marriagePerson")]
    [XmlElement(ElementName = "marriagePerson")]
    public PersonIdentification MarriagePerson
    {
        get { return _marriagePerson; }

        set
        {
            _marriagePerson = value ?? throw new XmlSchemaValidationException(MarriagePersonNullValidateExceptionMessage);
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

    [JsonProperty("maritalRelationship")]
    [XmlElement(ElementName = "maritalRelationship")]
    public MaritalRelationship MaritalRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalRelationshipSpecified => MaritalRelationship != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
