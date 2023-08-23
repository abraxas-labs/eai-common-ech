// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "candidateInformationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class CandidateInformationType
{
    private string _candidateIdentification;
    private string _candidateReference;
    private string _familyName;
    private string _firstName;
    private string _callName;

    [XmlElement(ElementName = "candidateIdentification", DataType = "token", Order = 1)]
    public string CandidateIdentification { get => _candidateIdentification; set => _candidateIdentification = value; }

    [XmlElement(ElementName = "candidateReference", DataType = "token", Order = 2)]
    public string CandidateReference { get => _candidateReference; set => _candidateReference = value; }

    [XmlElement(ElementName = "familyName", DataType = "token", Order = 3)]
    public string FamilyName { get => _familyName; set => _familyName = value; }

    [XmlElement(ElementName = "firstName", DataType = "token", Order = 4)]
    public string FirstName { get => _firstName; set => _firstName = value; }

    [XmlElement(ElementName = "callName", DataType = "token", Order = 5)]
    public string CallName { get => _callName; set => _callName = value; }

    [XmlElement(ElementName = "candidateText", IsNullable = false, Order = 6)]
    public CandidateTextInformation CandidateText { get; set; }

    [XmlElement(ElementName = "officialCandidateYesNo", Order = 7)]
    public bool OfficialCandidateYesNo { get; set; }
}
