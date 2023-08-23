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
[JsonObject("birthPerson")]
[XmlRoot(ElementName = "birthPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class BirthPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private NameInfo _nameInfo;
    private BirthInfo _birthInfo;
    private ReligionData _religionData;
    private MaritalData _maritalData;
    private NationalityData _nationalityData;
    private LockData _lockData;

    public BirthPerson()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="birthInfo">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is required.</param>
    /// <param name="lockData">Field is required.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <returns>BirthPerson.</returns>
    public static BirthPerson Create(PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalData maritalData, NationalityData nationalityData, List<PlaceOfOriginInfo> placeOfOriginInfos, LockData lockData, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, List<ParentalRelationship> parentalRelationships = null, HealthInsuranceData healthInsuranceData = null)
    {
        return new BirthPerson()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalData = maritalData,
            NationalityData = nationalityData,
            ContactData = contactData,
            PersonAdditionalData = personAdditionalData,
            PlaceOfOriginInfos = placeOfOriginInfos,
            ResidencePermitData = null,
            LockData = lockData,
            ParentalRelationships = parentalRelationships,
            HealthInsuranceData = healthInsuranceData
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="birthInfo">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="residencePermitData">Field is required.</param>
    /// <param name="lockData">Field is required.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="personAdditionalData">Field is optional.</param>
    /// <param name="parentalRelationships">Field is optional.</param>
    /// <param name="healthInsuranceData">Field is optional.</param>
    /// <returns>BirthPerson.</returns>
    public static BirthPerson Create(PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, ReligionData religionData, MaritalData maritalData, NationalityData nationalityData, ResidencePermitData residencePermitData, LockData lockData, ContactData contactData = null, PersonAdditionalData personAdditionalData = null, List<ParentalRelationship> parentalRelationships = null, HealthInsuranceData healthInsuranceData = null)
    {
        return new BirthPerson()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            ReligionData = religionData,
            MaritalData = maritalData,
            NationalityData = nationalityData,
            ContactData = contactData,
            PersonAdditionalData = personAdditionalData,
            PlaceOfOriginInfos = null,
            ResidencePermitData = residencePermitData,
            LockData = lockData,
            ParentalRelationships = parentalRelationships,
            HealthInsuranceData = healthInsuranceData
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

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalData MaritalData
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

    [JsonProperty("parentalRelationship")]
    [XmlElement(ElementName = "parentalRelationship")]
    public List<ParentalRelationship> ParentalRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ParentalRelationshipsSpecified => ParentalRelationships != null && ParentalRelationships.Any();

    [JsonProperty("healthInsuranceData")]
    [XmlElement(ElementName = "healthInsuranceData")]
    public HealthInsuranceData HealthInsuranceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceDataSpecified => HealthInsuranceData != null;
}
