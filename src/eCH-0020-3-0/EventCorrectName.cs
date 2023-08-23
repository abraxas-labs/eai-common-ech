// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectName.
/// </summary>
[Serializable]
[JsonObject("eventCorrectName")]
[XmlRoot(ElementName = "eventCorrectName", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectName
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectNamePersonNullValidateExceptionMessage = "CorrectNamePerson is not valid! CorrectNamePerson is required";
    private const string NameInfoNullValidateExceptionMessage = "NameInfo is not valid! NameInfo is required";

    private PersonIdentification _correctNamePerson;
    private NameInfo _nameInfo;

    public EventCorrectName()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctNamePerson">Field is required.</param>
    /// <param name="nameInfo">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectName Create(PersonIdentification correctNamePerson, NameInfo nameInfo, object extension = null)
    {
        return new EventCorrectName()
        {
            CorrectNamePerson = correctNamePerson,
            NameInfo = nameInfo,
            Extension = extension
        };
    }

    [JsonProperty("correctNamePerson")]
    [XmlElement(ElementName = "correctNamePerson")]
    public PersonIdentification CorrectNamePerson
    {
        get { return _correctNamePerson; }

        set
        {
            _correctNamePerson = value ?? throw new XmlSchemaValidationException(CorrectNamePersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nameInfo")]
    [XmlElement(ElementName = "nameInfo")]
    public NameInfo NameInfo
    {
        get { return _nameInfo; }

        set
        {
            _nameInfo = value ?? throw new XmlSchemaValidationException(NameInfoNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
