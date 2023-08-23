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
[JsonObject("negativeReport")]
[XmlRoot(ElementName = "negativeReport", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class NegativeReport
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public NegativeReport()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="generalErrors">Field is optional.</param>
    /// <param name="personErrors">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static NegativeReport Create(List<Info> generalErrors = null, List<PersonInfo> personErrors = null)
    {
        return new NegativeReport()
        {
            GeneralErrors = generalErrors,
            PersonErrors = personErrors
        };
    }

    [JsonProperty("generalError")]
    [XmlElement(ElementName = "generalError")]
    public List<Info> GeneralErrors { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GeneralErrorsSpecified => GeneralErrors != null;

    [JsonProperty("personError")]
    [XmlElement(ElementName = "personError")]
    public List<PersonInfo> PersonErrors { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonErrorsSpecified => PersonErrors != null && PersonErrors.Any();
}
