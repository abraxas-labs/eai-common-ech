// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0021_7_0f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("maritalInfo")]
[XmlRoot(ElementName = "maritalInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class MaritalInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private MaritalData _maritalData;

    public MaritalInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="maritalDataAddon">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static MaritalInfo Create(eCH_0011_8_1.MaritalData maritalData, eCH_0021_7_0.MaritalDataAddon maritalDataAddon = null)
    {
        return new MaritalInfo()
        {
            MaritalData = eCH_0011_8_1f.Mapper.ECHtoECHf.GetMaritalData(maritalData),
            MaritalDataAddon = (maritalDataAddon != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetMaritalDataAddon(maritalDataAddon) : null
        };
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalData MaritalData
    {
        get { return _maritalData; }
        set { _maritalData = value; }
    }

    [JsonProperty("maritalDataAddon")]
    [XmlElement(ElementName = "maritalDataAddon")]
    public MaritalDataAddon MaritalDataAddon { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalDataAddonSpecified => MaritalDataAddon != null;
}
