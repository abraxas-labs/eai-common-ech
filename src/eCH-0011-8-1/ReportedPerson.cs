// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("reportedPerson")]
[XmlRoot(ElementName = "reportedPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class ReportedPerson
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonNullValidateExceptionMessage = "Person is not valid! Person is required";

    private Person _person;

    public ReportedPerson()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is requried.</param>
    /// <param name="hasMainResidence">Field is requried.</param>
    /// <returns>ForeignerName.</returns>
    public static ReportedPerson Create(Person person, MainResidenceType hasMainResidence)
    {
        return new ReportedPerson()
        {
            Person = person,
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
    /// <param name="hasSecondaryResidence">Field is requried.</param>
    /// <returns>ForeignerName.</returns>
    public static ReportedPerson Create(Person person, SecondaryResidenceData hasSecondaryResidence)
    {
        return new ReportedPerson()
        {
            Person = person,
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
    /// <param name="hasOtherResidence">Field is requried.</param>
    /// <returns>ForeignerName.</returns>
    public static ReportedPerson Create(Person person, OtherResidenceType hasOtherResidence)
    {
        return new ReportedPerson()
        {
            Person = person,
            HasMainResidence = null,
            HasSecondaryResidence = null,
            HasOtherResidence = hasOtherResidence
        };
    }

    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public Person Person
    {
        get { return _person; }

        set
        {
            _person = value ?? throw new XmlSchemaValidationException(PersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement(ElementName = "hasMainResidence", Order = 2)]
    public MainResidenceType HasMainResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasMainResidence != null;

    [JsonProperty("hasSecondaryResidence")]
    [XmlElement(ElementName = "hasSecondaryResidence", Order = 3)]
    public SecondaryResidenceData HasSecondaryResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasSecondaryResidenceSpecified => HasSecondaryResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement(ElementName = "hasOtherResidence", Order = 4)]
    public OtherResidenceType HasOtherResidence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasOtherResidence != null;
}
