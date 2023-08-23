// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_6_0;
using Newtonsoft.Json;

namespace eCH_0046_4_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Kontakt (eCH-0046)
/// addressType - Postadresse.
/// </summary>
[Serializable]
[JsonObject("addressType")]
[XmlRoot(ElementName = "addressType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0046/4")]
public class AddressType : FieldValueChecker<AddressType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AddressCategoryType? _addressCategory;
    private string _otherAddressCategory;
    private MailAddressType _postalAddress;
    private DateRangeType _validity;

    public AddressType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="postalAddress">Field is required.</param>
    /// <param name="addressCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Address.</returns>
    public static AddressType Create(MailAddressType postalAddress, AddressCategoryType? addressCategory = null, DateRangeType validity = null)
    {
        return new AddressType
        {
            AddressCategory = addressCategory,
            OtherCategoryText = null,
            PostalAddress = postalAddress,
            Validity = validity
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="postalAddress">Field is required.</param>
    /// <param name="otherAddressCategory">Field is optional.</param>
    /// <param name="validity">Field is optional.</param>
    /// <returns>Address.</returns>
    public static AddressType Create(MailAddressType postalAddress, string otherAddressCategory = null, DateRangeType validity = null)
    {
        return new AddressType
        {
            AddressCategory = null,
            OtherCategoryText = otherAddressCategory,
            PostalAddress = postalAddress,
            Validity = validity
        };
    }

    [JsonProperty("addressCategory")]
    [XmlElement(ElementName = "addressCategory")]
    public AddressCategoryType? AddressCategory
    {
        get => _addressCategory;
        set
        {
            CheckAndSetValue(ref _addressCategory, value);
            _otherAddressCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool AddressCategorySpecified => AddressCategory.HasValue;

    [FieldMaxLength(100)]
    [JsonProperty("otherAddressCategory")]
    [XmlElement(ElementName = "otherAddressCategory")]
    public string OtherCategoryText
    {
        get => _otherAddressCategory;
        set
        {
            CheckAndSetValue(ref _otherAddressCategory, value);
            _addressCategory = null;
        }
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool OtherCategoryTextSpecified => string.IsNullOrWhiteSpace(OtherCategoryText);

    [FieldRequired]
    [JsonProperty("postalAddress")]
    [XmlElement(ElementName = "postalAddress")]
    public MailAddressType PostalAddress
    {
        get => _postalAddress;
        set => CheckAndSetValue(ref _postalAddress, value);
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
