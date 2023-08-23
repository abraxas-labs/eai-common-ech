// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0058_5_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public partial class Delivery
{
    private EventResultDelivery _resultDelivery;
    private Header _deliveryHeader;

    [XmlElement("deliveryHeader", Order = 1)]
    public Header DeliveryHeader { get => _deliveryHeader; set => _deliveryHeader = value; }

    [XmlElement("resultDelivery", Order = 2)]
    public EventResultDelivery ResultDelivery { get => _resultDelivery; set => _resultDelivery = value; }

    [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "integer")]
    public string MinorVersion { get; set; }
}
