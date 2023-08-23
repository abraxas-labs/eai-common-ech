// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("personAddonRoot")]
[XmlRoot(ElementName = "personAddonRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class PersonAddonRoot : FieldValueChecker<PersonAddonRoot>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonAddonType _personAddon;

    public PersonAddonRoot()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personAddon">Field is required.</param>
    /// <returns>LockData.</returns>
    public static PersonAddonRoot Create(PersonAddonType personAddon)
    {
        return new PersonAddonRoot
        {
            PersonAddon = personAddon
        };
    }

    [FieldRequired]
    [JsonProperty("personAddon")]
    [XmlElement(ElementName = "personAddon")]
    public PersonAddonType PersonAddon
    {
        get => _personAddon;
        set => CheckAndSetValue(ref _personAddon, value);
    }
}
