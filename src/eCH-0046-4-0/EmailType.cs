// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0046_4_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Kontakt (eCH-0046)
/// emailType - E-Mail.
/// </summary>
[Serializable]
[JsonObject("emailType")]
[XmlRoot(ElementName = "emailType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/4")]
public class EmailType : FieldValueChecker<EmailType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private EmailCategoryType? _emailCategory;
    private string _otherEmailCategory;
    private string _emailAddress;
    private DateRangeType _validity;

    public EmailType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="emailCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Email.</returns>
    public static EmailType Create(string emailAddress, EmailCategoryType? emailCategory = null, DateRangeType validity = null)
    {
        return new EmailType
        {
            EmailCategory = emailCategory,
            OtherEmailCategory = null,
            EmailAddress = emailAddress,
            Validity = validity
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="otherEmailCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Email.</returns>
    public static EmailType Create(string emailAddress, string otherEmailCategory = null, DateRangeType validity = null)
    {
        return new EmailType
        {
            EmailCategory = null,
            OtherEmailCategory = otherEmailCategory,
            EmailAddress = emailAddress,
            Validity = validity
        };
    }

    [JsonProperty("emailCategory")]
    [XmlElement(ElementName = "emailCategory")]
    public EmailCategoryType? EmailCategory
    {
        get => _emailCategory;
        set
        {
            CheckAndSetValue(ref _emailCategory, value);
            _otherEmailCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool EmailCategorySpecified => EmailCategory.HasValue;

    [FieldMaxLength(100)]
    [JsonProperty("otherEmailCategory")]
    [XmlElement(ElementName = "otherEmailCategory")]
    public string OtherEmailCategory
    {
        get => _otherEmailCategory;
        set
        {
            CheckAndSetValue(ref _otherEmailCategory, value);
            _emailCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool OtherEmailCategorySpecified => string.IsNullOrWhiteSpace(OtherEmailCategory);

    [FieldRequired]
    [FieldRegex("[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-\'\\*\\+\\-/=\\?\\^_`\\{-~]+(\\.[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-\'\\*\\+\\-/=\\?\\^_`\\{-~]+)*@[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-\'\\*\\+\\-/=\\?\\^_`\\{-~]+(\\.[A-Za-zäöüÄÖÜàáâãåæçèéêëìíîïðñòóôõøùúûýþÿ0-9!#-\'\\*\\+\\-/=\\?\\^_`\\{-~]+)*")]
    [JsonProperty("emailAddress")]
    [XmlElement(ElementName = "emailAddress")]
    public string EmailAddress
    {
        get => _emailAddress;
        set => CheckAndSetValue(ref _emailAddress, value);
    }

    [JsonProperty("validity")]
    [XmlElement(ElementName = "validity")]
    public DateRangeType Validity
    {
        get => _validity;
        set => CheckAndSetValue(ref _validity, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool ValiditySpecified => Validity != null;
}
