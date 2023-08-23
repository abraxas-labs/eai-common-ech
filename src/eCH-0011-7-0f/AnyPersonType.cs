// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("anyPerson")]
[XmlRoot(ElementName = "anyPerson", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class AnyPersonType : FieldValueChecker<ReportedPersonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private SwissType _swiss;
    private ForeignerType _foreigner;

    public AnyPersonType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swiss">Field is optional.</param>
    /// <param name="foreigner">Field is optional.</param>
    /// <returns>AnyPersonType.</returns>
    public static AnyPersonType Create(SwissType swiss, ForeignerType foreigner)
    {
        if (swiss != null && foreigner == null)
        {
            return new AnyPersonType
            {
                Swiss = swiss,
                Foreigner = null
            };
        }

        if (swiss == null && foreigner != null)
        {
            return new AnyPersonType
            {
                Swiss = null,
                Foreigner = foreigner
            };
        }

        if (swiss == null && foreigner == null)
        {
            return new AnyPersonType
            {
                Swiss = null,
                Foreigner = null
            };
        }

        throw new FieldValidationException("Just one of the two fields 'swiss' and 'foreigner' must be filled.");
    }

    [JsonProperty("swiss")]
    [XmlElement(ElementName = "swiss")]
    public SwissType Swiss
    {
        get => _swiss;
        set => CheckAndSetValue(ref _swiss, value);
    }

    [JsonProperty("swiss")]
    [XmlElement(ElementName = "swiss")]
    public ForeignerType Foreigner
    {
        get => _foreigner;
        set => CheckAndSetValue(ref _foreigner, value);
    }
}
