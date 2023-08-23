// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("electoralAddressType")]
[XmlRoot(ElementName = "electoralAddressType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class ElectoralAddress
{
    private const string PersonNullValidateExceptionMessage =
        "Person is not valid! Person is required";

    private const string AddressInformationNullValidateExceptionMessage =
        "AddressInformation is not valid! AddressInformation is required";

    private PersonMailAddressInfo _person;
    private AddressInformation _addressInformation;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ElectoralAddress()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public PersonMailAddressInfo Person
    {
        get => _person;
        set => _person = value ?? throw new XmlSchemaValidationException(PersonNullValidateExceptionMessage);
    }

    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation")]
    public AddressInformation AddressInformation
    {
        get => _addressInformation;
        set => _addressInformation = value ?? throw new XmlSchemaValidationException(AddressInformationNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="addressInformation">Field is required.</param>
    /// <returns>ElectoralAddress.</returns>
    public static ElectoralAddress Create(PersonMailAddressInfo person, AddressInformation addressInformation)
    {
        return new ElectoralAddress
        {
            Person = person,
            AddressInformation = addressInformation
        };
    }
}
