// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung der Vorlage als optionaler Freitext von 255 Zeichen und optionaler kurzer Freitext von 100 Zeichen.
///     Ob diese Information notwendig ist oder nicht muss vom Sender bestimmt werden.
/// </summary>
[Serializable]
[JsonObject("ballotDescriptionInfo")]
[XmlRoot(ElementName = "ballotDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class BallotDescriptionInfo
{
    private const string BallotDescriptionLongOutOfRangeValidateExceptionMessage =
        "TypeOfBallot is not valid! TypeOfBallot has minimal leght of 1 and maximal length of 255";

    private const string BallotDescriptionShortOutOfRangeValidateExceptionMessage =
        "TypeOfBallot is not valid! TypeOfBallot has minimal leght of 1 and maximal length of 100";

    private string _ballotDescriptionLong;
    private string _ballotDescriptionShort;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public BallotDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("ballotDescriptionLong")]
    [XmlElement(ElementName = "ballotDescriptionLong")]
    public string BallotDescriptionLong
    {
        get => _ballotDescriptionLong;
        set
        {
            if (value.Length < 1 || value.Length > 255)
            {
                throw new XmlSchemaValidationException(BallotDescriptionLongOutOfRangeValidateExceptionMessage);
            }

            _ballotDescriptionLong = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BallotDescriptionLongSpecified => !string.IsNullOrEmpty(BallotDescriptionLong);

    [JsonProperty("ballotDescriptionShort")]
    [XmlElement(ElementName = "ballotDescriptionShort")]
    public string BallotDescriptionShort
    {
        get => _ballotDescriptionShort;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(BallotDescriptionShortOutOfRangeValidateExceptionMessage);
            }

            _ballotDescriptionShort = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BallotDescriptionShortSpecified => !string.IsNullOrEmpty(BallotDescriptionShort);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="ballotDescriptionLong">Field is required.</param>
    /// <param name="ballotDescriptionShort">Field is optional.</param>
    /// <returns>BallotDescriptionInfo.</returns>
    public static BallotDescriptionInfo Create(Language language, string ballotDescriptionLong,
        string ballotDescriptionShort)
    {
        return new BallotDescriptionInfo
        {
            Language = language,
            BallotDescriptionLong = ballotDescriptionLong,
            BallotDescriptionShort = ballotDescriptionShort
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <returns>BallotDescriptionInfo.</returns>
    public static BallotDescriptionInfo Create(Language language)
    {
        return new BallotDescriptionInfo
        {
            Language = language
        };
    }
}
