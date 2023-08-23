// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Abstimmungsfrage Information.
/// </summary>
[Serializable]
[JsonObject("questionInformation")]
[XmlRoot(ElementName = "questionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class QuestionInformationType : FieldValueChecker<QuestionInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _questionIdentification;
    private string _ballotQuestionNumber;
    private uint? _questionPosition;
    private AnswerInformationType _answerInformation;
    private BallotQuestion _ballotQuestion;

    public QuestionInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("questionIdentification")]
    [XmlElement(ElementName = "questionIdentification", Order = 1)]
    public string QuestionIdentification
    {
        get => _questionIdentification;
        set => CheckAndSetValue(ref _questionIdentification, value);
    }

    [FieldMinMaxLength(1, 15)]
    [JsonProperty("ballotQuestionNumber")]
    [XmlElement(ElementName = "ballotQuestionNumber", Order = 2)]
    public string BallotQuestionNumber
    {
        get => _ballotQuestionNumber;
        set => CheckAndSetValue(ref _ballotQuestionNumber, value);
    }

    [JsonProperty("questionPosition")]
    [XmlElement(ElementName = "questionPosition", Order = 3)]
    public uint? QuestionPosition
    {
        get => _questionPosition;
        set => CheckAndSetValue(ref _questionPosition, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionPositionSpecified => QuestionPosition.HasValue;

    [JsonProperty("answerInformation")]
    [XmlElement(ElementName = "answerInformation", Order = 4)]
    public AnswerInformationType AnswerInformation
    {
        get => _answerInformation;
        set => CheckAndSetValue(ref _answerInformation, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnswerInformationSpecified => AnswerInformation != null;

    [FieldRequired]
    [JsonProperty("ballotQuestion")]
    [XmlElement(ElementName = "ballotQuestion", Order = 5)]
    public BallotQuestion BallotQuestion
    {
        get => _ballotQuestion;
        set => CheckAndSetValue(ref _ballotQuestion, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="ballotQuestionNumber">Field is optional.</param>
    /// <param name="questionPosition">Field is optional.</param>
    /// <param name="answerType">Field is optional.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>QuestionInformation.</returns>
    public static QuestionInformationType Create(string questionIdentification, string ballotQuestionNumber, uint? questionPosition,
        AnswerType answerType, BallotQuestion ballotQuestion)
    {
        return new QuestionInformationType
        {
            QuestionIdentification = questionIdentification,
            BallotQuestionNumber = ballotQuestionNumber,
            QuestionPosition = questionPosition,
            AnswerInformation = AnswerInformationType.Create(answerType),
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
    public static QuestionInformationType Create(string questionIdentification, BallotQuestion ballotQuestion)
    {
        return new QuestionInformationType
        {
            QuestionIdentification = questionIdentification,
            BallotQuestion = ballotQuestion
        };
    }
}
