// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0039_3_0;
using Newtonsoft.Json;

namespace eCH_0223_1_0;

[Serializable]
[JsonObject("personEventMessage")]
[XmlType(TypeName = "personEventMessageType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
[XmlRoot(ElementName = "personEventMessage", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class PersonEventMessage
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string HeaderValidateExceptionMessage = "header is not valid! header cannot be null";
    private const string ContentValidateExceptionMessage = "content is not valid! content cannot be null";

    private Header _header;
    private Content _content;

    public PersonEventMessage()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
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

    [JsonProperty("content")]
    [XmlElement(ElementName = "content")]
    public Content Content
    {
        get { return _content; }

        set
        {
            _content = value ?? throw new XmlSchemaValidationException(ContentValidateExceptionMessage);
        }
    }
}
