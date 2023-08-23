// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("swissDomesticType")]
[XmlRoot(ElementName = "swissDomesticType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class SwissDomestic
{
    private const string SwissDomesticPersonNullValidateExceptionMessage =
        "SwissDomesticPerson is not valid! SwissDomesticPerson is required";

    private const string MunicipalityNullValidateExceptionMessage =
        "Municipality is not valid! Municipality is required";

    private Person _swissDomesticPerson;
    private SwissMunicipality _municipality;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public SwissDomestic()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("swissDomesticPerson")]
    [XmlElement(ElementName = "swissDomesticPerson")]
    public Person SwissDomesticPerson
    {
        get => _swissDomesticPerson;
        set => _swissDomesticPerson = value ?? throw new XmlSchemaValidationException(SwissDomesticPersonNullValidateExceptionMessage);
    }

    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality")]
    public SwissMunicipality Municipality
    {
        get => _municipality;
        set => _municipality = value ?? throw new XmlSchemaValidationException(MunicipalityNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissDomesticPerson">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>SwissDomestic.</returns>
    public static SwissDomestic Create(Person swissDomesticPerson, SwissMunicipality municipality)
    {
        return new SwissDomestic
        {
            SwissDomesticPerson = swissDomesticPerson,
            Municipality = municipality
        };
    }
}
