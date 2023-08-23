// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Personendaten zu einer Geburt.
/// </summary>
[Serializable]
[JsonObject("infostarPerson")]
[XmlRoot(ElementName = "infostarPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class InfostarPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is required";
    private const string NameInfoNullValidateExceptionMessage = "NameInfo is not valid! NameInfo is required";
    private const string BirthInfoNullValidateExceptionMessage = "BirthInfo is not valid! BirthInfo is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";
    private const string NationalityDataNullValidateExceptionMessage = "NationalityData is not valid! NationalityData is required";
    private const string PlaceOfOriginInfoNullValidateExceptionMessage = "PlaceOfOriginInfo is not valid! PlaceOfOriginInfo is required";

    private PersonIdentification _personIdentification;
    private NameInfo _nameInfo;
    private BirthInfo _birthInfo;
    private MaritalInfo _maritaData;
    private NationalityData _nationalityData;

    public InfostarPerson()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="birthInfo">Field is required.</param>
    /// <param name="maritalInfo">Field is required.</param>
    /// <param name="nationalityData">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is optional.</param>
    /// <param name="deathData">Field is optional.</param>
    /// <returns>InfostarPerson.</returns>
    public static InfostarPerson Create(PersonIdentification personIdentification, NameInfo nameInfo, BirthInfo birthInfo, MaritalInfo maritalInfo, NationalityData nationalityData, List<PlaceOfOriginInfo> placeOfOriginInfos = null, DeathData deathData = null)
    {
        if (placeOfOriginInfos == null)
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
        if (placeOfOriginInfos != null && !placeOfOriginInfos.Any())
        {
            throw new XmlSchemaValidationException(PlaceOfOriginInfoNullValidateExceptionMessage);
        }
        return new InfostarPerson()
        {
            PersonIdentification = personIdentification,
            NameInfo = nameInfo,
            BirthInfo = birthInfo,
            MaritalInfo = maritalInfo,
            NationalityData = nationalityData,
            PlaceOfOriginInfos = placeOfOriginInfos,
            DeathData = deathData
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

    [JsonProperty("maritalInfo")]
    [XmlElement(ElementName = "maritalInfo")]
    public MaritalInfo MaritalInfo
    {
        get { return _maritaData; }

        set
        {
            _maritaData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
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

    [JsonProperty("placeOfOriginInfo")]
    [XmlElement(ElementName = "placeOfOriginInfo")]
    public List<PlaceOfOriginInfo> PlaceOfOriginInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginInfosSpecified => PlaceOfOriginInfos != null && PlaceOfOriginInfos.Any();

    [JsonProperty("deathData")]
    [XmlElement(ElementName = "deathData")]
    public DeathData DeathData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeathDataSpecified => DeathData != null;
}
