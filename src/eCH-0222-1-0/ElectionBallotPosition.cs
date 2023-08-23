// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0222_1_0;

[Serializable]
public class ElectionBallotPosition
{
    [XmlElement("candidate", typeof(ElectionCandidate))]
    [XmlElement("isEmpty", typeof(bool))]
    public object Item { get; set; }
}
