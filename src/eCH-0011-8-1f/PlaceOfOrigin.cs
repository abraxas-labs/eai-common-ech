// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Heimatort (eCH-0011)
/// Die Heimatorte werden in vielen Prozessen der öffentlichen Verwaltung verwendet.
/// </summary>
[Serializable]
[JsonObject("placeOfOrigin")]
[XmlRoot(ElementName = "placeOfOrigin", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class PlaceOfOrigin
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceOfOriginIdNullValidateExceptionMessage = "PlaceOfOriginId is not valid! PlaceOfOriginId is required";

    private int? _placeOfOriginId;
    private string _originName;

    public PlaceOfOrigin()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="originName">Field is reqired.</param>
    /// <param name="cantonAbbreviation">Field is reqired.</param>
    /// <param name="placeOfOriginId">Field is optional.</param>
    /// <param name="historyMunicipalityId">Field is optional.</param>
    /// <returns>PlaceOfOrigin.</returns>
    public static PlaceOfOrigin Create(string originName, eCH_0007_5_0.CantonAbbreviation cantonAbbreviation, int? placeOfOriginId = null, int? historyMunicipalityId = null)
    {
        return new PlaceOfOrigin()
        {
            OriginName = originName,
            CantonAbbreviation = (eCH_0007_5_0f.CantonAbbreviation?)Enum.Parse(typeof(eCH_0007_5_0f.CantonAbbreviation), cantonAbbreviation.ToString()),
            PlaceOfOriginId = placeOfOriginId,
            HistoryMunicipalityId = historyMunicipalityId,
        };
    }

    [JsonProperty("originName")]
    [XmlElement(ElementName = "originName")]
    public string OriginName
    {
        get { return _originName; }
        set { _originName = value; }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OriginNameSpecified => !string.IsNullOrEmpty(OriginName);

    [JsonProperty("canton")]
    [XmlElement(ElementName = "canton")]
    public eCH_0007_5_0f.CantonAbbreviation? CantonAbbreviation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation.HasValue;

    [JsonProperty("placeOfOriginId")]
    [XmlElement(ElementName = "placeOfOriginId")]
    public int? PlaceOfOriginId
    {
        get { return _placeOfOriginId; }

        set
        {
            if (value.HasValue && value < 1)
            {
                throw new XmlSchemaValidationException(PlaceOfOriginIdNullValidateExceptionMessage);
            }
            _placeOfOriginId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginIdSpecified => PlaceOfOriginId.HasValue;

    [JsonProperty("historyMunicipalityId")]
    [XmlElement(ElementName = "historyMunicipalityId")]
    public int? HistoryMunicipalityId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HistoryMunicipalityIdSpecified => HistoryMunicipalityId.HasValue;
}
