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
[JsonObject("maritalRelationship")]
[XmlRoot(ElementName = "maritalRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class MaritalRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Partner _partner;
    private TypeOfRelationship _typeOfRelationship;

    private const string PartnerNullValidateExceptionMessage = "Partner is not valid! Partner is Required";
    private const string TypeOfRelationshipValidateExceptionMessage = "TypeOfRelationship is not valid! TypeOfRelationship has to be 1 or 2";

    public MaritalRelationship()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partner">Field is required.</param>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <returns>LockData.</returns>
    public static MaritalRelationship Create(Partner partner, TypeOfRelationship typeOfRelationship)
    {
        return new MaritalRelationship()
        {
            Partner = partner,
            TypeOfRelationship = typeOfRelationship
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

    [JsonProperty("typeOfRelationship")]
    [XmlElement(ElementName = "typeOfRelationship", Order = 2)]
    public TypeOfRelationship TypeOfRelationship
    {
        get { return _typeOfRelationship; }

        set
        {
            if (value != TypeOfRelationship.Ehepartner &&
                value != TypeOfRelationship.Partnerschaft)
            {
                throw new XmlSchemaValidationException(TypeOfRelationshipValidateExceptionMessage);
            }
            _typeOfRelationship = value;
        }
    }
}
