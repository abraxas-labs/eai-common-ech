// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventContact.
/// </summary>
[Serializable]
[JsonObject("eventCorrectIdentification")]
[XmlRoot(ElementName = "eventCorrectIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectIdentification
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectIdentificationPersonNullValidateExceptionMessage = "CorrectIdentificationPerson is not valid! CorrectIdentificationPerson is required";

    private CorrectIdentificationPerson _correctIdentificationPerson;

    public EventCorrectIdentification()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctIdentificationPerson">Field is required.</param>
    /// <param name="identificationValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectIdentification Create(CorrectIdentificationPerson correctIdentificationPerson, DateTime? identificationValidFrom = null, object extension = null)
    {
        return new EventCorrectIdentification()
        {
            CorrectIdentificationPerson = correctIdentificationPerson,
            IdentificationValidFrom = identificationValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("correctIdentificationPerson")]
    [XmlElement(ElementName = "correctIdentificationPerson")]
    public CorrectIdentificationPerson CorrectIdentificationPerson
    {
        get { return _correctIdentificationPerson; }

        set
        {
            _correctIdentificationPerson = value ?? throw new XmlSchemaValidationException(CorrectIdentificationPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("identificationValidFrom")]
    [XmlElement(DataType = "date", ElementName = "identificationValidFrom")]
    public DateTime? IdentificationValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IdentificationValidFromSpecified => IdentificationValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
