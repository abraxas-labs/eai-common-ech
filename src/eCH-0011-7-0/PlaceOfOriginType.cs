// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0;
using eCH_0135_1_0;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("placeOfOriginType")]
[XmlRoot(ElementName = "placeOfOriginType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class PlaceOfOriginType : FieldValueChecker<SwissType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _originName;
    private CantonAbbreviation _canton;
    private PlaceOfOrigin _placeOfOriginId;
    private int? _historyMunicipalityId;

    public PlaceOfOriginType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="originName">Field is required.</param>
    /// <param name="canton">Field is optional.</param>
    /// <param name="placeOfOriginId">Field is optional.</param>
    /// <param name="historyMunicipalityId">Field is optional.</param>
    /// <returns>SwissType.</returns>
    public static PlaceOfOriginType Create(string originName, CantonAbbreviation canton, PlaceOfOrigin placeOfOriginId, int? historyMunicipalityId)
    {
        return new PlaceOfOriginType
        {
            OriginName = originName,
            Canton = canton,
            PlaceOfOriginId = placeOfOriginId,
            HistoryMunicipalityId = historyMunicipalityId
        };
    }

    [FieldRequired]
    [JsonProperty("originName")]
    [XmlElement(ElementName = "originName")]
    public string OriginName
    {
        get => _originName;
        set => CheckAndSetValue(ref _originName, value);
    }

    [JsonProperty("canton")]
    [XmlElement(ElementName = "canton")]
    public CantonAbbreviation Canton
    {
        get => _canton;
        set => CheckAndSetValue(ref _canton, value);
    }

    [JsonProperty("placeOfOriginId")]
    [XmlElement(ElementName = "placeOfOriginId")]
    public PlaceOfOrigin PlaceOfOriginId
    {
        get => _placeOfOriginId;
        set => CheckAndSetValue(ref _placeOfOriginId, value);
    }

    [JsonProperty("historyMunicipalityId")]
    [XmlElement(ElementName = "historyMunicipalityId")]
    public int? HistoryMunicipalityId
    {
        get => _historyMunicipalityId;
        set => CheckAndSetValue(ref _historyMunicipalityId, value);
    }
}
