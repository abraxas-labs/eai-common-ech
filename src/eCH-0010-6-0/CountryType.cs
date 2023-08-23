// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Adressinformationen, welche in allen Postadressen vorhanden sein können.
/// </summary>
[Serializable]
[JsonObject("countryType")]
[XmlRoot(ElementName = "countryType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0010/6")]
public class CountryType : FieldValueChecker<CountryType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private int? _countryId;
    private string _countryIdIso2;
    private string _countryNameShort;

    public CountryType()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="countryId">Field is required.</param>
    /// <param name="countryIdIso2">Field can be null.</param>
    /// <param name="countryNameShort">Field can be null.</param>
    /// <returns>Country.</returns>
    public static CountryType Create(int? countryId, string countryIdIso2, string countryNameShort)
    {
        return new CountryType
        {
            CountryId = countryId,
            CountryIdIso2 = countryIdIso2,
            CountryNameShort = countryNameShort
        };
    }

    [FieldRangeInclusive(1000, 9999)]
    [JsonProperty("countryId")]
    [XmlElement(ElementName = "countryId", Order = 1)]
    public int? CountryId
    {
        get => _countryId;
        set => CheckAndSetValue(ref _countryId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdSpecified => CountryId.HasValue;

    [FieldMinMaxLength(2, 2)]
    [JsonProperty("countryIdISO2")]
    [XmlElement(ElementName = "countryIdISO2", Order = 2)]
    public string CountryIdIso2
    {
        get => _countryIdIso2;
        set => CheckAndSetValue(ref _countryIdIso2, value);
    }

    [FieldRequired]
    [FieldMaxLength(50)]
    [JsonProperty("countryNameShort")]
    [XmlElement(ElementName = "countryNameShort", Order = 3)]
    public string CountryNameShort
    {
        get => _countryNameShort;
        set => CheckAndSetValue(ref _countryNameShort, value);
    }
}
