// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_1_0;

[Serializable]
[JsonObject("dateRangeType")]
[XmlRoot(ElementName = "dateRangeType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/1")]
public class DateRange
{
    [JsonProperty("dateFrom")]
    [XmlElement(ElementName = "dateFrom")]
    public DateTime? DateFrom { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool DateFromSpecified => DateFrom != null;

    [JsonProperty("dateTo")]
    [XmlElement(ElementName = "dateTo")]
    public DateTime? DateTo { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool DateToSpecified => DateTo != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateFrom">Field is optional.</param>
    /// <param name="dateTo">Field is optional.</param>
    /// <returns>DateRange.</returns>
    public static DateRange Create(DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        return new DateRange
        {
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }
}
