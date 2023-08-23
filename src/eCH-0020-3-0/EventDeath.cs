// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventDeath.
/// </summary>
[Serializable]
[JsonObject("eventDeath")]
[XmlRoot(ElementName = "eventDeath", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventDeath
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DeathPersonNullValidateExceptionMessage = "DeathPerson is not valid! DeathPerson is required";
    private const string DeathDataNullValidateExceptionMessage = "DeathData is not valid! DeathData is required";

    private PersonIdentification _deathPerson;
    private DeathData _deathData;

    public EventDeath()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deathPerson">Field is required.</param>
    /// <param name="deathData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventDeath Create(PersonIdentification deathPerson, DeathData deathData, object extension = null)
    {
        return new EventDeath()
        {
            DeathPerson = deathPerson,
            DeathData = deathData,
            Extension = extension
        };
    }

    [JsonProperty("deathPerson")]
    [XmlElement(ElementName = "deathPerson")]
    public PersonIdentification DeathPerson
    {
        get { return _deathPerson; }

        set
        {
            _deathPerson = value ?? throw new XmlSchemaValidationException(DeathPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathData DeathData
    {
        get { return _deathData; }

        set
        {
            _deathData = value ?? throw new XmlSchemaValidationException(DeathDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
