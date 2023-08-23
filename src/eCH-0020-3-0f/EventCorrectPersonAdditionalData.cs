// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectPersonAdditionalData.
/// </summary>
[Serializable]
[JsonObject("eventCorrectPersonAdditionalData")]
[XmlRoot(ElementName = "eventCorrectPersonAdditionalData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectPersonAdditionalData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctPersonAdditionalDataPerson;

    public EventCorrectPersonAdditionalData()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctPersonAdditionalDataPerson">Field is required.</param>
    /// <param name="personAdditionalData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectPersonAdditionalData Create(PersonIdentification correctPersonAdditionalDataPerson, PersonAdditionalData personAdditionalData = null, object extension = null)
    {
        return new EventCorrectPersonAdditionalData()
        {
            CorrectPersonAdditionalDataPerson = correctPersonAdditionalDataPerson,
            PersonAdditionalData = personAdditionalData,
            Extension = extension
        };
    }

    [JsonProperty("correctPersonAdditionalDataPerson")]
    [XmlElement(ElementName = "correctPersonAdditionalDataPerson")]
    public PersonIdentification CorrectPersonAdditionalDataPerson
    {
        get { return _correctPersonAdditionalDataPerson; }
        set { _correctPersonAdditionalDataPerson = value; }
    }

    [JsonProperty("personAdditionalData")]
    [XmlElement(ElementName = "personAdditionalData")]
    public PersonAdditionalData PersonAdditionalData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonAdditionalDataSpecified => PersonAdditionalData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
