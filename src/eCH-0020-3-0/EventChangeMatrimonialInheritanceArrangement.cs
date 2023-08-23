// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventChangeHealthInsurance.
/// </summary>
[Serializable]
[JsonObject("eventChangeMatrimonialInheritanceArrangement")]
[XmlRoot(ElementName = "eventChangeMatrimonialInheritanceArrangement", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeMatrimonialInheritanceArrangement
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeMatrimonialInheritanceArrangementPersonNullValidateExceptionMessage = "ChangeMatrimonialInheritanceArrangementPerson is not valid! ChangeMatrimonialInheritanceArrangementPerson is required";

    private PersonIdentification _changeMatrimonialInheritanceArrangementPerson;

    public EventChangeMatrimonialInheritanceArrangement()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeMatrimonialInheritanceArrangementPerson">Field is required.</param>
    /// <param name="matrimonialInheritanceArrangementData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeMatrimonialInheritanceArrangement Create(PersonIdentification changeMatrimonialInheritanceArrangementPerson, MatrimonialInheritanceArrangementData matrimonialInheritanceArrangementData, object extension = null)
    {
        return new EventChangeMatrimonialInheritanceArrangement()
        {
            ChangeMatrimonialInheritanceArrangementPerson = changeMatrimonialInheritanceArrangementPerson,
            MatrimonialInheritanceArrangementData = matrimonialInheritanceArrangementData,
            Extension = extension
        };
    }

    [JsonProperty("changeMatrimonialInheritanceArrangementPerson")]
    [XmlElement(ElementName = "changeMatrimonialInheritanceArrangementPerson")]
    public PersonIdentification ChangeMatrimonialInheritanceArrangementPerson
    {
        get { return _changeMatrimonialInheritanceArrangementPerson; }

        set
        {
            _changeMatrimonialInheritanceArrangementPerson = value ?? throw new XmlSchemaValidationException(ChangeMatrimonialInheritanceArrangementPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("matrimonialInheritanceArrangementData")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangementData")]
    public MatrimonialInheritanceArrangementData MatrimonialInheritanceArrangementData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MatrimonialInheritanceArrangementDataSpecified => MatrimonialInheritanceArrangementData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
