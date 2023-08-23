// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0222_1_0;

[Serializable]
public class ElectionCandidate
{
    [XmlElement("candidateIdentification", typeof(string), DataType = "token")]
    [XmlElement("candidateReferenceOnPosition", typeof(string), DataType = "token")]
    [XmlElement("writeIn", typeof(string), DataType = "token")]
    [XmlChoiceIdentifier("ItemsElementName")]
    public string[] Items { get; set; }

    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName { get; set; }
}

[Serializable]
[XmlType(Namespace = "http://www.ech.ch/xmlns/eCH-0222/1", IncludeInSchema = false)]
public enum ItemsChoiceType
{
    candidateIdentification,
    candidateReferenceOnPosition,
    writeIn
}
