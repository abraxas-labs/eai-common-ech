// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
public class ElectedCandidate
{
    [XmlElement("candidate", typeof(CandidateType))]
    [XmlElement("writeIn", typeof(string), DataType = "token")]
    public object Item { get; set; }
}
