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
/// EventChangeCivilDefense.
/// </summary>
[Serializable]
[JsonObject("eventChangeCivilDefense")]
[XmlRoot(ElementName = "eventChangeCivilDefense", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeCivilDefense
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _changeCivilDefensePerson;

    public EventChangeCivilDefense()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeCivilDefensePerson">Field is required.</param>
    /// <param name="civilDefenseData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeCivilDefense Create(PersonIdentification changeCivilDefensePerson, CivilDefenseData civilDefenseData, object extension = null)
    {
        return new EventChangeCivilDefense()
        {
            ChangeCivilDefensePerson = changeCivilDefensePerson,
            CivilDefenseData = civilDefenseData,
            Extension = extension
        };
    }

    [JsonProperty("changeCivilDefensePerson")]
    [XmlElement(ElementName = "changeCivilDefensePerson")]
    public PersonIdentification ChangeCivilDefensePerson
    {
        get { return _changeCivilDefensePerson; }
        set { _changeCivilDefensePerson = value; }
    }

    [JsonProperty("civilDefenseData")]
    [XmlElement(ElementName = "civilDefenseData")]
    public CivilDefenseData CivilDefenseData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseDataSpecified => CivilDefenseData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
