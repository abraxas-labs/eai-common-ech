// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0008_2_0;

/// <summary>
/// ///. <summary>
/// eCH eGovernment - Standards
/// Datenstandard Staaten und Gebiete (eCH-0008)
/// Beschreibung des Verzeichnisses der Staaten und Gebiete.
/// </summary>
/// </summary>
[Serializable]
[JsonObject("countryRoot")]
[XmlRoot(ElementName = "countryRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0008/2")]
public class CountryRoot : FieldValueChecker<CountryRoot>
{
    private Country _country;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public CountryRoot()
    {
        Xmlns.Add("eCH-0008", "http://www.ech.ch/xmlns/eCH-0008/2");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="country"></param>
    /// <returns>CountryRoot.</returns>
    public static CountryRoot Create(Country country)
    {
        return new CountryRoot()
        {
            Country = country
        };
    }

    [FieldRequired]
    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public Country Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }
}
