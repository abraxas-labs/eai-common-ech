// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventKeyExchange.
/// </summary>
[Serializable]
[JsonObject("changeSexPersonType")]
[XmlRoot(ElementName = "changeSexPersonType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class ChangeSexPersonType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;

    public ChangeSexPersonType()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static ChangeSexPersonType Create(PersonIdentification personIdentification, SexType sex)
    {
        return new ChangeSexPersonType()
        {
            PersonIdentification = personIdentification,
            Sex = sex
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }
        set { _personIdentification = value; }
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType? Sex { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SexSpecified => Sex.HasValue;
}
