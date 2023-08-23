// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_2_0;

[Serializable]
[JsonObject("reference")]
[XmlType(TypeName = "referenceType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public class Reference
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UuidValidateExceptionMessage = "uuid is not valid! uuid cannot be null";

    private string _uuid;

    public Reference()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/2");
    }

    [JsonProperty("uuid")]
    [XmlElement(ElementName = "uuid")]
    public string Uuid
    {
        get => _uuid;
        set
        {
            _uuid = value ?? throw new XmlSchemaValidationException(UuidValidateExceptionMessage);
        }
    }

    [JsonProperty("serviceInventoryId")]
    [XmlElement(ElementName = "serviceInventoryId")]
    public string ServiceInventoryId { get; set; }

    [JsonProperty("serviceId")]
    [XmlElement(ElementName = "serviceId")]
    public string ServiceId { get; set; }

    [JsonProperty("serviceTitle")]
    [XmlElement(ElementName = "serviceTitle")]
    public string ServiceTitle { get; set; }

    [JsonProperty("serviceProvider")]
    [XmlElement(ElementName = "serviceProvider")]
    public string ServiceProvider { get; set; }

    [JsonProperty("caseId")]
    [XmlElement(ElementName = "caseId")]
    public string CaseId { get; set; }

    [JsonProperty("caseTitle")]
    [XmlElement(ElementName = "caseTitle")]
    public string CaseTitle { get; set; }

    [JsonProperty("caseAnnotation")]
    [XmlElement(ElementName = "caseAnnotation")]
    public string CaseAnnotation { get; set; }
}
