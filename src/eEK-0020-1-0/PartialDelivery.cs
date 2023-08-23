// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eEK_0020_1_0;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("partialDelivery")]
[XmlRoot(ElementName = "partialDelivery", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class PartialDelivery
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UniqueIdDeliveryNullValidateExceptionMessage = "UniqueIdDelivery is not valid! UniqueIdDelivery is required";
    private const string UniqueIdDeliveryValidateExceptionMessage = "UniqueIdDelivery is not valid! UniqueIdDelivery  has max Length of 50";
    private const string TotalNumberOfPackagesValidateExceptionMessage = "TotalNumberOfPackages is not valid! TotalNumberOfPackages has to be between 1 and 9999";
    private const string NumberOfActualPackageValidateExceptionMessage = "NumberOfActualPackage is not valid! NumberOfActualPackage has to be between 1 and 9999";

    private string _uniqueIdDelivery;
    private short _totalNumberOfPackages;
    private short _numberOfActualPackage;

    public PartialDelivery()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="uniqueIdDelivery">Field is reqired.</param>
    /// <param name="totalNumberOfPackages">Field is reqired.</param>
    /// <param name="numberOfActualPackage">Field is reqired.</param>
    /// <returns>PartialDelivery.</returns>
    public static PartialDelivery Create(string uniqueIdDelivery, short totalNumberOfPackages, short numberOfActualPackage)
    {
        return new PartialDelivery()
        {
            UniqueIdDelivery = uniqueIdDelivery,
            NumberOfActualPackage = numberOfActualPackage,
            TotalNumberOfPackages = totalNumberOfPackages
        };
    }

    [JsonProperty("uniqueIdDelivery")]
    [XmlElement(ElementName = "uniqueIdDelivery")]
    public string UniqueIdDelivery
    {
        get { return _uniqueIdDelivery; }

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
        get { return _totalNumberOfPackages; }

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
        get { return _numberOfActualPackage; }

        set
        {
            if (value < 1 || value > 9999)
            {
                throw new XmlSchemaValidationException(NumberOfActualPackageValidateExceptionMessage);
            }
            _numberOfActualPackage = value;
        }
    }
}
