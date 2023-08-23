// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Listenbezeichnung Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listDescriptionInformation")]
[XmlRoot(ElementName = "listDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ListDescriptionInformation
{
    private const string ListDescriptionNullValidateExceptionMessage =
        "ListDescriptionInfo is not valid! ListDescriptionInfo is required";

    private List<ListDescriptionInfo> _listDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("listDescriptionInfo")]
    [XmlElement(ElementName = "listDescriptionInfo", Order = 1)]
    public List<ListDescriptionInfo> ListDescriptionInfo
    {
        get => _listDescriptionInfo;
        set
        {
            _listDescriptionInfo = value ?? throw new XmlSchemaValidationException(ListDescriptionNullValidateExceptionMessage);
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="listDescriptionInfo">Field is required.</param>
    /// <returns>ListDescriptionInformation.</returns>
    public static ListDescriptionInformation Create(List<ListDescriptionInfo> listDescriptionInfo)
    {
        return new ListDescriptionInformation
        {
            ListDescriptionInfo = listDescriptionInfo
        };
    }
}
