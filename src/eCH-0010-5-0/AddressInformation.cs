// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Adressinformationen, welche in allen Postadressen vorhanden sein können.
/// </summary>
[Serializable]
[JsonObject("addressInformation")]
[XmlRoot(ElementName = "addressInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/5")]
public class AddressInformation : FieldValueChecker<AddressInformation>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string StreetNullValidateExceptionMessage = "Street is not valid! Street can not be null, when HouseNumber or DewllingNumber have a value";
    private const string PostOfficeBoxTextNullValidateExceptionMessage = "PostOfficeBoxText is not valid! PostOfficeBoxNumber can not be null, when PostOfficeBoxNumber has a value";
    private const string SwissZipCodeNullValidateExceptionMessage = "SwissZipCode is not valid! SwissZipCode can not be null, when SwissZipCodeAddOn or SwissZipCodeId have a value";

    private string _addressLine1;
    private string _addressLine2;
    private string _street;
    private string _houseNumber;
    private string _dwellingNumber;
    private int? _postOfficeBoxNumber;
    private string _postOfficeBoxText;
    private string _locality;
    private string _town;
    private int? _swissZipCode;
    private string _swissZipCodeAddOn;
    private string _foreignZipCode;
    private string _country;

    public AddressInformation()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/5");
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
    /// <param name="postOfficeBoxNumber">Field can be null.</param>
    /// <param name="postOfficeBoxText">Has dependency to postOfficeBoxNumber.</param>
    /// <param name="locality">Field can be null.</param>
    /// <param name="town">Field is reqired.</param>
    /// <param name="swissZipCode">Has dependency to swissZipCodeAddOn, swissZipCodeId.</param>
    /// <param name="swissZipCodeAddOn">Field can be null.</param>
    /// <param name="swissZipCodeId">Field can be null.</param>
    /// <param name="country">Field is reqired.</param>
    /// <returns>AddressInformation.</returns>
    public static AddressInformation Create(string addressLine1, string addressLine2, string street, string houseNumber, string dwellingNumber, int? postOfficeBoxNumber, string postOfficeBoxText, string locality, string town, int? swissZipCode, string swissZipCodeAddOn, int? swissZipCodeId, string country)
    {
        if (string.IsNullOrEmpty(street) && (!string.IsNullOrEmpty(houseNumber) || !string.IsNullOrEmpty(dwellingNumber)))
        {
            throw new FieldValidationException(StreetNullValidateExceptionMessage);
        }

        if (string.IsNullOrEmpty(postOfficeBoxText) && postOfficeBoxNumber.HasValue)
        {
            throw new FieldValidationException(PostOfficeBoxTextNullValidateExceptionMessage);
        }

        if (!swissZipCode.HasValue && (!string.IsNullOrEmpty(swissZipCodeAddOn) || swissZipCodeId.HasValue))
        {
            throw new FieldValidationException(SwissZipCodeNullValidateExceptionMessage);
        }

        return new AddressInformation
        {
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            Street = street,
            HouseNumber = houseNumber,
            DwellingNumber = dwellingNumber,
            PostOfficeBoxNumber = postOfficeBoxNumber,
            PostOfficeBoxText = postOfficeBoxText,
            Locality = locality,
            Town = town,
            SwissZipCode = swissZipCode,
            SwissZipCodeAddOn = swissZipCodeAddOn,
            SwissZipCodeId = swissZipCodeId,
            ForeignZipCode = null,
            Country = country
        };
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
    /// <param name="postOfficeBoxNumber">Field can be null.</param>
    /// <param name="postOfficeBoxText">Has dependency to postOfficeBoxNumber.</param>
    /// <param name="locality">Field can be null.</param>
    /// <param name="town">Field is reqired.</param>
    /// <param name="foreignZipCode">Field can be null.</param>
    /// <param name="country">Field is reqired.</param>
    /// <returns>AddressInformation.</returns>
    public static AddressInformation Create(string addressLine1, string addressLine2, string street, string houseNumber, string dwellingNumber, int? postOfficeBoxNumber, string postOfficeBoxText, string locality, string town, string foreignZipCode, string country)
    {
        if (string.IsNullOrEmpty(street) && (!string.IsNullOrEmpty(houseNumber) || !string.IsNullOrEmpty(dwellingNumber)))
        {
            throw new FieldValidationException(StreetNullValidateExceptionMessage);
        }

        if (string.IsNullOrEmpty(postOfficeBoxText) && postOfficeBoxNumber.HasValue)
        {
            throw new FieldValidationException(PostOfficeBoxTextNullValidateExceptionMessage);
        }

        return new AddressInformation
        {
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            Street = street,
            HouseNumber = houseNumber,
            DwellingNumber = dwellingNumber,
            PostOfficeBoxNumber = postOfficeBoxNumber,
            PostOfficeBoxText = postOfficeBoxText,
            Locality = locality,
            Town = town,
            SwissZipCode = null,
            SwissZipCodeAddOn = null,
            SwissZipCodeId = null,
            ForeignZipCode = foreignZipCode,
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
    /// <returns>AddressInformation.</returns>
    public static AddressInformation Create(string town, string country)
    {
        return new AddressInformation
        {
            AddressLine1 = null,
            AddressLine2 = null,
            Street = null,
            HouseNumber = null,
            DwellingNumber = null,
            PostOfficeBoxNumber = null,
            PostOfficeBoxText = null,
            Locality = null,
            Town = town,
            SwissZipCode = null,
            SwissZipCodeAddOn = null,
            SwissZipCodeId = null,
            ForeignZipCode = null,
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
        get { return _dwellingNumber; }
        set => CheckAndSetValue(ref _dwellingNumber, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DwellingNumberSpecified => !string.IsNullOrWhiteSpace(DwellingNumber);

    [FieldMaxInclusive(99999999)]
    [JsonProperty("postOfficeBoxNumber")]
    [XmlElement(ElementName = "postOfficeBoxNumber")]
    public int? PostOfficeBoxNumber
    {
        get => _postOfficeBoxNumber;
        set => CheckAndSetValue(ref _postOfficeBoxNumber, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PostOfficeBoxNumberSpecified => PostOfficeBoxNumber.HasValue;

    [FieldMaxLength(15)]
    [JsonProperty("postOfficeBoxText")]
    [XmlElement(ElementName = "postOfficeBoxText")]
    public string PostOfficeBoxText
    {
        get => _postOfficeBoxText;
        set => CheckAndSetValue(ref _postOfficeBoxText, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PostOfficeBoxTextSpecified => !string.IsNullOrWhiteSpace(PostOfficeBoxText);

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

    [FieldRequired]
    [FieldMaxLength(40)]
    [JsonProperty("town")]
    [XmlElement(ElementName = "town")]
    public string Town
    {
        get => _town;
        set => CheckAndSetValue(ref _town, value);
    }

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

    [FieldMaxLength(15)]
    [JsonProperty("foreignZipCode")]
    [XmlElement(ElementName = "foreignZipCode")]
    public string ForeignZipCode
    {
        get => _foreignZipCode;
        set => CheckAndSetValue(ref _foreignZipCode, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ForeignZipCodeSpecified => !string.IsNullOrWhiteSpace(ForeignZipCode);

    [FieldRequired]
    [FieldMinMaxLength(2, 2)]
    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public string Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }
}
