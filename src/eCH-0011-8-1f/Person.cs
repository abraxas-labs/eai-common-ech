// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Eine Person, welche in der Schweiz Wohnsitz hat oder nimmt, muss sich bei der zuständigen
/// Gemeinde melden. Dadurch geht sie mit der Gemeinde ein Meldeverhältnis ein.
/// </summary>
[Serializable]
[JsonObject("person")]
[XmlRoot(ElementName = "person", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class Person
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

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
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
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
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }
        set { _personIdentification = value; }
    }

    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData")]
    public NameData NameData
    {
        get { return _nameData; }
        set { _nameData = value; }
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthData BirthData
    {
        get { return _birthData; }
        set { _birthData = value; }
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

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
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
    [XmlElement(ElementName = "restrictedVotingAndElectionRightFederation")]
    public bool? RestrictedVotingAndElectionRightFederation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RestrictedVotingAndElectionRightFederationSpecified => RestrictedVotingAndElectionRightFederation.HasValue;

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin")]
    public List<PlaceOfOrigin> PlaceOfOrigins { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginsSpecified => PlaceOfOrigins != null && PlaceOfOrigins.Any();

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit")]
    public ResidencePermitData ResidencePermit { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitSpecified => ResidencePermit != null;
}
