// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("parentRelationshipMutation")]
[XmlRoot(ElementName = "parentRelationshipMutation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class ParentRelationshipMutation : ParentalRelationship
{
    public ParentRelationshipMutation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partner">Field is required.</param>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="care">Field is required.</param>
    /// <param name="relationshipValidFrom">Field is optional.</param>
    /// <param name="nameOfParentAtEvent">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static ParentRelationshipMutation Create(Partner partner, TypeOfRelationship typeOfRelationship, Care care, DateTime? relationshipValidFrom = null, NameOfParent nameOfParentAtEvent = null)
    {
        return new ParentRelationshipMutation()
        {
            Partner = partner,
            RelationshipValidFrom = relationshipValidFrom,
            TypeOfRelationship = typeOfRelationship,
            Care = care,
            NameOfParentAtEvent = nameOfParentAtEvent
        };
    }

    [JsonProperty("nameOfParentAtEvent")]
    [XmlElement(ElementName = "nameOfParentAtEvent")]
    public NameOfParent NameOfParentAtEvent { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameOfParentAtEventSpecified => NameOfParentAtEvent != null;
}
