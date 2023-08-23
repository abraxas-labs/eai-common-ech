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
[JsonObject("foreignCountry")]
[XmlRoot(ElementName = "foreignCountry", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class ForeignCountry
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CountryNullValidateExceptionMessage = "Country is not valid! Country is required";
    private const string TownValidateExceptionMessage = "Town is not valid! Town  has max Length of 100";

    private Country _country;
    private string _town;

    public ForeignCountry()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="country">Field is required.</param>
    /// <param name="town">Field is optional.</param>
    /// <returns></returns>
    public static ForeignCountry Create(Country country, string town = null)
    {
        return new ForeignCountry()
        {
            Country = country,
            Town = town
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

    [JsonProperty("town")]
    [XmlElement(ElementName = "town", Order = 2)]
    public string Town
    {
        get { return _town; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(TownValidateExceptionMessage);
            }
            _town = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TownSpecified => !string.IsNullOrEmpty(Town);
}
