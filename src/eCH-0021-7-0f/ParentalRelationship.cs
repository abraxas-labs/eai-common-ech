// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehung zu Ehepartner, respektive Partner bei eingetragener Partnerschaft..
/// </summary>
[Serializable]
[JsonObject("parentalRelationship")]
[XmlRoot(ElementName = "parentalRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class ParentalRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Partner _partner;
    private TypeOfRelationship? _typeOfRelationship;

    private const string TypeOfRelationshipValidateExceptionMessage = "TypeOfRelationship is not valid! TypeOfRelationship has to be 3, 4, 5 or 6";

    public ParentalRelationship()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
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
    public static ParentalRelationship Create(eCH_0021_7_0.Partner partner, eCH_0021_7_0.TypeOfRelationship typeOfRelationship, eCH_0021_7_0.Care care, DateTime? relationshipValidFrom = null)
    {
        var fParentalRelationship = new ParentalRelationship();

        var fPartner = new Partner()
        {
            Address = partner.AddressSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(partner.Address) : null,
            PersonIdentification = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(partner.PersonIdentification),
        };

        if (partner.PartnerIdOrganisationSpecified)
        {
            fPartner.PartnerIdOrganisation = eCH_0011_8_1f.Mapper.ECHtoECHf.GetPartnerIdOrganisation(partner.PartnerIdOrganisation);
        }

        if (partner.PersonIdentificationPartnerSpecified)
        {
            fPartner.PersonIdentificationPartner = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentificationLight(partner.PersonIdentificationPartner);
        }

        return new ParentalRelationship()
        {
            Partner = fPartner,
            RelationshipValidFrom = relationshipValidFrom,
            TypeOfRelationship = (TypeOfRelationship)Enum.Parse(typeof(TypeOfRelationship), typeOfRelationship.ToString()),
            Care = (Care)Enum.Parse(typeof(Care), care.ToString()),
        };
    }

    [JsonProperty("partner")]
    [XmlElement(ElementName = "partner")]
    public Partner Partner
    {
        get { return _partner; }
        set { _partner = value; }
    }

    [JsonProperty("relationshipValidFrom")]
    [XmlElement(DataType = "date", ElementName = "relationshipValidFrom")]
    public DateTime? RelationshipValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RelationshipValidFromSpecified => RelationshipValidFrom.HasValue;

    [JsonProperty("typeOfRelationship")]
    [XmlElement(ElementName = "typeOfRelationship")]
    public TypeOfRelationship? TypeOfRelationship
    {
        get { return _typeOfRelationship; }

        set
        {
            if (value == null)
            {
                _typeOfRelationship = null;
                return;
            }

            if (value != eCH_0021_7_0f.TypeOfRelationship.Mutter &&
                value != eCH_0021_7_0f.TypeOfRelationship.Vater &&
                value != eCH_0021_7_0f.TypeOfRelationship.Pflegevater &&
                value != eCH_0021_7_0f.TypeOfRelationship.Pflegemutter)
            {
                throw new XmlSchemaValidationException(TypeOfRelationshipValidateExceptionMessage);
            }
            _typeOfRelationship = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TypeOfRelationshipSpecified => TypeOfRelationship.HasValue;

    [JsonProperty("care")]
    [XmlElement(ElementName = "care")]
    public Care? Care { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CareSpecified => Care.HasValue;
}
