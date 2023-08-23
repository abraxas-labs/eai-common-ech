// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("file")]
[XmlType(TypeName = "fileType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class File
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PathFileNameValidateExceptionMessage = "pathFileName is not valid! pathFileName cannot be null";
    private const string MimeTypeValidateExceptionMessage = "mimeType is not valid! mimeType cannot be null";

    private string _pathFileName;
    private string _mimeType;

    public File()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/3");
    }

    [JsonProperty("pathFileName")]
    [XmlElement(ElementName = "pathFileName")]
    public string PathFileName
    {
        get => _pathFileName;
        set => _pathFileName = value ?? throw new XmlSchemaValidationException(PathFileNameValidateExceptionMessage);
    }

    [JsonProperty("mimeType")]
    [XmlElement(ElementName = "mimeType")]
    public string MimeType
    {
        get => _mimeType;
        set => _mimeType = value ?? throw new XmlSchemaValidationException(MimeTypeValidateExceptionMessage);
    }

    [JsonProperty("internalSortOrder")]
    [XmlElement(ElementName = "internalSortOrder")]
    public string InternalSortOrder { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool InternalSortOrderSpecified => InternalSortOrder != null;

    [JsonProperty("version")]
    [XmlElement(ElementName = "version")]
    public string Version { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool VersionSpecified => Version != null;

    [JsonProperty("hashCode")]
    [XmlElement(ElementName = "hashCode")]
    public string HashCode { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HashCodeSpecified => HashCode != null;

    [JsonProperty("hashCodeAlgorithm")]
    [XmlElement(ElementName = "hashCodeAlgorithm")]
    public string HashCodeAlgorithm { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HashCodeAlgorithmSpecified => HashCodeAlgorithm != null;

    [JsonProperty("lang")]
    [XmlAttribute(AttributeName = "lang", Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "language")]
    public string Lang { get; set; }
}
