// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0222_1_0;

public class CountingCircleRawData
{
    [XmlElement(DataType = "token", Order = 1)]
    public string countingCircleId { get; set; }

    [XmlElement("voteRawData", Order = 2)]
    public VoteRawDataType[] VoteRawData { get; set; }

    [XmlElement("electionGroupBallotRawData", Order = 3)]
    public ElectionGroupBallotRawData[] electionGroupBallotRawData { get; set; }
}
