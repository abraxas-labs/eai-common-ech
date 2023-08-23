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
/// EventMoveOut.
/// </summary>
[XmlInclude(typeof(EventMoveOutExtension))]

[Serializable]
[JsonObject("eventMoveOut")]
[XmlRoot(ElementName = "eventMoveOut", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventMoveOut
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _moveOutPerson;
    private ReportingMunicipalityRestrictedMoveOut _moveOutReportingDestination;

    public EventMoveOut()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="moveOutPerson">Field is required.</param>
    /// <param name="moveOutReportingDestination">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMoveOut Create(eCH_0044_4_1.PersonIdentification moveOutPerson, eCH_0020_3_0.ReportingMunicipalityRestrictedMoveOut moveOutReportingDestination, object extension = null)
    {
        return new EventMoveOut()
        {
            MoveOutPerson = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(moveOutPerson),
            MoveOutReportingDestination = Mapper.ECHtoECHf.GetReportingMunicipalityRestrictedMoveOut(moveOutReportingDestination),
            Extension = extension
        };
    }

    [JsonProperty("moveOutPerson")]
    [XmlElement(ElementName = "moveOutPerson")]
    public PersonIdentification MoveOutPerson
    {
        get { return _moveOutPerson; }
        set { _moveOutPerson = value; }
    }

    [JsonProperty("moveOutReportingDestination")]
    [XmlElement(ElementName = "moveOutReportingDestination")]
    public ReportingMunicipalityRestrictedMoveOut MoveOutReportingDestination
    {
        get { return _moveOutReportingDestination; }
        set { _moveOutReportingDestination = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
