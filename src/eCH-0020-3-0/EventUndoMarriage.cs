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
/// EventUndoMarriage.
/// </summary>
[Serializable]
[JsonObject("eventUndoMarriage")]
[XmlRoot(ElementName = "eventUndoMarriage", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventUndoMarriage
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UndoMarriagePersonNullValidateExceptionMessage = "UndoMarriagePerson is not valid! UndoMarriagePerson is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";

    private PersonIdentification _undoMarriagePerson;
    private MaritalDataRestrictedUndoMarried _maritalData;

    public EventUndoMarriage()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoMarriagePerson">Field is required.</param>
    /// <param name="maritalData">Fueld is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventUndoMarriage Create(PersonIdentification undoMarriagePerson, MaritalDataRestrictedUndoMarried maritalData, object extension = null)
    {
        return new EventUndoMarriage()
        {
            UndoMarriagePerson = undoMarriagePerson,
            MaritalData = maritalData,
            Extension = extension
        };
    }

    [JsonProperty("undoMarriagePerson")]
    [XmlElement(ElementName = "undoMarriagePerson")]
    public PersonIdentification UndoMarriagePerson
    {
        get { return _undoMarriagePerson; }

        set
        {
            _undoMarriagePerson = value ?? throw new XmlSchemaValidationException(UndoMarriagePersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataRestrictedUndoMarried MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
