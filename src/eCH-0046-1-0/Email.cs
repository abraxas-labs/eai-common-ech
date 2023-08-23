// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_1_0;

[Serializable]
[JsonObject("emailType")]
[XmlRoot(ElementName = "emailType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/1")]
public class Email
{
    private const string EmailAddressNullValidationExceptionMessage =
        "EmailAddress is not valid! EmailAddress is required";

    private const string EmailAddressValidationExceptionMessage =
        "EmailAddress is not valid! EmailAddress has to be max. 100 chars long and has to match the pattern of gabriel@nobel.ch";

    private string _emailAddress;
    private string _emailCategory;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Email()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/1");
    }

    [JsonProperty("emailCategory")]
    [XmlElement(ElementName = "emailCategory")]
    public string EmailCategory
    {
        get => _emailCategory;
        set => _emailCategory = value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool EmailCategorySpecified => EmailCategory != null;

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

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="emailCategory">Field is optional.</param>
    /// <returns>Email.</returns>
    public static Email Create(string emailAddress, string emailCategory = null)
    {
        return new Email
        {
            EmailCategory = emailCategory,
            EmailAddress = emailAddress
        };
    }
}
