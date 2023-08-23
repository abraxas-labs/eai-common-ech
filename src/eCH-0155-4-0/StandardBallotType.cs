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
///     Helferklasse um den Choiche-Node vom Ballot abzubilden.
/// </summary>
[Serializable]
[JsonObject("standardBallot")]
[XmlRoot(ElementName = "standardBallot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class StandardBallotType : FieldValueChecker<StandardBallotType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _questionIdentification;
    private string _ballotQuestionNumber;
    private AnswerInformationType _answerType;
    private BallotQuestion _ballotQuestion;

    public StandardBallotType()
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

    [JsonIgnore]
    [XmlIgnore]
    public bool QuestionIdentificationSpecified => !string.IsNullOrEmpty(QuestionIdentification);

    [FieldMinMaxLength(1, 15)]
    [JsonProperty("ballotQuestionNumber")]
    [XmlElement(ElementName = "ballotQuestionNumber", Order = 2)]
    public string BallotQuestionNumber
    {
        get => _ballotQuestionNumber;
        set => CheckAndSetValue(ref _ballotQuestionNumber, value);
    }

    [JsonProperty("answerInformation")]
    [XmlElement(ElementName = "answerInformation", Order = 3)]
    public AnswerInformationType AnswerType
    {
        get => _answerType;
        set => CheckAndSetValue(ref _answerType, value);
    }

    [FieldRequired]
    [JsonProperty("ballotQuestion")]
    [XmlElement(ElementName = "ballotQuestion", Order = 4)]
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
    /// <param name="answerType">Field is optional.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>StandardBallot.</returns>
    public static StandardBallotType Create(string questionIdentification, string ballotQuestionNumber, AnswerInformationType answerType, BallotQuestion ballotQuestion)
    {
        return new StandardBallotType
        {
            AnswerType = answerType,
            BallotQuestionNumber = ballotQuestionNumber,
            QuestionIdentification = questionIdentification,
            BallotQuestion = ballotQuestion
        };
    }
}
