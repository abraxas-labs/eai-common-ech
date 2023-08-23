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
/// EventChangeArmedForces.
/// </summary>
[Serializable]
[JsonObject("eventChangeArmedForces")]
[XmlRoot(ElementName = "eventChangeArmedForces", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeArmedForces
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeArmedForcesPersonNullValidateExceptionMessage = "ChangeArmedForcesPerson is not valid! ChangeArmedForcesPerson is required";

    private PersonIdentification _changeArmedForcesPerson;

    public EventChangeArmedForces()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeArmedForcesPerson">Field is required.</param>
    /// <param name="armedForcesData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeArmedForces Create(PersonIdentification changeArmedForcesPerson, ArmedForcesData armedForcesData, object extension = null)
    {
        return new EventChangeArmedForces()
        {
            ChangeArmedForcesPerson = changeArmedForcesPerson,
            ArmedForcesData = armedForcesData,
            Extension = extension
        };
    }

    [JsonProperty("changeArmedForcesPerson")]
    [XmlElement(ElementName = "changeArmedForcesPerson")]
    public PersonIdentification ChangeArmedForcesPerson
    {
        get { return _changeArmedForcesPerson; }

        set
        {
            _changeArmedForcesPerson = value ?? throw new XmlSchemaValidationException(ChangeArmedForcesPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("armedForcesData")]
    [XmlElement(ElementName = "armedForcesData")]
    public ArmedForcesData ArmedForcesData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesDataSpecified => ArmedForcesData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
