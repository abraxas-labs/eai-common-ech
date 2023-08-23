// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectOccupation.
/// </summary>
[Serializable]
[JsonObject("eventCorrectOccupation")]
[XmlRoot(ElementName = "eventCorrectOccupation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectOccupation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectOccupationPersonNullValidateExceptionMessage = "CorrectOccupationPerson is not valid! CorrectOccupationPerson is required";

    private PersonIdentification _correctOccupationPerson;

    public EventCorrectOccupation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctOccupationPerson">Field is required.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectOccupation Create(PersonIdentification correctOccupationPerson, JobData jobData = null, object extension = null)
    {
        return new EventCorrectOccupation()
        {
            CorrectOccupationPerson = correctOccupationPerson,
            JobData = jobData,
            Extension = extension
        };
    }

    [JsonProperty("correctOccupationPerson")]
    [XmlElement(ElementName = "correctOccupationPerson")]
    public PersonIdentification CorrectOccupationPerson
    {
        get { return _correctOccupationPerson; }

        set
        {
            _correctOccupationPerson = value ?? throw new XmlSchemaValidationException(CorrectOccupationPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData")]
    public JobData JobData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDataSpecified => JobData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
