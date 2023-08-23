// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "countingCircleResultsType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class CountingCircleResultsType
{
    private CountingCircleType _countingCircleField;

    private VotingCardsInformationType _votingCardsInformationField;

    private VoteResultType[] _voteResultsField;

    private ElectionGroupResultsType[] _electionGroupResultsField;

    private ExtensionType _extensionField;

    [XmlElement("countingCircle", Order = 1)]
    public CountingCircleType CountingCircle
    {
        get
        {
            return _countingCircleField;
        }

        set
        {
            _countingCircleField = value;
        }
    }

    [XmlElement("votingCardsInformation", Order = 2)]
    public VotingCardsInformationType VotingCardsInformation
    {
        get
        {
            return _votingCardsInformationField;
        }

        set
        {
            _votingCardsInformationField = value;
        }
    }

    [XmlElement("voteResults", Order = 3)]
    public VoteResultType[] VoteResults
    {
        get
        {
            return _voteResultsField;
        }

        set
        {
            _voteResultsField = value;
        }
    }

    [XmlElement("electionGroupResults", Order = 4)]
    public ElectionGroupResultsType[] ElectionGroupResults
    {
        get
        {
            return _electionGroupResultsField;
        }

        set
        {
            _electionGroupResultsField = value;
        }
    }

    [XmlElement("extension", Order = 5)]
    public ExtensionType Extension
    {
        get
        {
            return _extensionField;
        }

        set
        {
            _extensionField = value;
        }
    }
}
