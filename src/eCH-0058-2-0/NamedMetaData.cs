// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_2_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Meldungsrahmen (eCH-0058)
///     Liste benannter Metadaten welche die gezielte Erweiterung um spezifische Metadaten zur Lieferung zulässt.
/// </summary>
[Serializable]
[JsonObject("namedMetaData")]
[XmlRoot(ElementName = "namedMetaData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/5")]
public class NamedMetaData
{
    private const string MetaDataNameNullValidateExceptionMessage =
        "MetaDataName is not valid! MetaDataName is required";

    private const string MetaDataValueNullValidateExceptionMessage =
        "MetaDataValue is not valid! MetaDataValue is required";

    private string _metaDataName;
    private string _metaDataValue;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public NamedMetaData()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/5");
    }

    [JsonProperty("metaDataName")]
    [XmlElement(ElementName = "metaDataName")]
    public string MetaDataName
    {
        get => _metaDataName;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 20)
            {
                throw new XmlSchemaValidationException(MetaDataNameNullValidateExceptionMessage);
            }

            _metaDataName = value;
        }
    }

    [JsonProperty("metaDataValue")]
    [XmlElement(ElementName = "metaDataValue")]
    public string MetaDataValue
    {
        get => _metaDataValue;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 20)
            {
                throw new XmlSchemaValidationException(MetaDataValueNullValidateExceptionMessage);
            }

            _metaDataValue = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="metaDataName">Field is reqired.</param>
    /// <param name="metaDataValue">Field is reqired.</param>
    /// <returns>NamedMetaData.</returns>
    public static NamedMetaData Create(string metaDataName, string metaDataValue)
    {
        return new NamedMetaData
        {
            MetaDataName = metaDataName,
            MetaDataValue = metaDataValue
        };
    }
}
