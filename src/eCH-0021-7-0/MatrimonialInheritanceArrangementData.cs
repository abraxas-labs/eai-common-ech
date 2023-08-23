// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben hinsichtlich Güter- und/oder erbrechtlicher Vereinbarungen.
/// </summary>
[Serializable]
[JsonObject("matrimonialInheritanceArrangementData")]
[XmlRoot(ElementName = "matrimonialInheritanceArrangementData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class MatrimonialInheritanceArrangementData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MatrimonialInheritanceArrangementData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="matrimonialInheritanceArrangement">Field is required.</param>
    /// <param name="matrimonialInheritanceArrangementValidFrom">Field is optional.</param>
    /// <returns>MatrimonialInheritanceArrangementData.</returns>
    public static MatrimonialInheritanceArrangementData Create(YesNo matrimonialInheritanceArrangement, DateTime? matrimonialInheritanceArrangementValidFrom = null)
    {
        return new MatrimonialInheritanceArrangementData()
        {
            MatrimonialInheritanceArrangement = matrimonialInheritanceArrangement,
            MatrimonialInheritanceArrangementValidFrom = matrimonialInheritanceArrangementValidFrom
        };
    }

    [JsonProperty("matrimonialInheritanceArrangement")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangement", Order = 1)]
    public YesNo MatrimonialInheritanceArrangement { get; set; }

    [JsonProperty("matrimonialInheritanceArrangementValidFrom")]
    [XmlElement(DataType = "date", ElementName = "matrimonialInheritanceArrangementValidFrom", Order = 2)]
    public DateTime? MatrimonialInheritanceArrangementValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MatrimonialInheritanceArrangementValidFromSpecified => MatrimonialInheritanceArrangementValidFrom.HasValue;
}
