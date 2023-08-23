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
/// EventAdoption.
/// </summary>
[Serializable]
[JsonObject("eventAdoption")]
[XmlRoot(ElementName = "eventAdoption", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventAdoption
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string AdoptionPersonNullValidateExceptionMessage = "AdoptionPerson is not valid! AdoptionPerson is required";

    private PersonIdentification _adoptionPerson;

    public EventAdoption()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="adoptionPerson">Field is required.</param>
    /// <param name="addParents">Field is optional.</param>
    /// <param name="removeParents">Field is optional.</param>
    /// <param name="adoptionValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventAdoption Create(PersonIdentification adoptionPerson, List<ParentalRelationship> addParents = null, List<ParentalRelationship> removeParents = null, DateTime? adoptionValidFrom = null, object extension = null)
    {
        return new EventAdoption()
        {
            AdoptionPerson = adoptionPerson,
            AddParents = addParents,
            RemoveParents = removeParents,
            AdoptionValidFrom = adoptionValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("adoptionPerson")]
    [XmlElement(ElementName = "adoptionPerson")]
    public PersonIdentification AdoptionPerson
    {
        get { return _adoptionPerson; }

        set
        {
            _adoptionPerson = value ?? throw new XmlSchemaValidationException(AdoptionPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("addParent")]
    [XmlElement(ElementName = "addParent")]
    public List<ParentalRelationship> AddParents { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddParentsSpecified => AddParents != null && !AddParents.Any();

    [JsonProperty("removeParent")]
    [XmlElement(ElementName = "removeParent")]
    public List<ParentalRelationship> RemoveParents { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RemoveParentsSpecified => RemoveParents != null && !RemoveParents.Any();

    [JsonProperty("adoptionValidFrom")]
    [XmlElement(DataType = "date", ElementName = "adoptionValidFrom")]
    public DateTime? AdoptionValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AdoptionValidFromSpecified => AdoptionValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
