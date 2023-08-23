// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_6_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("electoralAddressType")]
[XmlRoot(ElementName = "electoralAddressType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class ElectoralAddressType : FieldValueChecker<ElectoralAddressType>
{
    private PersonMailAddressInfoType _person;
    private AddressInformationType _addressInformation;
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ElectoralAddressType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="addressInformation">Field is required.</param>
    /// <returns>ElectoralAddress.</returns>
    public static ElectoralAddressType Create(PersonMailAddressInfoType person, AddressInformationType addressInformation)
    {
        return new ElectoralAddressType
        {
            Person = person,
            AddressInformation = addressInformation
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public PersonMailAddressInfoType Person
    {
        get => _person;
        set => CheckAndSetValue(ref _person, value);
    }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 2)]
    public AddressInformationType AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
