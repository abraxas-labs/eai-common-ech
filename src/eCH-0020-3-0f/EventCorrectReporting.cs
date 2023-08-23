// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectReporting.
/// </summary>
[Serializable]
[JsonObject("eventCorrectReporting")]
[XmlRoot(ElementName = "eventCorrectReporting", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectReporting
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctReportingPerson;

    public EventCorrectReporting()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctReportingPerson">Field is required.</param>
    /// <param name="hasMainResidence">Field is required.</param>
    /// <param name="reportingValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectReporting Create(PersonIdentification correctReportingPerson, MainResidenceType hasMainResidence, DateTime? reportingValidFrom, object extension = null)
    {
        return new EventCorrectReporting()
        {
            CorrectReportingPerson = correctReportingPerson,
            HasMainResidence = hasMainResidence,
            HasSecondaryResidence = null,
            HasOtherResidence = null,
            ReportingValidFrom = reportingValidFrom,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctReportingPerson">Field is required.</param>
    /// <param name="hasSecondaryResidence">Field is required.</param>
    /// <param name="reportingValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectReporting Create(PersonIdentification correctReportingPerson, SecondaryResidenceType hasSecondaryResidence, DateTime? reportingValidFrom, object extension = null)
    {
        return new EventCorrectReporting()
        {
            CorrectReportingPerson = correctReportingPerson,
            HasMainResidence = null,
            HasSecondaryResidence = hasSecondaryResidence,
            HasOtherResidence = null,
            ReportingValidFrom = reportingValidFrom,
            Extension = extension
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctReportingPerson">Field is required.</param>
    /// <param name="hasOtherResidence">Field is required.</param>
    /// <param name="reportingValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectReporting Create(PersonIdentification correctReportingPerson, OtherResidenceType hasOtherResidence, DateTime? reportingValidFrom, object extension = null)
    {
        return new EventCorrectReporting()
        {
            CorrectReportingPerson = correctReportingPerson,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence,
            ReportingValidFrom = reportingValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("correctReportingPerson")]
    [XmlElement(ElementName = "correctReportingPerson")]
    public PersonIdentification CorrectReportingPerson
    {
        get { return _correctReportingPerson; }
        set { _correctReportingPerson = value; }
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence")]
    public MainResidenceType HasMainResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence")]
    public SecondaryResidenceType HasSecondaryResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence")]
    public OtherResidenceType HasOtherResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasOtherResidence != null;

    [JsonProperty("reportingValidFrom")]
    [XmlElement(DataType = "date", ElementName = "reportingValidFrom")]
    public DateTime? ReportingValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReportingValidFromSpecified => ReportingValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
