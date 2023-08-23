// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("maritalInfo")]
[XmlRoot(ElementName = "maritalInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class MaritalInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";

    private MaritalData _maritalData;

    public MaritalInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="maritalDataAddon">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static MaritalInfo Create(MaritalData maritalData, MaritalDataAddon maritalDataAddon = null)
    {
        return new MaritalInfo()
        {
            MaritalData = maritalData,
            MaritalDataAddon = maritalDataAddon
        };
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalData MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalDataAddon")]
    [XmlElement(ElementName = "maritalDataAddon")]
    public MaritalDataAddon MaritalDataAddon { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalDataAddonSpecified => MaritalDataAddon != null;
}
