// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

[Serializable]
[JsonObject("extension")]
[XmlRoot(ElementName = "extension", IsNullable = true)]
public class EventMoveOutExtension
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";
    private const string BirthDataNullValidateExceptionMessage = "BirthData is not valid! BirthData is required";
    private const string NationalityDataNullValidateExceptionMessage = "NationalityData is not valid! NationalityData is required";

    private MaritalData _maritalData;
    private BirthData _birthData;
    private NationalityData _nationalityData;

    public EventMoveOutExtension()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalData MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthData BirthData
    {
        get { return _birthData; }

        set
        {
            _birthData = value ?? throw new XmlSchemaValidationException(BirthDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin")]
    public List<PlaceOfOrigin> PlaceOfOrigins { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginsSpecified => PlaceOfOrigins != null && PlaceOfOrigins.Any();

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
}
