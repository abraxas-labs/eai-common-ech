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
[JsonObject("response")]
[XmlType(TypeName = "responseType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class Response
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationValidateExceptionMessage = "personIdentification is not valid! personIdentification cannot be null";
    private const string ReasonValidateExceptionMessage = "reason is not valid! reason cannot be null or empty";

    private PersonIdentificationLight _personIdentification;
    private ReasonCode[] _reason;

    public Response()
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

    [JsonProperty("reason")]
    [XmlElement(ElementName = "reason")]
    public ReasonCode[] Reason
    {
        get { return _reason; }

        set
        {
            _reason = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(ReasonValidateExceptionMessage);
        }
    }

    [JsonProperty("notice")]
    [XmlElement(ElementName = "notice")]
    public Notice Notice { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NoticeSpecified => Notice != null;
}
