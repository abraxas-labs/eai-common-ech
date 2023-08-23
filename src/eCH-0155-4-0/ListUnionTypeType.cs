// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Listenverbindung.
/// </summary>
[Serializable]
[JsonObject("listUnionType")]
[XmlRoot(ElementName = "listUnionType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ListUnionTypeType : FieldValueChecker<ListUnionTypeType>
{
    private const string ReferencedListNullValidateExceptionMessage = "ReferencedList is not valid! ReferencedList is required";

    private const string ReferencedListOutOfRangeValidateExceptionMessage = "ReferencedList is not valid! ReferencedList has minimal leght of 1 and maximal length of 50";

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _listUnionIdentification;
    private ListUnionDescriptionType _listUnionDescription;
    private ListRelationType _listUnionType;
    private string[] _referencedList;
    private string _referencedListUnion;

    public ListUnionTypeType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("listUnionIdentification")]
    [XmlElement(ElementName = "listUnionIdentification", Order = 1)]
    public string ListUnionIdentification
    {
        get => _listUnionIdentification;
        set => CheckAndSetValue(ref _listUnionIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("listUnionDescription")]
    [XmlElement(ElementName = "listUnionDescription", Order = 2)]
    public ListUnionDescriptionType ListUnionDescription
    {
        get => _listUnionDescription;
        set => CheckAndSetValue(ref _listUnionDescription, value);
    }

    [FieldRequired]
    [JsonProperty("listUnionType")]
    [XmlElement(ElementName = "listUnionType", Order = 3)]
    public ListRelationType ListUnionType
    {
        get => _listUnionType;
        set => CheckAndSetValue(ref _listUnionType, value);
    }

    [JsonProperty("referencedList")]
    [XmlElement(ElementName = "referencedList", Order = 4)]
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

    [FieldMinMaxLength(1, 50)]
    [JsonProperty("referencedListUnion")]
    [XmlElement(ElementName = "referencedListUnion", Order = 5)]
    public string ReferencedListUnion
    {
        get => _referencedListUnion;
        set => CheckAndSetValue(ref _referencedListUnion, value);
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
    public static ListUnionTypeType Create(string listUnionIdentification, ListUnionDescriptionType listUnionDescription,
        ListRelationType listUnionType, List<string> referencedList)
    {
        return new ListUnionTypeType
        {
            ListUnionIdentification = listUnionIdentification,
            ListUnionDescription = listUnionDescription,
            ListUnionType = listUnionType,
            ReferencedList = (referencedList != null) ? referencedList.ToArray() : null
        };
    }
}
