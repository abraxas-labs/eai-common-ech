// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_6_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("swissDomesticType")]
[XmlRoot(ElementName = "swissDomesticType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class SwissDomesticType : FieldValueChecker<SwissDomesticType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private SwissPersonType _swissDomesticPerson;
    private SwissMunicipality _municipality;

    public SwissDomesticType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    [FieldRequired]
    [JsonProperty("swissDomesticPerson")]
    [XmlElement(ElementName = "swissDomesticPerson", Order = 1)]
    public SwissPersonType SwissDomesticPerson
    {
        get => _swissDomesticPerson;
        set => CheckAndSetValue(ref _swissDomesticPerson, value);
    }

    [FieldRequired]
    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality", Order = 2)]
    public SwissMunicipality Municipality
    {
        get => _municipality;
        set => CheckAndSetValue(ref _municipality, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissDomesticPerson">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>SwissDomestic.</returns>
    public static SwissDomesticType Create(SwissPersonType swissDomesticPerson, SwissMunicipality municipality)
    {
        return new SwissDomesticType
        {
            SwissDomesticPerson = swissDomesticPerson,
            Municipality = municipality
        };
    }
}
