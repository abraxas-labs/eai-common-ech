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
[JsonObject("birthInfo")]
[XmlRoot(ElementName = "birthInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class BirthInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private BirthData _birthData;

    public BirthInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="birthData">Field is required.</param>
    /// <param name="birthAddonData">Field is optional.</param>
    /// <returns>BirthInfo.</returns>
    public static BirthInfo Create(eCH_0011_8_1.BirthData birthData, eCH_0021_7_0.BirthAddonData birthAddonData = null)
    {
        return new BirthInfo()
        {
            BirthData = eCH_0011_8_1f.Mapper.ECHtoECHf.GetBirthData(birthData),
            BirthAddonData = (birthAddonData != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetBirthAddonData(birthAddonData) : null
        };
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthData BirthData
    {
        get { return _birthData; }
        set { _birthData = value; }
    }

    [JsonProperty("birthAddonData")]
    [XmlElement(ElementName = "birthAddonData")]
    public BirthAddonData BirthAddonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BirthAddonDataSpecified => BirthAddonData != null;
}
