// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "voteResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class VoteResultType
{
    private CountOfVotersInformationType _countOfVotersInformationField;

    private BallotResultType[] _ballotResultField;

    [XmlElement("vote", Order = 1)]
    public VoteType Vote { get; set; }

    [XmlElement("countOfVotersInformation", Order = 2)]
    public CountOfVotersInformationType CountOfVotersInformation
    {
        get
        {
            return this._countOfVotersInformationField;
        }

        set
        {
            this._countOfVotersInformationField = value;
        }
    }

    [XmlElement("ballotResult", Order = 3)]
    public BallotResultType[] ballotResult
    {
        get
        {
            return this._ballotResultField;
        }

        set
        {
            this._ballotResultField = value;
        }
    }
}
