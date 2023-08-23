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
///     Stichfrage als Freitext von 700 Zeichen mit optionalem Titel von 100 Zeichen und optionaler zweiter Stichfrage von
///     700 Zeichen.
/// </summary>
[Serializable]
[JsonObject("tieBreakQuestionInfo")]
[XmlRoot(ElementName = "tieBreakQuestionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class TieBreakQuestionInfo
{
    private const string TieBreakQuestionTitleOutOfRangeValidateExceptionMessage =
            "TieBreakQuestionTitle is not valid! TieBreakQuestionTitle has minimal leght of 1 and maximal length of 100"
        ;

    private const string TieBreakQuestionNullValidateExceptionMessage =
        "TieBreakQuestion is not valid! TieBreakQuestion is required";

    private const string TieBreakQuestionOutOfRangeValidateExceptionMessage =
        "TieBreakQuestion is not valid! TieBreakQuestion has minimal leght of 1 and maximal length of 700";

    private const string TieBreakQuestion2OutOfRangeValidateExceptionMessage =
        "TieBreakQuestion2 is not valid! TieBreakQuestion2 has minimal leght of 1 and maximal length of 700";

    private string _tieBreakQuestion;
    private string _tieBreakQuestion2;

    private string _tieBreakQuestionTitle;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public TieBreakQuestionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("tieBreakQuestionTitle")]
    [XmlElement(ElementName = "tieBreakQuestionTitle")]
    public string TieBreakQuestionTitle
    {
        get => _tieBreakQuestionTitle;
        set
        {
            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(TieBreakQuestionTitleOutOfRangeValidateExceptionMessage);
            }

            _tieBreakQuestionTitle = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TieBreakQuestionTitleSpecified => !string.IsNullOrEmpty(TieBreakQuestionTitle);

    [JsonProperty("tieBreakQuestion")]
    [XmlElement(ElementName = "tieBreakQuestion")]
    public string TieBreakQuestion
    {
        get => _tieBreakQuestion;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(TieBreakQuestionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 700)
            {
                throw new XmlSchemaValidationException(TieBreakQuestionOutOfRangeValidateExceptionMessage);
            }

            _tieBreakQuestion = value;
        }
    }

    [JsonProperty("tieBreakQuestion2")]
    [XmlElement(ElementName = "tieBreakQuestion2")]
    public string TieBreakQuestion2
    {
        get => _tieBreakQuestion2;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 700))
            {
                throw new XmlSchemaValidationException(TieBreakQuestion2OutOfRangeValidateExceptionMessage);
            }

            _tieBreakQuestion2 = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TieBreakQuestion2TitleSpecified => !string.IsNullOrEmpty(TieBreakQuestion2);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="tieBreakQuestionTitle">Field is optional.</param>
    /// <param name="tieBreakQuestion">Field is required.</param>
    /// <param name="tieBreakQuestion2">Field is optional.</param>
    /// <returns>TieBreakQuestionInfo.</returns>
    public static TieBreakQuestionInfo Create(Language language, string tieBreakQuestionTitle,
        string tieBreakQuestion, string tieBreakQuestion2)
    {
        return new TieBreakQuestionInfo
        {
            Language = language,
            TieBreakQuestionTitle = tieBreakQuestionTitle,
            TieBreakQuestion = tieBreakQuestion,
            TieBreakQuestion2 = tieBreakQuestion2
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="tieBreakQustion">Field is required.</param>
    /// <returns>TieBreakQuestionInfo.</returns>
    public static TieBreakQuestionInfo Create(Language language, string tieBreakQustion)
    {
        return new TieBreakQuestionInfo
        {
            Language = language,
            TieBreakQuestion = tieBreakQustion
        };
    }
}
