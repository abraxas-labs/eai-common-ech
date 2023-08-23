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
/// Geschlechtsänderung.
/// </summary>
[Serializable]
[JsonObject("changeSexPerson")]
[XmlRoot(ElementName = "changeSexPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class ChangeSexPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is required";

    private PersonIdentification _personIdentification;

    public ChangeSexPerson()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <returns>NameInfo.</returns>
    public static ChangeSexPerson Create(PersonIdentification personIdentification, SexType sex)
    {
        return new ChangeSexPerson()
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

        set
        {
            _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType Sex { get; set; }
}
