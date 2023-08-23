// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0222_1_0;

public class VoteBallotCastedQuestionRawData
{
    [XmlElement(ElementName = "questionIdentification", DataType = "token", Order = 1)]
    public string QuestionIdentification { get; set; }

    [XmlElement("casted", Order = 2)]
    public VoteBallotCastedQuestionRawDataCasted Casted { get; set; }
}
