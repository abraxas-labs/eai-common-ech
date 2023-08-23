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
[JsonObject("swissNationality")]
[XmlRoot(ElementName = "swissNationality", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class SwissNationality
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NationalityStatusValidateExceptionMessage = "CountryId is not valid! CountryId has to be a Value of 2";

    private string _nationalityStatus;
    private Country _country;

    public SwissNationality()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nationalityStatus">Field is required.</param>
    /// <param name="country">Field is required.</param>
    /// <returns>Country.</returns>
    public static SwissNationality Create(string nationalityStatus, Country country)
    {
        return new SwissNationality()
        {
            NationalityStatus = nationalityStatus,
            Country = country
        };
    }

    [JsonProperty("nationalityStatus")]
    [XmlElement(ElementName = "nationalityStatus")]
    public string NationalityStatus
    {
        get { return _nationalityStatus; }

        set
        {
            if (value != null && value != "2")
            {
                throw new XmlSchemaValidationException(NationalityStatusValidateExceptionMessage);
            }
            _nationalityStatus = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool NationalityStatusSpecified => !string.IsNullOrWhiteSpace(NationalityStatus);

    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public Country Country
    {
        get { return _country; }
        set { _country = value; }
    }
}
