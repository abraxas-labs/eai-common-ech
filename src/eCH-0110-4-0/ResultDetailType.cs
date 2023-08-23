// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "resultDetailType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ResultDetailType
{
    [XmlElement(ElementName = "total", DataType = "nonNegativeInteger", Order = 1)]
    public string Total { get; set; }

    [XmlElement("subTotalInfo", Order = 2)]
    public ResultDetailTypeSubTotalInfo[] SubTotalInfo { get; set; }
}
