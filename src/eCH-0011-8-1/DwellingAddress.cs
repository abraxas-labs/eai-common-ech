// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_1;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Angaben, wo die Person wohnt (Wohnadresse).
/// </summary>
[Serializable]
[JsonObject("dwellingAddress")]
[XmlRoot(ElementName = "dwellingAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class DwellingAddress
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string EGIDValidateExceptionMessage = "EGID is not valid! EGID has maxumal Value of 999999999";
    private const string EWIDValidateExceptionMessage = "EGID is not valid! EGID has maxumal Value of 999";
    private const string AddressNullValidateExceptionMessage = "Address is not valid! Address is required";

    private int? _egid;
    private short? _ewid;
    private SwissAddressInformation _address;

    public DwellingAddress()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="address">Field is required.</param>
    /// <param name="typeOfHousehold">Field is optional.</param>
    /// <param name="egid">Field is optional.</param>
    /// <param name="ewid">Field is optional.</param>
    /// <param name="householdID">Field is optional.</param>
    /// <param name="movingDate"></param>
    /// <returns>DwellingAddress.</returns>
    public static DwellingAddress Create(SwissAddressInformation address, TypeOfHousehold typeOfHousehold, int? egid = null, short? ewid = null, string householdID = null, DateTime? movingDate = null)
    {
        return new DwellingAddress()
        {
            EGID = egid,
            EWID = ewid,
            HouseholdID = householdID,
            Address = address,
            TypeOfHousehold = typeOfHousehold,
            MovingDate = movingDate
        };
    }

    [JsonProperty("EGID")]
    [XmlElement(ElementName = "EGID", Order = 1)]
    public int? EGID
    {
        get { return _egid; }

        set
        {
            if (value.HasValue && value.Value > 999999999)
            {
                throw new XmlSchemaValidationException(EGIDValidateExceptionMessage);
            }
            _egid = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EGIDSpecified => EGID.HasValue;

    [JsonProperty("EWID")]
    [XmlElement(ElementName = "EWID", Order = 2)]
    public short? EWID
    {
        get { return _ewid; }

        set
        {
            if (value.HasValue && value.Value > 999)
            {
                throw new XmlSchemaValidationException(EWIDValidateExceptionMessage);
            }
            _ewid = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EWIDSpecified => EWID.HasValue;

    [JsonProperty("householdID")]
    [XmlElement(ElementName = "householdID", Order = 3)]
    public string HouseholdID { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HouseholdIDSpecified => !string.IsNullOrEmpty(HouseholdID);

    [JsonProperty("address")]
    [XmlElement(ElementName = "address", Order = 4)]
    public SwissAddressInformation Address
    {
        get { return _address; }

        set
        {
            _address = value ?? throw new XmlSchemaValidationException(AddressNullValidateExceptionMessage);
        }
    }

    [JsonProperty("typeOfHousehold")]
    [XmlElement(ElementName = "typeOfHousehold", Order = 5)]
    public TypeOfHousehold TypeOfHousehold { get; set; }

    [JsonProperty("movingDate")]
    [XmlElement(DataType = "date", ElementName = "movingDate", Order = 6)]
    public DateTime? MovingDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MovingDateSpecified => MovingDate.HasValue;
}
