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
/// EventPaperLock.
/// </summary>
[Serializable]
[JsonObject("eventPaperLock")]
[XmlRoot(ElementName = "eventPaperLock", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventPaperLock
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _paperLockPerson;

    public EventPaperLock()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="paperLockPerson">Field is required.</param>
    /// <param name="paperLock">Field is reqired.</param>
    /// <param name="paperLockValidTill">Field is optional.</param>
    /// <param name="paperLockValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventPaperLock Create(PersonIdentification paperLockPerson, YesNo paperLock, DateTime? paperLockValidFrom = null, DateTime? paperLockValidTill = null, object extension = null)
    {
        return new EventPaperLock()
        {
            PaperLockPerson = paperLockPerson,
            PaperLock = paperLock,
            PaperLockValidFrom = paperLockValidFrom,
            PaperLockValidTill = paperLockValidTill,
            Extension = extension
        };
    }

    [JsonProperty("paperLockPerson")]
    [XmlElement(ElementName = "paperLockPerson")]
    public PersonIdentification PaperLockPerson
    {
        get { return _paperLockPerson; }
        set { _paperLockPerson = value; }
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
