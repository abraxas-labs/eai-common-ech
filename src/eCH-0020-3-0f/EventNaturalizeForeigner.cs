// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventAdoption.
/// </summary>
[Serializable]
[JsonObject("eventNaturalizeForeigner")]
[XmlRoot(ElementName = "eventNaturalizeForeigner", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventNaturalizeForeigner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _naturalizeForeignerPerson;
    private List<PlaceOfOriginInfo> _placeOfOriginInfos;
    private SwissNationality _nationality;

    public EventNaturalizeForeigner()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="naturalizeForeignerPerson">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is optional.</param>
    /// <param name="nationality">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventNaturalizeForeigner Create(PersonIdentification naturalizeForeignerPerson, List<PlaceOfOriginInfo> placeOfOriginInfos, SwissNationality nationality, object extension = null)
    {
        return new EventNaturalizeForeigner()
        {
            NaturalizeForeignerPerson = naturalizeForeignerPerson,
            PlaceOfOriginInfos = placeOfOriginInfos,
            Nationality = nationality,
            Extension = extension
        };
    }

    [JsonProperty("naturalizeForeignerPerson")]
    [XmlElement(ElementName = "naturalizeForeignerPerson")]
    public PersonIdentification NaturalizeForeignerPerson
    {
        get { return _naturalizeForeignerPerson; }
        set { _naturalizeForeignerPerson = value; }
    }

    [JsonProperty("placeOfOriginInfo")]
    [XmlElement(ElementName = "placeOfOriginInfo")]
    public List<PlaceOfOriginInfo> PlaceOfOriginInfos
    {
        get { return _placeOfOriginInfos; }
        set { _placeOfOriginInfos = value; }
    }

    [JsonProperty("nationality")]
    [XmlElement(ElementName = "nationality")]
    public SwissNationality Nationality
    {
        get { return _nationality; }
        set { _nationality = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
