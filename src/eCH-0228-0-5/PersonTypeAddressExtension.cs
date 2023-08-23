// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

public class PersonTypeAddressExtension
{
    [System.Xml.Serialization.XmlElement("line1")]
    public string Line1 { get; set; }

    [System.Xml.Serialization.XmlElement("line2")]
    public string Line2 { get; set; }

    [System.Xml.Serialization.XmlElement("line3")]
    public string Line3 { get; set; }

    [System.Xml.Serialization.XmlElement("line4")]
    public string Line4 { get; set; }

    [System.Xml.Serialization.XmlElement("line5")]
    public string Line5 { get; set; }

    [System.Xml.Serialization.XmlElement("line6")]
    public string Line6 { get; set; }

    [System.Xml.Serialization.XmlElement("line7")]
    public string Line7 { get; set; }
}

public class AddressOnEnvelope
{
    [System.Xml.Serialization.XmlElement("address")]
    public PersonTypeAddressExtension Address { get; set; }
}
