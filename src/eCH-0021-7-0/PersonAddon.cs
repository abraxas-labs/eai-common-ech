// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Zusätzliche Personendaten.
/// </summary>
[Serializable]
[JsonObject("personAddon")]
[XmlRoot(ElementName = "personAddon", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class PersonAddon
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification InsuranceName not valid! PersonIdentification is required";

    private PersonIdentification _personidentification;

    public PersonAddon()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="personAdditionalData">Fiels is optional.</param>
    /// <param name="politicalRightData">Fiels is optional.</param>
    /// <param name="birthAddonData">Fiels is optional.</param>
    /// <param name="lockData">Fiels is optional.</param>
    /// <param name="placeOfOriginAddonDatas">Fiels is optional.</param>
    /// <param name="jobData">Fiels is optional.</param>
    /// <param name="maritalRelationship">Fiels is optional.</param>
    /// <param name="parentalRelationships">Fiels is optional.</param>
    /// <param name="guardianRelationships">Fiels is optional.</param>
    /// <param name="armedForcesData">Fiels is optional.</param>
    /// <param name="civilDefenseData">Fiels is optional.</param>
    /// <param name="fireServiceData">Fiels is optional.</param>
    /// <param name="healthInsuranceData">Fiels is optional.</param>
    /// <param name="matrimonialInheritanceArrangementData">Fiels is optional.</param>
    /// <returns>PersonAddon.</returns>
    public static PersonAddon Create(PersonIdentification personIdentification,
        PersonAdditionalData personAdditionalData = null, PoliticalRightData politicalRightData = null,
        BirthAddonData birthAddonData = null, LockData lockData = null,
        List<PlaceOfOriginAddonData> placeOfOriginAddonDatas = null, JobData jobData = null,
        MaritalRelationship maritalRelationship = null, List<ParentalRelationship> parentalRelationships = null,
        List<GuardianRelationship> guardianRelationships = null, ArmedForcesData armedForcesData = null,
        CivilDefenseData civilDefenseData = null, FireServiceData fireServiceData = null,
        HealthInsuranceData healthInsuranceData = null,
        MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData = null)
    {
        return new PersonAddon()
        {
            PersonIdentification = personIdentification,
            PersonAdditionalData = personAdditionalData,
            PoliticalRightData = politicalRightData,
            BirthAddonData = birthAddonData,
            LockData = lockData,
            PlaceOfOriginAddonDatas = placeOfOriginAddonDatas,
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

    [JsonProperty("personidentification")]
    [XmlElement(ElementName = "personidentification", Order = 1)]
    public PersonIdentification PersonIdentification
    {
        get { return _personidentification; }

        set
        {
            _personidentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("personAdditionalData")]
    [XmlElement(ElementName = "personAdditionalData", Order = 2)]
    public PersonAdditionalData PersonAdditionalData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonAdditionalDataSpecified => PersonAdditionalData != null;

    [JsonProperty("politicalRightData")]
    [XmlElement(ElementName = "politicalRightData", Order = 3)]
    public PoliticalRightData PoliticalRightData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PoliticalRightDataSpecified => PoliticalRightData != null;

    [JsonProperty("birthAddonData")]
    [XmlElement(ElementName = "birthAddonData", Order = 4)]
    public BirthAddonData BirthAddonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BirthAddonDataSpecified => BirthAddonData != null;

    [JsonProperty("lockData")]
    [XmlElement(ElementName = "lockData", Order = 5)]
    public LockData LockData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool LockDataSpecified => LockData != null;

    [JsonProperty("placeOfOriginAddonData")]
    [XmlElement(ElementName = "placeOfOriginAddonData", Order = 6)]
    public List<PlaceOfOriginAddonData> PlaceOfOriginAddonDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginAddonDatasSpecified => PlaceOfOriginAddonDatas != null && PlaceOfOriginAddonDatas.Any();

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData", Order = 7)]
    public JobData JobData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDataSpecified => JobData != null;

    [JsonProperty("maritalRelationship")]
    [XmlElement(ElementName = "maritalRelationship", Order = 8)]
    public MaritalRelationship MaritalRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalRelationshipSpecified => MaritalRelationship != null;

    [JsonProperty("parentalRelationship")]
    [XmlElement(ElementName = "parentalRelationship", Order = 9)]
    public List<ParentalRelationship> ParentalRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ParentalRelationshipsSpecified => ParentalRelationships != null && ParentalRelationships.Any();

    [JsonProperty("guardianRelationship")]
    [XmlElement(ElementName = "guardianRelationship", Order = 10)]
    public List<GuardianRelationship> GuardianRelationships { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianRelationshipsSpecified => GuardianRelationships != null && GuardianRelationships.Any();

    [JsonProperty("armedForcesData")]
    [XmlElement(ElementName = "armedForcesData", Order = 11)]
    public ArmedForcesData ArmedForcesData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesDataSpecified => ArmedForcesData != null;

    [JsonProperty("civilDefenseData")]
    [XmlElement(ElementName = "civilDefenseData", Order = 12)]
    public CivilDefenseData CivilDefenseData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseDataSpecified => CivilDefenseData != null;

    [JsonProperty("fireServiceData")]
    [XmlElement(ElementName = "fireServiceData", Order = 13)]
    public FireServiceData FireServiceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceDataSpecified => FireServiceData != null;

    [JsonProperty("healthInsuranceData")]
    [XmlElement(ElementName = "healthInsuranceData", Order = 14)]
    public HealthInsuranceData HealthInsuranceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceDataSpecified => HealthInsuranceData != null;

    [JsonProperty("matrimonialInheritanceArrangementData")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangementData", Order = 15)]
    public MatrimonialInheritanceArrangementData MatrimonialInheritanceArrangementData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MatrimonialInheritanceArrangementDataSpecified => MatrimonialInheritanceArrangementData != null;
}
