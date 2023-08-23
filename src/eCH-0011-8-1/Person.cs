// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Eine Person, welche in der Schweiz Wohnsitz hat oder nimmt, muss sich bei der zuständigen
/// Gemeinde melden. Dadurch geht sie mit der Gemeinde ein Meldeverhältnis ein.
/// </summary>
[Serializable]
[JsonObject("person")]
[XmlRoot(ElementName = "person", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class Person
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is required";
    private const string NameDataNullValidateExceptionMessage = "NameData is not valid! NameData is required";
    private const string BirthDataNullValidateExceptionMessage = "BirthData is not valid! BirthData is required";
    private const string ReligionDataNullValidateExceptionMessage = "ReligionData is not valid! ReligionData is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";
    private const string NationalityDataNullValidateExceptionMessage = "NationalityData is not valid! NationalityData is required";
    private const string PlaceOfOriginsNullValidateExceptionMessage = "PlaceOfOrigins is not valid! PlaceOfOrigins is required";
    private const string ResidencePermitNullValidateExceptionMessage = "ResidencePermit is not valid! ResidencePermit is required";

    private const string LanguageOfCorrespondanceValidateExceptionMessage = "LanguageOfCorrespondance is not valid! LanguageOfCorrespondance has to be with max lenght 2";

    private PersonIdentification _personIdentification;
    private NameData _nameData;
    private BirthData _birthData;
    private ReligionData _religionData;
    private MaritalData _maritalData;
    private string _languageOfCorrespondance;
    private NationalityData _nationalityData;

    public Person()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameData">Field is required.</param>
    /// <param name="birthData">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="residencePermit">Field is required.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="languageOfCorrespondance">Field is optional.</param>
    /// <param name="restrictedVotingAndElectionRightFederation">Field is optional.</param>
    /// <returns></returns>
    public static Person Create(PersonIdentification personIdentification, NameData nameData, BirthData birthData, ReligionData religionData, MaritalData maritalData, NationalityData nationalityData, ResidencePermitData residencePermit, DeathData deathData = null, ContactData contactData = null, string languageOfCorrespondance = null, bool? restrictedVotingAndElectionRightFederation = null)
    {
        if (residencePermit == null)
        {
            throw new XmlSchemaValidationException(ResidencePermitNullValidateExceptionMessage);
        }
        return new Person()
        {
            PersonIdentification = personIdentification,
            NameData = nameData,
            BirthData = birthData,
            ReligionData = religionData,
            MaritalData = maritalData,
            NationalityData = nationalityData,
            DeathData = deathData,
            ContactData = contactData,
            LanguageOfCorrespondance = languageOfCorrespondance,
            RestrictedVotingAndElectionRightFederation = restrictedVotingAndElectionRightFederation,
            PlaceOfOrigins = null,
            ResidencePermit = residencePermit
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameData">Field is required.</param>
    /// <param name="birthData">Field is required.</param>
    /// <param name="religionData">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="placeOfOrigins">Field is required.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="languageOfCorrespondance">Field is optional.</param>
    /// <param name="restrictedVotingAndElectionRightFederation">Field is optional.</param>
    /// <returns></returns>
    public static Person Create(PersonIdentification personIdentification, NameData nameData, BirthData birthData, ReligionData religionData, MaritalData maritalData, NationalityData nationalityData, List<PlaceOfOrigin> placeOfOrigins, DeathData deathData = null, ContactData contactData = null, string languageOfCorrespondance = null, bool? restrictedVotingAndElectionRightFederation = null)
    {
        if (placeOfOrigins == null || placeOfOrigins.Count == 0)
        {
            throw new XmlSchemaValidationException(PlaceOfOriginsNullValidateExceptionMessage);
        }

        return new Person()
        {
            PersonIdentification = personIdentification,
            NameData = nameData,
            BirthData = birthData,
            ReligionData = religionData,
            MaritalData = maritalData,
            NationalityData = nationalityData,
            DeathData = deathData,
            ContactData = contactData,
            LanguageOfCorrespondance = languageOfCorrespondance,
            RestrictedVotingAndElectionRightFederation = restrictedVotingAndElectionRightFederation,
            PlaceOfOrigins = placeOfOrigins,
            ResidencePermit = null
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification", Order = 1)]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }

        set
        {
            _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData", Order = 2)]
    public NameData NameData
    {
        get { return _nameData; }

        set
        {
            _nameData = value ?? throw new XmlSchemaValidationException(NameDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData", Order = 3)]
    public BirthData BirthData
    {
        get { return _birthData; }

        set
        {
            _birthData = value ?? throw new XmlSchemaValidationException(BirthDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData", Order = 4)]
    public ReligionData ReligionData
    {
        get { return _religionData; }

        set
        {
            _religionData = value ?? throw new XmlSchemaValidationException(ReligionDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData", Order = 5)]
    public MaritalData MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData", Order = 5)]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }

        set
        {
            _nationalityData = value ?? throw new XmlSchemaValidationException(NationalityDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData", Order = 6)]
    public DeathData DeathData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeathDataSpecified => DeathData != null;

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData", Order = 7)]
    public ContactData ContactData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactDataSpecified => ContactData != null;

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance", Order = 8)]
    public string LanguageOfCorrespondance
    {
        get { return _languageOfCorrespondance; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 2)
            {
                throw new XmlSchemaValidationException(LanguageOfCorrespondanceValidateExceptionMessage);
            }
            _languageOfCorrespondance = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LanguageOfCorrespondanceSpecified => string.IsNullOrEmpty(LanguageOfCorrespondance);

    [JsonProperty("restrictedVotingAndElectionRightFederation")]
    [XmlElement(ElementName = "restrictedVotingAndElectionRightFederation", Order = 9)]
    public bool? RestrictedVotingAndElectionRightFederation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RestrictedVotingAndElectionRightFederationSpecified => RestrictedVotingAndElectionRightFederation.HasValue;

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin", Order = 10)]
    public List<PlaceOfOrigin> PlaceOfOrigins { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginsSpecified => PlaceOfOrigins != null && PlaceOfOrigins.Any();

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit", Order = 11)]
    public ResidencePermitData ResidencePermit { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitSpecified => ResidencePermit != null;
}
