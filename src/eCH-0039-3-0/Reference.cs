// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("reference")]
[XmlType(TypeName = "referenceType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class Reference
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UuidValidateExceptionMessage = "uuid is not valid! uuid cannot be null";

    private string _uuid;

    public Reference()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/3");
    }

    [JsonProperty("uuid")]
    [XmlElement(ElementName = "uuid")]
    public string Uuid
    {
        get { return _uuid; }

        set
        {
            _uuid = value ?? throw new XmlSchemaValidationException(UuidValidateExceptionMessage);
        }
    }

    [JsonProperty("serviceInventoryId")]
    [XmlElement(ElementName = "serviceInventoryId")]
    public string ServiceInventoryId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ServiceInventoryIdSpecified => ServiceInventoryId != null;

    [JsonProperty("serviceId")]
    [XmlElement(ElementName = "serviceId")]
    public string ServiceId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ServiceIdSpecified => ServiceId != null;

    [JsonProperty("serviceTitle")]
    [XmlElement(ElementName = "serviceTitle")]
    public string ServiceTitle { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ServiceTitleSpecified => ServiceTitle != null;

    [JsonProperty("serviceProvider")]
    [XmlElement(ElementName = "serviceProvider")]
    public string ServiceProvider { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ServiceProviderSpecified => ServiceProvider != null;

    [JsonProperty("caseId")]
    [XmlElement(ElementName = "caseId")]
    public string CaseId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CaseIdSpecified => CaseId != null;

    [JsonProperty("caseTitle")]
    [XmlElement(ElementName = "caseTitle")]
    public string CaseTitle { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CaseTitleSpecified => CaseTitle != null;

    [JsonProperty("caseAnnotation")]
    [XmlElement(ElementName = "caseAnnotation")]
    public string CaseAnnotation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CaseAnnotationSpecified => CaseAnnotation != null;
}
