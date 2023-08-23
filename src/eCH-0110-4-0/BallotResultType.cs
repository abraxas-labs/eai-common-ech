// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "ballotResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class BallotResultType
{
    private string _ballotIdentification;
    private string _ballotGroup;
    private string _ballotPosition;

    [XmlElement(ElementName = "ballotIdentification", Order = 1)]
    public string BallotIdentification { get => _ballotIdentification; set => _ballotIdentification = value; }

    [XmlElement(ElementName = "ballotGroup", DataType = "token", Order = 2)]
    public string BallotGroup { get => _ballotGroup; set => _ballotGroup = value; }

    [XmlElement(ElementName = "ballotPosition", DataType = "nonNegativeInteger", Order = 3)]
    public string BallotPosition { get => _ballotPosition; set => _ballotPosition = value; }

    [XmlElement(ElementName = "ballotDescription", IsNullable = false, Order = 4)]
    public BallotDescriptionInformation BallotDescription { get; set; }

    [XmlElement(ElementName = "countOfReceivedBallotsTotal", Order = 5)]
    public ResultDetailType CountOfReceivedBallotsTotal { get; set; }

    [XmlElement(ElementName = "countOfAccountedBallotsTotal", Order = 6)]
    public ResultDetailType CountOfAccountedBallotsTotal { get; set; }

    [XmlElement(ElementName = "countOfUnaccountedBallotsTotal", Order = 7)]
    public ResultDetailType CountOfUnaccountedBallotsTotal { get; set; }

    [XmlElement(ElementName = "countOfUnaccountedBlankBallots", Order = 8)]
    public ResultDetailType CountOfUnaccountedBlankBallots { get; set; }

    [XmlElement(ElementName = "countOfUnaccountedInvalidBallots", Order = 9)]
    public ResultDetailType CountOfUnaccountedInvalidBallots { get; set; }

    [XmlElement("standardBallot", typeof(StandardBallotResultType), Order = 10)]
    [XmlElement("variantBallot", typeof(VariantBallotResultType), Order = 10)]
    public object Item { get; set; }

    [XmlElement(ElementName = "extension", Order = 11)]
    public ExtensionType Extension { get; set; }
}
