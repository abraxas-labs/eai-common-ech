// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Berufsbezeichung wie sie für die Wahllisten verwendet wird. Information wie sie vom
///     Kandidaten gewünscht wird, muss nicht mit der Berufsbezeichnung im Einwohnerregister übereinstimmen.
/// </summary>
[Serializable]
[JsonObject("occupationalTitleInformation")]
[XmlRoot(ElementName = "occupationalTitleInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class OccupationalTitleInformation
{
    private const string OccupationalTitleNullValidateExceptionMessage =
        "OccupationalTitleInfo is not valid! OccupationalTitleInfo is required";

    private const string OccupationalTitleInfoOutOfRangeValidateExceptionMessage =
        "OccupationalTitleInfo is not valid! OccupationalTitleInfo needs adt least one item";

    private List<OccupationalTitleInfo> _occupationalTitleInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public OccupationalTitleInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("occupationalTitleInfo")]
    [XmlElement(ElementName = "occupationalTitleInfo")]
    public List<OccupationalTitleInfo> OccupationalTitleInfo
    {
        get => _occupationalTitleInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(OccupationalTitleNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(OccupationalTitleInfoOutOfRangeValidateExceptionMessage);
            }

            _occupationalTitleInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="occupationalTitleInfo">Field is required.</param>
    /// <returns>OccupationalTitleInformation.</returns>
    public static OccupationalTitleInformation Create(List<OccupationalTitleInfo> occupationalTitleInfo)
    {
        return new OccupationalTitleInformation
        {
            OccupationalTitleInfo = occupationalTitleInfo
        };
    }
}
