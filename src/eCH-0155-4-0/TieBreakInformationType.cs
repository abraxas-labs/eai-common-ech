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
///     Stichfrage Information.
/// </summary>
[Serializable]
[JsonObject("tieBreakInformation")]
[XmlRoot(ElementName = "tieBreakInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class TieBreakInformationType : FieldValueChecker<TieBreakInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AnswerInformationType _answerType;
    private string _questionIdentification;
    private string _tieBreakQuestionNumber;
    private uint? _questionPosition;
    private string _referencedQuestion1;
    private string _referencedQuestion2;
    private TieBreakQuestion _tieBreakQuestion;

    public TieBreakInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("answerInformation")]
    [XmlElement(ElementName = "answerInformation", Order = 1)]
    public AnswerInformationType AnswerType
    {
        get => _answerType;
        set => CheckAndSetValue(ref _answerType, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnswerTypeSpecified => AnswerType != null;

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("questionIdentification")]
    [XmlElement(ElementName = "questionIdentification", Order = 2)]
    public string QuestionIdentification
    {
        get => _questionIdentification;
        set => CheckAndSetValue(ref _questionIdentification, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionIdentificationSpecified => !string.IsNullOrEmpty(QuestionIdentification);

    [FieldMinMaxLength(1, 15)]
    [JsonProperty("tieBreakQuestionNumber")]
    [XmlElement(ElementName = "tieBreakQuestionNumber", Order = 3)]
    public string TieBreakQuestionNumber
    {
        get => _tieBreakQuestionNumber;
        set => CheckAndSetValue(ref _tieBreakQuestionNumber, value);
    }

    [JsonProperty("questionPosition")]
    [XmlElement(ElementName = "questionPosition", Order = 4)]
    public uint? QuestionPosition
    {
        get => _questionPosition;
        set => CheckAndSetValue(ref _questionPosition, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionPositionSpecified => QuestionPosition.HasValue;

    [FieldRequired]
    [JsonProperty("tieBreakQuestion")]
    [XmlElement(ElementName = "tieBreakQuestion", Order = 5)]
    public TieBreakQuestion TieBreakQuestion
    {
        get => _tieBreakQuestion;
        set => CheckAndSetValue(ref _tieBreakQuestion, value);
    }

    [FieldMinMaxLength(1, 50)]
    [JsonProperty("referencedQuestion1")]
    [XmlElement(ElementName = "referencedQuestion1", Order = 6)]
    public string ReferencedQuestion1
    {
        get => _referencedQuestion1;
        set => CheckAndSetValue(ref _referencedQuestion1, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReferencedQuestion1Specified => !string.IsNullOrEmpty(ReferencedQuestion1);

    [FieldMinMaxLength(1, 50)]
    [JsonProperty("referencedQuestion2")]
    [XmlElement(ElementName = "referencedQuestion2", Order = 7)]
    public string ReferencedQuestion2
    {
        get => _referencedQuestion2;
        set => CheckAndSetValue(ref _referencedQuestion2, value);
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
    /// <param name="tieBreakQuestionNumber">Field is optional.</param>
    /// <param name="questionPosition">Field is optional.</param>
    /// <param name="tieBreakQuestion">Field is required.</param>
    /// <param name="referencedQuestion1">Field is optional.</param>
    /// <param name="referencedQuestion2">Field is optional.</param>
    /// <returns>TieBreakInformation.</returns>
    public static TieBreakInformationType Create(AnswerType answerType, string questionIdentification, string tieBreakQuestionNumber,
        uint? questionPosition, TieBreakQuestion tieBreakQuestion, string referencedQuestion1,
        string referencedQuestion2)
    {
        return new TieBreakInformationType
        {
            AnswerType = AnswerInformationType.Create(answerType),
            QuestionIdentification = questionIdentification,
            TieBreakQuestionNumber = tieBreakQuestionNumber,
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
    public static TieBreakInformationType Create(string questionIdentification, TieBreakQuestion tieBreakQuestion)
    {
        return new TieBreakInformationType
        {
            QuestionIdentification = questionIdentification,
            TieBreakQuestion = tieBreakQuestion
        };
    }
}
