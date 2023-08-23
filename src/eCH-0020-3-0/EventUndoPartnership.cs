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
/// EventUndoMarriage.
/// </summary>
[Serializable]
[JsonObject("eventUndoPartnership")]
[XmlRoot(ElementName = "eventUndoPartnership", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventUndoPartnership
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UndoPartnershipPersonNullValidateExceptionMessage = "UndoPartnershipPerson is not valid! UndoPartnershipPerson is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";

    private PersonIdentification _undoPartnershipPerson;
    private MaritalDataRestrictedUndoPartnership _maritalData;

    public EventUndoPartnership()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoPartnershipPerson">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventUndoPartnership Create(PersonIdentification undoPartnershipPerson, MaritalDataRestrictedUndoPartnership maritalData, object extension = null)
    {
        return new EventUndoPartnership()
        {
            UndoPartnershipPerson = undoPartnershipPerson,
            MaritalData = maritalData,
            Extension = extension
        };
    }

    [JsonProperty("undoPartnershipPerson")]
    [XmlElement(ElementName = "undoPartnershipPerson")]
    public PersonIdentification UndoPartnershipPerson
    {
        get { return _undoPartnershipPerson; }

        set
        {
            _undoPartnershipPerson = value ?? throw new XmlSchemaValidationException(UndoPartnershipPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataRestrictedUndoPartnership MaritalData
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
