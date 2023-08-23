// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Zivilschutzdienstpflichtangaben.
/// </summary>
[Serializable]
[JsonObject("civilDefenseData")]
[XmlRoot(ElementName = "civilDefenseData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class CivilDefenseData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public CivilDefenseData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="civilDefense">Field is optional.</param>
    /// <param name="civilDefenseValidFrom">Field is optional.</param>
    /// <returns>CivilDefenseData.</returns>
    public static CivilDefenseData Create(YesNo? civilDefense = null, DateTime? civilDefenseValidFrom = null)
    {
        return new CivilDefenseData()
        {
            CivilDefense = civilDefense,
            CivilDefenseValidFrom = civilDefenseValidFrom
        };
    }

    [JsonProperty("civilDefense")]
    [XmlElement(ElementName = "civilDefense")]
    public YesNo? CivilDefense { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseSpecified => CivilDefense.HasValue;

    [JsonProperty("civilDefenseValidFrom")]
    [XmlElement(DataType = "date", ElementName = "civilDefenseValidFrom")]
    public DateTime? CivilDefenseValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CivilDefenseValidFromSpecified => CivilDefenseValidFrom.HasValue;
}
