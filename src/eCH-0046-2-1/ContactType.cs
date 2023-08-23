// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0044_2_0;
using Newtonsoft.Json;

namespace eCH_0046_2_1;

[Serializable]
[JsonObject("contactType")]
[XmlRoot(ElementName = "contactType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class ContactType : FieldValueChecker<ContactType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private NamedPersonId _localId;
    private List<AddressType> _address;
    private List<EmailType> _email;
    private List<PhoneType> _phone;
    private List<InternetType> _internet;

    public ContactType()
    {
        Xmlns.Add("eCH-0046", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

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
    public static ContactType Create(NamedPersonId namedPersonId = null, List<AddressType> address = null, List<EmailType> email = null, List<PhoneType> phone = null, List<InternetType> internet = null)
    {
        return new ContactType
        {
            LocalId = namedPersonId,
            Address = address,
            Email = email,
            Phone = phone,
            Internet = internet
        };
    }

    [JsonProperty("localID")]
    [XmlElement(ElementName = "localID")]
    public NamedPersonId LocalId
    {
        get => _localId;
        set => CheckAndSetValue(ref _localId, value);
    }

    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public List<AddressType> Address
    {
        get => _address;
        set => CheckAndSetValue(ref _address, value);
    }

    [JsonProperty("email")]
    [XmlElement(ElementName = "email")]
    public List<EmailType> Email
    {
        get => _email;
        set => CheckAndSetValue(ref _email, value);
    }

    [JsonProperty("phone")]
    [XmlElement(ElementName = "phone")]
    public List<PhoneType> Phone
    {
        get => _phone;
        set => CheckAndSetValue(ref _phone, value);
    }

    [JsonProperty("internet")]
    [XmlElement(ElementName = "internet")]
    public List<InternetType> Internet
    {
        get => _internet;
        set => CheckAndSetValue(ref _internet, value);
    }
}
