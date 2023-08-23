﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eEK_0020_1_1;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "birthInfo", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class BirthInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string BirthDataNullValidateExceptionMessage = "NameData is not valid! NameData is required";

    private BirthData _birthData;

    public BirthInfo()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="birthData">Field is required.</param>
    /// <param name="birthAddonData">Field is optional.</param>
    /// <returns>BirthInfo.</returns>
    public static BirthInfo Create(BirthData birthData, BirthAddonData birthAddonData = null)
    {
        return new BirthInfo()
        {
            BirthData = birthData,
            BirthAddonData = birthAddonData
        };
    }

    [JsonProperty("birthData")]
    [XmlElement(ElementName = "birthData")]
    public BirthData BirthData
    {
        get { return _birthData; }

        set
        {
            _birthData = value ?? throw new XmlSchemaValidationException(BirthDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("birthAddonData")]
    [XmlElement(ElementName = "birthAddonData")]
    public BirthAddonData BirthAddonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BirthAddonDataSpecified => BirthAddonData != null;
}
