// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     "Parteizugehörigkeit " Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("partyAffiliationInfo")]
[XmlRoot(ElementName = "partyAffiliationInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class PartyAffiliationInfo
{
    private const string PartyAffiliationShortNullValidateExceptionMessage =
        "PartyAffiliationShort is not valid! PartyAffiliationShort is required";

    private const string PartyAffiliationShortOutOfRangeValidateExceptionMessage =
        "PartyAffiliationShort is not valid! PartyAffiliationShort has minimal leght of 1 and maximal length of 12";

    private const string PartyAffiliationOutOfRangeValidateExceptionMessage =
        "PartyAffiliation is not valid! PartyAffiliation has minimal leght of 1 and maximal length of 100";

    private string _partyAffiliation;
    private string _partyAffiliationShort;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PartyAffiliationInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("partyAffiliation")]
    [XmlElement(ElementName = "partyAffiliation")]
    public string PartyAffiliation
    {
        get => _partyAffiliation;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(PartyAffiliationOutOfRangeValidateExceptionMessage);
            }

            _partyAffiliation = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartyAffiliationSpecified => !string.IsNullOrEmpty(PartyAffiliation);

    [JsonProperty("partyAffiliationShort")]
    [XmlElement(ElementName = "partyAffiliationShort")]
    public string PartyAffiliationShort
    {
        get => _partyAffiliationShort;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(PartyAffiliationShortNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 12)
            {
                throw new XmlSchemaValidationException(PartyAffiliationShortOutOfRangeValidateExceptionMessage);
            }

            _partyAffiliationShort = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötige Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="partyAffiliationShort">Field is required.</param>
    /// <returns>PartyAffiliationInfo.</returns>
    public static PartyAffiliationInfo Create(Language language, string partyAffiliationShort)
    {
        return new PartyAffiliationInfo
        {
            Language = language,
            PartyAffiliationShort = partyAffiliationShort
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="partyAffiliationShort">Field is required.</param>
    /// <param name="partyAffiliation">Field my be null.</param>
    /// <returns>PartyAffiliationInfo.</returns>
    public static PartyAffiliationInfo Create(Language language, string partyAffiliationShort,
        string partyAffiliation)
    {
        return new PartyAffiliationInfo
        {
            Language = language,
            PartyAffiliationShort = partyAffiliationShort,
            PartyAffiliation = partyAffiliation
        };
    }
}
