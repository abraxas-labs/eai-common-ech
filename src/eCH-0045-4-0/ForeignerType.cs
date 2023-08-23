// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_6_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("foreignerType")]
[XmlRoot(ElementName = "foreignerType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class ForeignerType : FieldValueChecker<ForeignerType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ForeignerPersonType _foreignerPerson;
    private SwissMunicipality _municipality;

    public ForeignerType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="foreignerPerson">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>Foreigner.</returns>
    public static ForeignerType Create(ForeignerPersonType foreignerPerson, SwissMunicipality municipality)
    {
        return new ForeignerType
        {
            ForeignerPerson = foreignerPerson,
            Municipality = municipality
        };
    }

    [FieldRequired]
    [JsonProperty("foreignerPerson")]
    [XmlElement(ElementName = "foreignerPerson", Order = 1)]
    public ForeignerPersonType ForeignerPerson
    {
        get => _foreignerPerson;
        set => CheckAndSetValue(ref _foreignerPerson, value);
    }

    [FieldRequired]
    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality", Order = 2)]
    public SwissMunicipality Municipality
    {
        get => _municipality;
        set => CheckAndSetValue(ref _municipality, value);
    }
}
