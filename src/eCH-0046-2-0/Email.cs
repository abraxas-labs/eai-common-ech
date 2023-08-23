// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_2_0;

[Serializable]
[JsonObject("emailType")]
[XmlRoot(ElementName = "emailType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class Email
{
    private const string EmailAddressNullValidationExceptionMessage =
        "EmailAddress is not valid! EmailAddress is required";

    private const string EmailCategoryValidationExceptionMessage =
        "EmailCategory is not valid! EmailCategory has to be 1, 2 or null";

    private const string EmailAddressValidationExceptionMessage =
        "EmailAddress is not valid! EmailAddress has to be max. 100 chars long and has to match the pattern of gabriel@nobel.ch";

    private const string FreeCategoryTextValidationExceptionMessage =
        "FreeCategoryText is not valid! FreeCategoryText has to be max. 100 chars";

    private string _emailAddress;
    private int? _emailCategory;
    private string _freeCategoryText;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Email()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    [JsonProperty("emailCategory")]
    [XmlElement(ElementName = "emailCategory")]
    public int? EmailCategory
    {
        get => _emailCategory;
        set => _emailCategory = EmailCategoryIsValid(value);
    }

    private int? EmailCategoryIsValid(int? value)
    {
        if (value < 1 || value > 2)
        {
            throw new XmlSchemaValidationException(EmailCategoryValidationExceptionMessage);
        }

        return value.GetValueOrDefault();
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool EmailCategorySpecified => EmailCategory != null;

    [JsonProperty("otherEmailCategory")]
    [XmlElement(ElementName = "otherEmailCategory")]
    public string FreeCategoryText
    {
        get => _freeCategoryText;
        set => _freeCategoryText = FreeCategoryTextIsValid(value);
    }

    private string FreeCategoryTextIsValid(string value)
    {
        Regex.Replace(value, @"\s+", "");
        if (value.Length > 100)
        {
            throw new XmlSchemaValidationException(FreeCategoryTextValidationExceptionMessage);
        }

        return value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool FreeCategoryTextSpecified => FreeCategoryText != null;

    [JsonProperty("emailAddress")]
    [XmlElement(ElementName = "emailAddress")]
    public string EmailAddress
    {
        get => _emailAddress;
        set => _emailAddress = EmailAddressIsValid(value);
    }

    private string EmailAddressIsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new XmlSchemaValidationException(EmailAddressNullValidationExceptionMessage);
        }

        Regex.Replace(value, @"\s+", "");
        if (value.Length > 100 || !Regex.Match(value, @"[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-'\*\+\-/=\?\^_`\{-~]+(\.[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-'\*\+\-/=\?\^_`\{-~]+)*@[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-'\*\+\-/=\?\^_`\{-~]+(\.[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-'\*\+\-/=\?\^_`\{-~]+)*", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
        {
            throw new XmlSchemaValidationException(EmailAddressValidationExceptionMessage);
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
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="emailCategory">Field is optional.</param>
    /// <param name="freeCategoryText">Field is optional.</param>
    /// <param name="dateRange">Field is optional.</param>
    /// <returns>Email.</returns>
    public static Email Create(string emailAddress, int? emailCategory = null, string freeCategoryText = null, DateRange dateRange = null)
    {
        return new Email
        {
            EmailCategory = emailCategory,
            FreeCategoryText = freeCategoryText,
            EmailAddress = emailAddress,
            DateRange = dateRange
        };
    }
}
