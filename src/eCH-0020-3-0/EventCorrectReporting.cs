// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectReporting.
/// </summary>
[Serializable]
[JsonObject("eventCorrectReporting")]
[XmlRoot(ElementName = "eventCorrectReporting", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectReporting
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectReportingPersonNullValidateExceptionMessage = "CorrectReportingPerson is not valid! CorrectReportingPerson is required";
    private const string HasMainResidenceNullValidateExceptionMessage = "HasMainResidence is not valid! HasMainResidence is required";
    private const string HasSecondaryResidenceNullValidateExceptionMessage = "HasSecondaryResidence is not valid! HasSecondaryResidence is required";
    private const string HasOtherResidenceNullValidateExceptionMessage = "HasOtherResidence is not valid! HasOtherResidence is required";

    private PersonIdentification _correctReportingPerson;

    public EventCorrectReporting()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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
        if (hasMainResidence == null)
        {
            throw new XmlSchemaValidationException(HasMainResidenceNullValidateExceptionMessage);
        }
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
        if (hasSecondaryResidence == null)
        {
            throw new XmlSchemaValidationException(HasSecondaryResidenceNullValidateExceptionMessage);
        }
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
        if (hasOtherResidence == null)
        {
            throw new XmlSchemaValidationException(HasOtherResidenceNullValidateExceptionMessage);
        }
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

        set
        {
            _correctReportingPerson = value ?? throw new XmlSchemaValidationException(CorrectReportingPersonNullValidateExceptionMessage);
        }
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
