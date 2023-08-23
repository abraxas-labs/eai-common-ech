// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("positivReport")]
[XmlRoot(ElementName = "positivReport", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class PositivReport
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PositivReport()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="generalResponses">Field is optional.</param>
    /// <param name="personResponses">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static PositivReport Create(List<Info> generalResponses = null, List<PersonInfo> personResponses = null)
    {
        return new PositivReport()
        {
            GeneralResponses = generalResponses,
            PersonResponses = personResponses
        };
    }

    [JsonProperty("generalResponse")]
    [XmlElement(ElementName = "generalResponse")]
    public List<Info> GeneralResponses { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GeneralResponsesSpecified => GeneralResponses != null;

    [JsonProperty("personResponse")]
    [XmlElement(ElementName = "personResponse")]
    public List<PersonInfo> PersonResponses { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonResponsesSpecified => PersonResponses != null && PersonResponses.Any();
}
