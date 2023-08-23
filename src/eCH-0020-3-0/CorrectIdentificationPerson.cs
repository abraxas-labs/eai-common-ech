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
/// Personenangaben.
/// </summary>
[Serializable]
[JsonObject("correctIdentificationPerson")]
[XmlRoot(ElementName = "correctIdentificationPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class CorrectIdentificationPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationBeforeNullValidateExceptionMessage = "PersonIdentificationBefore is not valid! PersonIdentificationBefore is required";
    private const string PersonIdentificationAfterNullValidateExceptionMessage = "PersonIdentificationAfter is not valid! PersonIdentificationAfter is required";

    private PersonIdentification _personIdentificationBefore;
    private PersonIdOnly _personIdentificationAfter;

    public CorrectIdentificationPerson()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentificationBefore">Field is required.</param>
    /// <param name="personIdentificationAfter">Field is required.</param>
    /// <returns>CorrectIdentificationPerson.</returns>
    public static CorrectIdentificationPerson Create(PersonIdentification personIdentificationBefore, PersonIdOnly personIdentificationAfter)
    {
        return new CorrectIdentificationPerson()
        {
            PersonIdentificationBefore = personIdentificationBefore,
            PersonIdentificationAfter = personIdentificationAfter
        };
    }

    [JsonProperty("personIdentificationBefore")]
    [XmlElement(ElementName = "personIdentificationBefore")]
    public PersonIdentification PersonIdentificationBefore
    {
        get { return _personIdentificationBefore; }

        set
        {
            _personIdentificationBefore = value ?? throw new XmlSchemaValidationException(PersonIdentificationBeforeNullValidateExceptionMessage);
        }
    }

    [JsonProperty("personIdentificationAfter")]
    [XmlElement(ElementName = "personIdentificationAfter")]
    public PersonIdOnly PersonIdentificationAfter
    {
        get { return _personIdentificationAfter; }

        set
        {
            _personIdentificationAfter = value ?? throw new XmlSchemaValidationException(PersonIdentificationAfterNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nameValidFrom")]
    [XmlElement(DataType = "date", ElementName = "nameValidFrom")]
    public DateTime? NameValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameValidFromSpecified => NameValidFrom.HasValue;
}
