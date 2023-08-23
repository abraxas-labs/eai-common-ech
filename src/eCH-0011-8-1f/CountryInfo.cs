// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0008_3_0f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Geburtsort im Ausland mit optionaler Angabe des Ortes.
/// </summary>
[Serializable]
[JsonObject("countryInfo")]
[XmlRoot(ElementName = "countryInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class CountryInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Country _country;

    public CountryInfo()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="country">Field is required.</param>
    /// <param name="nationalityValidFrom">Field is optional.</param>
    /// <returns></returns>
    public static CountryInfo Create(Country country, DateTime? nationalityValidFrom = null)
    {
        return new CountryInfo()
        {
            Country = country,
            NationalityValidFrom = nationalityValidFrom
        };
    }

    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public Country Country
    {
        get { return _country; }
        set { _country = value; }
    }

    [JsonProperty("nationalityValidFrom")]
    [XmlElement(DataType = "date", ElementName = "nationalityValidFrom")]
    public DateTime? NationalityValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NationalityValidFromSpecified => NationalityValidFrom.HasValue;
}
