// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("extension")]
[XmlType(TypeName = "extensionType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class Extension
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ReferenceValidateExceptionMessage = "reference is not valid! reference cannot be null";

    private Reference _reference;

    public Extension()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/3");
    }

    [JsonProperty("reference")]
    [XmlElement(ElementName = "reference")]
    public Reference Reference
    {
        get { return _reference; }

        set
        {
            _reference = value ?? throw new XmlSchemaValidationException(ReferenceValidateExceptionMessage);
        }
    }
}
