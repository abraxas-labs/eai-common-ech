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
/// Militärdienstpflichtangaben.
/// </summary>
[Serializable]
[JsonObject("fireServiceData")]
[XmlRoot(ElementName = "fireServiceData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class FireServiceData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public FireServiceData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="fireService">Field is optional.</param>
    /// <param name="fireServiceLiability">Field is optional.</param>
    /// <param name="fireServiceValidFrom">Field is optional.</param>
    /// <returns>FireServiceData.</returns>
    public static FireServiceData Create(YesNo? fireService = null, YesNo? fireServiceLiability = null, DateTime? fireServiceValidFrom = null)
    {
        return new FireServiceData()
        {
            FireService = fireService,
            FireServiceLiability = fireServiceLiability,
            FireServiceValidFrom = fireServiceValidFrom
        };
    }

    [JsonProperty("fireService")]
    [XmlElement(ElementName = "fireService")]
    public YesNo? FireService { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceSpecified => FireService.HasValue;

    [JsonProperty("fireServiceLiability")]
    [XmlElement(ElementName = "fireServiceLiability")]
    public YesNo? FireServiceLiability { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceLiabilitySpecified => FireServiceLiability.HasValue;

    [JsonProperty("fireServiceValidFrom")]
    [XmlElement(DataType = "date", ElementName = "fireServiceValidFrom")]
    public DateTime? FireServiceValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FireServiceValidFromSpecified => FireServiceValidFrom.HasValue;
}
