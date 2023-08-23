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
///     Stichfrage Information.
/// </summary>
[Serializable]
[JsonObject("tieBreakInformation")]
[XmlRoot(ElementName = "tieBreakInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class TieBreakInformation
{
    private const string QuestionIdentificationNullValidateExceptionMessage =
        "AnswerType is not valid! AnswerType is required";

    private const string QuestionIdentificationOutOfRangeValidateExceptionMessage =
            "QuestionIdentification is not valid! QuestionIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private const string QuestionPositionOutOfRangeValidateExceptionMessage =
        "QuestionPosition is not valid! QuestionPosition has to be a positive number";

    private const string TieBreakQuestionNullValidateExceptionMessage =
        "TieBreakQuestion is not valid! TieBreakQuestion is required";

    private const string ReferenceQuestion1OutOfRangeValidateExceptionMessage =
        "ReferenceQuestion1 is not valid! ReferenceQuestion1 has minimal leght of 1 and maximal length of 50";

    private const string ReferenceQuestion2OutOfRangeValidateExceptionMessage =
        "ReferenceQuestion2 is not valid! ReferenceQuestion2 has minimal leght of 1 and maximal length of 50";

    private string _questionIdentification;
    private int? _questionPosition;
    private string _referencedQuestion1;
    private string _referencedQuestion2;
    private TieBreakQuestion _tieBreakQuestion;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public TieBreakInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("answerType")]
    [XmlElement(ElementName = "answerType")]
    public AnswerInformation AnswerType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnswerTypeSpecified => AnswerType != null;

    [JsonProperty("questionIdentification")]
    [XmlElement(ElementName = "questionIdentification")]
    public string QuestionIdentification
    {
        get => _questionIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(QuestionIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(QuestionIdentificationOutOfRangeValidateExceptionMessage);
            }

            _questionIdentification = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionIdentificationSpecified => !string.IsNullOrEmpty(QuestionIdentification);

    [JsonProperty("questionPosition")]
    [XmlElement(ElementName = "questionPosition")]
    public int? QuestionPosition
    {
        get => _questionPosition;
        set
        {
            if (value.HasValue && value < 1)
            {
                throw new XmlSchemaValidationException(QuestionPositionOutOfRangeValidateExceptionMessage);
            }

            _questionPosition = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionPositionSpecified => QuestionPosition.HasValue;

    [JsonProperty("tieBreakQuestion")]
    [XmlElement(ElementName = "tieBreakQuestion")]
    public TieBreakQuestion TieBreakQuestion
    {
        get => _tieBreakQuestion;
        set => _tieBreakQuestion =
            value ?? throw new XmlSchemaValidationException(TieBreakQuestionNullValidateExceptionMessage);
    }

    [JsonProperty("referencedQuestion1")]
    [XmlElement(ElementName = "referencedQuestion1")]
    public string ReferencedQuestion1
    {
        get => _referencedQuestion1;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 50))
            {
                throw new XmlSchemaValidationException(ReferenceQuestion1OutOfRangeValidateExceptionMessage);
            }

            _referencedQuestion1 = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReferencedQuestion1Specified => !string.IsNullOrEmpty(ReferencedQuestion1);

    [JsonProperty("referencedQuestion2")]
    [XmlElement(ElementName = "referencedQuestion2")]
    public string ReferencedQuestion2
    {
        get => _referencedQuestion2;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 50))
            {
                throw new XmlSchemaValidationException(ReferenceQuestion2OutOfRangeValidateExceptionMessage);
            }

            _referencedQuestion2 = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReferencedQuestion2Specified => !string.IsNullOrEmpty(ReferencedQuestion2);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="answerType">Field is optional.</param>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="questionPosition">Field is optional.</param>
    /// <param name="tieBreakQuestion">Field is required.</param>
    /// <param name="referencedQuestion1">Field is optional.</param>
    /// <param name="referencedQuestion2">Field is optional.</param>
    /// <returns>TieBreakInformation.</returns>
    public static TieBreakInformation Create(AnswerType answerType, string questionIdentification,
        int? questionPosition, TieBreakQuestion tieBreakQuestion, string referencedQuestion1,
        string referencedQuestion2)
    {
        return new TieBreakInformation
        {
            AnswerType = AnswerInformation.Create(answerType),
            QuestionIdentification = questionIdentification,
            QuestionPosition = questionPosition,
            TieBreakQuestion = tieBreakQuestion,
            ReferencedQuestion1 = referencedQuestion1,
            ReferencedQuestion2 = referencedQuestion2
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="tieBreakQuestion">Field is required.</param>
    /// <returns>TieBreakInformation.</returns>
    public static TieBreakInformation Create(string questionIdentification, TieBreakQuestion tieBreakQuestion)
    {
        return new TieBreakInformation
        {
            QuestionIdentification = questionIdentification,
            TieBreakQuestion = tieBreakQuestion
        };
    }
}
