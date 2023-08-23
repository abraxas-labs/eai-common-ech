// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("hasSecondaryResidence")]
[XmlRoot(ElementName = "hasSecondaryResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class SecondaryResidenceType : FieldValueChecker<SecondaryResidenceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private SwissMunicipality _mainResidence;
    private ResidenceInformationType _secondaryResidence;

    public SecondaryResidenceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="mainResidence">Field is requried.</param>
    /// <param name="secondaryResidence">Field is requried.</param>
    /// <returns>HasMainResidenceType.</returns>
    public static SecondaryResidenceType Create(SwissMunicipality mainResidence, ResidenceInformationType secondaryResidence)
    {
        return new SecondaryResidenceType
        {
            MainResidence = mainResidence,
            SecondaryResidence = secondaryResidence
        };
    }

    [FieldRequired]
    [JsonProperty("mainResidence")]
    [XmlElement(ElementName = "mainResidence")]
    public SwissMunicipality MainResidence
    {
        get => _mainResidence;
        set => CheckAndSetValue(ref _mainResidence, value);
    }

    [FieldRequired]
    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public ResidenceInformationType SecondaryResidence
    {
        get => _secondaryResidence;
        set => CheckAndSetValue(ref _secondaryResidence, value);
    }
}
