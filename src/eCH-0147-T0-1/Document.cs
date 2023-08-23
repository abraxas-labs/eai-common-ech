// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("document")]
[XmlType("documentType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Document : FieldValueChecker<Document>
{
    private string _uuid;
    private Title[] _titles;
    private DocumentStatus? _status;
    private File[] _files;
    private string _sortOrder;

    [FieldRequired]
    [JsonProperty("uuid")]
    [XmlElement("uuid", DataType = "token")]
    public string Uuid
    {
        get => _uuid;
        set => CheckAndSetValue(ref _uuid, value);
    }

    [FieldRequired]
    [JsonProperty("titles")]
    [XmlArray("titles")]
    [XmlArrayItem("title", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Title[] Titles
    {
        get => _titles;
        set => CheckAndSetValue(ref _titles, value);
    }

    [FieldRequired]
    [JsonProperty("status")]
    [XmlElement("status")]
    public DocumentStatus? Status
    {
        get => _status;
        set => CheckAndSetValue(ref _status, value);
    }

    [FieldRequired]
    [JsonProperty("files")]
    [XmlArray("files")]
    [XmlArrayItem("file", IsNullable = false)]
    public File[] Files
    {
        get => _files;
        set => CheckAndSetValue(ref _files, value);
    }

    [JsonProperty("classification")]
    [XmlElement("classification")]
    public Classification? Classification { get; set; }

    [JsonProperty("openToThePublic")]
    [XmlElement("openToThePublic")]
    public OpenToThePublic? OpenToThePublic { get; set; }

    [JsonProperty("hasPrivacyProtection")]
    [XmlElement("hasPrivacyProtection")]
    public bool? HasPrivacyProtection { get; set; }

    [JsonProperty("openingDate")]
    [XmlElement("openingDate", DataType = "date")]
    public DateTime? OpeningDate { get; set; }

    [JsonProperty("owner")]
    [XmlElement("owner", DataType = "token")]
    public string Owner { get; set; }

    [JsonProperty("signer")]
    [XmlElement("signer", DataType = "token")]
    public string Signer { get; set; }

    [JsonProperty("ourRecordReference")]
    [XmlElement("ourRecordReference", DataType = "token")]
    public string OurRecordReference { get; set; }

    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [JsonProperty("keywords")]
    [XmlArray("keywords")]
    [XmlArrayItem("keyword", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Keyword[] Keywords { get; set; }

    [JsonProperty("isLeadingDocument")]
    [XmlElement("isLeadingDocument")]
    public bool? IsLeadingDocument { get; set; }

    [FieldNonNegativeInteger]
    [JsonProperty("sortOrder")]
    [XmlElement("sortOrder", DataType = "nonNegativeInteger")]
    public string SortOrder
    {
        get => _sortOrder;
        set => CheckAndSetValue(ref _sortOrder, value);
    }

    [JsonProperty("documentKind")]
    [XmlElement("documentKind", DataType = "token")]
    public string DocumentKind { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom[] ApplicationCustoms { get; set; }

    [JsonProperty("lang")]
    [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", DataType = "language")]
    public string Lang { get; set; }
}
