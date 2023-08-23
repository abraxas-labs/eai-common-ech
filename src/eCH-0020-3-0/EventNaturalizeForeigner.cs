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
/// EventAdoption.
/// </summary>
[Serializable]
[JsonObject("eventNaturalizeForeigner")]
[XmlRoot(ElementName = "eventNaturalizeForeigner", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventNaturalizeForeigner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NaturalizeForeignerPersonNullValidateExceptionMessage = "NaturalizeForeignerPerson is not valid! NaturalizeForeignerPerson is required";
    private const string PlaceOfOriginInfosNullValidateExceptionMessage = "PlaceOfOriginInfo is not valid! PlaceOfOriginInfo is required";
    private const string NationalityNullValidateExceptionMessage = "Nationality is not valid! Nationality is required";

    private PersonIdentification _naturalizeForeignerPerson;
    private PlaceOfOriginInfo[] _placeOfOriginInfos;
    private SwissNationality _nationality;

    public EventNaturalizeForeigner()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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
            PlaceOfOriginInfos = (placeOfOriginInfos != null) ? placeOfOriginInfos.ToArray() : null,
            Nationality = nationality,
            Extension = extension
        };
    }

    [JsonProperty("naturalizeForeignerPerson")]
    [XmlElement(ElementName = "naturalizeForeignerPerson")]
    public PersonIdentification NaturalizeForeignerPerson
    {
        get { return _naturalizeForeignerPerson; }

        set
        {
            _naturalizeForeignerPerson = value ?? throw new XmlSchemaValidationException(NaturalizeForeignerPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOriginInfo")]
    [XmlElement(ElementName = "placeOfOriginInfo")]
    public PlaceOfOriginInfo[] PlaceOfOriginInfos
    {
        get { return _placeOfOriginInfos; }

        set
        {
            _placeOfOriginInfos = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(PlaceOfOriginInfosNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nationality")]
    [XmlElement(ElementName = "nationality")]
    public SwissNationality Nationality
    {
        get { return _nationality; }

        set
        {
            _nationality = value ?? throw new XmlSchemaValidationException(NationalityNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
