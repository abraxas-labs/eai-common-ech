// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Adressinformationen, welche in allen Postadressen vorhanden sein können.
/// </summary>
[Serializable]
[JsonObject("swissAddressInformation")]
[XmlRoot(ElementName = "swissAddressInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010-f/5")]
public class SwissAddressInformation : FieldValueChecker<SwissAddressInformation>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _addressLine1;
    private string _addressLine2;
    private string _street;
    private string _houseNumber;
    private string _dwellingNumber;
    private string _locality;
    private string _town;
    private int? _swissZipCode;
    private string _swissZipCodeAddOn;
    private string _country;

    public SwissAddressInformation()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010-f/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="addressLine1">Field can be null.</param>
    /// <param name="addressLine2">Field can be null.</param>
    /// <param name="street">Has dependency to houseNumber, dwellingNumber.</param>
    /// <param name="houseNumber">Field can be null.</param>
    /// <param name="dwellingNumber">Field can be null.</param>
    /// <param name="locality">Field can be null.</param>
    /// <param name="town">Field is reqired.</param>
    /// <param name="swissZipCode">Has dependency to swissZipCodeAddOn, swissZipCodeId.</param>
    /// <param name="swissZipCodeAddOn">Field can be null.</param>
    /// <param name="swissZipCodeId">Field can be null.</param>
    /// <param name="country">Field is reqired.</param>
    /// <returns>SwissAddressInformation.</returns>
    public static SwissAddressInformation Create(string addressLine1, string addressLine2, string street, string houseNumber, string dwellingNumber, string locality, string town, int swissZipCode, string swissZipCodeAddOn, int? swissZipCodeId, string country)
    {
        return new SwissAddressInformation
        {
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            Street = street,
            HouseNumber = houseNumber,
            DwellingNumber = dwellingNumber,
            Locality = locality,
            Town = town,
            SwissZipCode = swissZipCode,
            SwissZipCodeAddOn = swissZipCodeAddOn,
            SwissZipCodeId = swissZipCodeId,
            Country = country
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="town">Field is reqired.</param>
    /// <param name="country">Field is reqired.</param>
    /// <param name="swissZipCode">Field is reqired.</param>
    /// <returns>SwissAddressInformation.</returns>
    public static SwissAddressInformation Create(string town, string country, int swissZipCode)
    {
        return new SwissAddressInformation
        {
            AddressLine1 = null,
            AddressLine2 = null,
            Street = null,
            HouseNumber = null,
            DwellingNumber = null,
            Locality = null,
            Town = town,
            SwissZipCode = swissZipCode,
            SwissZipCodeAddOn = null,
            SwissZipCodeId = null,
            Country = country
        };
    }

    [FieldMaxLength(60)]
    [JsonProperty("addressLine1")]
    [XmlElement(ElementName = "addressLine1")]
    public string AddressLine1
    {
        get => _addressLine1;
        set => CheckAndSetValue(ref _addressLine1, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddressLine1Specified => !string.IsNullOrWhiteSpace(AddressLine1);

    [FieldMaxLength(60)]
    [JsonProperty("addressLine2")]
    [XmlElement(ElementName = "addressLine2")]
    public string AddressLine2
    {
        get => _addressLine2;
        set => CheckAndSetValue(ref _addressLine2, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddressLine2Specified => !string.IsNullOrWhiteSpace(AddressLine2);

    [FieldMaxLength(60)]
    [JsonProperty("street")]
    [XmlElement(ElementName = "street")]
    public string Street
    {
        get => _street;
        set => CheckAndSetValue(ref _street, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool StreetSpecified => !string.IsNullOrWhiteSpace(Street);

    [FieldMaxLength(12)]
    [JsonProperty("houseNumber")]
    [XmlElement(ElementName = "houseNumber")]
    public string HouseNumber
    {
        get => _houseNumber;
        set => CheckAndSetValue(ref _houseNumber, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HouseNumberSpecified => !string.IsNullOrWhiteSpace(HouseNumber);

    [FieldMaxLength(10)]
    [JsonProperty("dwellingNumber")]
    [XmlElement(ElementName = "dwellingNumber")]
    public string DwellingNumber
    {
        get => _dwellingNumber;
        set => CheckAndSetValue(ref _dwellingNumber, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DwellingNumberSpecified => !string.IsNullOrWhiteSpace(DwellingNumber);

    [FieldMaxLength(40)]
    [JsonProperty("locality")]
    [XmlElement(ElementName = "locality")]
    public string Locality
    {
        get => _locality;
        set => CheckAndSetValue(ref _locality, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LocalitySpecified => !string.IsNullOrWhiteSpace(Locality);

    [FieldMaxLength(40)]
    [JsonProperty("town")]
    [XmlElement(ElementName = "town")]
    public string Town
    {
        get => _town;
        set => CheckAndSetValue(ref _town, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TownSpecified => !string.IsNullOrWhiteSpace(Town);

    [FieldRangeInclusive(1000, 9999)]
    [JsonProperty("swissZipCode")]
    [XmlElement(ElementName = "swissZipCode")]
    public int? SwissZipCode
    {
        get => _swissZipCode;
        set => CheckAndSetValue(ref _swissZipCode, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SwissZipCodeSpecified => SwissZipCode.HasValue;

    [FieldMaxLength(2)]
    [JsonProperty("swissZipCodeAddOn")]
    [XmlElement(ElementName = "swissZipCodeAddOn")]
    public string SwissZipCodeAddOn
    {
        get => _swissZipCodeAddOn;
        set => CheckAndSetValue(ref _swissZipCodeAddOn, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SwissZipCodeAddOnSpecified => !string.IsNullOrWhiteSpace(SwissZipCodeAddOn);

    [JsonProperty("swissZipCodeId")]
    [XmlElement(ElementName = "swissZipCodeId")]
    public int? SwissZipCodeId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SwissZipCodeIdSpecified => SwissZipCodeId.HasValue;

    [FieldMinMaxLength(1, 2)]
    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public string Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountrySpecified => !string.IsNullOrWhiteSpace(Country);
}
