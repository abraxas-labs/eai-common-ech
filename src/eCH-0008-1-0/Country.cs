// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0008_1_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Staaten und Gebiete (eCH-0008)
/// Für den Austausch von Informationen über Staaten und Gebiete (Staatszugehörigkeit, Herkunftsland u.a.) ist das Schema eCH-0008 anzuwenden.
/// </summary>
[Serializable]
[JsonObject("country")]
[XmlRoot(ElementName = "country", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0008/1")]
public class Country : FieldValueChecker<Country>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private int? _countryId;
    private LanguageType _languageType;
    private string _countryIdIso2;
    private string _countryNameShort;

    public Country()
    {
        Xmlns.Add("eCH-0008", "http://www.ech.ch/xmlns/eCH-0008/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="countryId">Field can be null.</param>
    /// <param name="countryIdIso2">Field can be null.</param>
    /// <param name="countryNameShort">Field is reqired.</param>
    /// <returns>Country.</returns>
    public static Country Create(int? countryId, string countryIdIso2, string countryNameShort)
    {
        return new Country
        {
            CountryId = countryId,
            CountryIdIso2 = countryIdIso2,
            CountryNameShort = countryNameShort
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="countryNameShort">Field is reqired.</param>
    /// <returns>Country.</returns>
    public static Country Create(string countryNameShort)
    {
        return new Country
        {
            CountryId = null,
            CountryIdIso2 = null,
            CountryNameShort = countryNameShort
        };
    }

    [FieldRequired]
    [FieldRangeInclusive(1000, 9999)]
    [XmlElement(ElementName = "countryId")]
    public int? CountryId
    {
        get => _countryId;
        set => CheckAndSetValue(ref _countryId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdSpecified => CountryId.HasValue;

    [FieldMaxLength(2)]
    [XmlElement(ElementName = "countryIdISO2")]
    public string CountryIdIso2
    {
        get => _countryIdIso2;
        set => CheckAndSetValue(ref _countryIdIso2, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdIso2Specified => !string.IsNullOrWhiteSpace(CountryIdIso2);

    [FieldRequired]
    [FieldMaxLength(50)]
    [XmlElement(ElementName = "countryNameShort")]
    public string CountryNameShort
    {
        get => _countryNameShort;
        set => CheckAndSetValue(ref _countryNameShort, value);
    }

    [FieldRequired]
    [XmlElement(ElementName = "languageType")]
    public LanguageType LanguageType
    {
        get => _languageType;
        set => CheckAndSetValue(ref _languageType, value);
    }
}
