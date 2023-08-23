// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0008_3_0;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Geburtsort im Ausland mit optionaler Angabe des Ortes.
/// </summary>
[Serializable]
[JsonObject("countryInfo")]
[XmlRoot(ElementName = "countryInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class CountryInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CountryNullValidateExceptionMessage = "Country is not valid! Country is required";

    private Country _country;

    public CountryInfo()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
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
    [XmlElement(ElementName = "country", Order = 1)]
    public Country Country
    {
        get { return _country; }

        set
        {
            _country = value ?? throw new XmlSchemaValidationException(CountryNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nationalityValidFrom")]
    [XmlElement(DataType = "date", ElementName = "nationalityValidFrom", Order = 2)]
    public DateTime? NationalityValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NationalityValidFromSpecified => NationalityValidFrom.HasValue;
}
