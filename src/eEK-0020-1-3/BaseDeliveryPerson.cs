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

namespace eEK_0020_1_3;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, aber die Felder armedForcesData, civilDefenseData, fireServiceData entfern.
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020)
/// Loganto - Meldewesen - Ereignisse Message.
/// </summary>
[Serializable]
[JsonObject("baseDeliveryPerson")]
[XmlRoot(ElementName = "baseDeliveryPerson", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class BaseDeliveryPerson
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

    public BaseDeliveryPerson()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
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
    /// <param name="extension"></param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional>.</param>
    /// <param name="politicalRightData">Field is optional.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryPerson Create(PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, List<PlaceOfOriginInfo> placeOfOriginInfos, LockData lockData, DeathData deathData = null, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, PoliticalRightData politicalRightData = null, JobData jobData = null, MaritalRelationship maritalRelationship = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, HealthInsuranceData healthInsuranceData = null, MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData = null, Extension extension = null)
    {
        if (placeOfOriginInfos == null)
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
        if (placeOfOriginInfos != null && !placeOfOriginInfos.Any())
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
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
            PoliticalRightData = politicalRightData,
            PlaceOfOriginInfos = placeOfOriginInfos,
            ResidencePermitData = null,
            LockData = lockData,
            JobData = jobData,
            MaritalRelationship = maritalRelationship,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            HealthInsuranceData = healthInsuranceData,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData,
            Extension = extension
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
    /// <param name="extension"></param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional>.</param>
    /// <param name="politicalRightData">Field is optional.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="maritalRelationship">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="guardianRelationships">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is optional.</param>
    /// <returns></returns>
    public static BaseDeliveryPerson Create(
        PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalInfo maritalInfo, NationalityData nationalityData, ResidencePermitData residencePermitData, LockData lockData, DeathData deathData = null, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, PoliticalRightData politicalRightData = null, JobData jobData = null, MaritalRelationship maritalRelationship = null, List<ParentalRelationship> parentalRelationships = null, List<GuardianRelationship> guardianRelationships = null, HealthInsuranceData healthInsuranceData = null, MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData = null, Extension extension = null)
    {
        if (residencePermitData == null)
        {
            throw new XmlSchemaValidationException(ResidencePermitDataNullValidateExceptionMessage);
        }

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
            PoliticalRightData = politicalRightData,
            PlaceOfOriginInfos = null,
            ResidencePermitData = residencePermitData,
            LockData = lockData,
            JobData = jobData,
            MaritalRelationship = maritalRelationship,
            ParentalRelationships = parentalRelationships,
            GuardianRelationships = guardianRelationships,
            HealthInsuranceData = healthInsuranceData,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData,
            Extension = extension
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

        set
        {
            _lockData = value ?? throw new XmlSchemaValidationException(LockDataNullValidateExceptionMessage);
        }
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

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public Extension Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
