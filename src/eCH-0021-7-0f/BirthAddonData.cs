// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Geburtszusatzangaben.
/// </summary>
[Serializable]
[JsonObject("birthAddonData")]
[XmlRoot(ElementName = "birthAddonData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class BirthAddonData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public BirthAddonData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nameOfFather">Field is optional.</param>
    /// <param name="nameOfMother">Field is optional.</param>
    /// <returns>BirthAddonData.</returns>
    public static BirthAddonData Create(NameOfParent nameOfFather = null, NameOfParent nameOfMother = null)
    {
        return new BirthAddonData()
        {
            NameOfFather = nameOfFather,
            NameOfMother = nameOfMother
        };
    }

    [JsonProperty("nameOfFather")]
    [XmlElement(ElementName = "nameOfFather")]
    public NameOfParent NameOfFather { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameOfFatherSpecified => NameOfFather != null;

    [JsonProperty("nameOfMother")]
    [XmlElement(ElementName = "nameOfMother")]
    public NameOfParent NameOfMother { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameOfMotherSpecified => NameOfMother != null;
}
