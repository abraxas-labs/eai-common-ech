// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_4_0;
using Newtonsoft.Json;

namespace eCH_0046_2_0;

[Serializable]
[JsonObject("addressType")]
[XmlRoot(ElementName = "addressType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class Address
{
    private const string MailAddressNullValidationExceptionMessage =
        "MailAddress is not valid! MailAddress is required";

    private const string AddressCategoryValidationExceptionMessage =
        "AddressCategory is not valid! AddressCategory has to be 1, 2 or null";

    private const string FreeCategoryTextValidationExceptionMessage =
        "FreeCategoryText is not valid! FreeCategoryText has to be max. 100 chars";

    private MailAddress _mailAddress;
    private int? _addressCategory;
    private string _freeCategoryText;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Address()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    [JsonProperty("addressCategory")]
    [XmlElement(ElementName = "addressCategory")]
    public int? AddressCategory
    {
        get => _addressCategory;
        set => _addressCategory = AddressCategoryIsValid(value);
    }

    private int? AddressCategoryIsValid(int? value)
    {
        if (value < 1 || value > 2)
        {
            throw new XmlSchemaValidationException(AddressCategoryValidationExceptionMessage);
        }

        return value.GetValueOrDefault();
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool AddressCategorySpecified => AddressCategory != null;

    [JsonProperty("otherAddressCategory")]
    [XmlElement(ElementName = "otherAddressCategory")]
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

    [JsonProperty("postalAddress")]
    [XmlElement(ElementName = "postalAddress")]
    public MailAddress MailAddress
    {
        get => _mailAddress;
        set => _mailAddress = value ?? throw new XmlSchemaValidationException(MailAddressNullValidationExceptionMessage);
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
    /// <param name="mailAddress">Field is required.</param>
    /// <param name="addressCategory">Field is optional.</param>
    /// <param name="freeCategoryText">Field is optional.</param>
    /// <param name="dateRange">Field is optional.</param>
    /// <returns>Address.</returns>
    public static Address Create(MailAddress mailAddress, int? addressCategory = null, string freeCategoryText = null, DateRange dateRange = null)
    {
        return new Address
        {
            AddressCategory = addressCategory,
            FreeCategoryText = freeCategoryText,
            MailAddress = mailAddress,
            DateRange = dateRange
        };
    }
}
