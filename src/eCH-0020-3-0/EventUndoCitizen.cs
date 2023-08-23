// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventUndoCitizen.
/// </summary>
[Serializable]
[JsonObject("eventUndoCitizen")]
[XmlRoot(ElementName = "eventUndoCitizen", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventUndoCitizen
{
    [JsonIgnore]
    [XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    private const string UndoCitizenPersonNullValidateExceptionMessage = "UndoCitizenPerson is not valid! UndoCitizenPerson is required";
    private const string PlaceOfOriginsNullValidateExceptionMessage = "PlaceOfOrigin is not valid! PlaceOfOrigin is required";

    private PlaceOfOrigin _placeOfOrigin;
    private PersonIdentification _undoCitizenPerson;

    public EventUndoCitizen()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoCitizenPerson">Field is required.</param>
    /// <param name="placeOfOrigin">Field is required.</param>
    /// <param name="placeOfOriginAddon">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventUndoCitizen Create(PersonIdentification undoCitizenPerson, PlaceOfOrigin placeOfOrigin, PlaceOfOriginAddonRestrictedUnDoData placeOfOriginAddon = null, object extension = null)
    {
        return new EventUndoCitizen()
        {
            UndoCitizenPerson = undoCitizenPerson,
            PlaceOfOrigin = placeOfOrigin,
            PlaceOfOriginAddon = placeOfOriginAddon,
            Extension = extension
        };
    }

    [JsonProperty("undoCitizenPerson")]
    [XmlElement(ElementName = "undoCitizenPerson")]
    public PersonIdentification UndoCitizenPerson
    {
        get { return _undoCitizenPerson; }

        set
        {
            _undoCitizenPerson = value ?? throw new XmlSchemaValidationException(UndoCitizenPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin")]
    public PlaceOfOrigin PlaceOfOrigin
    {
        get { return _placeOfOrigin; }

        set
        {
            _placeOfOrigin = value ?? throw new XmlSchemaValidationException(PlaceOfOriginsNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOriginAddon")]
    [XmlElement(ElementName = "placeOfOriginAddon")]
    public PlaceOfOriginAddonRestrictedUnDoData PlaceOfOriginAddon { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginAddonSpecified => PlaceOfOriginAddon != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
