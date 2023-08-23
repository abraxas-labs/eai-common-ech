// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0007_4_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Gemeinden (eCH-0007)
/// swissAndFLMunicipalityType verwendet cantonFLAbbreviationType und beinhaltet somit auch die Information zum Fürstentum Liechtenstein.
/// </summary>
[Serializable]
[JsonObject("swissAndFlMunicipality")]
[XmlRoot(ElementName = "swissAndFlMunicipality", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0007/4")]
public class SwissAndFlMunicipality : FieldValueChecker<SwissAndFlMunicipality>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private int _municipalityId;
    private string _municipalityName;
    private CantonFlAbbreviation _cantonFlAbbreviation;
    private int? _historyMunicipalityId;

    public SwissAndFlMunicipality()
    {
        Xmlns.Add("eCH-0007", "http://www.ech.ch/xmlns/eCH-0007/4");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="municipalityId">Field is reqired". </param>
    /// <param name="municipalityName">Field is reqired.</param>
    /// <param name="cantonFlAbbreviation">Field is reqired.</param>
    /// <param name="historyMunicipalityId">Field can be null.</param>
    /// <returns>SwissAndFlMunicipality.</returns>
    public static SwissAndFlMunicipality Create(int municipalityId, string municipalityName, CantonFlAbbreviation cantonFlAbbreviation, int? historyMunicipalityId)
    {
        return new SwissAndFlMunicipality
        {
            MunicipalityId = municipalityId,
            MunicipalityName = municipalityName,
            CantonFlAbbreviation = cantonFlAbbreviation,
            HistoryMunicipalityId = historyMunicipalityId
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="municipalityId">Field is reqired.</param>
    /// <param name="municipalityName">Field is reqired.</param>
    /// <param name="cantonFlAbbreviation">Field is reqired.</param>
    /// <returns>SwissAndFlMunicipality.</returns>
    public static SwissAndFlMunicipality Create(int municipalityId, string municipalityName, CantonFlAbbreviation cantonFlAbbreviation)
    {
        return new SwissAndFlMunicipality
        {
            MunicipalityId = municipalityId,
            MunicipalityName = municipalityName,
            CantonFlAbbreviation = cantonFlAbbreviation,
            HistoryMunicipalityId = null
        };
    }

    [FieldRequired]
    [FieldRangeInclusive(1, 9999)]
    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId")]
    public int MunicipalityId
    {
        get => _municipalityId;
        set => CheckAndSetValue(ref _municipalityId, value);
    }

    [FieldRequired]
    [FieldMaxLength(40)]
    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName")]
    public string MunicipalityName
    {
        get => _municipalityName;
        set => CheckAndSetValue(ref _municipalityName, value);
    }

    [FieldRequired]
    [JsonProperty("cantonFlAbbreviation")]
    [XmlElement(ElementName = "cantonFlAbbreviation")]
    public CantonFlAbbreviation CantonFlAbbreviation
    {
        get => _cantonFlAbbreviation;
        set => CheckAndSetValue(ref _cantonFlAbbreviation, value);
    }

    [JsonProperty("historyMunicipialityId")]
    [XmlElement(ElementName = "historyMunicipialityId")]
    public int? HistoryMunicipalityId
    {
        get => _historyMunicipalityId;
        set => CheckAndSetValue(ref _historyMunicipalityId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HistoryMunicipalityIdSpecified => HistoryMunicipalityId.HasValue;
}
