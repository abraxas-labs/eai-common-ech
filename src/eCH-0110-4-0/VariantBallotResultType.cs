// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "variantBallotResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class VariantBallotResultType
{
    private StandardBallotResultType[] _questionInformationField;
    private TieBreak[] _tieBreakField;

    [XmlElement("questionInformation", Order = 1)]
    public StandardBallotResultType[] questionInformation
    {
        get
        {
            return _questionInformationField;
        }

        set
        {
            _questionInformationField = value;
        }
    }

    [XmlElement("tieBreak", Order = 2)]
    public TieBreak[] tieBreak
    {
        get
        {
            return _tieBreakField;
        }

        set
        {
            _tieBreakField = value;
        }
    }
}
