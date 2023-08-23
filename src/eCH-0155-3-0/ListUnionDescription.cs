// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Beschreibung einer Listenverbindung als Freitext von maximal 255 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listUnionDescription")]
[XmlRoot(ElementName = "listUnionDescription", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ListUnionDescription
{
    private const string ListUnionDescriptionInfoNullValidateExceptionMessage =
        "ListUnionDescriptionInfo is not valid! ListUnionDescriptionInfo is required";

    private const string ListUnionDescriptionInfoOutOfRangeValidateExceptionMessage =
        "ListUnionDescriptionInfo is not valid! ListUnionDescriptionInfo needs adt least one item";

    private List<ListUnionDescriptionInfo> _listUnionDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListUnionDescription()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("listUnionDescriptionInfo")]
    [XmlElement(ElementName = "listUnionDescriptionInfo")]
    public List<ListUnionDescriptionInfo> ListUnionDescriptionInfo
    {
        get => _listUnionDescriptionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ListUnionDescriptionInfoNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(ListUnionDescriptionInfoOutOfRangeValidateExceptionMessage);
            }

            _listUnionDescriptionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="listUnionDescriptionInfo">Field is required.</param>
    /// <returns>ListUnionDescription.</returns>
    public static ListUnionDescription Create(List<ListUnionDescriptionInfo> listUnionDescriptionInfo)
    {
        return new ListUnionDescription
        {
            ListUnionDescriptionInfo = listUnionDescriptionInfo
        };
    }
}
