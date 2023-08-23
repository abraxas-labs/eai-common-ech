// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("hasOtherResidence")]
[XmlRoot(ElementName = "hasOtherResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class OtherResidenceType : FieldValueChecker<OtherResidenceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ResidenceInformationType _secondaryResidenceInformation;

    public OtherResidenceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="secondaryResidenceInformation">Field is requried.</param>
    /// <returns>HasMainResidenceType.</returns>
    public static OtherResidenceType Create(ResidenceInformationType secondaryResidenceInformation)
    {
        return new OtherResidenceType
        {
            SecondaryResidenceInformation = secondaryResidenceInformation
        };
    }

    [FieldRequired]
    [JsonProperty("secondaryResidenceInformation")]
    [XmlElement(ElementName = "secondaryResidenceInformation")]
    public ResidenceInformationType SecondaryResidenceInformation
    {
        get => _secondaryResidenceInformation;
        set => CheckAndSetValue(ref _secondaryResidenceInformation, value);
    }
}
