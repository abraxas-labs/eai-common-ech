// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155).
/// </summary>
[Serializable]
[JsonObject("electionGroupDescriptionType")]
[XmlRoot(ElementName = "electionGroupDescriptionType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ElectionGroupDescriptionType : FieldValueChecker<ElectionGroupDescriptionType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ElectionGroupDescriptionType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionDescriptionInfo">Field is required.</param>
    /// <returns>ElectionGroupDescriptionType.</returns>
    public static ElectionGroupDescriptionType Create(List<ElectionDescriptionInfoType> electionDescriptionInfo)
    {
        return new ElectionGroupDescriptionType
        {
            ElectionDescriptionInfo = electionDescriptionInfo
        };
    }

    [FieldRequired]
    [JsonProperty("electionDescriptionInfo")]
    [XmlElement(ElementName = "electionDescriptionInfo", Order = 1)]
    public List<ElectionDescriptionInfoType> ElectionDescriptionInfo { get; set; }
}
