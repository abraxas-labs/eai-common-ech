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
/// Personenzusatzangaben.
/// </summary>
[Serializable]
[JsonObject("personAdditional")]
[XmlRoot(ElementName = "personAdditional", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class PersonAdditionalData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string TitleValidateExceptionMessage = "Title is not valid! Title has to be maximum length 50";
    private const string LanguageOfCorrespondanceValidateExceptionMessage = "LanguageOfCorrespondance is not valid! LanguageOfCorrespondance has to be maximum length 2";

    private string _title;
    private string _languageOfCorrespondance;

    public PersonAdditionalData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="mrMrs">Field is optional.</param>
    /// <param name="title">Field is optional.</param>
    /// <param name="languageOfCorrespondance">Field is optional.</param>
    /// <returns>PersonAdditional.</returns>
    public static PersonAdditionalData Create(MrMrs? mrMrs = null, string title = null, string languageOfCorrespondance = null)
    {
        return new PersonAdditionalData()
        {
            MrMrs = mrMrs,
            Title = title,
            LanguageOfCorrespondance = languageOfCorrespondance
        };
    }

    [JsonProperty("mrMrs")]
    [XmlElement(ElementName = "mrMrs")]
    public MrMrs? MrMrs { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MrMrsSpecified => MrMrs.HasValue;

    [JsonProperty("title")]
    [XmlElement(ElementName = "title")]
    public string Title
    {
        get { return _title; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(TitleValidateExceptionMessage);
            }
            _title = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TitleSpecified => !string.IsNullOrEmpty(Title);

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
    public string LanguageOfCorrespondance
    {
        get { return _languageOfCorrespondance; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 2)
            {
                throw new XmlSchemaValidationException(LanguageOfCorrespondanceValidateExceptionMessage);
            }
            _languageOfCorrespondance = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LanguageOfCorrespondanceSpecified => !string.IsNullOrEmpty(LanguageOfCorrespondance);
}
