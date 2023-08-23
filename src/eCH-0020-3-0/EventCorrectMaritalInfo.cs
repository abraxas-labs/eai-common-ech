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
[JsonObject("eventCorrectMaritalInfo")]
[XmlRoot(ElementName = "eventCorrectMaritalInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectMaritalInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectMaritalDataPersonNullValidateExceptionMessage = "CorrectMaritalDataPerson is not valid! CorrectMaritalDataPerson is required";

    private PersonIdentification _correctMaritalDataPerson;
    private MaritalInfo _maritalInfo;

    public EventCorrectMaritalInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctMaritalDataPerson">Field is required.</param>
    /// <param name="maritalInfo">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventCorrectMaritalInfo Create(PersonIdentification correctMaritalDataPerson, MaritalInfo maritalInfo, MaritalRelationship maritalRelationship = null, object extension = null)
    {
        return new EventCorrectMaritalInfo()
        {
            CorrectMaritalDataPerson = correctMaritalDataPerson,
            MaritalInfo = maritalInfo,
            MaritalRelationship = maritalRelationship,
            Extension = extension
        };
    }

    [JsonProperty("correctMaritalDataPerson")]
    [XmlElement(ElementName = "correctMaritalDataPerson")]
    public PersonIdentification CorrectMaritalDataPerson
    {
        get { return _correctMaritalDataPerson; }

        set
        {
            _correctMaritalDataPerson = value ?? throw new XmlSchemaValidationException(CorrectMaritalDataPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalInfo")]
    [XmlElement(ElementName = "maritalInfo")]
    public MaritalInfo MaritalInfo
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
