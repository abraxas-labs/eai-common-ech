// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_6_0;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("votingPersonOnlyType")]
[XmlRoot(ElementName = "votingPersonOnlyType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class VotingPersonOnlyType : FieldValueChecker<VotingPersonOnlyType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Nationality _person;
    private DataLockType _dataLock;
    private PersonMailAddressType _electoralAddress;
    private PersonMailAddressType _deliveryAddress;
    private EmailType _email;
    private PhoneType _phone;
    private bool? _isEvoter;

    public VotingPersonOnlyType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="dataLock">Field is required.</param>
    /// <param name="electoralAddress">Field is required.</param>
    /// <returns>VotingPersonOnlyType.</returns>
    public static VotingPersonOnlyType Create(Nationality person, DataLockType dataLock, PersonMailAddressType electoralAddress)
    {
        return new VotingPersonOnlyType
        {
            Person = person,
            DataLock = dataLock,
            ElectoralAddress = electoralAddress
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="dataLock">Field is required.</param>
    /// <param name="electoralAddress">Field is required.</param>
    /// <param name="deliveryAddress">Field is optional.</param>
    /// <param name="email">Field is optional.</param>
    /// <param name="phone">Field is optional.</param>
    /// <param name="isEvoter">Field is optional.</param>
    /// <returns>VotingPersonOnlyType.</returns>
    public static VotingPersonOnlyType Create(Nationality person, DataLockType dataLock, PersonMailAddressType electoralAddress,
        PersonMailAddressType deliveryAddress, EmailType email, PhoneType phone, bool? isEvoter)
    {
        return new VotingPersonOnlyType
        {
            Person = person,
            DataLock = dataLock,
            ElectoralAddress = electoralAddress,
            DeliveryAddress = deliveryAddress,
            Email = email,
            Phone = phone,
            IsEvoter = isEvoter
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public Nationality Person
    {
        get => _person;
        set => CheckAndSetValue(ref _person, value);
    }

    [FieldRequired]
    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock", Order = 2)]
    public DataLockType DataLock
    {
        get => _dataLock;
        set => CheckAndSetValue(ref _dataLock, value);
    }

    [FieldRequired]
    [JsonProperty("electoralAddress")]
    [XmlElement(ElementName = "electoralAddress", Order = 3)]
    public PersonMailAddressType ElectoralAddress
    {
        get => _electoralAddress;
        set => CheckAndSetValue(ref _electoralAddress, value);
    }

    [JsonProperty("deliveryAddress")]
    [XmlElement(ElementName = "deliveryAddress", Order = 4)]
    public PersonMailAddressType DeliveryAddress
    {
        get => _deliveryAddress;
        set => CheckAndSetValue(ref _deliveryAddress, value);
    }

    [JsonProperty("email")]
    [XmlElement(ElementName = "email", Order = 5)]
    public EmailType Email
    {
        get => _email;
        set => CheckAndSetValue(ref _email, value);
    }

    [JsonProperty("phone")]
    [XmlElement(ElementName = "phone", Order = 6)]
    public PhoneType Phone
    {
        get => _phone;
        set => CheckAndSetValue(ref _phone, value);
    }

    [JsonProperty("isEvoter")]
    [XmlElement(ElementName = "isEvoter", Order = 7)]
    public bool? IsEvoter
    {
        get => _isEvoter;
        set => CheckAndSetValue(ref _isEvoter, value);
    }
}
