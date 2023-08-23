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
/// EventChangeGuardian.
/// </summary>
[Serializable]
[JsonObject("eventChangeGuardian")]
[XmlRoot(ElementName = "eventChangeGuardian", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeGuardian
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeGuardianPersonNullValidateExceptionMessage = "ChangeGuardianPerson is not valid! ChangeGuardianPerson is required";
    private const string RelationshipNullValidateExceptionMessage = "Relationship is not valid! Relationship is required";

    private PersonIdentification _changeGuardianPerson;
    private GuardianRelationship _relationship;

    public EventChangeGuardian()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeGuardianPerson">Field is required.</param>
    /// <param name="relationship">Field is reqired.</param>
    /// <param name="changeGuardianValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeGuardian Create(PersonIdentification changeGuardianPerson, GuardianRelationship relationship, DateTime? changeGuardianValidFrom = null, object extension = null)
    {
        return new EventChangeGuardian()
        {
            ChangeGuardianPerson = changeGuardianPerson,
            Relationship = relationship,
            ChangeGuardianValidFrom = changeGuardianValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("changeGuardianPerson")]
    [XmlElement(ElementName = "changeGuardianPerson")]
    public PersonIdentification ChangeGuardianPerson
    {
        get { return _changeGuardianPerson; }

        set
        {
            _changeGuardianPerson = value ?? throw new XmlSchemaValidationException(ChangeGuardianPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("relationship")]
    [XmlElement(ElementName = "relationship")]
    public GuardianRelationship Relationship
    {
        get { return _relationship; }

        set
        {
            _relationship = value ?? throw new XmlSchemaValidationException(RelationshipNullValidateExceptionMessage);
        }
    }

    [JsonProperty("changeGuardianValidFrom")]
    [XmlElement(DataType = "date", ElementName = "changeGuardianValidFrom")]
    public DateTime? ChangeGuardianValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeGuardianValidFromSpecified => ChangeGuardianValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
