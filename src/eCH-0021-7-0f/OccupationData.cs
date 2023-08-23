// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_1f;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Arbeitgeberangaben.
/// </summary>
[Serializable]
[JsonObject("occupationData")]
[XmlRoot(ElementName = "occupationData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class OccupationData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string EmployerValidateExceptionMessage = "Title is not valid! Title has to be maximum length 100";

    private string _employer;

    public OccupationData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="uid">Field is optional.</param>
    /// <param name="employer">Field is optional.</param>
    /// <param name="placeOfWork">Field is optional.</param>
    /// <param name="placeOfEmployer">Field is optional.</param>
    /// <param name="occupationValidFrom">Field is optional.</param>
    /// <param name="occupationValidTill">Field is optional.</param>
    /// <returns>OccupationData.</returns>
    public static OccupationData Create(UidStructure uid = null, string employer = null, AddressInformation placeOfWork = null, AddressInformation placeOfEmployer = null, DateTime? occupationValidFrom = null, DateTime? occupationValidTill = null)
    {
        return new OccupationData()
        {
            UID = uid,
            Employer = employer,
            PlaceOfWork = placeOfWork,
            PlaceOfEmployer = placeOfEmployer,
            OccupationValidFrom = occupationValidFrom,
            OccupationValidTill = occupationValidTill
        };
    }

    [JsonProperty("UID")]
    [XmlElement(ElementName = "UID")]
    public UidStructure UID { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UIDSpecified => UID != null;

    [JsonProperty("employer")]
    [XmlElement(ElementName = "employer")]
    public string Employer
    {
        get { return _employer; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(EmployerValidateExceptionMessage);
            }
            _employer = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EmployerSpecified => !string.IsNullOrEmpty(Employer);

    [JsonProperty("placeOfWork")]
    [XmlElement(ElementName = "placeOfWork")]
    public AddressInformation PlaceOfWork { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfWorkSpecified => PlaceOfWork != null;

    [JsonProperty("placeOfEmployer")]
    [XmlElement(ElementName = "placeOfEmployer")]
    public AddressInformation PlaceOfEmployer { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfEmployerSpecified => PlaceOfEmployer != null;

    [JsonProperty("occupationValidFrom")]
    [XmlElement(DataType = "date", ElementName = "occupationValidFrom")]
    public DateTime? OccupationValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OccupationValidFromSpecified => OccupationValidFrom != null;

    [JsonProperty("occupationValidTill")]
    [XmlElement(DataType = "date", ElementName = "occupationValidTill")]
    public DateTime? OccupationValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OccupationValidTillSpecified => OccupationValidTill != null;
}
