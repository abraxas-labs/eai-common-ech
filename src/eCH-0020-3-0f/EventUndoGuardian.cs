// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventUndoGuardian.
/// </summary>
[Serializable]
[JsonObject("eventUndoGuardian")]
[XmlRoot(ElementName = "eventUndoGuardian", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventUndoGuardian
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string GuardianRelationshipIdValidateExceptionMessage = "GuardianRelationshipId is not valid! GuardianRelationshipId has maximal lenght of 36";

    private PersonIdentification _undoGuardianPerson;
    private string _guardianRelationshipId;

    public EventUndoGuardian()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoGuardianPerson">Field is required.</param>
    /// <param name="guardianRelationshipId">Field is reqired.</param>
    /// <param name="undoGuardianValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventUndoGuardian Create(PersonIdentification undoGuardianPerson, string guardianRelationshipId, DateTime? undoGuardianValidFrom = null, object extension = null)
    {
        return new EventUndoGuardian()
        {
            UndoGuardianPerson = undoGuardianPerson,
            GuardianRelationshipId = guardianRelationshipId,
            UndoGuardianValidFrom = undoGuardianValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("undoGuardianPerson")]
    [XmlElement(ElementName = "undoGuardianPerson")]
    public PersonIdentification UndoGuardianPerson
    {
        get { return _undoGuardianPerson; }
        set { _undoGuardianPerson = value; }
    }

    [JsonProperty("guardianRelationshipId")]
    [XmlElement(ElementName = "guardianRelationshipId")]
    public string GuardianRelationshipId
    {
        get { return _guardianRelationshipId; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 36)
            {
                throw new XmlSchemaValidationException(GuardianRelationshipIdValidateExceptionMessage);
            }
            _guardianRelationshipId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianRelationshipIdSpecified => !string.IsNullOrWhiteSpace(GuardianRelationshipId);

    [JsonProperty("undoGuardianValidFrom")]
    [XmlElement(DataType = "date", ElementName = "undoGuardianValidFrom")]
    public DateTime? UndoGuardianValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoGuardianValidFromSpecified => UndoGuardianValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
