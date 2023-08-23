// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Angaben zur Staatsangehörigkeit einer Person (auch von Schweizerinnen und Schweizern).
/// </summary>
[Serializable]
[JsonObject("nationalityData")]
[XmlRoot(ElementName = "nationalityData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class NationalityData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public NationalityData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nationalityStatus">Field is required.</param>
    /// <param name="countryInfos">Field is optional.</param>
    /// <returns></returns>
    public static NationalityData Create(eCH_0011_8_1.NationalityStatus nationalityStatus, List<CountryInfo> countryInfos = null)
    {
        return new NationalityData()
        {
            NationalityStatus = (NationalityStatus)Enum.Parse(typeof(NationalityStatus), nationalityStatus.ToString()),
            CountryInfos = countryInfos
        };
    }

    [JsonProperty("nationalityStatus")]
    [XmlElement(ElementName = "nationalityStatus")]
    public NationalityStatus? NationalityStatus { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NationalityStatusSpecified => NationalityStatus.HasValue;

    [JsonProperty("countryInfo")]
    [XmlElement(ElementName = "countryInfo")]
    public List<CountryInfo> CountryInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryInfosSpecified => CountryInfos != null && CountryInfos.Any();
}
