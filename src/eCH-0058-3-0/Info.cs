// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Meldungsrahmen (eCH-0058)
///     Die detaillierte Antwort auf eine Meldung wird in Form
///     einer positiven Quittung (positiveReport) oder negativen Quittung (negativeReport) übergeben.
/// </summary>
[Serializable]
[JsonObject("header")]
[XmlRoot(ElementName = "header", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/5")]
public class Info
{
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Info()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/5");
    }

    [JsonProperty("positiveReport")]
    [XmlElement(ElementName = "positiveReport")]
    public Report PositiveReport { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PositiveReportSpecified => PositiveReport != null;

    [JsonProperty("negativeReport")]
    [XmlElement(ElementName = "negativeReport")]
    public Report NegativeReport { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NegativeReportSpecified => NegativeReport != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt eine positive Quittung oder eine negative Quittung.
    ///     Mit dem Boolean wird definiert, ob die Quittung positiv (true) oder negativ (false) ist.
    /// </summary>
    /// <param name="report">Field is reqired.</param>
    /// <param name="isReportPositive">Field is reqired.</param>
    /// <returns>Info.</returns>
    public static Info Create(Report report, bool isReportPositive)
    {
        return new Info
        {
            PositiveReport = isReportPositive ? report : null,
            NegativeReport = !isReportPositive ? report : null
        };
    }
}
