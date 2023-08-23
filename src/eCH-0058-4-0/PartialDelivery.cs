// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Meldungsrahmen (eCH-0058)
///     Eine Gesamtlieferung ist ein fachlich vollständiges, eventuell umfangreiches
///     Informationspaket, das in einer oder mehreren Meldungen weitergegeben wird.
/// </summary>
[Serializable]
[JsonObject("partialDelivery")]
[XmlRoot(ElementName = "partialDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/4")]
public class PartialDelivery
{
    private const string UniqueIdDeliveryNullValidateExceptionMessage =
        "UniqueIdDelivery is not valid! UniqueIdDelivery is required";

    private const string UniqueIdDeliveryValidateExceptionMessage =
        "UniqueIdDelivery is not valid! UniqueIdDelivery  has max Length of 50";

    private const string TotalNumberOfPackagesValidateExceptionMessage =
        "TotalNumberOfPackages is not valid! TotalNumberOfPackages has to be between 1 and 9999";

    private const string NumberOfActualPackageValidateExceptionMessage =
        "NumberOfActualPackage is not valid! NumberOfActualPackage has to be between 1 and 9999";

    private short _numberOfActualPackage;
    private short _totalNumberOfPackages;

    private string _uniqueIdDelivery;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PartialDelivery()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/4");
    }

    [JsonProperty("uniqueIdDelivery")]
    [XmlElement(ElementName = "uniqueIdDelivery")]
    public string UniqueIdDelivery
    {
        get => _uniqueIdDelivery;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(UniqueIdDeliveryNullValidateExceptionMessage);
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(UniqueIdDeliveryValidateExceptionMessage);
            }

            _uniqueIdDelivery = value;
        }
    }

    [JsonProperty("totalNumberOfPackages")]
    [XmlElement(ElementName = "totalNumberOfPackages")]
    public short TotalNumberOfPackages
    {
        get => _totalNumberOfPackages;
        set
        {
            if (value < 1 || value > 9999)
            {
                throw new XmlSchemaValidationException(TotalNumberOfPackagesValidateExceptionMessage);
            }

            _totalNumberOfPackages = value;
        }
    }

    [JsonProperty("numberOfActualPackage")]
    [XmlElement(ElementName = "numberOfActualPackage")]
    public short NumberOfActualPackage
    {
        get => _numberOfActualPackage;
        set
        {
            if (value < 1 || value > 9999)
            {
                throw new XmlSchemaValidationException(NumberOfActualPackageValidateExceptionMessage);
            }

            _numberOfActualPackage = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="uniqueIdDelivery">Field is reqired.</param>
    /// <param name="totalNumberOfPackages">Field is reqired.</param>
    /// <param name="numberOfActualPackage">Field is reqired.</param>
    /// <returns>PartialDelivery.</returns>
    public static PartialDelivery Create(string uniqueIdDelivery, short totalNumberOfPackages,
        short numberOfActualPackage)
    {
        return new PartialDelivery
        {
            UniqueIdDelivery = uniqueIdDelivery,
            NumberOfActualPackage = numberOfActualPackage,
            TotalNumberOfPackages = totalNumberOfPackages
        };
    }
}
