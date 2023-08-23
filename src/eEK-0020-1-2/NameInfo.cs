// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("nameInfo")]
[XmlRoot(ElementName = "nameInfo", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class NameInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NameDataNullValidateExceptionMessage = "NameData is not valid! NameData is required";

    private NameData _nameData;

    public NameInfo()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nameData">Field is required.</param>
    /// <param name="nameValidFrom">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static NameInfo Create(NameData nameData, DateTime? nameValidFrom = null)
    {
        return new NameInfo()
        {
            NameData = nameData,
            NameValidFrom = nameValidFrom
        };
    }

    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData")]
    public NameData NameData
    {
        get { return _nameData; }

        set
        {
            _nameData = value ?? throw new XmlSchemaValidationException(NameDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nameValidFrom")]
    [XmlElement(DataType = "date", ElementName = "nameValidFrom")]
    public DateTime? NameValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameValidFromSpecified => NameValidFrom.HasValue;
}
