// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Zusatzangaben zum Heimatort.
/// </summary>
[Serializable]
[JsonObject("placeOfOriginAddonData")]
[XmlRoot(ElementName = "placeOfOriginAddonData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class PlaceOfOriginAddonData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PlaceOfOriginAddonData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="naturalizationDate">Field is optional.</param>
    /// <param name="expatriationDate">Field is optional.</param>
    /// <returns>BirthAddonData.</returns>
    public static PlaceOfOriginAddonData Create(DateTime? naturalizationDate = null, DateTime? expatriationDate = null)
    {
        return new PlaceOfOriginAddonData()
        {
            NaturalizationDate = naturalizationDate,
            ExpatriationDate = expatriationDate
        };
    }

    [JsonProperty("naturalizationDate")]
    [XmlElement(DataType = "date", ElementName = "naturalizationDate", Order = 1)]
    public DateTime? NaturalizationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NaturalizationDateSpecified => NaturalizationDate.HasValue;

    [JsonProperty("expatriationDate")]
    [XmlElement(DataType = "date", ElementName = "expatriationDate", Order = 2)]
    public DateTime? ExpatriationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExpatriationDateSpecified => ExpatriationDate.HasValue;
}
