// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventChangeSex.
/// </summary>
[Serializable]
[JsonObject("eventChangeSex")]
[XmlRoot(ElementName = "eventChangeSex", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeSex
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ChangeSexPerson _changeSexPerson;

    public EventChangeSex()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeSexPerson">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeSex Create(ChangeSexPerson changeSexPerson, object extension = null)
    {
        return new EventChangeSex()
        {
            ChangeSexPerson = changeSexPerson,
            Extension = extension
        };
    }

    [XmlElement(ElementName = "changeSexPerson")]
    public ChangeSexPerson ChangeSexPerson
    {
        get { return _changeSexPerson; }
        set { _changeSexPerson = value; }
    }

    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
