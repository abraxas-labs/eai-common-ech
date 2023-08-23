// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben hinsichtlich Krankenkasse / Krankenversicherung.
/// </summary>
[Serializable]
[JsonObject("healthInsuranceData")]
[XmlRoot(ElementName = "healthInsuranceData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class HealthInsuranceType : FieldValueChecker<HealthInsuranceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private YesNoType _healthInsured;
    private InsuranceType _insurance;
    private DateTime? _healthInsuranceValidFrom;

    public HealthInsuranceType()
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
    public static HealthInsuranceType Create(YesNoType healthInsured, InsuranceType insurance = null, DateTime? healthInsuranceValidFrom = null)
    {
        return new HealthInsuranceType
        {
            HealthInsured = healthInsured,
            Insurance = insurance,
            HealthInsuranceValidFrom = healthInsuranceValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("healthInsured")]
    [XmlElement(ElementName = "healthInsured")]
    public YesNoType HealthInsured
    {
        get => _healthInsured;
        set => CheckAndSetValue(ref _healthInsured, value);
    }

    [JsonProperty("insurance")]
    [XmlElement(ElementName = "insurance")]
    public InsuranceType Insurance
    {
        get => _insurance;
        set => CheckAndSetValue(ref _insurance, value);
    }

    [JsonProperty("healthInsuranceValidFrom")]
    [XmlElement(DataType = "date", ElementName = "healthInsuranceValidFrom")]
    public DateTime? HealthInsuranceValidFrom
    {
        get => _healthInsuranceValidFrom;
        set => CheckAndSetValue(ref _healthInsuranceValidFrom, value);
    }
}
