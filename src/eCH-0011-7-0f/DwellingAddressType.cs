// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_1f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("dwellingAddress")]
[XmlRoot(ElementName = "dwellingAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class DwellingAddressType : FieldValueChecker<DwellingAddressType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private uint? _egid;
    private uint? _ewid;
    private string _householdId;
    private AddressInformation _address;
    private TypeOfHouseholdIdType _typeOfHouseholdId;
    private DateTime? _movingDate;

    public DwellingAddressType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="egid">Field is optional.</param>
    /// <param name="ewid">Field is optional.</param>
    /// <param name="householdId">Field is optional.</param>
    /// <param name="address">Field is required.</param>
    /// <param name="typeOfHousehold">Field is required.</param>
    /// <param name="movingDate">Field is optional.</param>
    /// <returns>DwellingAddressType.</returns>
    public static DwellingAddressType Create(uint? egid, uint? ewid, string householdId, AddressInformation address, TypeOfHouseholdIdType typeOfHousehold, DateTime? movingDate)
    {
        var dwellingAddress = new DwellingAddressType
        {
            Address = address,
            TypeOfHousehold = typeOfHousehold,
            MovingDate = movingDate
        };

        if (egid.HasValue)
        {
            dwellingAddress.Egid = egid;

            if (ewid.HasValue)
            {
                dwellingAddress.Ewid = ewid;
            }

            if (!string.IsNullOrWhiteSpace(householdId))
            {
                dwellingAddress.HouseholdId = householdId;
            }
        }
        else
        {
            dwellingAddress.WithoutEgid = new WithoutEgidType
            {
                HouseholdId = householdId
            };
        }

        return dwellingAddress;
    }

    [JsonProperty("EGID")]
    [XmlElement(ElementName = "EGID")]
    public uint? Egid
    {
        get => _egid;
        set => CheckAndSetValue(ref _egid, value);
    }

    [JsonProperty("EWID")]
    [XmlElement(ElementName = "EWID")]
    public uint? Ewid
    {
        get => _ewid;
        set => CheckAndSetValue(ref _ewid, value);
    }

    [JsonProperty("householdID")]
    [XmlElement(ElementName = "householdID")]
    public string HouseholdId
    {
        get => _householdId;
        set => CheckAndSetValue(ref _householdId, value);
    }

    [JsonProperty("withoutEGID")]
    [XmlElement(ElementName = "householdID")]
    public WithoutEgidType WithoutEgid
    {
        get;
        set;
    }

    [FieldRequired]
    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public AddressInformation Address
    {
        get => _address;
        set => CheckAndSetValue(ref _address, value);
    }

    [FieldRequired]
    [JsonProperty("typeOfHouseholdId")]
    [XmlElement(ElementName = "typeOfHouseholdId")]
    public TypeOfHouseholdIdType TypeOfHousehold
    {
        get => _typeOfHouseholdId;
        set => CheckAndSetValue(ref _typeOfHouseholdId, value);
    }

    [JsonProperty("movingDate")]
    [XmlElement(ElementName = "movingDate")]
    public DateTime? MovingDate
    {
        get => _movingDate;
        set => CheckAndSetValue(ref _movingDate, value);
    }
}
