// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_3_0;
using Newtonsoft.Json;

namespace eCH_0046_1_0;

[Serializable]
[JsonObject("addressType")]
[XmlRoot(ElementName = "addressType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0046/1")]
public class Address
{
    private const string MailAddressNullValidationExceptionMessage =
        "MailAddress is not valid! MailAddress is required";

    private const string FreeCategoryTextValidationExceptionMessage =
        "FreeCategoryText is not valid! FreeCategoryText has to be max. 100 chars";

    private MailAddress _mailAddress;
    private string _addressCategory;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Address()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/1");
    }

    [JsonProperty("addressCategory")]
    [XmlElement(ElementName = "addressCategory")]
    public string AddressCategory
    {
        get => _addressCategory;
        set => _addressCategory = value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool AddressCategorySpecified => AddressCategory != null;

    [JsonProperty("postalAddress")]
    [XmlElement(ElementName = "postalAddress")]
    public MailAddress MailAddress
    {
        get => _mailAddress;
        set => _mailAddress = value ?? throw new XmlSchemaValidationException(MailAddressNullValidationExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="mailAddress">Field is required.</param>
    /// <param name="addressCategory">Field is optional.</param>
    /// <returns>Address.</returns>
    public static Address Create(MailAddress mailAddress, string addressCategory)
    {
        return new Address
        {
            AddressCategory = addressCategory,
            MailAddress = mailAddress
        };
    }
}
