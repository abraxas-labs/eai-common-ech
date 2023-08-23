// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("file")]
[XmlType("fileType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class File : FieldValueChecker<File>
{
    private string _pathFileName;
    private string _mimeType;
    private string _internalSortOrder;

    [FieldRequired]
    [JsonProperty("pathFileName")]
    [XmlElement("pathFileName", DataType = "token")]
    public string PathFileName
    {
        get => _pathFileName;
        set => CheckAndSetValue(ref _pathFileName, value);
    }

    [FieldRequired]
    [JsonProperty("mimeType")]
    [XmlElement("mimeType", DataType = "token")]
    public string MimeType
    {
        get => _mimeType;
        set => CheckAndSetValue(ref _mimeType, value);
    }

    [FieldNonNegativeInteger]
    [JsonProperty("internalSortOrder")]
    [XmlElement("internalSortOrder", DataType = "nonNegativeInteger")]
    public string InternalSortOrder
    {
        get => _internalSortOrder;
        set => CheckAndSetValue(ref _internalSortOrder, value);
    }

    [JsonProperty("version")]
    [XmlElement("version", DataType = "token")]
    public string Version { get; set; }

    [JsonProperty("hashCode")]
    [XmlElement("hashCode", DataType = "token")]
    public string HashCode { get; set; }

    [JsonProperty("hashCodeAlgorithm")]
    [XmlElement("hashCodeAlgorithm", DataType = "token")]
    public string HashCodeAlgorithm { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom[] ApplicationCustoms { get; set; }

    [JsonProperty("lang")]
    [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", DataType = "language")]
    public string Lang { get; set; }
}
