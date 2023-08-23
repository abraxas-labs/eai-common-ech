// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("hasMainResidence")]
[XmlRoot(ElementName = "hasMainResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class MainResidenceType : FieldValueChecker<MainResidenceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ResidenceInformationType _mainResidence;
    private List<SwissMunicipality> _secondaryResidence;

    public MainResidenceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="mainResidence">Field is requried.</param>
    /// <param name="secondaryResidence">Field is optional.</param>
    /// <returns>HasMainResidenceType.</returns>
    public static MainResidenceType Create(ResidenceInformationType mainResidence, List<SwissMunicipality> secondaryResidence)
    {
        return new MainResidenceType
        {
            MainResidence = mainResidence,
            SecondaryResidence = secondaryResidence
        };
    }

    [FieldRequired]
    [JsonProperty("mainResidence")]
    [XmlElement(ElementName = "mainResidence")]
    public ResidenceInformationType MainResidence
    {
        get => _mainResidence;
        set => CheckAndSetValue(ref _mainResidence, value);
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public List<SwissMunicipality> SecondaryResidence
    {
        get => _secondaryResidence;
        set => CheckAndSetValue(ref _secondaryResidence, value);
    }
}
