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
/// EventCorrectPoliticalRightData.
/// </summary>
[Serializable]
[JsonObject("eventCorrectPoliticalRightData")]
[XmlRoot(ElementName = "eventCorrectPoliticalRightData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectPoliticalRightData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectPoliticalRightDataPersonNullValidateExceptionMessage = "CorrectPoliticalRightDataPerson is not valid! CorrectPoliticalRightDataPerson is required";

    private PersonIdentification _correctPoliticalRightDataPerson;

    public EventCorrectPoliticalRightData()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctPoliticalRightDataPerson">Field is required.</param>
    /// <param name="politicalRightData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectPoliticalRightData Create(PersonIdentification correctPoliticalRightDataPerson, PoliticalRightData politicalRightData = null, object extension = null)
    {
        return new EventCorrectPoliticalRightData()
        {
            CorrectPoliticalRightDataPerson = correctPoliticalRightDataPerson,
            PoliticalRightData = politicalRightData,
            Extension = extension
        };
    }

    [JsonProperty("correctPoliticalRightDataPerson")]
    [XmlElement(ElementName = "correctPoliticalRightDataPerson")]
    public PersonIdentification CorrectPoliticalRightDataPerson
    {
        get { return _correctPoliticalRightDataPerson; }

        set
        {
            _correctPoliticalRightDataPerson = value ?? throw new XmlSchemaValidationException(CorrectPoliticalRightDataPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("politicalRightData")]
    [XmlElement(ElementName = "politicalRightData")]
    public PoliticalRightData PoliticalRightData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PoliticalRightDataSpecified => PoliticalRightData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
