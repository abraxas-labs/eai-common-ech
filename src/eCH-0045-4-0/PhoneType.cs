// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("phoneType")]
[XmlRoot(ElementName = "phoneType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class PhoneType : FieldValueChecker<PhoneType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PhoneCategoryType _phoneCategory;
    private string _otherPhoneCategory;
    private string _phoneNumber;
    private DateRangeType _validity;

    public PhoneType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="phoneCategory">Field is optional.</param>
    /// <param name="phoneNumber">Field is required.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>PhoneType.</returns>
    public static PhoneType Create(PhoneCategoryType phoneCategory, string phoneNumber, DateRangeType validity)
    {
        return new PhoneType
        {
            PhoneCategory = phoneCategory,
            PhoneNumber = phoneNumber,
            Validity = validity
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="otherPhoneCategory">Field is optional.</param>
    /// <param name="phoneNumber">Field is required.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>PhoneType.</returns>
    public static PhoneType Create(string otherPhoneCategory, string phoneNumber, DateRangeType validity)
    {
        return new PhoneType
        {
            OtherPhoneCategory = otherPhoneCategory,
            PhoneNumber = phoneNumber,
            Validity = validity
        };
    }

    [JsonProperty("phoneCategory")]
    [XmlElement(ElementName = "phoneCategory", Order = 1)]
    public PhoneCategoryType PhoneCategory
    {
        get => _phoneCategory;
        set => CheckAndSetValue(ref _phoneCategory, value);
    }

    [JsonProperty("otherPhoneCategory")]
    [XmlElement(ElementName = "otherPhoneCategory", Order = 2)]
    public string OtherPhoneCategory
    {
        get => _otherPhoneCategory;
        set => CheckAndSetValue(ref _otherPhoneCategory, value);
    }

    [FieldRequired]
    [FieldRegex(@"\d{10,20}")]
    [FieldMaxLength(20)]
    [JsonProperty("phoneNumber")]
    [XmlElement(ElementName = "phoneNumber", Order = 3)]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => CheckAndSetValue(ref _phoneNumber, value);
    }

    [JsonProperty("validity")]
    [XmlElement(ElementName = "validity", Order = 4)]
    public DateRangeType Validity
    {
        get => _validity;
        set => CheckAndSetValue(ref _validity, value);
    }
}
