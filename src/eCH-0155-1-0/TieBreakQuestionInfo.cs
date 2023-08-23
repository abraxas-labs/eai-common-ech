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
///     Stichfrage als Freitext von 700 Zeichen mit optionalem Titel von 100 Zeichen und optionaler zweiter Stichfrage von
///     700 Zeichen.
/// </summary>
[Serializable]
[JsonObject("tieBreakQuestionInfo")]
[XmlRoot(ElementName = "tieBreakQuestionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class TieBreakQuestionInfo
{
    private const string TieBreakQuestionNullValidateExceptionMessage =
        "TieBreakQuestion is not valid! TieBreakQuestion is required";

    private const string TieBreakQuestionOutOfRangeValidateExceptionMessage =
        "TieBreakQuestion is not valid! TieBreakQuestion has minimal leght of 1 and maximal length of 700";

    private string _tieBreakQuestion;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public TieBreakQuestionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

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

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="tieBreakQuestion">Field is required.</param>
    /// <returns>TieBreakQuestionInfo.</returns>
    public static TieBreakQuestionInfo Create(Language language, string tieBreakQuestion)
    {
        return new TieBreakQuestionInfo
        {
            Language = language,
            TieBreakQuestion = tieBreakQuestion
        };
    }
}
