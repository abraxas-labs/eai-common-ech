// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Geburtsort im Ausland mit optionaler Angabe des Ortes.
/// </summary>
[Serializable]
[JsonObject("foreignCountry")]
[XmlRoot(ElementName = "foreignCountry", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class ForeignCountry
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string TownValidateExceptionMessage = "Town is not valid! Town  has max Length of 100";

    private eCH_0008_3_0f.Country _country;
    private string _town;

    public ForeignCountry()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="country">Field is required.</param>
    /// <param name="town">Field is optional.</param>
    /// <returns></returns>
    public static ForeignCountry Create(eCH_0008_3_0.Country country, string town = null)
    {
        eCH_0008_3_0f.Country fCountry = new()
        {
            CountryId = country.CountryId,
            CountryIdIso2 = country.CountryIdIso2,
            CountryNameShort = country.CountryNameShort
        };

        return new ForeignCountry()
        {
            Country = fCountry,
            Town = town
        };
    }

    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public eCH_0008_3_0f.Country Country
    {
        get { return _country; }
        set { _country = value; }
    }

    [JsonProperty("town")]
    [XmlElement(ElementName = "town")]
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
