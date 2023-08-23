// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Electionenbezeichnung Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("electionDescriptionInformation")]
[XmlRoot(ElementName = "electionDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ElectionDescriptionInformationType : FieldValueChecker<ElectionDescriptionInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ElectionDescriptionNullValidateExceptionMessage = "ElectionDescriptionInfo is not valid! ElectionDescriptionInfo is required";
    private List<ElectionDescriptionInfoType> _electionDescriptionInfo;

    public ElectionDescriptionInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [JsonProperty("electionDescriptionInfo")]
    [XmlElement(ElementName = "electionDescriptionInfo", Order = 1)]
    public List<ElectionDescriptionInfoType> ElectionDescriptionInfo
    {
        get => _electionDescriptionInfo;
        set
        {
            _electionDescriptionInfo = value ?? throw new XmlSchemaValidationException(ElectionDescriptionNullValidateExceptionMessage);
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionDescriptionInfo">Field is required.</param>
    /// <returns>ElectionDescriptionInformation.</returns>
    public static ElectionDescriptionInformationType Create(List<ElectionDescriptionInfoType> electionDescriptionInfo)
    {
        return new ElectionDescriptionInformationType
        {
            ElectionDescriptionInfo = electionDescriptionInfo
        };
    }
}
