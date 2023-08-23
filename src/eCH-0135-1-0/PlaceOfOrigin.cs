// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0135_1_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Heimatort (eCH-0135)
/// Die Heimatorte werden in vielen Prozessen der öffentlichen Verwaltung verwendet.
/// </summary>
[Serializable]
[JsonObject("placeOfOrigin")]
[XmlRoot(ElementName = "placeOfOrigin", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0135/1")]
public class PlaceOfOrigin
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceOfOriginIdNullValidateExceptionMessage = "PlaceOfOriginId is not valid! PlaceOfOriginId is required";
    private const string PlaceOfOriginNameNullValidateExceptionMessage = "PlaceOfOriginName is not valid! PlaceOfOriginId is required";

    private int _placeOfOriginId;
    private string _placeOfOriginName;

    public PlaceOfOrigin()
    {
        Xmlns.Add("eCH-0135", "http://www.ech.ch/xmlns/eCH-0135/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="validFrom">Field can be null.</param>
    /// <param name="validTo">Field can be null.</param>
    /// <param name="placeOfOriginId">Field is reqired.</param>
    /// <param name="historyMunicipalityId">Field can be null.</param>
    /// <param name="placeOfOriginName">Field is reqired.</param>
    /// <param name="cantonAbbreviation">Field is reqired.</param>
    /// <param name="successorId">Field can be null.</param>
    /// <returns>PlaceOfOrigin.</returns>
    public static PlaceOfOrigin Create(DateTime? validFrom, DateTime? validTo, int placeOfOriginId, int? historyMunicipalityId, string placeOfOriginName, CantonAbbreviation cantonAbbreviation, int? successorId)
    {
        return new PlaceOfOrigin()
        {
            ValidFrom = validFrom,
            ValidTo = validTo,
            PlaceOfOriginId = placeOfOriginId,
            HistoryMunicipalityId = historyMunicipalityId,
            PlaceOfOriginName = placeOfOriginName,
            CantonAbbreviation = cantonAbbreviation,
            SuccessorId = successorId
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="placeOfOriginId">Field is reqired.</param>
    /// <param name="placeOfOriginName">Field is reqired.</param>
    /// <param name="cantonAbbreviation">Field is reqired.</param>
    /// <returns>PlaceOfOrigin.</returns>
    public static PlaceOfOrigin Create(int placeOfOriginId, string placeOfOriginName, CantonAbbreviation cantonAbbreviation)
    {
        return new PlaceOfOrigin()
        {
            ValidFrom = null,
            ValidTo = null,
            PlaceOfOriginId = placeOfOriginId,
            HistoryMunicipalityId = null,
            PlaceOfOriginName = placeOfOriginName,
            CantonAbbreviation = cantonAbbreviation,
            SuccessorId = null
        };
    }

    [JsonProperty("validFrom")]
    [XmlElement(DataType = "date", ElementName = "validFrom", Order = 1)]
    public DateTime? ValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ValidFromSpecified => ValidFrom != null;

    [JsonProperty("validTo")]
    [XmlElement(DataType = "date", ElementName = "validTo", Order = 2)]
    public DateTime? ValidTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ValidToSpecified => ValidTo != null;

    [JsonProperty("placeOfOriginId")]
    [XmlElement(ElementName = "placeOfOriginId", Order = 3)]
    public int PlaceOfOriginId
    {
        get { return _placeOfOriginId; }

        set
        {
            if (value < 1)
            {
                throw new XmlSchemaValidationException(PlaceOfOriginIdNullValidateExceptionMessage);
            }
            _placeOfOriginId = value;
        }
    }

    [JsonProperty("historyMunicipalityId")]
    [XmlElement(ElementName = "historyMunicipalityId", Order = 4)]
    public int? HistoryMunicipalityId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HistoryMunicipalityIdSpecified => HistoryMunicipalityId.HasValue;

    [JsonProperty("placeOfOriginName")]
    [XmlElement(ElementName = "placeOfOriginName", Order = 5)]
    public string PlaceOfOriginName
    {
        get { return _placeOfOriginName; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(PlaceOfOriginNameNullValidateExceptionMessage);
            }
            _placeOfOriginName = value;
        }
    }

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 6)]
    public CantonAbbreviation CantonAbbreviation { get; set; }

    [JsonProperty("successorId")]
    [XmlElement(ElementName = "successorId", Order = 7)]
    public int? SuccessorId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SuccessorIdSpecified => SuccessorId.HasValue;
}
