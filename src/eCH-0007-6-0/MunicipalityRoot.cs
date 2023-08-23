// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0007_6_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Gemeinden (eCH-0007).
/// </summary>
[Serializable]
[JsonObject("municipalityRoot")]
[XmlRoot(ElementName = "municipalityRoot", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0007/6")]
public class MunicipalityRoot
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MunicipalityRoot()
    {
        Xmlns.Add("eCH-0007", "http://www.ech.ch/xmlns/eCH-0007/6");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissMunicipality"></param>
    /// <returns></returns>
    public static MunicipalityRoot Create(SwissMunicipality swissMunicipality)
    {
        return new MunicipalityRoot
        {
            SwissMunicipality = swissMunicipality
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissAndFlMunicipality"></param>
    /// <returns></returns>
    public static MunicipalityRoot Create(SwissAndFlMunicipality swissAndFlMunicipality)
    {
        return new MunicipalityRoot
        {
            SwissAndFlMunicipality = swissAndFlMunicipality
        };
    }

    [JsonProperty("swissMunicipality")]
    [XmlElement(ElementName = "swissMunicipality")]
    public SwissMunicipality SwissMunicipality { get; set; }

    [JsonProperty("swissAndFlMunicipality")]
    [XmlElement(ElementName = "swissAndFlMunicipality")]
    public SwissAndFlMunicipality SwissAndFlMunicipality { get; set; }
}
