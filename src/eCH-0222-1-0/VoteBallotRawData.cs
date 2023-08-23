// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0222_1_0;

public class VoteBallotRawData
{
    [XmlElement(ElementName = "ballotIdentification", DataType = "token", Order = 1)]
    public string BallotIdentification { get; set; }

    [XmlElement("ballotCasted", Order = 2)]
    public VoteBallotCasted BallotCasted { get; set; }
}
