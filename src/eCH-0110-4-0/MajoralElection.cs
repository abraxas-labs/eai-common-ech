// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
public class MajoralElection
{
    private CandidateResultType[] _candidateField;

    private ResultDetailType _countOfInvalidVotesTotalField;

    private ResultDetailType _countOfBlankVotesTotalField;

    private ResultDetailType _countOfIndividualVotesTotalField;

    [XmlElement("candidate", Order = 1)]
    public CandidateResultType[] Candidate
    {
        get
        {
            return _candidateField;
        }

        set
        {
            _candidateField = value;
        }
    }

    [XmlElement("countOfInvalidVotesTotal", Order = 2)]
    public ResultDetailType CountOfInvalidVotesTotal
    {
        get
        {
            return _countOfInvalidVotesTotalField;
        }

        set
        {
            _countOfInvalidVotesTotalField = value;
        }
    }

    [XmlElement("countOfBlankVotesTotal", Order = 3)]
    public ResultDetailType CountOfBlankVotesTotal
    {
        get
        {
            return _countOfBlankVotesTotalField;
        }

        set
        {
            _countOfBlankVotesTotalField = value;
        }
    }

    [XmlElement("countOfIndividualVotesTotal", Order = 4)]
    public ResultDetailType CountOfIndividualVotesTotal
    {
        get
        {
            return _countOfIndividualVotesTotalField;
        }

        set
        {
            _countOfIndividualVotesTotalField = value;
        }
    }
}
