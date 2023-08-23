// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("otherRegisterType")]
[XmlRoot(ElementName = "otherRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class OtherRegister : Register
{
    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <returns>OtherRegister.</returns>
    public static OtherRegister Create(string registerIdentification, string registerName)
    {
        return new OtherRegister
        {
            RegisterIdentification = registerIdentification,
            RegisterName = registerName
        };
    }
}
