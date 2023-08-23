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
[JsonObject("reportedPerson")]
[XmlRoot(ElementName = "reportedPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class ReportedPersonType : FieldValueChecker<ReportedPersonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonType _person;
    private AnyPersonType _anyPerson;
    private MainResidenceType _hasMainResidence;
    private SecondaryResidenceType _hasSecondaryResidence;
    private OtherResidenceType _hasOtherResidence;

    public ReportedPersonType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is requried.</param>
    /// <param name="anyPerson">Field is requried.</param>
    /// <param name="hasMainResidence">Field is requried.</param>
    /// <returns>ReportedPersonType.</returns>
    public static ReportedPersonType Create(PersonType person, AnyPersonType anyPerson, MainResidenceType hasMainResidence)
    {
        return new ReportedPersonType
        {
            Person = person,
            AnyPerson = anyPerson,
            HasMainResidence = hasMainResidence,
            HasSecondaryResidence = null,
            HasOtherResidence = null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is requried.</param>
    /// <param name="anyPerson">Field is requried.</param>
    /// <param name="hasSecondaryResidence">Field is requried.</param>
    /// <returns>ReportedPersonType.</returns>
    public static ReportedPersonType Create(PersonType person, AnyPersonType anyPerson, SecondaryResidenceType hasSecondaryResidence)
    {
        return new ReportedPersonType
        {
            Person = person,
            AnyPerson = anyPerson,
            HasMainResidence = null,
            HasSecondaryResidence = hasSecondaryResidence,
            HasOtherResidence = null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is requried.</param>
    /// <param name="anyPerson">Field is requried.</param>
    /// <param name="hasOtherResidence">Field is requried.</param>
    /// <returns>ReportedPersonType.</returns>
    public static ReportedPersonType Create(PersonType person, AnyPersonType anyPerson, OtherResidenceType hasOtherResidence)
    {
        return new ReportedPersonType
        {
            Person = person,
            AnyPerson = anyPerson,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public PersonType Person
    {
        get => _person;
        set => CheckAndSetValue(ref _person, value);
    }

    [FieldRequired]
    [JsonProperty("anyPerson")]
    [XmlElement(ElementName = "anyPerson")]
    public AnyPersonType AnyPerson
    {
        get => _anyPerson;
        set => CheckAndSetValue(ref _anyPerson, value);
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence")]
    public MainResidenceType HasMainResidence
    {
        get => _hasMainResidence;
        set => CheckAndSetValue(ref _hasMainResidence, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence")]
    public SecondaryResidenceType HasSecondaryResidence
    {
        get => _hasSecondaryResidence;
        set => CheckAndSetValue(ref _hasSecondaryResidence, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence")]
    public OtherResidenceType HasOtherResidence
    {
        get => _hasOtherResidence;
        set => CheckAndSetValue(ref _hasOtherResidence, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasOtherResidence != null;
}
