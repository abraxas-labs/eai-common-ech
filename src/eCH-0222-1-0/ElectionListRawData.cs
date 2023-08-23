// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0222_1_0;

[Serializable]
public class ElectionListRawData
{
    private string _listIdentification;

    [XmlElement(ElementName = "listIdentification", DataType = "token")]
    public string ListIdentification { get => _listIdentification; set => _listIdentification = value; }
}
