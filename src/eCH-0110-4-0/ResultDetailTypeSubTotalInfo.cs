// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
public class ResultDetailTypeSubTotalInfo
{
    [XmlElement(ElementName = "subTotal", DataType = "nonNegativeInteger", Order = 1)]
    public string SubTotal { get; set; }

    [XmlElement("channel", Order = 2)]
    public VotingChannel Channel { get; set; }
}
