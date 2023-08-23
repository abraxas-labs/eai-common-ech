// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_4_1f;

[Serializable]
[JsonObject("namedPersonId")]
[XmlRoot(ElementName = "namedPersonId", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044-f/4")]
public class NamedPersonId : FieldValueChecker<NamedPersonId>
{
    private string _personIdCategory;
    private string _personId;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public NamedPersonId()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044-f/4");
    }

    public static NamedPersonId Create(string personIdCategory, string personId)
    {
        return new NamedPersonId
        {
            PersonIdCategory = personIdCategory,
            PersonId = personId
        };
    }

    [FieldMinMaxLength(1, 20)]
    [JsonProperty("personIdCategory")]
    [XmlElement(ElementName = "personIdCategory")]
    public string PersonIdCategory
    {
        get => _personIdCategory;
        set => CheckAndSetValue(ref _personIdCategory, value);
    }

    [FieldMinMaxLength(1, 36)]
    [JsonProperty("personId")]
    [XmlElement(ElementName = "personId")]
    public string PersonId
    {
        get => _personId;
        set => CheckAndSetValue(ref _personId, value);
    }
}
