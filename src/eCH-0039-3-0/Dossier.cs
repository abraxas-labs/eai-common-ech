// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("dossier")]
[XmlType(TypeName = "dossierType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class Dossier
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UuidValidateExceptionMessage = "uuid is not valid! uuid cannot be null";
    private const string TitlesValidateExceptionMessage = "titles is not valid! titles cannot be null or empty";

    private string _uuid;
    private Title[] _titles;

    public Dossier()
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

    [JsonProperty("status")]
    [XmlElement(ElementName = "status")]
    public DossierStatus Status { get; set; }

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

    [JsonProperty("classification")]
    [XmlElement(ElementName = "classification")]
    public Classification? Classification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ClassificationSpecified => Classification != null;

    [JsonProperty("hasPrivacyProtection")]
    [XmlElement(ElementName = "hasPrivacyProtection")]
    public bool? HasPrivacyProtection { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasPrivacyProtectionSpecified => HasPrivacyProtection != null;

    [JsonProperty("openToThePublicType")]
    [XmlElement(ElementName = "openToThePublicType")]
    public OpenToThePublic? OpenToThePublicType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OpenToThePublicTypeSpecified => OpenToThePublicType != null;

    [JsonProperty("caseReferenceLocalId")]
    [XmlElement(ElementName = "caseReferenceLocalId")]
    public string CaseReferenceLocalId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CaseReferenceLocalIdSpecified => CaseReferenceLocalId != null;

    [JsonProperty("openingDate")]
    [XmlElement(DataType = "date", ElementName = "openingDate")]
    public DateTime? OpeningDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OpeningDateSpecified => OpeningDate != null;

    [JsonProperty("keywords")]
    [XmlArray(ElementName = "keywords")]
    [XmlArrayItem(ElementName = "keyword")]
    public Keyword[] Keywords { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool KeywordsSpecified => Keywords != null;

    [JsonProperty("comments")]
    [XmlArray(ElementName = "comments")]
    [XmlArrayItem(ElementName = "comment")]
    public Comment[] Comments { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CommentsSpecified => Comments != null;

    [JsonProperty("links")]
    [XmlArray(ElementName = "links")]
    [XmlArrayItem(ElementName = "link")]
    public Link[] Links { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool LinksSpecified => Links != null;

    [JsonProperty("lang")]
    [XmlAttribute(AttributeName = "lang", Form = XmlSchemaForm.Qualified, DataType = "language")]
    public string Lang { get; set; }
}
