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
[JsonObject("sendingApplication")]
[XmlRoot(ElementName = "sendingApplication", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/4")]
public class SendingApplication
{
    private const string ManufacturerNullValidateExceptionMessage =
        "Manufacturer is not valid! Manufacturer is required";

    private const string ManufacturerValidateExceptionMessage =
        "Manufacturer is not valid! Manufacturer  has max Length of 30";

    private const string ProductNullValidateExceptionMessage = "Product is not valid! Product is required";
    private const string ProductValidateExceptionMessage = "Product is not valid! Product  has max Length of 30";

    private const string ProductVersionNullValidateExceptionMessage =
        "ProductVersion is not valid! ProductVersion is required";

    private const string ProductVersionValidateExceptionMessage =
        "ProductVersion is not valid! ProductVersion  has max Length of 10";

    private string _manufacturer;
    private string _product;
    private string _productVersion;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public SendingApplication()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/4");
    }

    [JsonProperty("manufacturer")]
    [XmlElement(ElementName = "manufacturer")]
    public string Manufacturer
    {
        get => _manufacturer;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ManufacturerNullValidateExceptionMessage);
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(ManufacturerValidateExceptionMessage);
            }

            _manufacturer = value;
        }
    }

    [JsonProperty("product")]
    [XmlElement(ElementName = "product")]
    public string Product
    {
        get => _product;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ProductNullValidateExceptionMessage);
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 30)
            {
                throw new XmlSchemaValidationException(ProductValidateExceptionMessage);
            }

            _product = value;
        }
    }

    [JsonProperty("productVersion")]
    [XmlElement(ElementName = "productVersion")]
    public string ProductVersion
    {
        get => _productVersion;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ProductVersionNullValidateExceptionMessage);
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 10)
            {
                throw new XmlSchemaValidationException(ProductVersionValidateExceptionMessage);
            }

            _productVersion = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="product">Field is reqired.</param>
    /// <param name="manufacturer">Field is reqired.</param>
    /// <param name="productVersion">Field is reqired.</param>
    /// <returns>PartialDelivery.</returns>
    public static SendingApplication Create(string manufacturer, string product, string productVersion)
    {
        return new SendingApplication
        {
            Manufacturer = manufacturer,
            Product = product,
            ProductVersion = productVersion
        };
    }
}
