// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
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
[JsonObject("personAddonType")]
[XmlRoot(ElementName = "personAddonType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class PersonAddonType : FieldValueChecker<PersonAddonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private BirthDataType _birthData;
    private DeathDataType _deathData;
    private NameDataType _nameData;
    private MaritalDataType _maritalData;
    private ReligionDataType _religionData;
    private NationalityDataType _nationalityData;
    private GeneralDataType _generalDataType;
    private ResidencePermitDataType _residencePermitData;
    private List<RelationshipType> _relationship;
    private List<PlaceOfOriginAddonType> _placeOfOriginAddon;
    private string _jobTitle;
    private string _kindOfEmployment;
    private OccupationType _occupationType;
    private ArmedForcesType _armedForces;
    private CivilDefenseDataType _civilDefenseData;
    private FireServiceType _fireService;
    private HealthInsuranceType _healthInsurance;
    private MatrimonialInheritanceArrangementDataType _matrimonialInheritanceArrangementData;

    public PersonAddonType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="birthData">Field is required.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="nameData">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="generalDataType">Field is required.</param>
    /// <param name="residencePermitData">Field is optional.</param>
    /// <param name="relationship">Field is optional.</param>
    /// <param name="placeOfOriginAddon">Field is optional.</param>
    /// <param name="jobTitle">Field is optional.</param>
    /// <param name="kindOfEmployment">Field is required.</param>
    /// <param name="occupationType">Field is optional.</param>
    /// <param name="armedForces">Field is optional.</param>
    /// <param name="civilDefenseData">Field is optional.</param>
    /// <param name="fireService">Field is optional.</param>
    /// <param name="healthInsurance">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is optional.</param>
    /// <returns>PersonAddonType.</returns>
    public static PersonAddonType Create(PersonIdentification personIdentification, BirthDataType birthData, DeathDataType deathData, NameDataType nameData,
        MaritalDataType maritalData, ReligionDataType religionData, NationalityDataType nationalityData, GeneralDataType generalDataType, ResidencePermitDataType residencePermitData,
        List<RelationshipType> relationship, List<PlaceOfOriginAddonType> placeOfOriginAddon, string jobTitle, string kindOfEmployment, OccupationType occupationType, ArmedForcesType armedForces,
        CivilDefenseDataType civilDefenseData, FireServiceType fireService, HealthInsuranceType healthInsurance, MatrimonialInheritanceArrangementDataType matrimonialInheritanceArrangementData)
    {
        return new PersonAddonType
        {
            PersonIdentification = personIdentification,
            BirthData = birthData,
            DeathData = deathData,
            NameData = nameData,
            MaritalData = maritalData,
            ReligionData = religionData,
            NationalityData = nationalityData,
            GeneralDataType = generalDataType,
            ResidencePermitData = residencePermitData,
            Relationship = relationship,
            PlaceOfOriginAddon = placeOfOriginAddon,
            JobTitle = jobTitle,
            KindOfEmployment = kindOfEmployment,
            OccupationType = occupationType,
            ArmedForces = armedForces,
            CivilDefenseData = civilDefenseData,
            FireService = fireService,
            HealthInsurance = healthInsurance,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData
        };
    }

    [FieldRequired]
    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get => _personIdentification;
        set => CheckAndSetValue(ref _personIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthDataType BirthData
    {
        get => _birthData;
        set => CheckAndSetValue(ref _birthData, value);
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathDataType DeathData
    {
        get => _deathData;
        set => CheckAndSetValue(ref _deathData, value);
    }

    [FieldRequired]
    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData")]
    public NameDataType NameData
    {
        get => _nameData;
        set => CheckAndSetValue(ref _nameData, value);
    }

    [FieldRequired]
    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataType MaritalData
    {
        get => _maritalData;
        set => CheckAndSetValue(ref _maritalData, value);
    }

    [FieldRequired]
    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionDataType ReligionData
    {
        get => _religionData;
        set => CheckAndSetValue(ref _religionData, value);
    }

    [FieldRequired]
    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityDataType NationalityData
    {
        get => _nationalityData;
        set => CheckAndSetValue(ref _nationalityData, value);
    }

    [FieldRequired]
    [JsonProperty("generalData")]
    [XmlElement(ElementName = "generalData")]
    public GeneralDataType GeneralDataType
    {
        get => _generalDataType;
        set => CheckAndSetValue(ref _generalDataType, value);
    }

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitDataType ResidencePermitData
    {
        get => _residencePermitData;
        set => CheckAndSetValue(ref _residencePermitData, value);
    }

    [JsonProperty("relationship")]
    [XmlElement(ElementName = "relationship")]
    public List<RelationshipType> Relationship
    {
        get => _relationship;
        set => CheckAndSetValue(ref _relationship, value);
    }

    [JsonProperty("originAddon")]
    [XmlElement(ElementName = "originAddon")]
    public List<PlaceOfOriginAddonType> PlaceOfOriginAddon
    {
        get => _placeOfOriginAddon;
        set => CheckAndSetValue(ref _placeOfOriginAddon, value);
    }

    [FieldMaxLength(100)]
    [JsonProperty("jobTitle")]
    [XmlElement(ElementName = "jobTitle")]
    public string JobTitle
    {
        get => _jobTitle;
        set => CheckAndSetValue(ref _jobTitle, value);
    }

    [FieldRequired]
    [JsonProperty("kindOfEmployment")]
    [XmlElement(ElementName = "kindOfEmployment")]
    public string KindOfEmployment
    {
        get => _kindOfEmployment;
        set => CheckAndSetValue(ref _kindOfEmployment, value);
    }

    [JsonProperty("occupation")]
    [XmlElement(ElementName = "occupation")]
    public OccupationType OccupationType
    {
        get => _occupationType;
        set => CheckAndSetValue(ref _occupationType, value);
    }

    [JsonProperty("armedForces")]
    [XmlElement(ElementName = "armedForces")]
    public ArmedForcesType ArmedForces
    {
        get => _armedForces;
        set => CheckAndSetValue(ref _armedForces, value);
    }

    [JsonProperty("civilDefense")]
    [XmlElement(ElementName = "civilDefense")]
    public CivilDefenseDataType CivilDefenseData
    {
        get => _civilDefenseData;
        set => CheckAndSetValue(ref _civilDefenseData, value);
    }

    [JsonProperty("fireService")]
    [XmlElement(ElementName = "fireService")]
    public FireServiceType FireService
    {
        get => _fireService;
        set => CheckAndSetValue(ref _fireService, value);
    }

    [JsonProperty("healthInsurance")]
    [XmlElement(ElementName = "healthInsurance")]
    public HealthInsuranceType HealthInsurance
    {
        get => _healthInsurance;
        set => CheckAndSetValue(ref _healthInsurance, value);
    }

    [JsonProperty("matrimonialInheritanceArrangement")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangement")]
    public MatrimonialInheritanceArrangementDataType MatrimonialInheritanceArrangementData
    {
        get => _matrimonialInheritanceArrangementData;
        set => CheckAndSetValue(ref _matrimonialInheritanceArrangementData, value);
    }
}
