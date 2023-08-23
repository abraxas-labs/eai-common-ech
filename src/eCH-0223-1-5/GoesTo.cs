// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0223_1_5;

[Serializable]
[JsonObject("goesTo")]
[XmlType(TypeName = "goesToType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class GoesTo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MunicipalityNameValidateExceptionMessage = "municipalityName is not valid! municipalityName cannot be null and the length must be less or equal than 40 characters";
    private const string CountryNameShortValidateExceptionMessage = "countryNameShort is not valid! countryNameShort cannot be null";

    private string _municipalityName;
    private string _countryNameShort;

    public GoesTo()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    /// <summary>
    /// Creates the specified GoesTo.
    /// </summary>
    /// <param name="municipalityName">Name of the municipality.</param>
    /// <param name="departureDate">The departure date.</param>
    /// <param name="countryNameShort">The country name short.</param>
    /// <param name="cantonAbbreviation">The canton abbreviation.</param>
    /// <returns></returns>
    public static GoesTo Create(string municipalityName, DateTime departureDate, string countryNameShort, string cantonAbbreviation)
    {
        return new GoesTo
        {
            MunicipalityName = municipalityName,
            DepartureDate = departureDate,
            CountryNameShort = countryNameShort,
            CantonAbbreviation = cantonAbbreviation
        };
    }

    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName")]
    public string MunicipalityName
    {
        get { return _municipalityName; }

        set
        {
            if (value == null || value.Length > 40)
            {
                throw new XmlSchemaValidationException(MunicipalityNameValidateExceptionMessage);
            }

            _municipalityName = value;
        }
    }

    [JsonProperty("departureDate")]
    [XmlElement(DataType = "date", ElementName = "departureDate")]
    public DateTime DepartureDate { get; set; }

    [JsonProperty("countryNameShort")]
    [XmlElement(ElementName = "countryNameShort")]
    public string CountryNameShort
    {
        get { return _countryNameShort; }

        set
        {
            _countryNameShort = value ?? throw new XmlSchemaValidationException(CountryNameShortValidateExceptionMessage);
        }
    }

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation")]
    public string CantonAbbreviation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation != null;
}
