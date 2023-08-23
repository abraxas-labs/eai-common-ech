// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventChangeHealthInsurance.
/// </summary>
[Serializable]
[JsonObject("eventChangeHealthInsurance")]
[XmlRoot(ElementName = "eventChangeHealthInsurance", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeHealthInsurance
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _changeHealthInsurancePerson;

    public EventChangeHealthInsurance()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeHealthInsurancePerson">Field is required.</param>
    /// <param name="healthInsuranceData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeHealthInsurance Create(PersonIdentification changeHealthInsurancePerson, HealthInsuranceData healthInsuranceData, object extension = null)
    {
        return new EventChangeHealthInsurance()
        {
            ChangeHealthInsurancePerson = changeHealthInsurancePerson,
            HealthInsuranceData = healthInsuranceData,
            Extension = extension
        };
    }

    [JsonProperty("changeHealthInsurancePerson")]
    [XmlElement(ElementName = "changeHealthInsurancePerson")]
    public PersonIdentification ChangeHealthInsurancePerson
    {
        get { return _changeHealthInsurancePerson; }
        set { _changeHealthInsurancePerson = value; }
    }

    [JsonProperty("healthInsuranceData")]
    [XmlElement(ElementName = "healthInsuranceData")]
    public HealthInsuranceData HealthInsuranceData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HealthInsuranceDataSpecified => HealthInsuranceData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
