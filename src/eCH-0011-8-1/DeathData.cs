﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Todesangaben.
/// </summary>
[Serializable]
[JsonObject("deathData")]
[XmlRoot(ElementName = "deathData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class DeathData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DeathPeriodNullValidateExceptionMessage = "DeathPeriod is not valid! DeathPeriod is required";

    private DeathPeriod _deathPeriod;

    public DeathData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deathPeriod">Field is required.</param>
    /// <param name="placeOfDeath">Field is optional.</param>
    /// <returns>DeathData.</returns>
    public static DeathData Create(DeathPeriod deathPeriod, GeneralPlace placeOfDeath = null)
    {
        return new DeathData()
        {
            DeathPeriod = deathPeriod,
            PlaceOfDeath = placeOfDeath
        };
    }

    [JsonProperty("deathPeriod")]
    [XmlElement(ElementName = "deathPeriod", Order = 1)]
    public DeathPeriod DeathPeriod
    {
        get { return _deathPeriod; }

        set
        {
            _deathPeriod = value ?? throw new XmlSchemaValidationException(DeathPeriodNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfDeath")]
    [XmlElement(ElementName = "placeOfDeath", Order = 2)]
    public GeneralPlace PlaceOfDeath { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfDeathSpecified => PlaceOfDeath != null;
}
