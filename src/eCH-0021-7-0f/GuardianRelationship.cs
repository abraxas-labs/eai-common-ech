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
/// Beziehung im Bereich Kindes- und Erwachsenenschutz (KESR).
/// </summary>
[Serializable]
[JsonObject("guardianRelationship")]
[XmlRoot(ElementName = "guardianRelationship", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class GuardianRelationship
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private TypeOfRelationship? _typeOfRelationship;
    private string _guardianRelationshipId;
    private GuardianMeasureInfo _guardianMeasureInfo;

    private const string GuardianRelationshipIdValidateExceptionMessage = "GuardianRelationshipId is not valid! GuardianRelationshipId has to be maximal lenght of 36";
    private const string TypeOfRelationshipValidateExceptionMessage = "TypeOfRelationship is not valid! TypeOfRelationship has to be 7, 8, 9 or 10";

    public GuardianRelationship()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="guardianRelationshipId">Field is required.</param>
    /// <param name="typeOfRelationship">Field is required.</param>
    /// <param name="guardianMeasureInfo">Field is required.</param>
    /// <param name="partner">Field is optional.</param>
    /// <param name="care">Field is optional.</param>
    /// <returns>GuardianRelationship.</returns>
    public static GuardianRelationship Create(string guardianRelationshipId, TypeOfRelationship typeOfRelationship, GuardianMeasureInfo guardianMeasureInfo, Partner partner = null, Care? care = null)
    {
        return new GuardianRelationship()
        {
            GuardianRelationshipId = guardianRelationshipId,
            Partner = partner,
            TypeOfRelationship = typeOfRelationship,
            GuardianMeasureInfo = guardianMeasureInfo,
            Care = care
        };
    }

    [JsonProperty("guardianRelationshipId")]
    [XmlElement(ElementName = "guardianRelationshipId")]
    public string GuardianRelationshipId
    {
        get { return _guardianRelationshipId; }

        set
        {
            if (value != null && value.Length > 36)
            {
                throw new XmlSchemaValidationException(GuardianRelationshipIdValidateExceptionMessage);
            }
            _guardianRelationshipId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianRelationshipIdSpecified => !string.IsNullOrWhiteSpace(GuardianRelationshipId);

    [JsonProperty("partner")]
    [XmlElement(ElementName = "partner")]
    public Partner Partner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnerSpecified => Partner != null;

    [JsonProperty("typeOfRelationship")]
    [XmlElement(ElementName = "typeOfRelationship")]
    public TypeOfRelationship? TypeOfRelationship
    {
        get { return _typeOfRelationship; }

        set
        {
            if (value == null)
            {
                _typeOfRelationship = value;
                return;
            }

            if (value != eCH_0021_7_0f.TypeOfRelationship.Beistand &&
                value != eCH_0021_7_0f.TypeOfRelationship.Beirat &&
                value != eCH_0021_7_0f.TypeOfRelationship.Vormund &&
                value != eCH_0021_7_0f.TypeOfRelationship.Vorsorgebeauftragter)
            {
                throw new XmlSchemaValidationException(TypeOfRelationshipValidateExceptionMessage);
            }
            _typeOfRelationship = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TypeOfRelationshipSpecified => TypeOfRelationship.HasValue;

    [JsonProperty("guardianMeasureInfo")]
    [XmlElement(ElementName = "guardianMeasureInfo")]
    public GuardianMeasureInfo GuardianMeasureInfo
    {
        get { return _guardianMeasureInfo; }
        set { _guardianMeasureInfo = value; }
    }

    [JsonProperty("care")]
    [XmlElement(ElementName = "care")]
    public Care? Care { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CareSpecified => Care.HasValue;
}
