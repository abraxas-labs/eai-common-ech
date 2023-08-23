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
///     Helferklasse um den Choiche-Node vom Ballot abzubilden.
/// </summary>
[Serializable]
[JsonObject("standardBallot")]
[XmlRoot(ElementName = "standardBallot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class StandardBallot
{
    private const string QuestionIdentificationNullValidateExceptionMessage =
        "QuestionIdentification is not valid! QuestionIdentification is required";

    private const string QuestionIdentificationOutOfRangeValidateExceptionMessage =
            "QuestionIdentification is not valid! QuestionIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private const string BallotQuestionNullValidateExceptionMessage =
        "BallotQuestion is not valid! AnswerType is required";

    private BallotQuestion _ballotQuestion;

    private string _questionIdentification;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public StandardBallot()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

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

    [JsonProperty("answerType")]
    [XmlElement(ElementName = "answerType")]
    public AnswerInformation AnswerType { get; set; }

    [JsonProperty("ballotQuestion")]
    [XmlElement(ElementName = "ballotQuestion")]
    public BallotQuestion BallotQuestion
    {
        get => _ballotQuestion;
        set => _ballotQuestion =
            value ?? throw new XmlSchemaValidationException(BallotQuestionNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="questionIdentification">Field is required.</param>
    /// <param name="answerType">Field is optional.</param>
    /// <param name="ballotQuestion">Field is required.</param>
    /// <returns>StandardBallot.</returns>
    public static StandardBallot Create(string questionIdentification, AnswerType answerType,
        BallotQuestion ballotQuestion)
    {
        return new StandardBallot
        {
            AnswerType = AnswerInformation.Create(answerType),
            QuestionIdentification = questionIdentification,
            BallotQuestion = ballotQuestion
        };
    }
}
