// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("religionData")]
[XmlRoot(ElementName = "religionData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class ReligionData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ReligionNullValidateExceptionMessage = "Religion is not valid! Religion is required";
    private const string ReligionTypeValidateExceptionMessage = "Religion is not valid! Religion can only has digit";
    private const string ReligionValidateExceptionMessage = "Religion is not valid! Religion has restriction (\\d){3,6}";

    private int _religion;

    public ReligionData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="religion">Field is optional.</param>
    /// <param name="religionValidFrom">Field is optional.</param>
    /// <returns>ForeignerName.</returns>
    public static ReligionData Create(string religion, DateTime? religionValidFrom = null)
    {
        return new ReligionData()
        {
            Religion = religion,
            ReligionValidFrom = religionValidFrom
        };
    }

    [JsonProperty("religion")]
    [XmlElement(ElementName = "religion", Order = 1)]
    public string Religion
    {
        get { return _religion.ToString().PadLeft(3, '0'); }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ReligionNullValidateExceptionMessage);
            }
            int i;
            if (!int.TryParse(value, out i))
            {
                throw new XmlSchemaValidationException(ReligionTypeValidateExceptionMessage);
            }
            if (i < 0 && i > 999999)
            {
                throw new XmlSchemaValidationException(ReligionValidateExceptionMessage);
            }
            _religion = i;
        }
    }

    [JsonProperty("religionValidFrom")]
    [XmlElement(DataType = "date", ElementName = "religionValidFrom", Order = 2)]
    public DateTime? ReligionValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReligionValidFromSpecified => ReligionValidFrom.HasValue;
}
