// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0008_3_0;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("foreignCountry")]
[XmlRoot(ElementName = "foreignCountry", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class ForeignCountryType : FieldValueChecker<ForeignCountryType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Country _country;
    private string _foreignBirthTown;

    public ForeignCountryType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="country">Field is required.</param>
    /// <param name="foreignBirthTown">Field is optional.</param>
    /// <returns>ForeignCountryType.</returns>
    public static ForeignCountryType Create(Country country, string foreignBirthTown)
    {
        return new ForeignCountryType
        {
            Country = country,
            ForeignBirthTown = foreignBirthTown
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

    [FieldMaxLength(100)]
    [JsonProperty("foreignBirthTown")]
    [XmlElement(ElementName = "foreignBirthTown")]
    public string ForeignBirthTown
    {
        get => _foreignBirthTown;
        set => CheckAndSetValue(ref _foreignBirthTown, value);
    }
}
