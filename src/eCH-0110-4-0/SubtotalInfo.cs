// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0044_4_1;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
public class SubtotalInfo
{
    [XmlElement(ElementName = "countOfVoters", DataType = "nonNegativeInteger", Order = 1)]
    public string CountOfVoters { get; set; }

    [XmlElement("voterType", Order = 2)]
    public VoterType VoterType { get; set; }

    [XmlIgnore]
    public bool VoterTypeSpecified { get; set; }

    [XmlElement("sex", Order = 3)]
    public SexType Sex { get; set; }

    [XmlIgnore]
    public bool SexSpecified { get; set; }

    [XmlElement("allowsEvoting", Order = 4)]
    public bool AllowsEvoting { get; set; }

    [XmlIgnore]
    public bool AllowsEvotingSpecified { get; set; }
}
