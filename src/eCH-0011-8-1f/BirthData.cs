// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Geburtsangaben.
/// </summary>
[Serializable]
[JsonObject("birthData")]
[XmlRoot(ElementName = "birthData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class BirthData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private eCH_0044_4_1f.DatePartiallyKnown _dateOfBirth;
    private GeneralPlace _placeOfBirth;

    public BirthData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateOfBirth">Field is required.</param>
    /// <param name="placeOfBirth">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <returns>BirthData.</returns>
    public static BirthData Create(eCH_0044_4_1.DatePartiallyKnown dateOfBirth, eCH_0011_8_1.GeneralPlace placeOfBirth, eCH_0044_4_1.SexType? sex)
    {
        eCH_0044_4_1f.DatePartiallyKnown fDateOfBirth = new()
        {
            Year = dateOfBirth.Year,
            YearMonth = dateOfBirth.YearMonth,
            YearMonthDay = dateOfBirth.YearMonthDay
        };

        eCH_0011_8_1f.GeneralPlace fPlaceOfBirth = null;

        // Town in Switzerland Switzerland
        if (placeOfBirth.SwissTownSpecified)
        {
            eCH_0007_5_0f.CantonAbbreviation? fCantonAbbreviation = null;

            if (placeOfBirth.SwissTown.CantonAbbreviationSpecified)
            {
                fCantonAbbreviation = (eCH_0007_5_0f.CantonAbbreviation)Enum.Parse(typeof(eCH_0007_5_0f.CantonAbbreviation), placeOfBirth.SwissTown.CantonAbbreviation.ToString());
            }

            eCH_0007_5_0f.SwissMunicipality fSwissMunicipality = new()
            {
                CantonAbbreviation = fCantonAbbreviation,
                HistoryMunicipalityId = placeOfBirth.SwissTown.HistoryMunicipalityId,
                MunicipalityId = placeOfBirth.SwissTown.MunicipalityId,
                MunicipalityName = placeOfBirth.SwissTown.MunicipalityName
            };

            fPlaceOfBirth = eCH_0011_8_1f.GeneralPlace.Create(fSwissMunicipality);
        }

        // Foreign Country
        else if (placeOfBirth.ForeignCountrySpecified)
        {
            eCH_0011_8_1f.ForeignCountry fForeignCountry = eCH_0011_8_1f.ForeignCountry.Create(placeOfBirth.ForeignCountry.Country, placeOfBirth.ForeignCountry.Town);

            fPlaceOfBirth = eCH_0011_8_1f.GeneralPlace.Create(fForeignCountry);
        }

        // Unknown
        else if (placeOfBirth.UnknownSpecified)
        {
            fPlaceOfBirth = eCH_0011_8_1f.GeneralPlace.Create(placeOfBirth.Unknown);
        }

        return new BirthData()
        {
            DateOfBirth = fDateOfBirth,
            PlaceOfBirth = fPlaceOfBirth,
            Sex = (sex != null) ? (eCH_0044_4_1f.SexType?)Enum.Parse(typeof(eCH_0044_4_1f.SexType), sex.ToString()) : null
        };
    }

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public eCH_0044_4_1f.DatePartiallyKnown DateOfBirth
    {
        get { return _dateOfBirth; }
        set { _dateOfBirth = value; }
    }

    [JsonProperty("placeOfBirth")]
    [XmlElement(ElementName = "placeOfBirth")]
    public GeneralPlace PlaceOfBirth
    {
        get { return _placeOfBirth; }
        set { _placeOfBirth = value; }
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public eCH_0044_4_1f.SexType? Sex { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SexSpecified => Sex.HasValue;
}
