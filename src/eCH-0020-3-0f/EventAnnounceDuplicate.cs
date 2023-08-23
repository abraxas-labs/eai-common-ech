// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventAnnounceDuplicate.
/// </summary>
[Serializable]
[JsonObject("eventAnnounceDuplicate")]
[XmlRoot(ElementName = "eventAnnounceDuplicate", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventAnnounceDuplicate
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctEntry;
    private List<PersonIdentification> _duplicateEntrys;

    public EventAnnounceDuplicate()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctEntry">Field is required.</param>
    /// <param name="duplicateEntrys">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventAnnounceDuplicate Create(PersonIdentification correctEntry, List<PersonIdentification> duplicateEntrys, object extension = null)
    {
        return new EventAnnounceDuplicate()
        {
            CorrectEntry = correctEntry,
            DuplicateEntrys = duplicateEntrys,
            Extension = extension
        };
    }

    [JsonProperty("correctEntry")]
    [XmlElement(ElementName = "correctEntry")]
    public PersonIdentification CorrectEntry
    {
        get { return _correctEntry; }
        set { _correctEntry = value; }
    }

    [JsonProperty("duplicateEntry")]
    [XmlElement(ElementName = "duplicateEntry")]
    public List<PersonIdentification> DuplicateEntrys
    {
        get { return _duplicateEntrys; }
        set { _duplicateEntrys = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
