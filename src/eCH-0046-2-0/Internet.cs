// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_2_0;

[Serializable]
[JsonObject("internetType")]
[XmlRoot(ElementName = "internetType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class Internet
{
    private const string InternetAddressValidationExceptionMessage =
        "InternetAddress is not valid! InternetAddress has to be max. 100 chars and has to contain https://. or http://.";

    private const string InternetAddressNullValidationExceptionMessage =
        "InternetAddress is not valid! InternetAddress is required";

    private const string InternetCategoryValidationExceptionMessage =
        "InternetCategory is not valid! InternetCategory has to be between 1 to 10 or null";

    private const string FreeCategoryTextValidationExceptionMessage =
        "FreeCategoryText is not valid! FreeCategoryText has to be max. 100 chars";

    private string _internetAddress;
    private int? _internetCategory;
    private string _freeCategoryText;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Internet()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    [JsonProperty("internetCategory")]
    [XmlElement(ElementName = "internetCategory")]
    public int? InternetCategory
    {
        get => _internetCategory;
        set => _internetCategory = InternetCategoryIsValid(value);
    }

    private int? InternetCategoryIsValid(int? value)
    {
        if (value < 1 || value > 2)
        {
            throw new XmlSchemaValidationException(InternetCategoryValidationExceptionMessage);
        }

        return value.GetValueOrDefault();
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool InternetCategoryTextSpecified => InternetCategory != null;

    [JsonProperty("otherInternetCategory")]
    [XmlElement(ElementName = "otherInternetCategory")]
    public string FreeCategoryText
    {
        get => _freeCategoryText;
        set => _freeCategoryText = FreeCategoryTextIsValid(value);
    }

    private string FreeCategoryTextIsValid(string value)
    {
        Regex.Replace(value, @"\s+", "");
        if (value.Length <= 100)
        {
            return value;
        }
        throw new XmlSchemaValidationException(FreeCategoryTextValidationExceptionMessage);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool FreeCategoryTextTextSpecified => FreeCategoryText != null;

    [JsonProperty("internetAddress")]
    [XmlElement(ElementName = "internetAddress")]
    public string InternetAddress
    {
        get => _internetAddress;
        set => _internetAddress = InternetAddressIsValid(value);
    }

    private string InternetAddressIsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new XmlSchemaValidationException(InternetAddressNullValidationExceptionMessage);
        }

        Regex.Replace(value, @"\s+", "");
        if (value.Length > 100 || !Regex.Match(value, @"https://.*", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success || !Regex.Match(value, @"http://.*", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
        {
            throw new XmlSchemaValidationException(InternetAddressValidationExceptionMessage);
        }

        return value;
    }

    [JsonProperty("validity")]
    [XmlElement(ElementName = "validity")]
    public DateRange DateRange { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool DateRangeSpecified => DateRange != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="internetAddress">Field is required.</param>
    /// <param name="internetCategory">Field is optional.</param>
    /// <param name="freeCategoryText">Field is optional.</param>
    /// <param name="dateRange">Field is optional.</param>
    /// <returns>Internet.</returns>
    public static Internet Create(string internetAddress, int? internetCategory = null, string freeCategoryText = null, DateRange dateRange = null)
    {
        return new Internet
        {
            InternetCategory = internetCategory,
            FreeCategoryText = freeCategoryText,
            InternetAddress = internetAddress,
            DateRange = dateRange
        };
    }
}
