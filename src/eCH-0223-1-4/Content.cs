// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0223_1_4;

[Serializable]
[JsonObject("content")]
[XmlType(TypeName = "contentType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class Content
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationValidateExceptionMessage = "personIdentification is not valid! personIdentification cannot be null";

    private PersonIdentificationLight _personIdentification;

    public Content()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentificationLight PersonIdentification
    {
        get { return _personIdentification; }

        set
        {
            _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationValidateExceptionMessage);
        }
    }

    [JsonProperty("personEvent")]
    [XmlElement(ElementName = "personEvent")]
    public PersonEvent? PersonEvent { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonEventSpecified => PersonEvent != null;

    [JsonProperty("personData")]
    [XmlElement(ElementName = "personData")]
    public PersonData PersonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonDataSpecified => PersonData != null;

    [JsonProperty("document")]
    [XmlElement(ElementName = "document")]
    public ContentDocument[] Document { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DocumentSpecified => Document != null && Document.Any();

    [JsonProperty("businessInformation")]
    [XmlElement(ElementName = "businessInformation")]
    public BusinessInformation BusinessInformation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BusinessInformationSpecified => BusinessInformation != null;
}
