// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Der Todeszeitraum wird durch Angabe eines DatumVon (dateFrom) und eines DatumBis (dateTo) abgebildet.
/// </summary>
[Serializable]
[JsonObject("deathPeriod")]
[XmlRoot(ElementName = "deathPeriod", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class DeathPeriod
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public DeathPeriod()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateFrom">Field is required.</param>
    /// <param name="dateTo">Field is optional.</param>
    /// <returns>ForeignerName.</returns>
    public static DeathPeriod Create(DateTime dateFrom, DateTime? dateTo = null)
    {
        return new DeathPeriod()
        {
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }

    [JsonProperty("dateFrom")]
    [XmlElement(DataType = "date", ElementName = "dateFrom")]
    public DateTime? DateFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateFromSpecified => DateFrom.HasValue;

    [JsonProperty("dateTo")]
    [XmlElement(DataType = "date", ElementName = "dateTo")]
    public DateTime? DateTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateToSpecified => DateTo.HasValue;
}
