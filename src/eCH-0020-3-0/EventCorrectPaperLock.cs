﻿// (c) Copyright 2023 by Abraxas Informatik AG
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
/// EventPaperLock.
/// </summary>
[Serializable]
[JsonObject("eventCorrectPaperLock")]
[XmlRoot(ElementName = "eventCorrectPaperLock", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectPaperLock
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectPaperLockPersonNullValidateExceptionMessage = "CorrectPaperLockPerson is not valid! CorrectPaperLockPerson is required";

    private PersonIdentification _correctPaperLockPerson;

    public EventCorrectPaperLock()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctPaperLockPerson">Field is required.</param>
    /// <param name="paperLock">Field is reqired.</param>
    /// <param name="paperLockValidTill">Field is optional.</param>
    /// <param name="paperLockValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectPaperLock Create(PersonIdentification correctPaperLockPerson, YesNo paperLock, DateTime? paperLockValidFrom = null, DateTime? paperLockValidTill = null, object extension = null)
    {
        return new EventCorrectPaperLock()
        {
            CorrectPaperLockPerson = correctPaperLockPerson,
            PaperLock = paperLock,
            PaperLockValidFrom = paperLockValidFrom,
            PaperLockValidTill = paperLockValidTill,
            Extension = extension
        };
    }

    [JsonProperty("correctPaperLockPerson")]
    [XmlElement(ElementName = "correctPaperLockPerson")]
    public PersonIdentification CorrectPaperLockPerson
    {
        get { return _correctPaperLockPerson; }

        set
        {
            _correctPaperLockPerson = value ?? throw new XmlSchemaValidationException(CorrectPaperLockPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("paperLock")]
    [XmlElement(ElementName = "paperLock")]
    public YesNo PaperLock { get; set; }

    [JsonProperty("paperLockValidFrom")]
    [XmlElement(DataType = "date", ElementName = "paperLockValidFrom")]
    public DateTime? PaperLockValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PaperLockValidFromSpecified => PaperLockValidFrom.HasValue;

    [JsonProperty("paperLockValidTill")]
    [XmlElement(DataType = "date", ElementName = "paperLockValidTill")]
    public DateTime? PaperLockValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PaperLockValidTillSpecified => PaperLockValidTill.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
