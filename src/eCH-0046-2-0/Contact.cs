// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0044_2_0;
using Newtonsoft.Json;

namespace eCH_0046_2_0;

[Serializable]
[JsonObject("contactType")]
[XmlRoot(ElementName = "contactType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class Contact
{
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Contact()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    [JsonProperty("localID")]
    [XmlElement(ElementName = "localID")]
    public NamedPersonId NamedPersonId { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool NamedPersonIdSpecified => NamedPersonId != null;

    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public List<Address> Address { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool AddressSpecified => Address != null;

    [JsonProperty("email")]
    [XmlElement(ElementName = "email")]
    public List<Email> Email { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool EmailSpecified => Email != null;

    [JsonProperty("phone")]
    [XmlElement(ElementName = "phone")]
    public List<Phone> Phone { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool PhoneSpecified => Phone != null;

    [JsonProperty("internet")]
    [XmlElement(ElementName = "internet")]
    public List<Internet> Internet { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool InternetSpecified => Internet != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="namedPersonId">Field is optional.</param>
    /// <param name="address">Field is optional.</param>
    /// <param name="email">Field is optional.</param>
    /// <param name="phone">Field is optional.</param>
    /// <param name="internet">Field is optional.</param>
    /// <returns>Contact.</returns>
    public static Contact Create(NamedPersonId namedPersonId = null, List<Address> address = null, List<Email> email = null, List<Phone> phone = null, List<Internet> internet = null)
    {
        return new Contact
        {
            NamedPersonId = namedPersonId,
            Address = address,
            Email = email,
            Phone = phone,
            Internet = internet
        };
    }
}
