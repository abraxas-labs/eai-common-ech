// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_4_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044).
/// </summary>
[Serializable]
[JsonObject("personIdentificationRoot")]
[XmlRoot(ElementName = "personIdentificationRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PersonIdentificationRoot : FieldValueChecker<PersonIdentificationRoot>
{
    private PersonIdentification _personIdentification;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PersonIdentificationRoot()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="personIdentification">Field can be null.</param>
    /// <returns>PersonIdentificationRoot.</returns>
    public static PersonIdentificationRoot Create(PersonIdentification personIdentification)
    {
        return new PersonIdentificationRoot
        {
            PersonIdentification = personIdentification
        };
    }

    [FieldRequired]
    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get => _personIdentification;
        set => CheckAndSetValue(ref _personIdentification, value);
    }
}
