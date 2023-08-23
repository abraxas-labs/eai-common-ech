// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0039_3_0;
using Newtonsoft.Json;

namespace eCH_0223_1_5;

[Serializable]
[JsonObject("eventReport")]
[XmlType(TypeName = "eventReportType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
[XmlRoot(ElementName = "eventReport", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class EventReport
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string HeaderValidateExceptionMessage = "header is not valid! header cannot be null";
    private const string ResponseValidateExceptionMessage = "response is not valid! response cannot be null";

    private Header _header;
    private Response _response;

    public EventReport()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("version")]
    [XmlAttribute(AttributeName = "version")]
    public string Version
    {
        get { return "1.5"; }
        set { }
    }

    [JsonProperty("header")]
    [XmlElement(ElementName = "header")]
    public Header Header
    {
        get { return _header; }

        set
        {
            _header = value ?? throw new XmlSchemaValidationException(HeaderValidateExceptionMessage);
        }
    }

    [JsonProperty("response")]
    [XmlElement(ElementName = "response")]
    public Response Response
    {
        get { return _response; }

        set
        {
            _response = value ?? throw new XmlSchemaValidationException(ResponseValidateExceptionMessage);
        }
    }
}
