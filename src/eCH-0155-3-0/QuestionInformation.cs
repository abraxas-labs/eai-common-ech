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
///     Abstimmungsfrage Information.
/// </summary>
[Serializable]
[JsonObject("questionInformation")]
[XmlRoot(ElementName = "questionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class QuestionInformation
{
    private const string QuestionIdentificationNullValidateExceptionMessage =
        "QuestionIdentification is not valid! QuestionIdentification is required";

    private const string QuestionIdentificationOutOfRangeValidateExceptionMessage =
        "QuestionIdentification is not valid! QuestionIdentification has minimal leght of 1 and maximal length of 50";

    private const string QuestionPositionOutOfRangeValidateExceptionMessage =
        "QuestionPosition is not valid! QuestionPosition has to be a positive number";

    private const string BallotQuestionNullValidateExceptionMessage =
        "BallotQuestion is not valid! BallotQuestion is required";

    private BallotQuestion _ballotQuestion;
    private string _questionIdentification;
    private int? _questionPosition;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public QuestionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("questionIdentification")]
    [XmlElement(ElementName = "questionIdentification")]
    public string QuestionIdentification
    {
        get => _questionIdentification;
        set
        {
            if (value == null)
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

    [JsonProperty("questionPosition")]
    [XmlElement(ElementName = "questionPosition")]
    public int? QuestionPosition
    {
        get => _questionPosition;
        set
        {
            if (value.HasValue && value < 0)
            {
                throw new XmlSchemaValidationException(QuestionPositionOutOfRangeValidateExceptionMessage);
            }

            _questionPosition = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionPositionSpecified => QuestionPosition.HasValue;

    [JsonProperty("answerType")]
    [XmlElement(ElementName = "answerType")]
    public AnswerInformation AnswerType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnswerTypeSpecified => AnswerType != null;

    [JsonProperty("ballotQuestion")]
    [XmlElement(ElementName = "ballotQuestion")]
    public BallotQuestion BallotQuestion
    {
        get => _ballotQuestion;
        set => _ballotQuestion = value ?? throw new XmlSchemaValidationException(BallotQuestionNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="questionPosition">Field is optional.</param>
    /// <param name="answerType">Field is optional.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>QuestionInformation.</returns>
    public static QuestionInformation Create(string questionIdentification, int? questionPosition,
        AnswerType answerType, BallotQuestion ballotQuestion)
    {
        return new QuestionInformation
        {
            QuestionIdentification = questionIdentification,
            QuestionPosition = questionPosition,
            AnswerType = AnswerInformation.Create(answerType),
            BallotQuestion = ballotQuestion
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>QuestionInformation.</returns>
    public static QuestionInformation Create(string questionIdentification, BallotQuestion ballotQuestion)
    {
        return new QuestionInformation
        {
            QuestionIdentification = questionIdentification,
            BallotQuestion = ballotQuestion
        };
    }
}
