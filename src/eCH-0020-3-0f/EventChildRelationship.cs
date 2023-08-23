// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventChildRelationship.
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "eventChildRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChildRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MaxParentsValidateExceptionMessage = "ParentList is not valid! Maximum 2 Parents aloud";

    private PersonIdentification _childRelationshipPerson;
    private List<ParentalRelationship> _addParents;
    private List<ParentalRelationship> _removeParents;

    public EventChildRelationship()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="childRelationshipPerson">Field is required.</param>
    /// <param name="addParents">Field is optional.</param>
    /// <param name="removeParents">Field is optional.</param>
    /// <param name="childRelationshipValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventChildRelationship Create(PersonIdentification childRelationshipPerson, List<ParentalRelationship> addParents = null, List<ParentalRelationship> removeParents = null, DateTime? childRelationshipValidFrom = null, object extension = null)
    {
        return new EventChildRelationship()
        {
            ChildRelationshipPerson = childRelationshipPerson,
            AddParents = addParents,
            RemoveParents = removeParents,
            ChildRelationshipValidFrom = childRelationshipValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("childRelationshipPerson")]
    [XmlElement(ElementName = "childRelationshipPerson")]
    public PersonIdentification ChildRelationshipPerson
    {
        get { return _childRelationshipPerson; }
        set { _childRelationshipPerson = value; }
    }

    [JsonProperty("addParent")]
    [XmlElement(ElementName = "addParent")]
    public List<ParentalRelationship> AddParents
    {
        get { return _addParents; }

        set
        {
            if (value != null && value.Count > 2)
            {
                throw new XmlSchemaValidationException(MaxParentsValidateExceptionMessage);
            }
            _addParents = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddParentsSpecified => AddParents != null && !AddParents.Any();

    [JsonProperty("removeParent")]
    [XmlElement(ElementName = "removeParent")]
    public List<ParentalRelationship> RemoveParents
    {
        get { return _removeParents; }

        set
        {
            if (value != null && value.Count > 2)
            {
                throw new XmlSchemaValidationException(MaxParentsValidateExceptionMessage);
            }
            _removeParents = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool RemoveParentsSpecified => RemoveParents != null && !RemoveParents.Any();

    [JsonProperty("childRelationshipValidFrom")]
    [XmlElement(DataType = "date", ElementName = "childRelationshipValidFrom")]
    public DateTime? ChildRelationshipValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChildRelationshipValidFromSpecified => ChildRelationshipValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
