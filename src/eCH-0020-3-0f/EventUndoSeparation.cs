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
/// EventUndoSeparation.
/// </summary>
[Serializable]
[JsonObject("eventUndoSeparation")]
[XmlRoot(ElementName = "eventUndoSeparation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventUndoSeparation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _undoSeparationPerson;

    public EventUndoSeparation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoSeparationPerson">Field is required.</param>
    /// <param name="separationValidTill">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventUndoSwiss.</returns>
    public static EventUndoSeparation Create(PersonIdentification undoSeparationPerson, DateTime? separationValidTill = null, object extension = null)
    {
        return new EventUndoSeparation()
        {
            UndoSeparationPerson = undoSeparationPerson,
            SeparationValidTill = separationValidTill,
            Extension = extension
        };
    }

    [JsonProperty("undoSeparationPerson")]
    [XmlElement(ElementName = "undoSeparationPerson")]
    public PersonIdentification UndoSeparationPerson
    {
        get { return _undoSeparationPerson; }
        set { _undoSeparationPerson = value; }
    }

    [JsonProperty("separationValidTill")]
    [XmlElement(DataType = "date", ElementName = "separationValidTill")]
    public DateTime? SeparationValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationValidTillSpecified => SeparationValidTill.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
