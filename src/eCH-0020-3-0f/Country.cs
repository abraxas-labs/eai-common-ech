// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Staatsangehörigkeitsangaben (Nur Schweizer).
/// </summary>
[Serializable]
[JsonObject("country")]
[XmlRoot(ElementName = "country", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class Country
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CountryIdValidateExceptionMessage = "CountryId is not valid! CountryId has to be a Value of 8100";
    private const string CountryIdISO2ValidateExceptionMessage = "CountryIdISO2 is not valid! CountryIdISO2 has to be a Value of CH";

    private int? _countryId;
    private string _countryIdISO2;

    public Country()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="countryId">Field is required.</param>
    /// <param name="countryIdISO2">Field is required.</param>
    /// <returns>Country.</returns>
    public static Country Create(int countryId, string countryIdISO2)
    {
        return new Country()
        {
            CountryId = countryId,
            CountryIdISO2 = countryIdISO2
        };
    }

    [JsonProperty("countryId")]
    [XmlElement(ElementName = "countryId")]
    public int? CountryId
    {
        get { return _countryId; }

        set
        {
            if (value != 8100)
            {
                throw new XmlSchemaValidationException(CountryIdValidateExceptionMessage);
            }
            _countryId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdSpecified => CountryId.HasValue;

    [JsonProperty("countryIdISO2")]
    [XmlElement(ElementName = "countryIdISO2")]
    public string CountryIdISO2
    {
        get { return _countryIdISO2; }

        set
        {
            if (value != null && value != "CH")
            {
                throw new XmlSchemaValidationException(CountryIdISO2ValidateExceptionMessage);
            }
            _countryIdISO2 = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountryIdISO2Specified => !string.IsNullOrWhiteSpace(CountryIdISO2);
}
