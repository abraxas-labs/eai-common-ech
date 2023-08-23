// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("reportingBodyType")]
[XmlRoot(ElementName = "reportingBodyType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class ReportingBodyType
{
    private const string CreationDateTimeNullValidateExceptionMessage = "CreationDateTime is not valid! CreationDateTime is required";
    private const string CreationDateTimeValidateExceptionMessage = "CreationDateTime is not valid! CreationDateTime is not a correct date";

    private DateTime _creationDateTime;

    [XmlElement(ElementName = "reportingBodyIdentification", DataType = "token", Order = 1)]
    public string ReportingBodyIdentification { get; set; }

    [XmlElement(ElementName = "creationDateTime", Order = 2)]
    public string CreationDateTime
    {
        get
        {
            return _creationDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(CreationDateTimeNullValidateExceptionMessage);
            }

            if (!DateTime.TryParse(value, out _creationDateTime))
            {
                throw new XmlSchemaValidationException(CreationDateTimeValidateExceptionMessage);
            }
        }
    }

    public static ReportingBodyType Create(string reportingBodyIdentification, DateTime creationDateTime)
    {
        return new ReportingBodyType
        {
            ReportingBodyIdentification = reportingBodyIdentification,
            _creationDateTime = creationDateTime,
        };
    }
}
