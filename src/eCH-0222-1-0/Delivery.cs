// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0222_1_0.Standard;

[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class Delivery
{
    [XmlElement("deliveryHeader", Order = 1)]
    public Header DeliveryHeader { get; set; }

    [XmlElement("rawDataDelivery", Order = 2)]
    public EventRawDataDelivery RawDataDelivery { get; set; }

    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "integer")]
    public string minorVersion { get; set; }
}
