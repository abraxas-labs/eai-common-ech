// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0044_1_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// Bestimmt das Geburtsdatum, welches auch nur Teilweise vorhanden sein kann.
/// </summary>
[JsonObject("datePartiallyKnown")]
[XmlRoot(ElementName = "datePartiallyKnown", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/1")]
public class DatePartiallyKnown
{
    private const string YearMonthRegex = @"^(\d){4}-(\d){2}";
    private const string YearMonthDayValidateExceptionMessage = "yearMonthDay is not valid!";
    private const string YearMonthValidateExceptionMessage = @"yearMonth is not valid! yearMonth has to expect on regex : ^(\d){4}-(\d){2}";
    private const string YearValidateExceptionMessage = "year is not valid! year has to bee between 1000 and 9999";
    private DateTime? _yearMonthDay;
    private string _yearMonth;
    private string _year;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public DatePartiallyKnown()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/1");
    }

    /// <summary>
    /// Statische Methode, welche das genaue Geburtsdatum setzt.
    /// </summary>
    /// <param name="yearMonthDay">Field is required.</param>
    /// <returns>DatePartiallyKnown.</returns>
    public static DatePartiallyKnown Create(DateTime yearMonthDay)
    {
        return new DatePartiallyKnown
        {
            YearMonthDay = yearMonthDay
        };
    }

    /// <summary>
    /// Statische Methode, welche das Geburtsjahr und den Geburtsmonat setzt.
    /// </summary>
    /// <param name="yearMonth">Field is required.</param>
    /// <returns>DatePartiallyKnown.</returns>
    public static DatePartiallyKnown Create(string yearMonth)
    {
        return new DatePartiallyKnown()
        {
            YearMonth = yearMonth
        };
    }

    /// <summary>
    /// Statische Methode, welche nur das Geburtsjahr setzt.
    /// </summary>
    /// <param name="year">Field is required.</param>
    /// <returns>DatePartiallyKnown.</returns>
    public static DatePartiallyKnown Create(short year)
    {
        return new DatePartiallyKnown()
        {
            Year = year.ToString()
        };
    }

    [JsonProperty("yearMonthDay")]
    [XmlElement(DataType = "date", ElementName = "yearMonthDay")]
    public DateTime? YearMonthDay
    {
        get => _yearMonthDay;
        set
        {
            if (value == DateTime.MinValue)
            {
                throw new XmlSchemaValidationException(YearMonthDayValidateExceptionMessage);
            }
            _yearMonthDay = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool YearMonthDaySpecified => YearMonthDay.HasValue;

    [JsonProperty("yearMonth")]
    [XmlElement(DataType = "gYearMonth", ElementName = "yearMonth")]
    public string YearMonth
    {
        get => _yearMonth;
        set
        {
            Regex regex = new(YearMonthRegex, RegexOptions.None, TimeSpan.FromMilliseconds(500));

            if (!string.IsNullOrEmpty(value) && !regex.IsMatch(value))
            {
                throw new XmlSchemaValidationException(YearMonthValidateExceptionMessage);
            }
            _yearMonth = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool YearMonthSpecified => !string.IsNullOrEmpty(YearMonth);

    [JsonProperty("year")]
    [XmlElement(DataType = "gYear", ElementName = "year")]
    public string Year
    {
        get => _year;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                _year = value;
                return;
            }
            if (value.Length < 4)
            {
                throw new XmlSchemaValidationException(YearValidateExceptionMessage);
            }
            var s = value.Substring(0, 4);
            if (!short.TryParse(s, out short year))
            {
                throw new XmlSchemaValidationException(YearValidateExceptionMessage);
            }
            if (year < 1000 || year > 9999)
            {
                throw new XmlSchemaValidationException(YearValidateExceptionMessage);
            }
            _year = s;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool YearSpecified => !string.IsNullOrEmpty(Year);
}
