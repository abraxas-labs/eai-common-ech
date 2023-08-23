// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectGuardianRelationship.
/// </summary>
[Serializable]
[JsonObject("eventCorrectGuardianRelationship")]
[XmlRoot(ElementName = "eventCorrectGuardianRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectGuardianRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctGuardianRelationshipPerson;

    public EventCorrectGuardianRelationship()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctGuardianRelationshipPerson">Field is required.</param>
    /// <param name="guardianRelationships">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectGuardianRelationship Create(PersonIdentification correctGuardianRelationshipPerson, List<GuardianRelationship> guardianRelationships, object extension = null)
    {
        return new EventCorrectGuardianRelationship()
        {
            CorrectGuardianRelationshipPerson = correctGuardianRelationshipPerson,
            GuardianRelationships = guardianRelationships,
            Extension = extension
        };
    }

    [JsonProperty("correctGuardianRelationshipPerson")]
    [XmlElement(ElementName = "correctGuardianRelationshipPerson")]
    public PersonIdentification CorrectGuardianRelationshipPerson
    {
        get { return _correctGuardianRelationshipPerson; }
        set { _correctGuardianRelationshipPerson = value; }
    }

    [JsonProperty("guardianRelationship")]
    [XmlElement(ElementName = "guardianRelationship")]
    public List<GuardianRelationship> GuardianRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianRelationshipsSpecified => GuardianRelationships != null && GuardianRelationships.Any();

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
