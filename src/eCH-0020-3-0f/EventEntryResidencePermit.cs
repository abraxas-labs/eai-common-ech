﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventEntryResidencePermit.
/// </summary>
[Serializable]
[JsonObject("eventEntryResidencePermit")]
[XmlRoot(ElementName = "eventEntryResidencePermit", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventEntryResidencePermit
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _entryResidencePermitPerson;
    private ResidencePermitData _residencePermitData;

    public EventEntryResidencePermit()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="entryResidencePermitPerson">Field is required.</param>
    /// <param name="residencePermitData">Field is reqired.</param>
    /// <param name="jobData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventEntryResidencePermit Create(PersonIdentification entryResidencePermitPerson, ResidencePermitData residencePermitData, JobData jobData = null, object extension = null)
    {
        return new EventEntryResidencePermit()
        {
            EntryResidencePermitPerson = entryResidencePermitPerson,
            JobData = jobData,
            ResidencePermitData = residencePermitData,
            Extension = extension
        };
    }

    [JsonProperty("entryResidencePermitPerson")]
    [XmlElement(ElementName = "entryResidencePermitPerson")]
    public PersonIdentification EntryResidencePermitPerson
    {
        get { return _entryResidencePermitPerson; }
        set { _entryResidencePermitPerson = value; }
    }

    [JsonProperty("jobData")]
    [XmlElement(ElementName = "jobData")]
    public JobData JobData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool JobDataSpecified => JobData != null;

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitData ResidencePermitData
    {
        get { return _residencePermitData; }
        set { _residencePermitData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
