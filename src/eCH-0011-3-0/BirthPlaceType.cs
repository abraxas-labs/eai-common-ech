// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("birthplace")]
[XmlRoot(ElementName = "birthplace", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/3")]
public class BirthPlaceType : FieldValueChecker<BirthPlaceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private UnknownType? _unknown;
    private SwissTownType _swissTown;
    private ForeignCountryType _foreignCountry;

    public BirthPlaceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/3");
    }

    public static BirthPlaceType Create(UnknownType? unknown, SwissTownType swissTown, ForeignCountryType foreignCountry)
    {
        if (unknown != null && swissTown == null && foreignCountry == null)
        {
            return new BirthPlaceType
            {
                Unknown = unknown
            };
        }

        if (unknown == null && swissTown != null && foreignCountry == null)
        {
            return new BirthPlaceType
            {
                SwissTown = swissTown
            };
        }

        if (unknown == null && swissTown == null && foreignCountry != null)
        {
            return new BirthPlaceType
            {
                ForeignCountry = foreignCountry
            };
        }

        throw new FieldValidationException("BirthPlace is not valid. Just one of the elements unknown, swissTown and ForeignCountry must be filled");
    }

    [JsonProperty("unknown")]
    [XmlElement(ElementName = "unknown")]
    public UnknownType? Unknown
    {
        get => _unknown;
        set => CheckAndSetValue(ref _unknown, value);
    }

    [JsonProperty("swissTown")]
    [XmlElement(ElementName = "swissTown")]
    public SwissTownType SwissTown
    {
        get => _swissTown;
        set => CheckAndSetValue(ref _swissTown, value);
    }

    [JsonProperty("foreignCountry")]
    [XmlElement(ElementName = "foreignCountry")]
    public ForeignCountryType ForeignCountry
    {
        get => _foreignCountry;
        set => CheckAndSetValue(ref _foreignCountry, value);
    }
}
