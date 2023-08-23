// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Es gibt Wahlen bei welchen auf einer Liste Kandidaten für unterschiedliche Ämter
///     aufgeführt sind (Bsp. Genf). In solchen Fällen wird diese Information sowohl im
///     „Freitext für Wahlliste“ (Siehe Kapitel 3.2.5.6) wie auch separat in diesem
///     Attribut geführt.
/// </summary>
[Serializable]
[JsonObject("roleInformation")]
[XmlRoot(ElementName = "roleInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class RoleInformation
{
    private const string RoleNullValidateExceptionMessage = "RoleInfo is not valid! RoleInfo is required";

    private const string RoleInfoOutOfRangeValidateExceptionMessage =
        "RoleInfo is not valid! RoleInfo needs adt least one item";

    private List<RoleInfo> _roleInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public RoleInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("roleInfo")]
    [XmlElement(ElementName = "roleInfo")]
    public List<RoleInfo> RoleInfo
    {
        get => _roleInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(RoleNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(RoleInfoOutOfRangeValidateExceptionMessage);
            }

            _roleInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="roleInfo">Field is required.</param>
    /// <returns>RoleInformation.</returns>
    public static RoleInformation Create(List<RoleInfo> roleInfo)
    {
        return new RoleInformation
        {
            RoleInfo = roleInfo
        };
    }
}
