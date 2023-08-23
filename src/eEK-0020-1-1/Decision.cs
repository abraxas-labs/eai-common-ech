// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eEK_0020_1_1;

[Serializable]
[JsonObject("decision")]
[XmlType(TypeName = "decision", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
[XmlRoot(ElementName = "decision", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class Decision : FieldValueChecker<Decision>
{
    private int? _municipalityId;
    private string _municipalityName;
    private int? _countryId;
    private DecisionId _decisionId;
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
    [XmlElement(ElementName = "decisionId", Order = 0)]
    public DecisionId DecisionId
    {
        get => _decisionId;
        set => CheckAndSetValue(ref _decisionId, value);
    }

    [FieldRequired]
    [JsonProperty("issueDate")]
    [XmlElement(DataType = "date", ElementName = "issueDate", Order = 1)]
    public DateTime IssueDate
    {
        get => _issueDate;
        set => CheckAndSetValue(ref _issueDate, value);
    }

    [FieldRequired]
    [JsonProperty("expirationDate")]
    [XmlElement(DataType = "date", ElementName = "expirationDate", Order = 2)]
    public DateTime ExpirationDate
    {
        get => _expirationDate;
        set => CheckAndSetValue(ref _expirationDate, value);
    }

    [FieldRangeInclusive(1, 9999)]
    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId", Order = 3)]
    public int? MunicipalityId
    {
        get => _municipalityId;
        set => CheckAndSetValue(ref _municipalityId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalityIdSpecified => MunicipalityId.HasValue;

    [FieldMaxLength(40)]
    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName", Order = 4)]
    public string MunicipalityName
    {
        get => _municipalityName;
        set => CheckAndSetValue(ref _municipalityName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalityNameSpecified => MunicipalityName != null;

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 5)]
    public CantonAbbreviation? CantonAbbreviation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation.HasValue;

    [FieldRangeInclusive(1000, 9999)]
    [JsonProperty("countryId")]
    [XmlElement(ElementName = "countryId", Order = 6)]
    public int? CountryId
    {
        get => _countryId;
        set => CheckAndSetValue(ref _countryId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdSpecified => CountryId.HasValue;

    [JsonProperty("town")]
    [XmlElement(ElementName = "town", Order = 7)]
    public string Town { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TownSpecified => Town != null;
}
