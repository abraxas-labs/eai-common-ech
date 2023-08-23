﻿// (c) Copyright 2023 by Abraxas Informatik AG
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
/// EventMissing.
/// </summary>
[Serializable]
[JsonObject("eventMissing")]
[XmlRoot(ElementName = "eventMissing", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventMissing
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _missingPerson;
    private DeathData _deathData;

    public EventMissing()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="missingPerson">Field is required.</param>
    /// <param name="deathData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMissing Create(PersonIdentification missingPerson, DeathData deathData, object extension = null)
    {
        return new EventMissing()
        {
            MissingPerson = missingPerson,
            DeathData = deathData,
            Extension = extension
        };
    }

    [JsonProperty("missingPerson")]
    [XmlElement(ElementName = "missingPerson")]
    public PersonIdentification MissingPerson
    {
        get { return _missingPerson; }
        set { _missingPerson = value; }
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathData DeathData
    {
        get { return _deathData; }
        set { _deathData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
