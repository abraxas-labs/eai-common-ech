// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Personendaten zu einer Geburt.
/// </summary>
[Serializable]
[JsonObject("baseDeliveryRestrictedMoveInPersonType")]
[XmlRoot(ElementName = "baseDeliveryRestrictedMoveInPersonType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class BaseDeliveryRestrictedMoveInPersonType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is required";
    private const string NameInfoNullValidateExceptionMessage = "NameInfo is not valid! NameInfo is required";
    private const string BirthInfoNullValidateExceptionMessage = "BirthInfo is not valid! BirthInfo is required";
    private const string ReligionDataNullValidateExceptionMessage = "ReligionData is not valid! ReligionData is required";
    private const string MaritalInfoNullValidateExceptionMessage = "MaritalInfo is not valid! MaritalInfo is required";
    private const string NationalityDataNullValidateExceptionMessage = "NationalityData is not valid! NationalityData is required";
    private const string LockDataNullValidateExceptionMessage = "LockData is not valid! LockData is required";
    private const string PlaceOfOriginInfoNullValidateExceptionMessage = "PlaceOfOriginInfo is not valid! PlaceOfOriginInfo is required";
    private const string ResidencePermitDataNullValidateExceptionMessage = "PlaceOfOriginInfos is not valid! PlaceOfOriginInfos is required";

    private PersonIdentification _personIdentification;
    private NameInfo _nameInfo;
    private BirthInfo _birthInfo;
    private ReligionData _religionData;
    private MaritalInfo _maritalData;
    private NationalityData _nationalityData;
    private LockData _lockData;

    public BaseDeliveryRestrictedMoveInPersonType()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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
    /// <param name="contactDatas">Field is optional.</param>
    /// <param name="personAdditionalDatas">Field is optional>.</param>
    /// <param name="politicalRightDatas">Field is optional.</param>
    /// <param name="jobDatas">Field is optional.</param>
    /// <param name="maritalRelationships">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="armedForcesDatas">Field is optional.</param>
    /// <param name="civilDefenseDatas">Field is optional.</param>
    /// <param name="fireServiceDatas">Field is optional.</param>
    /// <param name="healthInsuranceDatas">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementDatas">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryRestrictedMoveInPersonType Create(
        PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, List<PlaceOfOriginInfo> placeOfOriginInfos, LockData lockData, List<ContactData> contactDatas = null, List<PersonAdditionalData> personAdditionalDatas = null, List<PoliticalRightData> politicalRightDatas = null, List<JobData> jobDatas = null, List<MaritalRelationship> maritalRelationships = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, List<ArmedForcesData> armedForcesDatas = null, List<CivilDefenseData> civilDefenseDatas = null, List<FireServiceData> fireServiceDatas = null, List<HealthInsuranceData> healthInsuranceDatas = null, List<MatrimonialInheritanceArrangementData> matrimonialInheritanceArrangementDatas = null)
    {
        if (placeOfOriginInfos == null)
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
        if (placeOfOriginInfos != null && !placeOfOriginInfos.Any())
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
        return new BaseDeliveryRestrictedMoveInPersonType()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalInfo = maritalInfo,
            NationalityData = nationalityData,
            ContactDatas = contactDatas,
            PersonAdditionalDatas = personAdditionalDatas,
            PlaceOfOriginInfos = placeOfOriginInfos,
            ResidencePermitData = null,
            LockData = lockData,
            JobDatas = jobDatas,
            MaritalRelationships = maritalRelationships,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            ArmedForcesDatas = armedForcesDatas,
            CivilDefenseDatas = civilDefenseDatas,
            FireServiceDatas = fireServiceDatas,
            HealthInsuranceDatas = healthInsuranceDatas,
            MatrimonialInheritanceArrangementDatas = matrimonialInheritanceArrangementDatas
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
    /// <param name="contactDatas">Field is optional.</param>
    /// <param name="personAdditionalDatas">Field is optional>.</param>
    /// <param name="politicalRightDatas">Field is optional.</param>
    /// <param name="jobDatas">Field is optional.</param>
    /// <param name="maritalRelationships">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="armedForcesDatas">Field is optional.</param>
    /// <param name="civilDefenseDatas">Field is optional.</param>
    /// <param name="fireServiceDatas">Field is optional.</param>
    /// <param name="healthInsuranceDatas">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementDatas">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryRestrictedMoveInPersonType Create(
        PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, ResidencePermitData residencePermitData, LockData lockData, DeathData deathData = null, List<ContactData> contactDatas = null, List<PersonAdditionalData> personAdditionalDatas = null, List<PoliticalRightData> politicalRightDatas = null, List<JobData> jobDatas = null, List<MaritalRelationship> maritalRelationships = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, List<ArmedForcesData> armedForcesDatas = null, List<CivilDefenseData> civilDefenseDatas = null, List<FireServiceData> fireServiceDatas = null, List<HealthInsuranceData> healthInsuranceDatas = null, List<MatrimonialInheritanceArrangementData> matrimonialInheritanceArrangementDatas = null)
    {
        if (residencePermitData == null)
        {
            throw new XmlSchemaValidationException(ResidencePermitDataNullValidateExceptionMessage);
        }

        return new BaseDeliveryRestrictedMoveInPersonType()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalInfo = maritalInfo,
            NationalityData = nationalityData,
            ContactDatas = contactDatas,
            PersonAdditionalDatas = personAdditionalDatas,
            PlaceOfOriginInfos = null,
            ResidencePermitData = residencePermitData,
            LockData = lockData,
            JobDatas = jobDatas,
            MaritalRelationships = maritalRelationships,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            ArmedForcesDatas = armedForcesDatas,
            CivilDefenseDatas = civilDefenseDatas,
            FireServiceDatas = fireServiceDatas,
            HealthInsuranceDatas = healthInsuranceDatas,
            MatrimonialInheritanceArrangementDatas = matrimonialInheritanceArrangementDatas
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }

        set
        {
            _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nameInfo")]
    [XmlElement(ElementName = "nameInfo")]
    public NameInfo NameInfo
    {
        get { return _nameInfo; }

        set
        {
            _nameInfo = value ?? throw new XmlSchemaValidationException(NameInfoNullValidateExceptionMessage);
        }
    }

    [JsonProperty("birthInfo")]
    [XmlElement(ElementName = "birthInfo")]
    public BirthInfo BirthInfo
    {
        get { return _birthInfo; }

        set
        {
            _birthInfo = value ?? throw new XmlSchemaValidationException(BirthInfoNullValidateExceptionMessage);
        }
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionData ReligionData
    {
        get { return _religionData; }

        set
        {
            _religionData = value ?? throw new XmlSchemaValidationException(ReligionDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalInfo")]
    [XmlElement(ElementName = "maritalInfo")]
    public MaritalInfo MaritalInfo
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalInfoNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }

        set
        {
            _nationalityData = value ?? throw new XmlSchemaValidationException(NationalityDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData")]
    public List<ContactData> ContactDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactDatasSpecified => ContactDatas != null && PersonAdditionalDatas.Any();

    [JsonProperty("personAdditionalData")]
    [XmlElement(ElementName = "personAdditionalData")]
    public List<PersonAdditionalData> PersonAdditionalDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonAdditionalDatasSpecified => PersonAdditionalDatas != null && PersonAdditionalDatas.Any();

    [JsonProperty("politicalRightData")]
    [XmlElement(ElementName = "politicalRightData")]
    public List<PoliticalRightData> PoliticalRightDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PoliticalRightDatasSpecified => PoliticalRightDatas != null && PoliticalRightDatas.Any();

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

        set
        {
            _lockData = value ?? throw new XmlSchemaValidationException(LockDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData")]
    public List<JobData> JobDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDatasSpecified => JobDatas != null && JobDatas.Any();

    [JsonProperty("maritalRelationship")]
    [XmlElement(ElementName = "maritalRelationship")]
    public List<MaritalRelationship> MaritalRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalRelationshipsSpecified => MaritalRelationships != null && MaritalRelationships.Any();

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
    public List<ArmedForcesData> ArmedForcesDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesDatasSpecified => ArmedForcesDatas != null && ArmedForcesDatas.Any();

    [JsonProperty("civilDefenseData")]
    [XmlElement(ElementName = "civilDefenseData")]
    public List<CivilDefenseData> CivilDefenseDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseDatasSpecified => CivilDefenseDatas != null && CivilDefenseDatas.Any();

    [JsonProperty("fireServiceData")]
    [XmlElement(ElementName = "fireServiceData")]
    public List<FireServiceData> FireServiceDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceDatasSpecified => FireServiceDatas != null && FireServiceDatas.Any();

    [JsonProperty("healthInsuranceData")]
    [XmlElement(ElementName = "healthInsuranceData")]
    public List<HealthInsuranceData> HealthInsuranceDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceDatasSpecified => HealthInsuranceDatas != null && HealthInsuranceDatas.Any();

    [JsonProperty("matrimonialInheritanceArrangementData")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangementData")]
    public List<MatrimonialInheritanceArrangementData> MatrimonialInheritanceArrangementDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MatrimonialInheritanceArrangementDatasSpecified => MatrimonialInheritanceArrangementDatas != null && MatrimonialInheritanceArrangementDatas.Any();
}
