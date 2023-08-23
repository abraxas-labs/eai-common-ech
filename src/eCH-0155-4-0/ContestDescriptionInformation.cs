// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung des Urnengangs von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("contestDescriptionInformation")]
[XmlRoot(ElementName = "contestDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ContestDescriptionInformation
{
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ContestDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("contestDescriptionInfo")]
    [XmlElement(ElementName = "contestDescriptionInfo", Order = 1)]
    public List<ContestDescriptionInfo> ContestDescriptionInfo { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contestDescriptionInfo">Field is required.</param>
    /// <returns>ContestDescriptionInformation.</returns>
    public static ContestDescriptionInformation Create(List<ContestDescriptionInfo> contestDescriptionInfo)
    {
        return new ContestDescriptionInformation
        {
            ContestDescriptionInfo = contestDescriptionInfo
        };
    }
}
