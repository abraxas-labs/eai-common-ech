// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0222_1_0;

public class ElectionGroupBallotRawData
{
    [XmlElement(ElementName = "electionGroupIdentification", DataType = "token", Order = 1)]
    public string ElectionGroupIdentification { get; set; }

    [XmlElement("electionRawData", Order = 2)]
    public ElectionRawDataType[] ElectionRawData { get; set; }
}
