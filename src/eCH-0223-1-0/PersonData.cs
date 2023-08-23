// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0010_5_1;
using eCH_0011_8_1;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eCH_0223_1_0;

[Serializable]
[JsonObject("personData")]
[XmlType(TypeName = "personDataType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class PersonData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NameDataValidateExceptionMessage = "nameData is not valid! nameData cannot be null";
    private const string BirthDataValidateExceptionMessage = "birthData is not valid! birthData cannot be null";
    private const string NationalityDataValidateExceptionMessage = "nationalityData is not valid! nationalityData cannot be null";
    private const string MaritalDataValidateExceptionMessage = "maritalData is not valid! maritalData cannot be null";
    private const string ResidencePermitDataValidateExceptionMessage = "residencePermitData is not valid! residencePermitData cannot be null";
    private const string ResidenceAddressValidateExceptionMessage = "residenceAddress is not valid! residenceAddress cannot be null";
    private const string MunicipalityValidateExceptionMessage = "municipality is not valid! municipality cannot be null";
    private const string ReligionDataValidateExceptionMessage = "religionData is not valid! religionData cannot be null";

    private NameData _nameData;
    private BirthData _birthData;
    private NationalityData _nationalityData;
    private MaritalData _maritalData;
    private ResidencePermitData _residencePermitData;
    private SwissAddressInformation _residenceAddress;
    private SwissMunicipality _municipality;
    private ReligionData _religionData;

    public PersonData()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData")]
    public NameData NameData
    {
        get { return _nameData; }

        set
        {
            _nameData = value ?? throw new XmlSchemaValidationException(NameDataValidateExceptionMessage);
        }
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthData BirthData
    {
        get { return _birthData; }

        set
        {
            _birthData = value ?? throw new XmlSchemaValidationException(BirthDataValidateExceptionMessage);
        }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }

        set
        {
            _nationalityData = value ?? throw new XmlSchemaValidationException(NationalityDataValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalData MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataValidateExceptionMessage);
        }
    }

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitData ResidencePermitData
    {
        get { return _residencePermitData; }

        set
        {
            _residencePermitData = value ?? throw new XmlSchemaValidationException(ResidencePermitDataValidateExceptionMessage);
        }
    }

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData")]
    public JobData JobData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDataSpecified => JobData != null;

    [JsonProperty("residenceAddress")]
    [XmlElement(ElementName = "residenceAddress")]
    public SwissAddressInformation ResidenceAddress
    {
        get { return _residenceAddress; }

        set
        {
            _residenceAddress = value ?? throw new XmlSchemaValidationException(ResidenceAddressValidateExceptionMessage);
        }
    }

    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality")]
    public SwissMunicipality Municipality
    {
        get { return _municipality; }

        set
        {
            _municipality = value ?? throw new XmlSchemaValidationException(MunicipalityValidateExceptionMessage);
        }
    }

    [JsonProperty("parentalRelation")]
    [XmlElement(ElementName = "parentalRelation")]
    public ParentalRelation ParentalRelation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ParentalRelationSpecified => ParentalRelation != null;

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionData ReligionData
    {
        get { return _religionData; }

        set
        {
            _religionData = value ?? throw new XmlSchemaValidationException(ReligionDataValidateExceptionMessage);
        }
    }

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom")]
    public ComesFrom ComesFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ComesFromSpecified => ComesFrom != null;

    [JsonProperty("goesTo")]
    [XmlElement(ElementName = "goesTo")]
    public GoesTo GoesTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GoesToSpecified => GoesTo != null;
}
