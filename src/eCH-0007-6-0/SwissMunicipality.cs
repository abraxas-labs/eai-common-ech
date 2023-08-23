// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0007_6_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Gemeinden (eCH-0007 Version 6.0)
///     swissMunicipalityType verwendet cantonAbbreviationType und beinhaltet alle Kantonskürzel.
/// </summary>
[Serializable]
[JsonObject("swissMunicipality")]
[XmlRoot(ElementName = "swissMunicipality", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0007/6")]
public class SwissMunicipality : FieldValueChecker<SwissMunicipality>
{
    private int? _municipalityId;
    private string _municipalityName;
    private CantonAbbreviation? _cantonAbbreviation;
    private int? _historyMunicipalityId;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public SwissMunicipality()
    {
        Xmlns.Add("eCH-0007", "http://www.ech.ch/xmlns/eCH-0007/6");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="municipalityId">Field can be null. String has to be a number like "0022". </param>
    /// <param name="municipalityName">Field is reqired.</param>
    /// <param name="cantonAbbreviation">Field can be null.</param>
    /// <param name="historyMunicipalityId">Field can be null.</param>
    /// <returns></returns>
    public static SwissMunicipality Create(int? municipalityId, string municipalityName, CantonAbbreviation? cantonAbbreviation, int? historyMunicipalityId)
    {
        return new SwissMunicipality
        {
            MunicipalityId = municipalityId,
            MunicipalityName = municipalityName,
            CantonAbbreviation = cantonAbbreviation,
            HistoryMunicipalityId = historyMunicipalityId
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="municipalityName"></param>
    /// <returns></returns>
    public static SwissMunicipality Create(string municipalityName)
    {
        return new SwissMunicipality
        {
            MunicipalityId = null,
            MunicipalityName = municipalityName,
            CantonAbbreviation = null,
            HistoryMunicipalityId = null
        };
    }

    [FieldRangeInclusive(1, 9999)]
    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId", Order = 1)]
    public int? MunicipalityId
    {
        get => _municipalityId;
        set => CheckAndSetValue(ref _municipalityId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalityIdSpecified => MunicipalityId.HasValue;

    [FieldRequired]
    [FieldMaxLength(40)]
    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName", Order = 2)]
    public string MunicipalityName
    {
        get => _municipalityName;
        set => CheckAndSetValue(ref _municipalityName, value);
    }

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 3)]
    public CantonAbbreviation? CantonAbbreviation
    {
        get => _cantonAbbreviation;
        set => CheckAndSetValue(ref _cantonAbbreviation, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation.HasValue;

    [FieldRangeInclusive(10001, 99999)]
    [JsonProperty("historyMunicipalityId")]
    [XmlElement(ElementName = "historyMunicipalityId", Order = 4)]
    public int? HistoryMunicipalityId
    {
        get => _historyMunicipalityId;
        set => CheckAndSetValue(ref _historyMunicipalityId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HistoryMunicipalityIdSpecified => HistoryMunicipalityId.HasValue;
}
