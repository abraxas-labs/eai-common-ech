// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class DeliveryType : FieldValueChecker<DeliveryType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Header _deliveryHeader;
    private List<ReportedPersonType> _reportedPerson;
    private object _extension;

    public DeliveryType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle minimalen Werte.
    /// </summary>
    /// <param name="header">Field is required.</param>
    /// <param name="reportedPerson">Field is required.</param>
    /// <param name="extension">Field is required.</param>
    /// <returns>Delivery.</returns>
    public static DeliveryType Create(Header header, List<ReportedPersonType> reportedPerson, object extension = null)
    {
        return new DeliveryType
        {
            DeliveryHeader = header,
            ReportedPerson = reportedPerson,
            Extension = extension
        };
    }

    [JsonProperty("version")]
    [XmlAttribute("version")]
    public string Version
    {
        get { return "1.0"; }
        set { }
    }

    [FieldRequired]
    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader")]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => CheckAndSetValue(ref _deliveryHeader, value);
    }

    [FieldRequired]
    [JsonProperty("reportedPerson")]
    [XmlElement(ElementName = "reportedPerson")]
    public List<ReportedPersonType> ReportedPerson
    {
        get => _reportedPerson;
        set => CheckAndSetValue(ref _reportedPerson, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }
}
