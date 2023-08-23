// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("foreignerType")]
[XmlRoot(ElementName = "foreignerType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class Foreigner
{
    private const string ForeignerPersonNullValidateExceptionMessage =
        "ForeignerPerson is not valid! ForeignerPerson is required";

    private const string MunicipalityNullValidateExceptionMessage =
        "Municipality is not valid! Municipality is required";

    private Person _foreignerPerson;
    private SwissMunicipality _municipality;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Foreigner()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("foreignerPerson")]
    [XmlElement(ElementName = "foreignerPerson")]
    public Person ForeignerPerson
    {
        get => _foreignerPerson;
        set => _foreignerPerson = value ?? throw new XmlSchemaValidationException(ForeignerPersonNullValidateExceptionMessage);
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
    /// <param name="foreignerPerson">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>Foreigner.</returns>
    public static Foreigner Create(Person foreignerPerson, SwissMunicipality municipality)
    {
        return new Foreigner
        {
            ForeignerPerson = foreignerPerson,
            Municipality = municipality
        };
    }
}
