// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "reportingBodyType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ReportingBodyType
{
    private const string CreationDateTimeNullValidateExceptionMessage = "CreationDateTime is not valid! CreationDateTime is required";
    private const string CreationDateTimeValidateExceptionMessage = "CreationDateTime is not valid! CreationDateTime is not a correct date";

    private DateTime _creationDateTime;

    [XmlElement(ElementName = "reportingBodyIdentification", DataType = "token", Order = 1)]
    public string ReportingBodyIdentification { get; set; }

    [XmlElement("domainOfInfluence", Order = 2)]
    public DomainOfInfluenceType DomainOfInfluence { get; set; }

    [XmlElement("creationDateTime", Order = 3)]
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

    public static ReportingBodyType Create(string reportingBodyIdentification, DomainOfInfluenceType domainOfInfluence, DateTime creationDateTime)
    {
        return new ReportingBodyType
        {
            ReportingBodyIdentification = reportingBodyIdentification,
            DomainOfInfluence = domainOfInfluence,
            _creationDateTime = creationDateTime,
        };
    }
}
