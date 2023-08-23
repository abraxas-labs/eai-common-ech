// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0222_1_0;

public class VoteBallotCasted
{
    [XmlElement(ElementName = "ballotCastedNumber", DataType = "nonNegativeInteger", Order = 1)]
    public string BallotCastedNumber { get; set; }

    [XmlElement("questionRawData", Order = 2)]
    public VoteBallotCastedQuestionRawData[] QuestionRawData { get; set; }
}
