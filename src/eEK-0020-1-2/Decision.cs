// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

[Serializable]
[JsonObject("decision")]
[XmlType(TypeName = "decision", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
[XmlRoot(ElementName = "decision", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class Decision : FieldValueChecker<Decision>
{
    private string _decisionId;
    private DateTime _issueDate;
    private DateTime _expirationDate;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public Decision()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("decisionId")]
    [XmlElement(ElementName = "decisionId")]
    public string DecisionId
    {
        get => _decisionId;
        set => CheckAndSetValue(ref _decisionId, value);
    }

    [FieldRequired]
    [JsonProperty("issueDate")]
    [XmlElement(DataType = "date", ElementName = "issueDate")]
    public DateTime IssueDate
    {
        get => _issueDate;
        set => CheckAndSetValue(ref _issueDate, value);
    }

    [FieldRequired]
    [JsonProperty("expirationDate")]
    [XmlElement(DataType = "date", ElementName = "expirationDate")]
    public DateTime ExpirationDate
    {
        get => _expirationDate;
        set => CheckAndSetValue(ref _expirationDate, value);
    }

    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId")]
    public int? MunicipalityId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalityIdSpecified => MunicipalityId.HasValue;

    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName")]
    public string MunicipalityName { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalityNameSpecified => !string.IsNullOrWhiteSpace(MunicipalityName);

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation")]
    public string CantonAbbreviation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CantonAbbreviationSpecified => !string.IsNullOrWhiteSpace(CantonAbbreviation);

    [JsonProperty("countryId")]
    [XmlElement(ElementName = "countryId")]
    public int? CountryId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdSpecified => CountryId.HasValue;

    [JsonProperty("town")]
    [XmlElement(ElementName = "town")]
    public string Town { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TownSpecified => !string.IsNullOrWhiteSpace(Town);
}
