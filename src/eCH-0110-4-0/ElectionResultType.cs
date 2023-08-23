// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "electionResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ElectionResultType
{
    [XmlElement("election", Order = 1)]
    public ElectionType Election { get; set; }

    [XmlElement("majoralElection", typeof(MajoralElection), Order = 2)]
    [XmlElement("proportionalElection", typeof(ProportionalElection), Order = 2)]
    public object Item { get; set; }

    [XmlElement("electedCandidate", Order = 3)]
    public ElectedCandidate[] ElectedCandidate { get; set; }

    [XmlElement("extension", Order = 4)]
    public ExtensionType Extension { get; set; }
}
