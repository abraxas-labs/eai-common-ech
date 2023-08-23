// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
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
[JsonObject("secondaryResidence")]
[XmlRoot(ElementName = "secondaryResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class SecondaryResidenceType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private SwissMunicipality _mainResidence;
    private ResidenceData _secondaryResidence;

    public SecondaryResidenceType()
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
    public static SecondaryResidenceType Create(SwissMunicipality mainResidence, SecondaryResidenceData secondaryResidence = null)
    {
        return new SecondaryResidenceType()
        {
            MainResidence = mainResidence,
            SecondaryResidence = secondaryResidence
        };
    }

    [JsonProperty("mainResidence")]
    [XmlElement(ElementName = "mainResidence")]
    public SwissMunicipality MainResidence
    {
        get { return _mainResidence; }
        set { _mainResidence = value; }
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public ResidenceData SecondaryResidence
    {
        get { return _secondaryResidence; }
        set { _secondaryResidence = value; }
    }
}
