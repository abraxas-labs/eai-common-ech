// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectPlaceOfOrigin.
/// </summary>
[Serializable]
[JsonObject("eventCorrectPlaceOfOrigin")]
[XmlRoot(ElementName = "eventCorrectPlaceOfOrigin", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectPlaceOfOrigin
{
    [JsonIgnore]
    [XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectPlaceOfOriginPersonNullValidateExceptionMessage = "CorrectPlaceOfOriginPerson is not valid! CorrectPlaceOfOriginPerson is required";

    private PersonIdentification _correctPlaceOfOriginPerson;

    public EventCorrectPlaceOfOrigin()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctPlaceOfOriginPerson">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventCorrectPlaceOfOrigin.</returns>
    public static EventCorrectPlaceOfOrigin Create(PersonIdentification correctPlaceOfOriginPerson, List<PlaceOfOriginInfo> placeOfOriginInfos = null, object extension = null)
    {
        return new EventCorrectPlaceOfOrigin()
        {
            CorrectPlaceOfOriginPerson = correctPlaceOfOriginPerson,
            PlaceOfOriginInfos = placeOfOriginInfos,
            Extension = extension
        };
    }

    [JsonProperty("correctPlaceOfOriginPerson")]
    [XmlElement(ElementName = "correctPlaceOfOriginPerson")]
    public PersonIdentification CorrectPlaceOfOriginPerson
    {
        get { return _correctPlaceOfOriginPerson; }

        set
        {
            _correctPlaceOfOriginPerson = value ?? throw new XmlSchemaValidationException(CorrectPlaceOfOriginPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOriginInfo")]
    [XmlElement(ElementName = "placeOfOriginInfo")]
    public List<PlaceOfOriginInfo> PlaceOfOriginInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginInfosSpecified => PlaceOfOriginInfos != null && PlaceOfOriginInfos.Any();

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
