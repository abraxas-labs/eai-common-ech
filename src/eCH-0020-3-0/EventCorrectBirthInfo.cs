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
/// EventCorrectBirthInfo.
/// </summary>
[Serializable]
[JsonObject("eventCorrectBirthInfo")]
[XmlRoot(ElementName = "eventCorrectBirthInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectBirthInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectBirthInfoPersonNullValidateExceptionMessage = "CorrectBirthInfoPerson is not valid! CorrectBirthInfoPerson is required";
    private const string BirthInfoNullValidateExceptionMessage = "BirthInfo is not valid! BirthInfo is required";

    private PersonIdentification _correctBirthInfoPerson;
    private BirthInfo _birthInfo;

    public EventCorrectBirthInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctBirthInfoPerson">Field is required.</param>
    /// <param name="birthInfo">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectBirthInfo Create(PersonIdentification correctBirthInfoPerson, BirthInfo birthInfo, object extension = null)
    {
        return new EventCorrectBirthInfo()
        {
            CorrectBirthInfoPerson = correctBirthInfoPerson,
            BirthInfo = birthInfo,
            Extension = extension
        };
    }

    [JsonProperty("correctBirthInfoPerson")]
    [XmlElement(ElementName = "correctBirthInfoPerson")]
    public PersonIdentification CorrectBirthInfoPerson
    {
        get { return _correctBirthInfoPerson; }

        set
        {
            _correctBirthInfoPerson = value ?? throw new XmlSchemaValidationException(CorrectBirthInfoPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("birthInfo")]
    [XmlElement(ElementName = "birthInfo")]
    public BirthInfo BirthInfo
    {
        get { return _birthInfo; }

        set
        {
            _birthInfo = value ?? throw new XmlSchemaValidationException(BirthInfoNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
