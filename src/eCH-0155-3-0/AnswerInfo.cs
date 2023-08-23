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
///     Bezeichnung einer Abstimmung von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("answerInfo")]
[XmlRoot(ElementName = "answerInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class AnswerInfo
{
    private const string AnswerNullValidateExceptionMessage = "Answer is not valid! Answer is required";

    private const string AnswerOutOfRangeValidateExceptionMessage =
        "Answer is not valid! Answer has minimal leght of 1 and maximal length of 100";

    private string _answer;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public AnswerInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("acceptableAnswer")]
    [XmlElement(ElementName = "acceptableAnswer")]
    public string Answer
    {
        get => _answer;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(AnswerNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(AnswerOutOfRangeValidateExceptionMessage);
            }

            _answer = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="answer">Field is required.</param>
    /// <returns>AnswerInfo.</returns>
    public static AnswerInfo Create(Language language, string answer)
    {
        return new AnswerInfo
        {
            Language = language,
            Answer = answer
        };
    }
}
