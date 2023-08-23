// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("person")]
[XmlRoot(ElementName = "person", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class Nationality
{
    private const string NationalityChoiceNullValidateExceptionMessage =
        "NationalityChoice is not valid! NationalityChoice is required";

    private const string NationalityChoiceOutOfRangeValidateExceptionMessage =
        "NationalityChoice is not valid! NationalityChoice is a false Type";

    [JsonIgnore][XmlIgnore] public NationalityChoiceIdentifier ElementTypeName;
    private object _nationalityChoice;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Nationality()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [XmlElement("swiss", typeof(SwissDomestic))]
    [XmlElement("swissAbroad", typeof(SwissAbroad))]
    [XmlElement("foreigner", typeof(Foreigner))]
    [XmlChoiceIdentifier("ElementTypeName")]
    public object NationalityChoice
    {
        get => _nationalityChoice;
        set => _nationalityChoice = NationalityChoiceIsValid(value);
    }

    private object NationalityChoiceIsValid(object value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(NationalityChoiceNullValidateExceptionMessage);
        }

        if (value is SwissDomestic)
        {
            ElementTypeName = NationalityChoiceIdentifier.swiss;
        }
        else if (value is SwissAbroad)
        {
            ElementTypeName = NationalityChoiceIdentifier.swissAbroad;
        }
        else if (value is Foreigner)
        {
            ElementTypeName = NationalityChoiceIdentifier.foreigner;
        }
        else
        {
            throw new XmlSchemaValidationException(NationalityChoiceOutOfRangeValidateExceptionMessage);
        }

        return value;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swiss">Field is required.</param>
    /// <returns>Nationality.</returns>
    public static Nationality Create(SwissDomestic swiss)
    {
        return new Nationality
        {
            NationalityChoice = swiss
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissAbroad">Field is required.</param>
    /// <returns>Nationality.</returns>
    public static Nationality Create(SwissAbroad swissAbroad)
    {
        return new Nationality
        {
            NationalityChoice = swissAbroad
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="foreigner">Field is required.</param>
    /// <returns>Nationality.</returns>
    public static Nationality Create(Foreigner foreigner)
    {
        return new Nationality
        {
            NationalityChoice = foreigner
        };
    }
}
public enum NationalityChoiceIdentifier
{
    swiss,
    swissAbroad,
    foreigner
}
