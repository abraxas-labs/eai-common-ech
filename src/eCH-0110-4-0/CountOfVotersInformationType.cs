// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "countOfVotersInformationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class CountOfVotersInformationType
{
    private SubtotalInfo[] _subtotalInfo;
    private string _countOfVotersTotal;

    [XmlElement(ElementName = "countOfVotersTotal", DataType = "nonNegativeInteger", Order = 1)]
    public string CountOfVotersTotal { get => _countOfVotersTotal; set => _countOfVotersTotal = value; }

    [XmlElement("subtotalInfo", Order = 2)]
    public SubtotalInfo[] SubtotalInfo { get => _subtotalInfo; set => _subtotalInfo = value; }
}
