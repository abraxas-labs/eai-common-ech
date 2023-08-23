// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("hasMainResidence")]
[XmlRoot(ElementName = "hasMainResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class MainResidenceType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ResidenceData _mainResidence;

    public MainResidenceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="mainResidence">Field is required.</param>
    /// <param name="secondaryResidence">Field is optional.</param>
    /// <returns>ForeignerName.</returns>
    public static MainResidenceType Create(ResidenceData mainResidence, List<SwissMunicipality> secondaryResidence = null)
    {
        return new MainResidenceType()
        {
            MainResidence = mainResidence,
            SecondaryResidences = secondaryResidence
        };
    }

    [JsonProperty("mainResidence")]
    [XmlElement(ElementName = "mainResidence")]
    public ResidenceData MainResidence
    {
        get { return _mainResidence; }
        set { _mainResidence = value; }
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public List<SwissMunicipality> SecondaryResidences { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SecondaryResidencesSpecified => SecondaryResidences != null && SecondaryResidences.Any();
}
