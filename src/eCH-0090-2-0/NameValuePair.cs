// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eCH_0090_2_0;

[Serializable]
[XmlRoot(ElementName = "nameValuePair", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0090/2")]
public class NameValuePair
{
    private const string NameNullValidateExceptionMessage = "Name is not valid! Name is required";
    private const string ValueNullValidateExceptionMessage = "Value is not valid! Value is required";

    private string _name;
    private string _value;

    [XmlElement(ElementName = "name")]
    public string Name
    {
        get { return _name; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(NameNullValidateExceptionMessage);
            }
            _name = value;
        }
    }

    [XmlElement(ElementName = "value")]
    public string Value
    {
        get { return _value; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ValueNullValidateExceptionMessage);
            }
            _value = value;
        }
    }
}
