// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_0;
using eCH_0011_7_0;
using eCH_0044_3_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("relationshipType")]
[XmlRoot(ElementName = "relationshipType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class RelationshipType : FieldValueChecker<RelationshipType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private TypeOfRelationshipType _typeOfRelationship;
    private List<BasedOnLawType> _basedOnLaw;
    private string _basedOnLawAddOn;
    private YesNoType _care;
    private PartnerType _partner;
    private DateTime? _relationshipValidFrom;

    public RelationshipType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="basedOnLaw">Field is optional.</param>
    /// <param name="basedOnLawAddOn">Field is optional.</param>
    /// <param name="care">Field is optional.</param>
    /// <param name="relationshipValidFrom">Field is optional.</param>
    /// <param name="personIdentification">Field is optional.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>RelationshipType.</returns>
    public static RelationshipType Create(TypeOfRelationshipType typeOfRelationship, List<BasedOnLawType> basedOnLaw, string basedOnLawAddOn, YesNoType care,
        DateTime? relationshipValidFrom, PersonIdentification personIdentification, MailAddress address = null)
    {
        return new RelationshipType
        {
            TypeOfRelationship = typeOfRelationship,
            BasedOnLaw = basedOnLaw,
            BasedOnLawAddOn = basedOnLawAddOn,
            Care = care,
            Partner = PartnerType.Create(personIdentification, address),
            RelationshipValidFrom = relationshipValidFrom
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="basedOnLaw">Field is optional.</param>
    /// <param name="basedOnLawAddOn">Field is optional.</param>
    /// <param name="care">Field is optional.</param>
    /// <param name="relationshipValidFrom">Field is optional.</param>
    /// <param name="personIdentificationLight">Field is optional.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>RelationshipType.</returns>
    public static RelationshipType Create(TypeOfRelationshipType typeOfRelationship, List<BasedOnLawType> basedOnLaw, string basedOnLawAddOn, YesNoType care,
        DateTime? relationshipValidFrom, PersonIdentificationLight personIdentificationLight, MailAddress address = null)
    {
        return new RelationshipType
        {
            TypeOfRelationship = typeOfRelationship,
            BasedOnLaw = basedOnLaw,
            BasedOnLawAddOn = basedOnLawAddOn,
            Care = care,
            Partner = PartnerType.Create(personIdentificationLight, address),
            RelationshipValidFrom = relationshipValidFrom
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="basedOnLaw">Field is optional.</param>
    /// <param name="basedOnLawAddOn">Field is optional.</param>
    /// <param name="care">Field is optional.</param>
    /// <param name="relationshipValidFrom">Field is optional.</param>
    /// <param name="partnerIdOrganisation">Field is optional.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>RelationshipType.</returns>
    public static RelationshipType Create(TypeOfRelationshipType typeOfRelationship, List<BasedOnLawType> basedOnLaw, string basedOnLawAddOn, YesNoType care,
        DateTime? relationshipValidFrom, PartnerIdOrganisationType partnerIdOrganisation, MailAddress address = null)
    {
        return new RelationshipType
        {
            TypeOfRelationship = typeOfRelationship,
            BasedOnLaw = basedOnLaw,
            BasedOnLawAddOn = basedOnLawAddOn,
            Care = care,
            Partner = PartnerType.Create(partnerIdOrganisation, address),
            RelationshipValidFrom = relationshipValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("typeOfRelationship")]
    [XmlElement(ElementName = "typeOfRelationship")]
    public TypeOfRelationshipType TypeOfRelationship
    {
        get => _typeOfRelationship;
        set => CheckAndSetValue(ref _typeOfRelationship, value);
    }

    [JsonProperty("basedOnLaw")]
    [XmlElement(ElementName = "basedOnLaw")]
    public List<BasedOnLawType> BasedOnLaw
    {
        get => _basedOnLaw;
        set => CheckAndSetValue(ref _basedOnLaw, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("basedOnLawAddOn")]
    [XmlElement(ElementName = "basedOnLawAddOn")]
    public string BasedOnLawAddOn
    {
        get => _basedOnLawAddOn;
        set => CheckAndSetValue(ref _basedOnLawAddOn, value);
    }

    [JsonProperty("care")]
    [XmlElement(ElementName = "care")]
    public YesNoType Care
    {
        get => _care;
        set => CheckAndSetValue(ref _care, value);
    }

    [JsonProperty("partner")]
    [XmlElement(ElementName = "partner")]
    public PartnerType Partner
    {
        get => _partner;
        set => CheckAndSetValue(ref _partner, value);
    }

    [JsonProperty("relationshipValidFrom")]
    [XmlElement(ElementName = "relationshipValidFrom")]
    public DateTime? RelationshipValidFrom
    {
        get => _relationshipValidFrom;
        set => CheckAndSetValue(ref _relationshipValidFrom, value);
    }
}
