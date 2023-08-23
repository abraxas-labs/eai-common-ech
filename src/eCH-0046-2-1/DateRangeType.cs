// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0046_2_1;

[Serializable]
[JsonObject("dateRangeType")]
[XmlRoot(ElementName = "dateRangeType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class DateRangeType : FieldValueChecker<DateRangeType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DateTime? _dateFrom;
    private DateTime? _dateTo;

    public DateRangeType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateFrom">Field is optional.</param>
    /// <param name="dateTo">Field is optional.</param>
    /// <returns>DateRange.</returns>
    public static DateRangeType Create(DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        return new DateRangeType
        {
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }

    [JsonProperty("dateFrom")]
    [XmlElement(DataType = "date", ElementName = "dateFrom")]
    public DateTime? DateFrom
    {
        get => _dateFrom;
        set => CheckAndSetValue(ref _dateFrom, value);
    }

    [JsonProperty("dateTo")]
    [XmlElement(DataType = "date", ElementName = "dateTo")]
    public DateTime? DateTo
    {
        get => _dateTo;
        set => CheckAndSetValue(ref _dateTo, value);
    }
}
