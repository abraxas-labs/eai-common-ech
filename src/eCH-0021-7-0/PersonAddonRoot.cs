// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("personAddonRoot")]
[XmlRoot(ElementName = "personAddonRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class PersonAddonRoot
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonAddonNullValidateExceptionMessage = "PersonAddon is not valid! PersonAddon is required";

    private PersonAddon _personAddon;

    public PersonAddonRoot()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personAddon">Field is required.</param>
    /// <returns>LockData.</returns>
    public static PersonAddonRoot Create(PersonAddon personAddon)
    {
        return new PersonAddonRoot()
        {
            PersonAddon = personAddon
        };
    }

    [JsonProperty("personAddon")]
    [XmlElement(ElementName = "personAddon", Order = 1)]
    public PersonAddon PersonAddon
    {
        get { return _personAddon; }

        set
        {
            _personAddon = value ?? throw new XmlSchemaValidationException(PersonAddonNullValidateExceptionMessage);
        }
    }
}
