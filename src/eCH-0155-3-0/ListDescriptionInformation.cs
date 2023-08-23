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
///     Listenbezeichnung Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listDescriptionInformation")]
[XmlRoot(ElementName = "listDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ListDescriptionInformation
{
    private const string ListDescriptionNullValidateExceptionMessage =
        "ListDescriptionInfo is not valid! ListDescriptionInfo is required";

    private const string ListDescriptionInfoOutOfRangeValidateExceptionMessage =
        "ListDescriptionInfo is not valid! ListDescriptionInfo needs at least one item";

    private List<ListDescriptionInfo> _listDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("listDescriptionInfo")]
    [XmlElement(ElementName = "listDescriptionInfo")]
    public List<ListDescriptionInfo> ListDescriptionInfo
    {
        get => _listDescriptionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ListDescriptionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(ListDescriptionInfoOutOfRangeValidateExceptionMessage);
            }

            _listDescriptionInfo = value;
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
