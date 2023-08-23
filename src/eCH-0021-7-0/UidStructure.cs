// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Die UID ist ein Unternehmensidentifikator, der für den Kontakt der Unternehmen mit den Be-hörden (B2G) und im
/// Kontakt und Datenaustausch (zu Unternehmen) von Verwaltungsstellen (G2G) verwendet wird.
/// </summary>
[Serializable]
[JsonObject("uidStructure")]
[XmlRoot(ElementName = "uidStructure", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class UidStructure
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UidOrganisationIdCategorieValidateExceptionMessage = "UidOrganisationIdCategorie is not valid! UidOrganisationIdCategorie has to be length 3";
    private const string UidOrganisationIdCategorieNullValidateExceptionMessage = "UidOrganisationIdCategorie is not valid! UidOrganisationIdCategorie is requred";
    private const string UidOrganisationIdValidateExceptionMessage = "UidOrganisationId is not valid! UidOrganisationId has to be between 1 and 999999999";

    private string _uidOrganisationIdCategorie;
    private int _uidOrganisationId;

    public UidStructure()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="uidOrganisationIdCategorie">Field is required.</param>
    /// <param name="uidOrganisationId">Field is required.</param>
    /// <returns>PersonAdditional.</returns>
    public static UidStructure Create(string uidOrganisationIdCategorie, int uidOrganisationId)
    {
        return new UidStructure()
        {
            UidOrganisationIdCategorie = uidOrganisationIdCategorie,
            UidOrganisationId = uidOrganisationId
        };
    }

    [JsonProperty("uidOrganisationIdCategorie")]
    [XmlElement(ElementName = "uidOrganisationIdCategorie", Order = 1)]
    public string UidOrganisationIdCategorie
    {
        get { return _uidOrganisationIdCategorie; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(UidOrganisationIdCategorieNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length != 3)
            {
                throw new XmlSchemaValidationException(UidOrganisationIdCategorieValidateExceptionMessage);
            }
            _uidOrganisationIdCategorie = value;
        }
    }

    [JsonProperty("uidOrganisationId")]
    [XmlElement(ElementName = "uidOrganisationId", Order = 2)]
    public int UidOrganisationId
    {
        get { return _uidOrganisationId; }

        set
        {
            if (value < 1 && value > 999999999)
            {
                throw new XmlSchemaValidationException(UidOrganisationIdValidateExceptionMessage);
            }
            _uidOrganisationId = value;
        }
    }
}
