﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventMove.
/// </summary>
[Serializable]
[JsonObject("eventMove")]
[XmlRoot(ElementName = "eventMove", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventMove
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _movePerson;
    private ReportingMunicipalityRestrictedMove _moveReportingMunicipality;

    public EventMove()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="movePerson">Field is required.</param>
    /// <param name="moveReportingMunicipality">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMove Create(PersonIdentification movePerson, ReportingMunicipalityRestrictedMove moveReportingMunicipality, object extension = null)
    {
        return new EventMove()
        {
            MovePerson = movePerson,
            MoveReportingMunicipality = moveReportingMunicipality,
            Extension = extension
        };
    }

    [JsonProperty("movePerson")]
    [XmlElement(ElementName = "movePerson")]
    public PersonIdentification MovePerson
    {
        get { return _movePerson; }
        set { _movePerson = value; }
    }

    [JsonProperty("moveReportingMunicipality")]
    [XmlElement(ElementName = "moveReportingMunicipality")]
    public ReportingMunicipalityRestrictedMove MoveReportingMunicipality
    {
        get { return _moveReportingMunicipality; }
        set { _moveReportingMunicipality = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
