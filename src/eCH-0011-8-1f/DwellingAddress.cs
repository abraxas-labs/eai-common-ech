// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0010_5_1f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Angaben, wo die Person wohnt (Wohnadresse).
/// </summary>
[Serializable]
[JsonObject("dwellingAddress")]
[XmlRoot(ElementName = "dwellingAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class DwellingAddress
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();
    private int? _egid;
    private short? _ewid;
    private SwissAddressInformation _address;

    public DwellingAddress()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
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
    [XmlElement(ElementName = "EGID")]
    public int? EGID
    {
        get { return _egid; }
        set { _egid = value; }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EGIDSpecified => EGID.HasValue;

    [JsonProperty("EWID")]
    [XmlElement(ElementName = "EWID")]
    public short? EWID
    {
        get { return _ewid; }
        set { _ewid = value; }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EWIDSpecified => EWID.HasValue;

    [JsonProperty("householdID")]
    [XmlElement(ElementName = "householdID")]
    public string HouseholdID { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HouseholdIDSpecified => !string.IsNullOrEmpty(HouseholdID);

    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public SwissAddressInformation Address
    {
        get { return _address; }
        set { _address = value; }
    }

    [JsonProperty("typeOfHousehold")]
    [XmlElement(ElementName = "typeOfHousehold")]
    public TypeOfHousehold TypeOfHousehold { get; set; }

    [JsonProperty("movingDate")]
    [XmlElement(DataType = "date", ElementName = "movingDate")]
    public DateTime? MovingDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MovingDateSpecified => MovingDate.HasValue;
}
