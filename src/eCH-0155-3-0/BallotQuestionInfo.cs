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
///     Bezeichnung der Vorlage als optionaler Freitext von 255 Zeichen und optionaler kurzer Freitext von 100 Zeichen.
///     Ob diese Information notwendig ist oder nicht muss vom Sender bestimmt werden.
/// </summary>
[Serializable]
[JsonObject("ballotQuestionInfo")]
[XmlRoot(ElementName = "ballotQuestionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class BallotQuestionInfo
{
    private const string BallotQuestionTitleOutOfRangeValidateExceptionMessage =
        "BallotQuestionTitle is not valid! BallotQuestionTitle has minimal leght of 1 and maximal length of 100";

    private const string BallotQuestionNullValidateExceptionMessage =
        "BallotQuestion is not valid! BallotQuestion is required";

    private const string BallotQuestionOutOfRangeValidateExceptionMessage =
        "BallotQuestion is not valid! BallotQuestion has minimal leght of 1 and maximal length of 700";

    private string _ballotQuestion;

    private string _ballotQuestionTitle;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public BallotQuestionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("ballotQuestionTitle")]
    [XmlElement(ElementName = "ballotQuestionTitle")]
    public string BallotQuestionTitle
    {
        get => _ballotQuestionTitle;
        set
        {
            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(BallotQuestionTitleOutOfRangeValidateExceptionMessage);
            }

            _ballotQuestionTitle = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BallotQuestionTitleSpecified => !string.IsNullOrEmpty(BallotQuestionTitle);

    [JsonProperty("ballotQuestion")]
    [XmlElement(ElementName = "ballotQuestion")]
    public string BallotQuestion
    {
        get => _ballotQuestion;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(BallotQuestionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 700)
            {
                throw new XmlSchemaValidationException(BallotQuestionOutOfRangeValidateExceptionMessage);
            }

            _ballotQuestion = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="ballotQuestionTitle">Field is optional.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>BallotQuestionInfo.</returns>
    public static BallotQuestionInfo Create(Language language, string ballotQuestionTitle, string ballotQuestion)
    {
        return new BallotQuestionInfo
        {
            Language = language,
            BallotQuestionTitle = ballotQuestionTitle,
            BallotQuestion = ballotQuestion
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="ballotQustion">Field is required.</param>
    /// <returns>BallotQuestionInfo.</returns>
    public static BallotQuestionInfo Create(Language language, string ballotQustion)
    {
        return new BallotQuestionInfo
        {
            Language = language,
            BallotQuestion = ballotQustion
        };
    }
}
