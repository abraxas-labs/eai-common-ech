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
/// internet – Internet-Adresse.
/// </summary>
[Serializable]
[JsonObject("internetType")]
[XmlRoot(ElementName = "internetType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0046/4")]
public class InternetType : FieldValueChecker<InternetType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private InternetCategoryType? _internetCategory;
    private string _otherInternetCategory;
    private string _internetAddress;
    private DateRangeType _validity;

    public InternetType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="internetAddress">Field is required.</param>
    /// <param name="internetCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Internet.</returns>
    public static InternetType Create(string internetAddress, InternetCategoryType? internetCategory = null, DateRangeType validity = null)
    {
        return new InternetType
        {
            InternetCategory = internetCategory,
            OtherInternetCategory = null,
            InternetAddress = internetAddress,
            Validity = validity
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="internetAddress">Field is required.</param>
    /// <param name="otherInternetCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Internet.</returns>
    public static InternetType Create(string internetAddress, string otherInternetCategory = null, DateRangeType validity = null)
    {
        return new InternetType
        {
            InternetCategory = null,
            OtherInternetCategory = otherInternetCategory,
            InternetAddress = internetAddress,
            Validity = validity
        };
    }

    [JsonProperty("internetCategory")]
    [XmlElement(ElementName = "internetCategory")]
    public InternetCategoryType? InternetCategory
    {
        get => _internetCategory;
        set
        {
            CheckAndSetValue(ref _internetCategory, value);
            _otherInternetCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool InternetCategorySpecified => InternetCategory.HasValue;

    [FieldMaxLength(100)]
    [JsonProperty("otherInternetCategory")]
    [XmlElement(ElementName = "otherInternetCategory")]
    public string OtherInternetCategory
    {
        get => _otherInternetCategory;
        set
        {
            CheckAndSetValue(ref _otherInternetCategory, value);
            _internetCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool OtherInternetCategorySpecified => string.IsNullOrWhiteSpace(OtherInternetCategory);

    [FieldRequired]
    [FieldMaxLength(100)]
    [FieldRegex("^(http|https)://.*")]
    [JsonProperty("internetAddress")]
    [XmlElement(ElementName = "internetAddress")]
    public string InternetAddress
    {
        get => _internetAddress;
        set => CheckAndSetValue(ref _internetAddress, value);
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
