// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehung zu Ehepartner, respektive Partner bei eingetragener Partnerschaft..
/// </summary>
[Serializable]
[JsonObject("parentalRelationship")]
[XmlRoot(ElementName = "parentalRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class ParentalRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Partner _partner;
    private TypeOfRelationship _typeOfRelationship;

    private const string PartnerNullValidateExceptionMessage = "Partner is not valid! Partner is Required";
    private const string TypeOfRelationshipValidateExceptionMessage = "TypeOfRelationship is not valid! TypeOfRelationship has to be 3, 4, 5, or 6";

    public ParentalRelationship()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partner">Field is required.</param>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="care">Field is required.</param>
    /// <param name="relationshipValidFrom">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static ParentalRelationship Create(Partner partner, TypeOfRelationship typeOfRelationship, Care care, DateTime? relationshipValidFrom = null)
    {
        return new ParentalRelationship()
        {
            Partner = partner,
            RelationshipValidFrom = relationshipValidFrom,
            TypeOfRelationship = typeOfRelationship,
            Care = care
        };
    }

    [JsonProperty("partner")]
    [XmlElement(ElementName = "partner", Order = 1)]
    public Partner Partner
    {
        get { return _partner; }

        set
        {
            _partner = value ?? throw new XmlSchemaValidationException(PartnerNullValidateExceptionMessage);
        }
    }

    [JsonProperty("relationshipValidFrom")]
    [XmlElement(DataType = "date", ElementName = "relationshipValidFrom", Order = 2)]
    public DateTime? RelationshipValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RelationshipValidFromSpecified => RelationshipValidFrom.HasValue;

    [JsonProperty("typeOfRelationship")]
    [XmlElement(ElementName = "typeOfRelationship", Order = 3)]
    public TypeOfRelationship TypeOfRelationship
    {
        get { return _typeOfRelationship; }

        set
        {
            if (value != TypeOfRelationship.Mutter &&
                value != TypeOfRelationship.Vater &&
                value != TypeOfRelationship.Pflegevater &&
                value != TypeOfRelationship.Pflegemutter)
            {
                throw new XmlSchemaValidationException(TypeOfRelationshipValidateExceptionMessage);
            }
            _typeOfRelationship = value;
        }
    }

    [JsonProperty("care")]
    [XmlElement(ElementName = "care", Order = 4)]
    public Care Care { get; set; }
}
