// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("separationData")]
[XmlRoot(ElementName = "separationData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class SeparationData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public SeparationData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="separation">Field is optional.</param>
    /// <param name="separationValidFrom">Field is optional.</param>
    /// <param name="separationValidTill">Field is optional.</param>
    /// <returns>ReligionData.</returns>
    public static SeparationData Create(eCH_0011_8_1.Separation? separation = null, DateTime? separationValidFrom = null, DateTime? separationValidTill = null)
    {
        return new SeparationData()
        {
            Separation = (separation != null) ? (Separation?)Enum.Parse(typeof(Separation), separation.ToString()) : null,
            SeparationValidFrom = separationValidFrom,
            SeparationValidTill = separationValidTill
        };
    }

    [JsonProperty("separation")]
    [XmlElement(ElementName = "separation")]
    public Separation? Separation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationSpecified => Separation.HasValue;

    [JsonProperty("separationValidFrom")]
    [XmlElement(DataType = "date", ElementName = "separationValidFrom")]
    public DateTime? SeparationValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationValidFromSpecified => SeparationValidFrom.HasValue;

    [JsonProperty("separationValidTill")]
    [XmlElement(DataType = "date", ElementName = "separationValidTill")]
    public DateTime? SeparationValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationValidTillSpecified => SeparationValidTill.HasValue;
}
