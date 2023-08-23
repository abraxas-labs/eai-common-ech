// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0008_2_0;
using Newtonsoft.Json;

namespace eCH_0011_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("coredata")]
[XmlRoot(ElementName = "coredata", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/3")]
public class NationalityType : FieldValueChecker<NationalityType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private NationalityStatusType _nationalityStatus;
    private Country _country;

    public NationalityType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nationalityStatus">Field is required.</param>
    /// <param name="country">Field is optional.</param>
    /// <returns>CoreData.</returns>
    public static NationalityType Create(NationalityStatusType nationalityStatus, Country country)
    {
        return new NationalityType
        {
            NationalityStatus = nationalityStatus,
            Country = country
        };
    }

    [FieldRequired]
    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public NationalityStatusType NationalityStatus
    {
        get => _nationalityStatus;
        set => CheckAndSetValue(ref _nationalityStatus, value);
    }

    [JsonProperty("nationalityStatus")]
    [XmlElement(ElementName = "nationalityStatus")]
    public Country Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }
}
