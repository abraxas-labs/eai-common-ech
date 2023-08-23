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
///     Beschreibung einer Listenverbindung als Freitext von maximal 255 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listUnionDescription")]
[XmlRoot(ElementName = "listUnionDescription", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ListUnionDescriptionType
{
    private const string ListUnionDescriptionInfoNullValidateExceptionMessage =
        "ListUnionDescriptionInfo is not valid! ListUnionDescriptionInfo is required";

    private List<ListUnionDescriptionInfoType> _listUnionDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListUnionDescriptionType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("listUnionDescriptionInfo")]
    [XmlElement(ElementName = "listUnionDescriptionInfo", Order = 1)]
    public List<ListUnionDescriptionInfoType> ListUnionDescriptionInfo
    {
        get => _listUnionDescriptionInfo;
        set
        {
            _listUnionDescriptionInfo = value ?? throw new XmlSchemaValidationException(ListUnionDescriptionInfoNullValidateExceptionMessage);
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="listUnionDescriptionInfo">Field is required.</param>
    /// <returns>ListUnionDescription.</returns>
    public static ListUnionDescriptionType Create(List<ListUnionDescriptionInfoType> listUnionDescriptionInfo)
    {
        return new ListUnionDescriptionType
        {
            ListUnionDescriptionInfo = listUnionDescriptionInfo
        };
    }
}
