// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventUndoMissing.
/// </summary>
[Serializable]
[JsonObject("eventUndoMissing")]
[XmlRoot(ElementName = "eventUndoMissing", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventUndoMissing
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _undoMissingPerson;

    public EventUndoMissing()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoMissingPerson">Field is required.</param>
    /// <param name="undoMissingValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventUndoMissing Create(PersonIdentification undoMissingPerson, DateTime? undoMissingValidFrom = null, object extension = null)
    {
        return new EventUndoMissing()
        {
            UndoMissingPerson = undoMissingPerson,
            UndoMissingValidFrom = undoMissingValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("undoMissingPerson")]
    [XmlElement(ElementName = "undoMissingPerson")]
    public PersonIdentification UndoMissingPerson
    {
        get { return _undoMissingPerson; }
        set { _undoMissingPerson = value; }
    }

    [JsonProperty("undoMissingValidFrom")]
    [XmlElement(DataType = "date", ElementName = "undoMissingValidFrom")]
    public DateTime? UndoMissingValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoMissingValidFromSpecified => UndoMissingValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
