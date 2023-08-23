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
/// EventChangeOccupation.
/// </summary>
[Serializable]
[JsonObject("eventChangeOccupation")]
[XmlRoot(ElementName = "eventChangeOccupation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeOccupation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeOccupationPersonNullValidateExceptionMessage = "ChangeOccupationPerson is not valid! ChangeOccupationPerson is required";

    private PersonIdentification _changeOccupationPerson;

    public EventChangeOccupation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeOccupationPerson">Field is required.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeOccupation Create(PersonIdentification changeOccupationPerson, JobData jobData = null, object extension = null)
    {
        return new EventChangeOccupation()
        {
            ChangeOccupationPerson = changeOccupationPerson,
            JobData = jobData,
            Extension = extension
        };
    }

    [JsonProperty("changeOccupationPerson")]
    [XmlElement(ElementName = "changeOccupationPerson")]
    public PersonIdentification ChangeOccupationPerson
    {
        get { return _changeOccupationPerson; }

        set
        {
            _changeOccupationPerson = value ?? throw new XmlSchemaValidationException(ChangeOccupationPersonNullValidateExceptionMessage);
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
