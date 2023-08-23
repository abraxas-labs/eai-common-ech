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
/// Militärdienstpflichtangaben.
/// </summary>
[Serializable]
[JsonObject("armedForcesData")]
[XmlRoot(ElementName = "armedForcesData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class ArmedForcesData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ArmedForcesData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="armedForcesService">Field is optional.</param>
    /// <param name="armedForcesLiability">Field is optional.</param>
    /// <param name="armedForcesValidFrom">Field is optional.</param>
    /// <returns>ArmedForcesData.</returns>
    public static ArmedForcesData Create(YesNo? armedForcesService = null, YesNo? armedForcesLiability = null, DateTime? armedForcesValidFrom = null)
    {
        return new ArmedForcesData()
        {
            ArmedForcesService = armedForcesService,
            ArmedForcesLiability = armedForcesLiability,
            ArmedForcesValidFrom = armedForcesValidFrom
        };
    }

    [JsonProperty("armedForcesService")]
    [XmlElement(ElementName = "armedForcesService", Order = 1)]
    public YesNo? ArmedForcesService { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesServiceSpecified => ArmedForcesService.HasValue;

    [JsonProperty("armedForcesLiability")]
    [XmlElement(ElementName = "armedForcesLiability", Order = 2)]
    public YesNo? ArmedForcesLiability { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesLiabilitySpecified => ArmedForcesLiability.HasValue;

    [JsonProperty("armedForcesValidFrom")]
    [XmlElement(DataType = "date", ElementName = "armedForcesValidFrom", Order = 3)]
    public DateTime? ArmedForcesValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArmedForcesValidFromSpecified => ArmedForcesValidFrom.HasValue;
}
