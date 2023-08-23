// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectParentalRelationship.
/// </summary>
[Serializable]
[JsonObject("eventCorrectParentalRelationship")]
[XmlRoot(ElementName = "eventCorrectParentalRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectParentalRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectParentalRelationshipPersonNullValidateExceptionMessage = "CorrectParentalRelationshipPerson is not valid! CorrectParentalRelationshipPerson is required";

    private PersonIdentification _correctParentalRelationshipPerson;

    public EventCorrectParentalRelationship()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctParentalRelationshipPerson">Field is required.</param>
    /// <param name="parentalRelationship">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectParentalRelationship Create(PersonIdentification correctParentalRelationshipPerson, List<ParentalRelationship> parentalRelationship, object extension = null)
    {
        return new EventCorrectParentalRelationship()
        {
            CorrectParentalRelationshipPerson = correctParentalRelationshipPerson,
            ParentalRelationships = parentalRelationship,
            Extension = extension
        };
    }

    [JsonProperty("correctParentalRelationshipPerson")]
    [XmlElement(ElementName = "correctParentalRelationshipPerson")]
    public PersonIdentification CorrectParentalRelationshipPerson
    {
        get { return _correctParentalRelationshipPerson; }

        set
        {
            _correctParentalRelationshipPerson = value ?? throw new XmlSchemaValidationException(CorrectParentalRelationshipPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("parentalRelationship")]
    [XmlElement(ElementName = "parentalRelationship")]
    public List<ParentalRelationship> ParentalRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ParentalRelationshipsSpecified => ParentalRelationships != null && ParentalRelationships.Any();

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
