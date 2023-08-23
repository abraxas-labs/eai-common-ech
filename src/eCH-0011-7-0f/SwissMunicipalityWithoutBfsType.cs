// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("swissMunicipalityWithoutBFS")]
[XmlRoot(ElementName = "swissMunicipalityWithoutBFS", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class SwissMunicipalityWithoutBfsType : FieldValueChecker<SwissMunicipalityWithoutBfsType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private uint? _municipalityId;
    private string _municipalityName;
    private CantonAbbreviation _cantonAbbreviation;

    public SwissMunicipalityWithoutBfsType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="municipalityId">Field is requried.</param>
    /// <param name="municipalityName">Field is requried.</param>
    /// <param name="cantonAbbreviation">Field is requried.</param>
    /// <returns>SwissMunicipalityWithoutBfsType.</returns>
    public static SwissMunicipalityWithoutBfsType Create(uint? municipalityId, string municipalityName, CantonAbbreviation cantonAbbreviation)
    {
        return new SwissMunicipalityWithoutBfsType
        {
            MunicipalityId = municipalityId,
            MunicipalityName = municipalityName,
            CantonAbbreviation = cantonAbbreviation
        };
    }

    [FieldRangeInclusive(1, 9999)]
    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId")]
    public uint? MunicipalityId
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

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation")]
    public CantonAbbreviation CantonAbbreviation
    {
        get => _cantonAbbreviation;
        set => CheckAndSetValue(ref _cantonAbbreviation, value);
    }
}
