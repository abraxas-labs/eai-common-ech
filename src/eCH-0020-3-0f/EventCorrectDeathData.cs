// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectDeathData.
/// </summary>
[Serializable]
[JsonObject("eventCorrectDeathData")]
[XmlRoot(ElementName = "eventCorrectDeathData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectDeathData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctDeathDataPerson;

    public EventCorrectDeathData()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctDeathDataPerson">Field is required.</param>
    /// <param name="deathData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectDeathData Create(PersonIdentification correctDeathDataPerson, DeathData deathData, object extension = null)
    {
        return new EventCorrectDeathData()
        {
            CorrectDeathDataPerson = correctDeathDataPerson,
            DeathData = deathData,
            Extension = extension
        };
    }

    [JsonProperty("correctDeathDataPerson")]
    [XmlElement(ElementName = "correctDeathDataPerson")]
    public PersonIdentification CorrectDeathDataPerson
    {
        get { return _correctDeathDataPerson; }
        set { _correctDeathDataPerson = value; }
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathData DeathData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeathDataSpecified => DeathData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
