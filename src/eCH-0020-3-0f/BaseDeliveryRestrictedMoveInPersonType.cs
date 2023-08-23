// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0020_3_0f.Mapper;
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
[JsonObject("baseDeliveryRestrictedMoveInPersonType")]
[XmlRoot(ElementName = "baseDeliveryRestrictedMoveInPersonType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class BaseDeliveryRestrictedMoveInPersonType
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

    public BaseDeliveryRestrictedMoveInPersonType()
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
        eCH_0044_4_1.PersonIdentification personIdentification, eCH_0020_3_0.NameInfo nameInfo, eCH_0020_3_0.BirthInfo birthInfo, eCH_0011_8_1.ReligionData religionData, eCH_0020_3_0.MaritalInfo maritalInfo, eCH_0011_8_1.NationalityData nationalityData, List<eCH_0020_3_0.PlaceOfOriginInfo> placeOfOriginInfos, eCH_0021_7_0.LockData lockData, List<eCH_0011_8_1.ContactData> contactDatas = null, List<eCH_0021_7_0.PersonAdditionalData> personAdditionalDatas = null, List<eCH_0021_7_0.PoliticalRightData> politicalRightDatas = null, List<eCH_0021_7_0.JobData> jobDatas = null, List<eCH_0021_7_0.MaritalRelationship> maritalRelationships = null, List<eCH_0021_7_0.ParentalRelationship> parentalRelationships = null, List<eCH_0021_7_0.GuardianRelationship> guardianRelationships = null, List<eCH_0021_7_0.ArmedForcesData> armedForcesDatas = null, List<eCH_0021_7_0.CivilDefenseData> civilDefenseDatas = null, List<eCH_0021_7_0.FireServiceData> fireServiceDatas = null, List<eCH_0021_7_0.HealthInsuranceData> healthInsuranceDatas = null, List<eCH_0021_7_0.MatrimonialInheritanceArrangementData> matrimonialInheritanceArrangementDatas = null)
    {
        var fMoveInPerson = new BaseDeliveryRestrictedMoveInPersonType()
        {
            PersonIdentification = (personIdentification != null) ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(personIdentification) : null,
            NameInfo = (nameInfo != null) ? NameInfo.Create(nameInfo.NameData, nameInfo.NameValidFrom) : null,
            BirthInfo = (birthInfo != null) ? ECHtoECHf.GetBirthInfo(birthInfo) : null,
            ContactDatas = null,
            ReligionData = (religionData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetReligionData(religionData) : null,
            MaritalInfo = (maritalInfo != null) ? ECHtoECHf.GetMaritalInfo(maritalInfo) : null,
            NationalityData = (nationalityData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetNationalityData(nationalityData) : null,
            PersonAdditionalDatas = (personAdditionalDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<PersonAdditionalData>(personAdditionalDatas.Cast<object>().ToList()) : null,
            PlaceOfOriginInfos = null,
            ResidencePermitData = null,
            LockData = (lockData != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetLockData(lockData) : null,
            MaritalRelationships = (maritalRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<MaritalRelationship>(maritalRelationships.Cast<object>().ToList()) : null,
            ParentalRelationships = (parentalRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<ParentalRelationship>(parentalRelationships.Cast<object>().ToList()) : null,
            GuardianRelationships = (guardianRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<GuardianRelationship>(guardianRelationships.Cast<object>().ToList()) : null,
            ArmedForcesDatas = (armedForcesDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<ArmedForcesData>(armedForcesDatas.Cast<object>().ToList()) : null,
            CivilDefenseDatas = (civilDefenseDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<CivilDefenseData>(civilDefenseDatas.Cast<object>().ToList()) : null,
            FireServiceDatas = (fireServiceDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<FireServiceData>(fireServiceDatas.Cast<object>().ToList()) : null,
            HealthInsuranceDatas = (healthInsuranceDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<HealthInsuranceData>(healthInsuranceDatas.Cast<object>().ToList()) : null,
            MatrimonialInheritanceArrangementDatas = (matrimonialInheritanceArrangementDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<MatrimonialInheritanceArrangementData>(matrimonialInheritanceArrangementDatas.Cast<object>().ToList()) : null,
            PoliticalRightDatas = (politicalRightDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<PoliticalRightData>(politicalRightDatas.Cast<object>().ToList()) : null,
        };

        if (contactDatas != null)
        {
            fMoveInPerson.ContactDatas = new List<eCH_0011_8_1f.ContactData>();
            foreach (var data in contactDatas)
            {
                fMoveInPerson.ContactDatas.Add(eCH_0011_8_1f.Mapper.ECHtoECHf.GetContactData(data));
            }
        }

        if (placeOfOriginInfos != null)
        {
            fMoveInPerson.PlaceOfOriginInfos = new List<PlaceOfOriginInfo>();
            foreach (var data in placeOfOriginInfos)
            {
                fMoveInPerson.PlaceOfOriginInfos.Add(ECHtoECHf.GetPlaceOfOriginInfo(data));
            }
        }

        return fMoveInPerson;
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
        eCH_0044_4_1.PersonIdentification personIdentification, eCH_0020_3_0.NameInfo nameInfo, eCH_0020_3_0.BirthInfo birthInfo, eCH_0011_8_1.ReligionData religionData, eCH_0020_3_0.MaritalInfo maritalInfo, eCH_0011_8_1.NationalityData nationalityData, eCH_0011_8_1.ResidencePermitData residencePermitData, eCH_0021_7_0.LockData lockData, eCH_0011_8_1.DeathData deathData = null, List<eCH_0011_8_1.ContactData> contactDatas = null, List<eCH_0021_7_0.PersonAdditionalData> personAdditionalDatas = null, List<eCH_0021_7_0.PoliticalRightData> politicalRightDatas = null, List<eCH_0021_7_0.JobData> jobDatas = null, List<eCH_0021_7_0.MaritalRelationship> maritalRelationships = null, List<eCH_0021_7_0.ParentalRelationship> parentalRelationships = null, List<eCH_0021_7_0.GuardianRelationship> guardianRelationships = null, List<eCH_0021_7_0.ArmedForcesData> armedForcesDatas = null, List<eCH_0021_7_0.CivilDefenseData> civilDefenseDatas = null, List<eCH_0021_7_0.FireServiceData> fireServiceDatas = null, List<eCH_0021_7_0.HealthInsuranceData> healthInsuranceDatas = null, List<eCH_0021_7_0.MatrimonialInheritanceArrangementData> matrimonialInheritanceArrangementDatas = null)
    {
        var fMoveInPerson = new BaseDeliveryRestrictedMoveInPersonType()
        {
            PersonIdentification = (personIdentification != null) ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(personIdentification) : null,
            NameInfo = (nameInfo != null) ? NameInfo.Create(nameInfo.NameData, nameInfo.NameValidFrom) : null,
            BirthInfo = (birthInfo != null) ? ECHtoECHf.GetBirthInfo(birthInfo) : null,
            ContactDatas = null,
            ReligionData = (religionData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetReligionData(religionData) : null,
            MaritalInfo = (maritalInfo != null) ? ECHtoECHf.GetMaritalInfo(maritalInfo) : null,
            NationalityData = (nationalityData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetNationalityData(nationalityData) : null,
            PersonAdditionalDatas = (personAdditionalDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<PersonAdditionalData>(personAdditionalDatas.Cast<object>().ToList()) : null,
            PlaceOfOriginInfos = null,
            ResidencePermitData = (residencePermitData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetResidencePermitData(residencePermitData) : null,
            LockData = (lockData != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetLockData(lockData) : null,
            MaritalRelationships = (maritalRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<MaritalRelationship>(maritalRelationships.Cast<object>().ToList()) : null,
            ParentalRelationships = (parentalRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<ParentalRelationship>(parentalRelationships.Cast<object>().ToList()) : null,
            GuardianRelationships = (guardianRelationships != null) ? ECHtoECHf.ConvertIntoForgivableList<GuardianRelationship>(guardianRelationships.Cast<object>().ToList()) : null,
            ArmedForcesDatas = (armedForcesDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<ArmedForcesData>(armedForcesDatas.Cast<object>().ToList()) : null,
            CivilDefenseDatas = (civilDefenseDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<CivilDefenseData>(civilDefenseDatas.Cast<object>().ToList()) : null,
            FireServiceDatas = (fireServiceDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<FireServiceData>(fireServiceDatas.Cast<object>().ToList()) : null,
            HealthInsuranceDatas = (healthInsuranceDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<HealthInsuranceData>(healthInsuranceDatas.Cast<object>().ToList()) : null,
            MatrimonialInheritanceArrangementDatas = (matrimonialInheritanceArrangementDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<MatrimonialInheritanceArrangementData>(matrimonialInheritanceArrangementDatas.Cast<object>().ToList()) : null,
            PoliticalRightDatas = (politicalRightDatas != null) ? ECHtoECHf.ConvertIntoForgivableList<PoliticalRightData>(politicalRightDatas.Cast<object>().ToList()) : null,
        };

        if (contactDatas != null)
        {
            fMoveInPerson.ContactDatas = new List<eCH_0011_8_1f.ContactData>();
            foreach (var data in contactDatas)
            {
                fMoveInPerson.ContactDatas.Add(eCH_0011_8_1f.Mapper.ECHtoECHf.GetContactData(data));
            }
        }

        return fMoveInPerson;
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
        set { _lockData = value; }
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
