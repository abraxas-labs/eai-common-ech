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
/// EventKeyExchange.
/// </summary>
[Serializable]
[JsonObject("eventSeparation")]
[XmlRoot(ElementName = "eventSeparation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventSeparation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _separationPerson;
    private SeparationData _separationData;

    public EventSeparation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="separationPerson">Field is required.</param>
    /// <param name="separationData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventSeparation Create(PersonIdentification separationPerson, SeparationData separationData, object extension = null)
    {
        return new EventSeparation()
        {
            SeparationPerson = separationPerson,
            SeparationData = separationData,
            Extension = extension
        };
    }

    [JsonProperty("separationPerson")]
    [XmlElement(ElementName = "separationPerson")]
    public PersonIdentification SeparationPerson
    {
        get { return _separationPerson; }
        set { _separationPerson = value; }
    }

    [JsonProperty("separationData")]
    [XmlElement(ElementName = "separationData")]
    public SeparationData SeparationData
    {
        get { return _separationData; }
        set { _separationData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
