// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0222_1_0;

public class VoteBallotCastedQuestionRawDataCasted
{
    [XmlElement(ElementName = "castedVote", DataType = "nonNegativeInteger", Order = 1)]
    public string CastedVote { get; set; }

    [XmlElement("answerOptionIdentification", Order = 2)]
    public AnswerOptionIdentificationType AnswerOptionIdentification { get; set; }
}
