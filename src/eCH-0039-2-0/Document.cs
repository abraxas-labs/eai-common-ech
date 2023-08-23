// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_2_0;

[Serializable]
[JsonObject("document")]
[XmlType(TypeName = "documentType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public class Document
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UuidValidateExceptionMessage = "uuid is not valid! uuid cannot be null";
    private const string TitlesValidateExceptionMessage = "titles is not valid! titles cannot be null or empty";
    private const string FilesValidateExceptionMessage = "files is not valid! files cannot be null or empty";

    private string _uuid;
    private Title[] _titles;
    private File[] _files;

    public Document()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/2");
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

    [JsonProperty("titles")]
    [XmlArray(ElementName = "titles")]
    [XmlArrayItem(ElementName = "title")]
    public Title[] Titles
    {
        get { return _titles; }

        set
        {
            _titles = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(TitlesValidateExceptionMessage);
        }
    }

    [JsonProperty("status")]
    [XmlElement(ElementName = "status")]
    public DocumentStatus Status { get; set; }

    [JsonProperty("files")]
    [XmlArray(ElementName = "files")]
    [XmlArrayItem(ElementName = "file")]
    public File[] Files
    {
        get { return _files; }

        set
        {
            _files = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(FilesValidateExceptionMessage);
        }
    }

    [JsonProperty("classification")]
    [XmlElement(ElementName = "classification")]
    public Classification? Classification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ClassificationSpecified => Classification != null;

    [JsonProperty("openToThePublicType")]
    [XmlElement(ElementName = "openToThePublicType")]
    public OpenToThePublic? OpenToThePublicType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OpenToThePublicTypeSpecified => OpenToThePublicType != null;

    [JsonProperty("hasPrivacyProtection")]
    [XmlElement(ElementName = "hasPrivacyProtection")]
    public bool? HasPrivacyProtection { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasPrivacyProtectionSpecified => HasPrivacyProtection != null;

    [JsonProperty("openingDate")]
    [XmlElement(DataType = "date", ElementName = "openingDate")]
    public DateTime? OpeningDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OpeningDateSpecified => OpeningDate != null;

    [JsonProperty("owner")]
    [XmlElement(ElementName = "owner")]
    public string Owner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OwnerSpecified => Owner != null;

    [JsonProperty("signer")]
    [XmlElement(ElementName = "signer")]
    public string Signer { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SignerSpecified => Signer != null;

    [JsonProperty("ourRecordReference")]
    [XmlElement(ElementName = "ourRecordReference")]
    public string OurRecordReference { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OurRecordReferenceSpecified => OurRecordReference != null;

    [JsonProperty("comments")]
    [XmlArray(ElementName = "comments")]
    [XmlArrayItem(ElementName = "comment")]
    public Comment[] Comments { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CommentsSpecified => Comments != null && Comments.Any();

    [JsonProperty("keywords")]
    [XmlArray(ElementName = "keywords")]
    [XmlArrayItem(ElementName = "keyword")]
    public Keyword[] Keywords { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool KeywordsSpecified => Keywords != null && Keywords.Any();

    [JsonProperty("isLeadingDocument")]
    [XmlElement(ElementName = "isLeadingDocument")]
    public bool? IsLeadingDocument { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IsLeadingDocumentSpecified => IsLeadingDocument != null;

    [JsonProperty("sortOrder")]
    [XmlElement(ElementName = "sortOrder")]
    public string SortOrder { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SortOrderSpecified => SortOrder != null;

    [JsonProperty("documentKind")]
    [XmlElement(ElementName = "documentKind")]
    public string DocumentKind { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DocumentKindSpecified => DocumentKind != null;

    [JsonProperty("lang")]
    [XmlAttribute(AttributeName = "lang", Form = XmlSchemaForm.Qualified, DataType = "language")]
    public string Lang { get; set; }
}
