// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
public class CountInFavourOf
{
    private string _questionIdentificationField;

    private ResultDetailType _countOfValidAnswersField;

    [XmlElement(ElementName = "questionIdentification", DataType = "token", Order = 1)]
    public string QuestionIdentification
    {
        get
        {
            return this._questionIdentificationField;
        }

        set
        {
            this._questionIdentificationField = value;
        }
    }

    [XmlElement("countOfValidAnswers", Order = 2)]
    public ResultDetailType CountOfValidAnswers
    {
        get
        {
            return this._countOfValidAnswersField;
        }

        set
        {
            this._countOfValidAnswersField = value;
        }
    }
}
