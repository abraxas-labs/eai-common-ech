// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Heimatort (eCH-0011)
/// Die Heimatorte werden in vielen Prozessen der öffentlichen Verwaltung verwendet.
/// </summary>
[Serializable]
[JsonObject("placeOfOrigin")]
[XmlRoot(ElementName = "placeOfOrigin", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class PlaceOfOrigin
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceOfOriginIdNullValidateExceptionMessage = "PlaceOfOriginId is not valid! PlaceOfOriginId is required";
    private const string OriginNameNullValidateExceptionMessage = "OriginName is not valid! OriginName is required";

    private int? _placeOfOriginId;
    private string _originName;

    public PlaceOfOrigin()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
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
    public static PlaceOfOrigin Create(string originName, CantonAbbreviation cantonAbbreviation, int? placeOfOriginId = null, int? historyMunicipalityId = null)
    {
        return new PlaceOfOrigin()
        {
            OriginName = originName,
            CantonAbbreviation = cantonAbbreviation,
            PlaceOfOriginId = placeOfOriginId,
            HistoryMunicipalityId = historyMunicipalityId,
        };
    }

    [JsonProperty("originName")]
    [XmlElement(ElementName = "originName", Order = 1)]
    public string OriginName
    {
        get { return _originName; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(OriginNameNullValidateExceptionMessage);
            }
            _originName = value;
        }
    }

    [JsonProperty("canton")]
    [XmlElement(ElementName = "canton", Order = 2)]
    public CantonAbbreviation CantonAbbreviation { get; set; }

    [JsonProperty("placeOfOriginId")]
    [XmlElement(ElementName = "placeOfOriginId", Order = 3)]
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
    [XmlElement(ElementName = "historyMunicipalityId", Order = 4)]
    public int? HistoryMunicipalityId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HistoryMunicipalityIdSpecified => HistoryMunicipalityId.HasValue;
}
