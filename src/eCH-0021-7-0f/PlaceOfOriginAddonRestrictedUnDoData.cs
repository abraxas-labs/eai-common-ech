// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Zusatzangaben zum Heimatort.
/// </summary>
[Serializable]
[JsonObject("placeOfOriginAddonRestrictedUnDoData")]
[XmlRoot(ElementName = "placeOfOriginAddonRestrictedUnDoData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class PlaceOfOriginAddonRestrictedUnDoData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PlaceOfOriginAddonRestrictedUnDoData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="expatriationDate">Field is required.</param>
    /// <returns>BirthAddonData.</returns>
    public static PlaceOfOriginAddonRestrictedUnDoData Create(DateTime expatriationDate)
    {
        return new PlaceOfOriginAddonRestrictedUnDoData()
        {
            ExpatriationDate = expatriationDate
        };
    }

    [JsonProperty("expatriationDate")]
    [XmlElement(DataType = "date", ElementName = "expatriationDate")]
    public DateTime? ExpatriationDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExpatriationDateSpecified => ExpatriationDate.HasValue;
}
