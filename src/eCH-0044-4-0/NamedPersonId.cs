// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0044_4_0;

[Serializable]
[JsonObject("namedPersonId")]
[XmlRoot(ElementName = "namedPersonId", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class NamedPersonId
{
    private const string PersonIdCategoryValidateExceptionMessage = "personIdCategory is Null, Empty or to long!";
    private const string PersonIdValidateExceptionMessage = "personId is Null, Empty or to long!";
    private string _personId;
    private string _personIdCategory;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public NamedPersonId()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
    }

    [JsonProperty("personIdCategory")]
    [XmlElement(ElementName = "personIdCategory")]
    public string PersonIdCategory
    {
        get => _personIdCategory;
        set
        {
            if (value != null && (string.IsNullOrEmpty(value) || (value.Length > 20)))
            {
                throw new XmlSchemaValidationException(PersonIdCategoryValidateExceptionMessage);
            }

            _personIdCategory = value;
        }
    }

    [JsonProperty("personId")]
    [XmlElement(ElementName = "personId")]
    public string PersonId
    {
        get => _personId;
        set
        {
            if (value != null && (string.IsNullOrEmpty(value) || (value.Length > 36)))
            {
                throw new XmlSchemaValidationException(PersonIdValidateExceptionMessage);
            }

            _personId = value;
        }
    }

    public static NamedPersonId Create(string personIdCategory, string personId)
    {
        return new NamedPersonId
        {
            PersonIdCategory = personIdCategory,
            PersonId = personId
        };
    }
}
