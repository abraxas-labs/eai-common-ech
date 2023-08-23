// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("residencePaper")]
[XmlType(TypeName = "residencePaperType", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
[XmlRoot(ElementName = "residencePaper", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class ResidencePaper : FieldValueChecker<ResidencePaper>
{
    private string _residencePaperId;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private int? _municipalityId;
    private string _municipalityName;
    private int? _countryId;

    public ResidencePaper()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("residencePaperId")]
    [XmlElement(ElementName = "residencePaperId", Order = 0)]
    public string ResidencePaperId
    {
        get => _residencePaperId;
        set => CheckAndSetValue(ref _residencePaperId, value);
    }

    [JsonProperty("issueDate")]
    [XmlElement(DataType = "date", ElementName = "issueDate", Order = 1)]
    public DateTime? IssueDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IssueDateSpecified => IssueDate.HasValue;

    [JsonProperty("expirationDate")]
    [XmlElement(DataType = "date", ElementName = "expirationDate", Order = 2)]
    public DateTime? ExpirationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExpirationDateSpecified => ExpirationDate.HasValue;

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
}
