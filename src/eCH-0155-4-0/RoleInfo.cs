// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     "Kandidiert als" Freitext von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("roleInfo")]
[XmlRoot(ElementName = "roleInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class RoleInfo : FieldValueChecker<RoleInfo>
{
    private const string RoleNullValidateExceptionMessage = "Role is not valid! Role is required";

    private const string RoleOutOfRangeValidateExceptionMessage =
        "Role is not valid! Role has minimal leght of 1 and maximal length of 100";

    private string _role;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public RoleInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language { get; set; }

    [JsonProperty("role")]
    [XmlElement(ElementName = "role", Order = 2)]
    public string Role
    {
        get => _role;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(RoleNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(RoleOutOfRangeValidateExceptionMessage);
            }

            _role = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="role">Field is required.</param>
    /// <returns>RoleInfo.</returns>
    public static RoleInfo Create(string language, string role)
    {
        return new RoleInfo
        {
            Language = language,
            Role = role
        };
    }
}
