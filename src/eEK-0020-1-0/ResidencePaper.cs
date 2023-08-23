// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_0;

[Serializable]
[JsonObject("residencePaper")]
[XmlType(TypeName = "residencePaperType", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class ResidencePaper : FieldValueChecker<ResidencePaper>
{
    private string _residencePaperId;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ResidencePaper()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("residencePaperId")]
    [XmlElement(ElementName = "residencePaperId")]
    public string ResidencePaperId
    {
        get => _residencePaperId;
        set => CheckAndSetValue(ref _residencePaperId, value);
    }

    [JsonProperty("issueDate")]
    [XmlElement(DataType = "date", ElementName = "issueDate")]
    public DateTime? IssueDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IssueDateSpecified => IssueDate.HasValue;

    [JsonProperty("expirationDate")]
    [XmlElement(DataType = "date", ElementName = "expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExpirationDateSpecified => ExpirationDate.HasValue;

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
}
