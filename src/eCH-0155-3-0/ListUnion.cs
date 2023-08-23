// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Listenverbindung.
/// </summary>
[Serializable]
[JsonObject("listUnion")]
[XmlRoot(ElementName = "listUnion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ListUnion
{
    private const string ListUnionIdentificationNullValidateExceptionMessage =
        "ListUnionIdentification is not valid! ListUnionIdentification is required";

    private const string ListUnionIdentificationOutOfRangeValidateExceptionMessage =
            "ListUnionIdentification is not valid! ListUnionIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private const string ListUnionDescriptionNullValidateExceptionMessage =
        "ListUnionDescription is not valid! ListUnionDescription is required";

    private const string ReferencedListNullValidateExceptionMessage =
        "ReferencedList is not valid! ReferencedList is required";

    private const string ReferencedListOutOfRangeValidateExceptionMessage =
        "ReferencedList is not valid! ReferencedList has minimal leght of 1 and maximal length of 50";

    private ListUnionDescription _listUnionDescription;

    private string _listUnionIdentification;
    private string[] _referencedList;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListUnion()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("listUnionIdentification")]
    [XmlElement(ElementName = "listUnionIdentification")]
    public string ListUnionIdentification
    {
        get => _listUnionIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ListUnionIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(ListUnionIdentificationOutOfRangeValidateExceptionMessage);
            }

            _listUnionIdentification = value;
        }
    }

    [JsonProperty("listUnionDescription")]
    [XmlElement(ElementName = "listUnionDescription")]
    public ListUnionDescription ListUnionDescription
    {
        get => _listUnionDescription;
        set => _listUnionDescription =
            value ?? throw new XmlSchemaValidationException(ListUnionDescriptionNullValidateExceptionMessage);
    }

    [JsonProperty("listUnionType")]
    [XmlElement(ElementName = "listUnionType")]
    public ListRelationType ListUnionType { get; set; }

    [JsonProperty("referencedList")]
    [XmlElement(ElementName = "referencedList")]
    public string[] ReferencedList
    {
        get => _referencedList;
        set
        {
            if (value == null || !value.Any())
            {
                throw new XmlSchemaValidationException(ReferencedListNullValidateExceptionMessage);
            }

            if (value.Any(x => string.IsNullOrEmpty(x) || x.Length < 1 || x.Length > 50))
            {
                throw new XmlSchemaValidationException(ReferencedListOutOfRangeValidateExceptionMessage);
            }

            _referencedList = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="listUnionIdentification">Field is required.</param>
    /// <param name="listUnionDescription">Field is required.</param>
    /// <param name="listUnionType">Field is required.</param>
    /// <param name="referencedList">Field is required.</param>
    /// <returns>ListUnion.</returns>
    public static ListUnion Create(string listUnionIdentification, ListUnionDescription listUnionDescription,
        ListRelationType listUnionType, List<string> referencedList)
    {
        return new ListUnion
        {
            ListUnionIdentification = listUnionIdentification,
            ListUnionDescription = listUnionDescription,
            ListUnionType = listUnionType,
            ReferencedList = (referencedList != null) ? referencedList.ToArray() : null
        };
    }
}
