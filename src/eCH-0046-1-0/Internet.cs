// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_1_0;

[Serializable]
[JsonObject("internetType")]
[XmlRoot(ElementName = "internetType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/1")]
public class Internet
{
    private const string InternetAddressValidationExceptionMessage =
        "InternetAddress is not valid! InternetAddress has to be max. 100 chars and has to contain https://. or http://.";

    private const string InternetAddressNullValidationExceptionMessage =
        "InternetAddress is not valid! InternetAddress is required";

    private string _internetAddress;
    private string _internetCategory;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Internet()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/1");
    }

    [JsonProperty("internetCategory")]
    [XmlElement(ElementName = "internetCategory")]
    public string InternetCategory
    {
        get => _internetCategory;
        set => _internetCategory = value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool InternetCategoryTextSpecified => InternetCategory != null;

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
        if (value.Length > 100 ||
           !Regex.Match(value, @"https://.*", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success ||
           !Regex.Match(value, @"http://.*", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
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
    /// <returns>Internet.</returns>
    public static Internet Create(string internetAddress, string internetCategory)
    {
        return new Internet
        {
            InternetCategory = internetCategory,
            InternetAddress = internetAddress
        };
    }
}
