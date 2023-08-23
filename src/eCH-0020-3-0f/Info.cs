// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Detailinformation.
/// </summary>
[Serializable]
[JsonObject("info")]
[XmlRoot(ElementName = "info", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class Info
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CodeValidateExceptionMessage = "Code is not valid! Code  has max Length of 250";

    private string _code;

    public Info()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// tatische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="code">Field is optional.</param>
    /// <param name="textEnglish">Field is optional.</param>
    /// <param name="textGerman">Field is optional.</param>
    /// <param name="textFrench">Field is optional.</param>
    /// <param name="textItalian">Field is optional.</param>
    /// <returns>Info.</returns>
    public static Info Create(string code = null, string textEnglish = null, string textGerman = null, string textFrench = null, string textItalian = null)
    {
        return new Info()
        {
            Code = code,
            TextEnglish = textEnglish,
            TextFrench = textFrench,
            TextGerman = textGerman,
            TextItalian = textItalian
        };
    }

    [JsonProperty("code")]
    [XmlElement(ElementName = "code")]
    public string Code
    {
        get { return _code; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 250)
            {
                throw new XmlSchemaValidationException(CodeValidateExceptionMessage);
            }
            _code = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CodeSpecified => !string.IsNullOrEmpty(Code);

    [JsonProperty("textEnglish")]
    [XmlElement(ElementName = "textEnglish")]
    public string TextEnglish { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextEnglishSpecified => !string.IsNullOrEmpty(TextEnglish);

    [JsonProperty("textGerman")]
    [XmlElement(ElementName = "textGerman")]
    public string TextGerman { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextGermanSpecified => !string.IsNullOrEmpty(TextGerman);

    [JsonProperty("textFrench")]
    [XmlElement(ElementName = "textFrench")]
    public string TextFrench { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextFrenchSpecified => !string.IsNullOrEmpty(TextFrench);

    [JsonProperty("textItalian")]
    [XmlElement(ElementName = "textItalian")]
    public string TextItalian { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextItalianSpecified => !string.IsNullOrEmpty(TextItalian);
}
