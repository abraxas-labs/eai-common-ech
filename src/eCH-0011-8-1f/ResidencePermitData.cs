// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Heimatort (eCH-0011)
/// Angaben zur Ausländerkategorie.
/// </summary>
[Serializable]
[JsonObject("residencePermitData")]
[XmlRoot(ElementName = "residencePermitData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class ResidencePermitData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _residencePermit;

    public ResidencePermitData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="residencePermit">Field is reqired.</param>
    /// <param name="residencePermitValidFrom">Field is optional.</param>
    /// <param name="residencePermitValidTill">Field is optional.</param>
    /// <param name="entryDate">Field is optional.</param>
    /// <returns>PlaceOfOrigin.</returns>
    public static ResidencePermitData Create(string residencePermit, DateTime? residencePermitValidFrom = null, DateTime? residencePermitValidTill = null, DateTime? entryDate = null)
    {
        return new ResidencePermitData()
        {
            ResidencePermit = residencePermit,
            ResidencePermitValidFrom = residencePermitValidFrom,
            ResidencePermitValidTill = residencePermitValidTill,
            EntryDate = entryDate
        };
    }

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit")]
    public string ResidencePermit
    {
        get { return _residencePermit; }

        set
        {
            if (!string.IsNullOrEmpty(value) && !eCH_0006_2_0.ResidencePermit.Validate(value))
            {
                throw new XmlSchemaValidationException($"{value} is not valide value for type eCH-0006.ResidencePermit!");
            }

            _residencePermit = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitSpecified => !string.IsNullOrEmpty(ResidencePermit);

    [JsonProperty("residencePermitValidFrom")]
    [XmlElement(DataType = "date", ElementName = "residencePermitValidFrom")]
    public DateTime? ResidencePermitValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitValidFromSpecified => ResidencePermitValidFrom.HasValue;

    [JsonProperty("residencePermitValidTill")]
    [XmlElement(DataType = "date", ElementName = "residencePermitValidTill")]
    public DateTime? ResidencePermitValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitValidTillSpecified => ResidencePermitValidTill.HasValue;

    [JsonProperty("entryDate")]
    [XmlElement(DataType = "date", ElementName = "entryDate")]
    public DateTime? EntryDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool EntryDateSpecified => EntryDate.HasValue;
}
