// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "electionGroupResultsType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ElectionGroupResultsType
{
    private ElectionResultType[] _electionResultsField;
    private string _electionGroupIdentification;
    private string _domainOfInfluenceIdentification;
    private ElectionGroupDescriptionType _electionGroupDescription;
    private string _electionGroupPosition;
    private CountOfVotersInformationType _countOfVotersInformation;
    private ResultDetailType _countOfUnaccountedInvalidBallots;
    private ResultDetailType _countOfUnaccountedBlankBallots;
    private ResultDetailType _countOfUnaccountedBallots;
    private ResultDetailType _countOfAccountedBallots;
    private ResultDetailType _countOfReceivedBallotsTotal;

    [XmlElement(ElementName = "electionGroupIdentification", DataType = "token", Order = 1)]
    public string ElectionGroupIdentification { get => _electionGroupIdentification; set => _electionGroupIdentification = value; }

    [XmlElement(ElementName = "domainOfInfluenceIdentification", DataType = "token", Order = 2)]
    public string DomainOfInfluenceIdentification { get => _domainOfInfluenceIdentification; set => _domainOfInfluenceIdentification = value; }

    [XmlElement("electionGroupDescription", Order = 3)]
    public ElectionGroupDescriptionType ElectionGroupDescription { get => _electionGroupDescription; set => _electionGroupDescription = value; }

    [XmlElement(ElementName = "electionGroupPosition", Order = 4)]
    public string ElectionGroupPosition { get => _electionGroupPosition; set => _electionGroupPosition = value; }

    [XmlElement("countOfVotersInformation", Order = 5)]
    public CountOfVotersInformationType CountOfVotersInformation { get => _countOfVotersInformation; set => _countOfVotersInformation = value; }

    [XmlElement("countOfReceivedBallotsTotal", Order = 6)]
    public ResultDetailType CountOfReceivedBallotsTotal { get => _countOfReceivedBallotsTotal; set => _countOfReceivedBallotsTotal = value; }

    [XmlElement("countOfAccountedBallots", Order = 7)]
    public ResultDetailType CountOfAccountedBallots { get => _countOfAccountedBallots; set => _countOfAccountedBallots = value; }

    [XmlElement("countOfUnaccountedBallots", Order = 8)]
    public ResultDetailType CountOfUnaccountedBallots { get => _countOfUnaccountedBallots; set => _countOfUnaccountedBallots = value; }

    [XmlElement("countOfUnaccountedBlankBallots", Order = 9)]
    public ResultDetailType CountOfUnaccountedBlankBallots { get => _countOfUnaccountedBlankBallots; set => _countOfUnaccountedBlankBallots = value; }

    [XmlElement("countOfUnaccountedInvalidBallots", Order = 10)]
    public ResultDetailType CountOfUnaccountedInvalidBallots { get => _countOfUnaccountedInvalidBallots; set => _countOfUnaccountedInvalidBallots = value; }

    [XmlElement("electionResults", Order = 11)]
    public ElectionResultType[] ElectionResults
    {
        get
        {
            return _electionResultsField;
        }

        set
        {
            _electionResultsField = value;
        }
    }
}
