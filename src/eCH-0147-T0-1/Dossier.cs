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
[JsonObject("dossier")]
[XmlType("dossierType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Dossier : FieldValueChecker<Dossier>
{
    private string _uuid;
    private DossierStatus? _status;
    private Title[] _titles;

    [FieldRequired]
    [JsonProperty("uuid")]
    [XmlElement("uuid", DataType = "token")]
    public string Uuid
    {
        get => _uuid;
        set => CheckAndSetValue(ref _uuid, value);
    }

    [FieldRequired]
    [JsonProperty("status")]
    [XmlElement("status")]
    public DossierStatus? Status
    {
        get => _status;
        set => CheckAndSetValue(ref _status, value);
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

    [JsonProperty("classification")]
    [XmlElement("classification")]
    public Classification Classification { get; set; }

    [JsonProperty("hasPrivacyProtection")]
    [XmlElement("hasPrivacyProtection")]
    public bool? HasPrivacyProtection { get; set; }

    [JsonProperty("openToThePublicType")]
    [XmlElement("openToThePublicType")]
    public OpenToThePublic OpenToThePublicType { get; set; }

    [JsonProperty("caseReferenceLocalId")]
    [XmlElement("caseReferenceLocalId", DataType = "token")]
    public string CaseReferenceLocalId { get; set; }

    [JsonProperty("openingDate")]
    [XmlElement("openingDate", DataType = "date")]
    public DateTime? OpeningDate { get; set; }

    [JsonProperty("keywords")]
    [XmlArray("keywords")]
    [XmlArrayItem("keyword", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Keyword[] Keywords { get; set; }

    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [JsonProperty("links")]
    [XmlArray("links")]
    [XmlArrayItem("link", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Link[] Links { get; set; }

    [JsonProperty("addresses")]
    [XmlArray("addresses")]
    [XmlArrayItem("address", IsNullable = false)]
    public Address[] Addresses { get; set; }

    [JsonProperty("dossiers")]
    [XmlArray("dossiers")]
    [XmlArrayItem("dossier", IsNullable = false)]
    public Dossier[] Dossiers { get; set; }

    [JsonProperty("documents")]
    [XmlArray("documents")]
    [XmlArrayItem("document", IsNullable = false)]
    public Document[] Documents { get; set; }

    [JsonProperty("folders")]
    [XmlArray("folders")]
    [XmlArrayItem("folder", IsNullable = false)]
    public Folder[] Folders { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom[] ApplicationCustoms { get; set; }

    [JsonProperty("lang")]
    [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", DataType = "language")]
    public string Lang { get; set; }
}
