// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0006_2_0;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("swiss")]
[XmlRoot(ElementName = "swiss", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class ForeignerType : FieldValueChecker<ForeignerType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ResidencePermit _residencePermit;
    private DateTime? _residencePermitTill;
    private string _nameOnPassport;
    private string _firstNameOnPassport;

    public ForeignerType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="residencePermit">Field is required.</param>
    /// <param name="residencePermitTill">Field is optional.</param>
    /// <param name="nameOnPassport">Field is optional.</param>
    /// <param name="firstNameOnPassport">Field is optional.</param>
    /// <returns>SwissType.</returns>
    public static ForeignerType Create(ResidencePermit residencePermit, DateTime? residencePermitTill, string nameOnPassport, string firstNameOnPassport)
    {
        return new ForeignerType
        {
            ResidencePermit = residencePermit,
            ResidencePermitTill = residencePermitTill,
            NameOnPassport = nameOnPassport,
            FirstNameOnPassport = firstNameOnPassport
        };
    }

    [FieldRequired]
    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit")]
    public ResidencePermit ResidencePermit
    {
        get => _residencePermit;
        set => CheckAndSetValue(ref _residencePermit, value);
    }

    [JsonProperty("residencePermitTill")]
    [XmlElement(ElementName = "residencePermitTill")]
    public DateTime? ResidencePermitTill
    {
        get => _residencePermitTill;
        set => CheckAndSetValue(ref _residencePermitTill, value);
    }

    [JsonProperty("nameOnPassport")]
    [XmlElement(ElementName = "nameOnPassport")]
    public string NameOnPassport
    {
        get => _nameOnPassport;
        set => CheckAndSetValue(ref _nameOnPassport, value);
    }

    [JsonProperty("firstNameOnPassport")]
    [XmlElement(ElementName = "firstNameOnPassport")]
    public string FirstNameOnPassport
    {
        get => _firstNameOnPassport;
        set => CheckAndSetValue(ref _firstNameOnPassport, value);
    }
}
