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
/// Angaben hinsichtlich Krankenkasse / Krankenversicherung.
/// </summary>
[Serializable]
[JsonObject("healthInsuranceData")]
[XmlRoot(ElementName = "healthInsuranceData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class HealthInsuranceData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public HealthInsuranceData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="healthInsured">Field is required.</param>
    /// <param name="insurance">Field is optional.</param>
    /// <param name="healthInsuranceValidFrom">Field is optional.</param>
    /// <returns>FireServiceData.</returns>
    public static HealthInsuranceData Create(YesNo healthInsured, Insurance insurance = null, DateTime? healthInsuranceValidFrom = null)
    {
        return new HealthInsuranceData()
        {
            HealthInsured = healthInsured,
            Insurance = insurance,
            HealthInsuranceValidFrom = healthInsuranceValidFrom
        };
    }

    [JsonProperty("healthInsured")]
    [XmlElement(ElementName = "healthInsured", Order = 1)]
    public YesNo HealthInsured { get; set; }

    [JsonProperty("insurance")]
    [XmlElement(ElementName = "insurance", Order = 2)]
    public Insurance Insurance { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool InsuranceSpecified => Insurance != null;

    [JsonProperty("healthInsuranceValidFrom")]
    [XmlElement(DataType = "date", ElementName = "healthInsuranceValidFrom", Order = 3)]
    public DateTime? HealthInsuranceValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceValidFromSpecified => HealthInsuranceValidFrom.HasValue;
}
