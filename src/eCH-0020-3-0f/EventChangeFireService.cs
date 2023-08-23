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
/// EventChangeFireService.
/// </summary>
[Serializable]
[JsonObject("eventChangeFireService")]
[XmlRoot(ElementName = "eventChangeFireService", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeFireService
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _changeFireServicePerson;

    public EventChangeFireService()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeFireServicePerson">Field is required.</param>
    /// <param name="fireServiceData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeFireService Create(PersonIdentification changeFireServicePerson, FireServiceData fireServiceData, object extension = null)
    {
        return new EventChangeFireService()
        {
            ChangeFireServicePerson = changeFireServicePerson,
            FireServiceData = fireServiceData,
            Extension = extension
        };
    }

    [JsonProperty("changeFireServicePerson")]
    [XmlElement(ElementName = "changeFireServicePerson")]
    public PersonIdentification ChangeFireServicePerson
    {
        get { return _changeFireServicePerson; }
        set { _changeFireServicePerson = value; }
    }

    [JsonProperty("fireServiceData")]
    [XmlElement(ElementName = "fireServiceData")]
    public FireServiceData FireServiceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceDataSpecified => FireServiceData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
