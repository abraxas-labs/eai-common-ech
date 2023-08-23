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
[JsonObject("eventNaturalizeSwiss")]
[XmlRoot(ElementName = "eventNaturalizeSwiss", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventNaturalizeSwiss
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NaturalizeSwissPersonNullValidateExceptionMessage = "NaturalizeSwissPerson is not valid! NaturalizeSwissPerson is required";
    private const string PlaceOfOriginInfosNullValidateExceptionMessage = "PlaceOfOriginInfo is not valid! PlaceOfOriginInfo is required";

    private PlaceOfOriginInfo[] _placeOfOriginInfos;
    private PersonIdentification _naturalizeSwissPerson;

    public EventNaturalizeSwiss()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="naturalizeSwissPerson">Field is required.</param>
    /// <param name="placeOfOriginInfos">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventAdoption.</returns>
    public static EventNaturalizeSwiss Create(PersonIdentification naturalizeSwissPerson, List<PlaceOfOriginInfo> placeOfOriginInfos, object extension = null)
    {
        return new EventNaturalizeSwiss()
        {
            NaturalizeSwissPerson = naturalizeSwissPerson,
            PlaceOfOriginInfos = (placeOfOriginInfos != null) ? placeOfOriginInfos.ToArray() : null,
            Extension = extension
        };
    }

    [JsonProperty("naturalizeSwissPerson")]
    [XmlElement(ElementName = "naturalizeSwissPerson")]
    public PersonIdentification NaturalizeSwissPerson
    {
        get { return _naturalizeSwissPerson; }

        set
        {
            _naturalizeSwissPerson = value ?? throw new XmlSchemaValidationException(NaturalizeSwissPersonNullValidateExceptionMessage);
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

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
