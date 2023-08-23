// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0046_2_1;

[Serializable]
[JsonObject("phoneType")]
[XmlRoot(ElementName = "phoneType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class PhoneType : FieldValueChecker<PhoneType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PhoneCategoryType? _phoneCategory;
    private string _otherPhoneCategory;
    private string _phoneNumber;
    private DateRangeType _validity;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="phoneNumber">Field is required.</param>
    /// <param name="phoneCategory">Field is optional.</param>
    /// <param name="otherPhoneCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Phone.</returns>
    public static PhoneType Create(string phoneNumber, PhoneCategoryType? phoneCategory = null, string otherPhoneCategory = null, DateRangeType validity = null)
    {
        return new PhoneType
        {
            PhoneCategory = phoneCategory,
            OtherPhoneCategory = otherPhoneCategory,
            PhoneNumber = phoneNumber,
            Validity = validity
        };
    }

    public PhoneType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    [JsonProperty("phoneCategory")]
    [XmlElement(ElementName = "phoneCategory")]
    public PhoneCategoryType? PhoneCategory
    {
        get => _phoneCategory;
        set => CheckAndSetValue(ref _phoneCategory, value);
    }

    [FieldMaxLength(100)]
    [JsonProperty("otherPhoneCategory")]
    [XmlElement(ElementName = "otherPhoneCategory")]
    public string OtherPhoneCategory
    {
        get => _otherPhoneCategory;
        set => CheckAndSetValue(ref _otherPhoneCategory, value);
    }

    [FieldMaxLength(20)]
    [FieldRegex(@"\d{10,20}")]
    [JsonProperty("phoneNumber")]
    [XmlElement(ElementName = "phoneNumber")]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => CheckAndSetValue(ref _phoneNumber, value);
    }

    [JsonProperty("validity")]
    [XmlElement(ElementName = "validity")]
    public DateRangeType Validity
    {
        get => _validity;
        set => CheckAndSetValue(ref _validity, value);
    }
}
