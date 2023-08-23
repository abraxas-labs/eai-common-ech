// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_0;
using eCH_0021_6_0;
using eCH_0046_2_0;
using eCH_0155_1_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("votingPersonType")]
[XmlRoot(ElementName = "votingPersonType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class VotingPerson
{
    private const string ElectoralAddressNullValidateExceptionMessage =
        "ElectoralAddress is not valid! ElectoralAddress is required";

    private const string PersonNullValidateExceptionMessage =
        "Person is not valid! Person is required";

    private PersonMailAddress _electoralAddress;
    private Nationality _person;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VotingPerson()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public Nationality Person
    {
        get => _person;
        set => _person = value ?? throw new XmlSchemaValidationException(PersonNullValidateExceptionMessage);
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public DataLockType DataLock { get; set; }

    [JsonProperty("electoralAddress")]
    [XmlElement(ElementName = "electoralAddress")]
    public PersonMailAddress ElectoralAddress
    {
        get => _electoralAddress;
        set => _electoralAddress = value ?? throw new XmlSchemaValidationException(ElectoralAddressNullValidateExceptionMessage);
    }

    [JsonProperty("deliveryAddress")]
    [XmlElement(ElementName = "deliveryAddress")]
    public PersonMailAddress DeliveryAddress { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool DeliveryAddressSpecified => DeliveryAddress != null;

    [JsonProperty("email")]
    [XmlElement(ElementName = "email")]
    public Email Email { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool EmailSpecified => Email != null;

    [JsonProperty("domaniOfInfluence")]
    [XmlElement(ElementName = "domaniOfInfluence")]
    public List<DomainOfInfluence> DomainOfInfluence { get; set; }
}
