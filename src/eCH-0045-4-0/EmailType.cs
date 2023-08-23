// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("emailType")]
[XmlRoot(ElementName = "emailType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class EmailType : FieldValueChecker<EmailType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private EmailCategoryType _emailCategory;
    private string _otherEmailCategory;
    private string _emailAddress;
    private DateRangeType _validity;

    public EmailType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="emailCategory">Field is optional.</param>
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>EmailType.</returns>
    public static EmailType Create(EmailCategoryType emailCategory, string emailAddress, DateRangeType validity)
    {
        return new EmailType
        {
            EmailCategory = emailCategory,
            EmailAddress = emailAddress,
            Validity = validity
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="otherEmailCategory">Field is optional.</param>
    /// <param name="emailAddress">Field is required.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>EmailType.</returns>
    public static EmailType Create(string otherEmailCategory, string emailAddress, DateRangeType validity)
    {
        return new EmailType
        {
            OtherEmailCategory = otherEmailCategory,
            EmailAddress = emailAddress,
            Validity = validity
        };
    }

    [JsonProperty("emailCategory")]
    [XmlElement(ElementName = "emailCategory", Order = 1)]
    public EmailCategoryType EmailCategory
    {
        get => _emailCategory;
        set => CheckAndSetValue(ref _emailCategory, value);
    }

    [JsonProperty("otherEmailCategory")]
    [XmlElement(ElementName = "otherEmailCategory", Order = 2)]
    public string OtherEmailCategory
    {
        get => _otherEmailCategory;
        set => CheckAndSetValue(ref _otherEmailCategory, value);
    }

    [FieldRequired]
    [FieldRegex(@"[A-Za-z0-9!#-'\*\+\-/=\?\^_`\{-~]+(\.[A-Za-z0-9!#-'\*\+\-/=\?\^_`\{-~]+)*@[A-Za-zäöüÄÖÜ0-9!#-'\*\+\-/=\?\^_`\{-~]+(\.[A-Za-z0-9!#-'\*\+\-/=\?\^_`\{-~]+)*")]
    [FieldMaxLength(100)]
    [JsonProperty("emailAddress")]
    [XmlElement(ElementName = "emailAddress", Order = 3)]
    public string EmailAddress
    {
        get => _emailAddress;
        set => CheckAndSetValue(ref _emailAddress, value);
    }

    [JsonProperty("validity")]
    [XmlElement(ElementName = "validity", Order = 4)]
    public DateRangeType Validity
    {
        get => _validity;
        set => CheckAndSetValue(ref _validity, value);
    }
}
