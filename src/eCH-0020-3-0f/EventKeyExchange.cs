// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventKeyExchange.
/// </summary>
[Serializable]
[JsonObject("eventKeyExchange")]
[XmlRoot(ElementName = "eventKeyExchange", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventKeyExchange
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private List<PersonIdentification> _keyExchangePersons;

    public EventKeyExchange()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="keyExchangePersons">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventKeyExchange Create(List<PersonIdentification> keyExchangePersons, object extension = null)
    {
        return new EventKeyExchange()
        {
            KeyExchangePersons = keyExchangePersons,
            Extension = extension
        };
    }

    [JsonProperty("keyExchangePerson")]
    [XmlElement(ElementName = "keyExchangePerson")]
    public List<PersonIdentification> KeyExchangePersons
    {
        get { return _keyExchangePersons; }
        set { _keyExchangePersons = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
