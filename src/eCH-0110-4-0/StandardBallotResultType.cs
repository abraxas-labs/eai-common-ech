// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "standardBallotResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class StandardBallotResultType
{
    [XmlElement(ElementName = "questionIdentification", DataType = "token", Order = 1)]
    public string QuestionIdentification { get; set; }

    [XmlElement("answerType", Order = 2)]
    public AnswerInformationType AnswerType { get; set; }

    [XmlElement(ElementName = "question", Order = 3)]
    public BallotQuestion Question { get; set; }

    [XmlElement("countOfAnswerYes", Order = 4)]
    public ResultDetailType CountOfAnswerYes { get; set; }

    [XmlElement("countOfAnswerNo", Order = 5)]
    public ResultDetailType CountOfAnswerNo { get; set; }

    [XmlElement("countOfAnswerInvalid", Order = 6)]
    public ResultDetailType CountOfAnswerInvalid { get; set; }

    [XmlElement("countOfAnswerEmpty", Order = 7)]
    public ResultDetailType CountOfAnswerEmpty { get; set; }
}
