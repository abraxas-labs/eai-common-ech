// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0f;
using eCH_0008_3_0;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("swissTown")]
[XmlRoot(ElementName = "swissTown", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class SwissTownType : FieldValueChecker<SwissTownType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Country _country;
    private SwissMunicipality _municipality;

    public SwissTownType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    public SwissTownType Create(Country country, SwissMunicipality municipality)
    {
        return new SwissTownType
        {
            Country = country,
            Municipality = municipality
        };
    }

    [FieldRequired]
    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public Country Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }

    [FieldRequired]
    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality")]
    public SwissMunicipality Municipality
    {
        get => _municipality;
        set => CheckAndSetValue(ref _municipality, value);
    }
}
