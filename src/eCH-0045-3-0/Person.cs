// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_3_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("personType")]
[XmlRoot(ElementName = "personType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class Person
{
    private const string PersonIdentificationNullValidateExceptionMessage =
        "PersonIdentification is not valid! PersonIdentification is required";

    private const string AllianceNameValidateExceptionMessage =
        "AllianceName is not valid! AllianceName has min Lenght 1 and max Lenght 100";

    private PersonIdentification _personIdentification;
    private string _allianceName;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Person()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get => _personIdentification;
        set => _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
    }

    [JsonProperty("allianceName")]
    [XmlElement(ElementName = "allianceName")]
    public string AllianceName
    {
        get => _allianceName;
        set => _allianceName = AllianceNameIsValid(value);
    }

    private string AllianceNameIsValid(string value)
    {
        if (value != null && (value.Length < 1 || value.Length > 100))
        {
            throw new XmlSchemaValidationException(AllianceNameValidateExceptionMessage);
        }

        return value;
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool AllianceNameSpecified => AllianceName != null;

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
    public Language LanguageOfCorrespondance { get; set; }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool ExtensionSpecified => Extension != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="languageOfCorrespondance">Field is required.</param>
    /// <param name="allianceName">Field is required.</param>
    /// <param name="extension">Field is required.</param>
    /// <returns>Person.</returns>
    public static Person Create(PersonIdentification personIdentification, Language languageOfCorrespondance, string allianceName = null, object extension = null)
    {
        return new Person
        {
            PersonIdentification = personIdentification,
            LanguageOfCorrespondance = languageOfCorrespondance,
            AllianceName = allianceName,
            Extension = extension
        };
    }
}
