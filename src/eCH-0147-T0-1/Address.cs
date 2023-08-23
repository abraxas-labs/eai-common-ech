// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using eCH_0046_1_0;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("address")]
[XmlType("addressType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Address : FieldValueChecker<Address>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _uuid;

    public Address()
    {
        Xmlns.Add("eCH-0147T0", "http://www.ech.ch/xmlns/eCH-0147/T0/1");
    }

    [FieldRequired]
    [JsonProperty("uuid")]
    [XmlElement("uuid", DataType = "token")]
    public string Uuid
    {
        get => _uuid;
        set => CheckAndSetValue(ref _uuid, value);
    }

    [JsonProperty("transactionRole")]
    [XmlElement("transactionRole")]
    public TransactionRole? TransactionRole { get; set; }

    [JsonProperty("position")]
    [XmlElement("position", DataType = "token")]
    public string Position { get; set; }

    [JsonProperty("contact")]
    [XmlElement("contact")]
    public Contact Contact { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom[] ApplicationCustoms { get; set; }
}
