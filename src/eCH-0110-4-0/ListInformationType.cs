// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "listInformationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ListInformationType
{
    private string _listIdentification;
    private string _listIndentureNumber;

    [XmlElement(ElementName = "listIdentification", DataType = "token", Order = 1)]
    public string ListIdentification { get => _listIdentification; set => _listIdentification = value; }

    [XmlElement(ElementName = "listIndentureNumber", DataType = "token", Order = 2)]
    public string ListIndentureNumber { get => _listIndentureNumber; set => _listIndentureNumber = value; }

    [XmlElement(ElementName = "listDescription", IsNullable = false, Order = 3)]
    public ListDescriptionInformation ListDescription { get; set; }
}
