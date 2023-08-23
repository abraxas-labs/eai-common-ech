// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0044_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Austausch von Personenidentifikationen (eCH-0044).
/// </summary>
[Serializable]
[JsonObject("personIdentificationRoot")]
[XmlRoot(ElementName = "personIdentificationRoot", IsNullable = true,
    Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PersonIdentificationRoot
{
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PersonIdentificationRoot()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
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
}
