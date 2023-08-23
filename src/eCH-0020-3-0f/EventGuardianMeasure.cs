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
/// EventGuardianMeasure.
/// </summary>
[Serializable]
[JsonObject("eventGuardianMeasure")]
[XmlRoot(ElementName = "eventGuardianMeasure", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventGuardianMeasure
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _guardianMeasurePerson;
    private GuardianRelationship _relationship;

    public EventGuardianMeasure()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="guardianMeasurePerson">Field is required.</param>
    /// <param name="relationship">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventGuardianMeasure Create(PersonIdentification guardianMeasurePerson, GuardianRelationship relationship, object extension = null)
    {
        return new EventGuardianMeasure()
        {
            GuardianMeasurePerson = guardianMeasurePerson,
            Relationship = relationship,
            Extension = extension
        };
    }

    [JsonProperty("guardianMeasurePerson")]
    [XmlElement(ElementName = "guardianMeasurePerson")]
    public PersonIdentification GuardianMeasurePerson
    {
        get { return _guardianMeasurePerson; }
        set { _guardianMeasurePerson = value; }
    }

    [JsonProperty("relationship")]
    [XmlElement(ElementName = "relationship")]
    public GuardianRelationship Relationship
    {
        get { return _relationship; }
        set { _relationship = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
