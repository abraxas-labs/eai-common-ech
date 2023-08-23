// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0046_2_0;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("address")]
[XmlType(TypeName = "addressType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class Address
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UuidValidateExceptionMessage = "uuid is not valid! uuid cannot be null";

    private string _uuid;

    public Address()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/3");
    }

    [JsonProperty("uuid")]
    [XmlElement(ElementName = "uuid")]
    public string Uuid
    {
        get { return _uuid; }

        set
        {
            _uuid = value ?? throw new XmlSchemaValidationException(UuidValidateExceptionMessage);
        }
    }

    [JsonProperty("transactionRole")]
    [XmlElement(ElementName = "transactionRole")]
    public TransactionRole? TransactionRole { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TransactionRoleSpecified => TransactionRole != null;

    [JsonProperty("position")]
    [XmlElement(ElementName = "position")]
    public string Position { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PositionSpecified => Position != null;

    [JsonProperty("contact")]
    [XmlElement(ElementName = "contact")]
    public Contact Contact { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactSpecified => Contact != null;
}
