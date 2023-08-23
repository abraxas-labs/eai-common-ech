// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
public class TieBreak
{
    private string _questionIdentificationField;

    private AnswerInformationType _answerTypeField;

    private ResultDetailType _countOfAnswerInvalidField;

    private ResultDetailType _countOfAnswerEmptyField;

    private CountInFavourOf[] _countInFavourOfField;

    [XmlElement(ElementName = "questionIdentification", DataType = "token", Order = 1)]
    public string QuestionIdentification
    {
        get
        {
            return _questionIdentificationField;
        }

        set
        {
            _questionIdentificationField = value;
        }
    }

    [XmlElement("answerType", Order = 2)]
    public AnswerInformationType AnswerType
    {
        get
        {
            return _answerTypeField;
        }

        set
        {
            _answerTypeField = value;
        }
    }

    [XmlElement(ElementName = "tieBreakQuestion", IsNullable = false, Order = 3)]
    public TieBreakQuestion TieBreakQuestion { get; set; }

    [XmlElement("countOfAnswerInvalid", Order = 4)]
    public ResultDetailType CountOfAnswerInvalid
    {
        get
        {
            return _countOfAnswerInvalidField;
        }

        set
        {
            _countOfAnswerInvalidField = value;
        }
    }

    [XmlElement("countOfAnswerEmpty", Order = 5)]
    public ResultDetailType CountOfAnswerEmpty
    {
        get
        {
            return _countOfAnswerEmptyField;
        }

        set
        {
            _countOfAnswerEmptyField = value;
        }
    }

    [XmlElement("countInFavourOf", Order = 6)]
    public CountInFavourOf[] CountInFavourOf
    {
        get
        {
            return _countInFavourOfField;
        }

        set
        {
            _countInFavourOfField = value;
        }
    }
}
