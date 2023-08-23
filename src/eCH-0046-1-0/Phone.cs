// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0046_1_0;

[Serializable]
[JsonObject("phoneType")]
[XmlRoot(ElementName = "phoneType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/1")]
public class Phone
{
    private const string PhoneNumberNullValidationExceptionMessage =
        "PhoneNumber is not valid! PhoneNumber is required";

    private const string PhoneNumberValidationExceptionMessage =
        "PhoneNumber is not valid! PhoneNumber has to be between 10 and 20 numbers";

    private string _phoneNumber;
    private string _phoneCategory;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Phone()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/1");
    }

    [JsonProperty("phoneCategory")]
    [XmlElement(ElementName = "phoneCategory")]
    public string PhoneCategory
    {
        get => _phoneCategory;
        set => _phoneCategory = value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool PhoneCategorySpecified => PhoneCategory != null;

    [JsonProperty("phoneNumber")]
    [XmlElement(ElementName = "phoneNumber")]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = PhoneNumberIsValid(value);
    }

    private string PhoneNumberIsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new XmlSchemaValidationException(PhoneNumberNullValidationExceptionMessage);
        }

        Regex.Replace(value, @"\s+", "");
        if (value.Length > 20 || !Regex.Match(value, @"\d{10,20}", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
        {
            throw new XmlSchemaValidationException(PhoneNumberValidationExceptionMessage);
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
    /// <param name="phoneNumber">Field is required.</param>
    /// <param name="phoneCategory">Field is optional.</param>
    /// <returns>Phone.</returns>
    public static Phone Create(string phoneNumber, string phoneCategory)
    {
        return new Phone
        {
            PhoneCategory = phoneCategory,
            PhoneNumber = phoneNumber
        };
    }
}
