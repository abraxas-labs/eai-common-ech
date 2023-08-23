// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Personendaten zu einer Geburt.
/// </summary>
[Serializable]
[JsonObject("baseDeliveryPerson")]
[XmlRoot(ElementName = "baseDeliveryPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class BaseDeliveryPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private NameInfo _nameInfo;
    private BirthInfo _birthInfo;
    private ReligionData _religionData;
    private MaritalInfo _maritalData;
    private NationalityData _nationalityData;
    private LockData _lockData;

    public BaseDeliveryPerson()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    ///
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="birthInfo">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalInfo">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is required.</param>
    /// <param name="lockData">Field is required.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional.</param>
    /// <param name="politicalRightData">Field is optional.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="armedForcesData">Field is optional.</param>
    /// <param name="civilDefenseData">Field is optional.</param>
    /// <param name="fireServiceData">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryPerson Create(
        PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, List<PlaceOfOriginInfo> placeOfOriginInfos, LockData lockData, DeathData deathData = null, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, PoliticalRightData politicalRightData = null, JobData jobData = null, MaritalRelationship maritalRelationship = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, ArmedForcesData armedForcesData = null, CivilDefenseData civilDefenseData = null, FireServiceData fireServiceData = null, HealthInsuranceData healthInsuranceData = null, MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData = null)
    {
        return new BaseDeliveryPerson()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalInfo = maritalInfo,
            NationalityData = nationalityData,
            DeathData = deathData,
            ContactData = contactData,
            PersonAdditionalData = personAdditionalData,
            PlaceOfOriginInfos = placeOfOriginInfos,
            ResidencePermitData = null,
            LockData = lockData,
            JobData = jobData,
            MaritalRelationship = maritalRelationship,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            ArmedForcesData = armedForcesData,
            CivilDefenseData = civilDefenseData,
            FireServiceData = fireServiceData,
            HealthInsuranceData = healthInsuranceData,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData
        };
    }

    /// <summary>
    ///
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="birthInfo">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalInfo">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="residencePermitData">Field is required.</param>
    /// <param name="lockData">Field is required.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional.</param>
    /// <param name="politicalRightData">Field is optional.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="armedForcesData">Field is optional.</param>
    /// <param name="civilDefenseData">Field is optional.</param>
    /// <param name="fireServiceData">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryPerson Create(
        PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, ResidencePermitData residencePermitData, LockData lockData, DeathData deathData = null, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, PoliticalRightData politicalRightData = null, JobData jobData = null, MaritalRelationship maritalRelationship = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, ArmedForcesData armedForcesData = null, CivilDefenseData civilDefenseData = null, FireServiceData fireServiceData = null, HealthInsuranceData healthInsuranceData = null, MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData = null)
    {
        return new BaseDeliveryPerson()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalInfo = maritalInfo,
            NationalityData = nationalityData,
            DeathData = deathData,
            ContactData = contactData,
            PersonAdditionalData = personAdditionalData,
            PlaceOfOriginInfos = null,
            ResidencePermitData = residencePermitData,
            LockData = lockData,
            JobData = jobData,
            MaritalRelationship = maritalRelationship,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            ArmedForcesData = armedForcesData,
            CivilDefenseData = civilDefenseData,
            FireServiceData = fireServiceData,
            HealthInsuranceData = healthInsuranceData,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }
        set { _personIdentification = value; }
    }

    [JsonProperty("nameInfo")]
    [XmlElement(ElementName = "nameInfo")]
    public NameInfo NameInfo
    {
        get { return _nameInfo; }
        set { _nameInfo = value; }
    }

    [JsonProperty("birthInfo")]
    [XmlElement(ElementName = "birthInfo")]
    public BirthInfo BirthInfo
    {
        get { return _birthInfo; }
        set { _birthInfo = value; }
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionData ReligionData
    {
        get { return _religionData; }
        set { _religionData = value; }
    }

    [JsonProperty("maritalInfo")]
    [XmlElement(ElementName = "maritalInfo")]
    public MaritalInfo MaritalInfo
    {
        get { return _maritalData; }
        set { _maritalData = value; }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }
        set { _nationalityData = value; }
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathData DeathData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeathDataSpecified => DeathData != null;

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData")]
    public ContactData ContactData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactDataSpecified => ContactData != null;

    [JsonProperty("personAdditionalData")]
    [XmlElement(ElementName = "personAdditionalData")]
    public PersonAdditionalData PersonAdditionalData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonAdditionalDataSpecified => PersonAdditionalData != null;

    [JsonProperty("politicalRightData")]
    [XmlElement(ElementName = "politicalRightData")]
    public PoliticalRightData PoliticalRightData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PoliticalRightDataSpecified => PoliticalRightData != null;

    [JsonProperty("placeOfOriginInfo")]
    [XmlElement(ElementName = "placeOfOriginInfo")]
    public List<PlaceOfOriginInfo> PlaceOfOriginInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginInfosSpecified => PlaceOfOriginInfos != null && PlaceOfOriginInfos.Any();

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitData ResidencePermitData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitDataSpecified => ResidencePermitData != null;

    [JsonProperty("lockData")]
    [XmlElement(ElementName = "lockData")]
    public LockData LockData
    {
        get { return _lockData; }
        set { _lockData = value; }
    }

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData")]
    public JobData JobData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDataSpecified => JobData != null;

    [JsonProperty("maritalRelationship")]
    [XmlElement(ElementName = "maritalRelationship")]
    public MaritalRelationship MaritalRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalRelationshipSpecified => MaritalRelationship != null;

    [JsonProperty("parentalRelationship")]
    [XmlElement(ElementName = "parentalRelationship")]
    public List<ParentalRelationship> ParentalRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ParentalRelationshipsSpecified => ParentalRelationships != null && ParentalRelationships.Any();

    [JsonProperty("guardianRelationship")]
    [XmlElement(ElementName = "guardianRelationship")]
    public List<GuardianRelationship> GuardianRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianRelationshipsSpecified => GuardianRelationships != null && GuardianRelationships.Any();

    [JsonProperty("armedForcesData")]
    [XmlElement(ElementName = "armedForcesData")]
    public ArmedForcesData ArmedForcesData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesDataSpecified => ArmedForcesData != null;

    [JsonProperty("civilDefenseData")]
    [XmlElement(ElementName = "civilDefenseData")]
    public CivilDefenseData CivilDefenseData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseDataSpecified => CivilDefenseData != null;

    [JsonProperty("fireServiceData")]
    [XmlElement(ElementName = "fireServiceData")]
    public FireServiceData FireServiceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceDataSpecified => FireServiceData != null;

    [JsonProperty("healthInsuranceData")]
    [XmlElement(ElementName = "healthInsuranceData")]
    public HealthInsuranceData HealthInsuranceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceDataSpecified => HealthInsuranceData != null;

    [JsonProperty("matrimonialInheritanceArrangementData")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangementData")]
    public MatrimonialInheritanceArrangementData MatrimonialInheritanceArrangementData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MatrimonialInheritanceArrangementDataSpecified => MatrimonialInheritanceArrangementData != null;
}
