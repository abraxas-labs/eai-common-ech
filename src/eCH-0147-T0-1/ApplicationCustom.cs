// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("applicationCustom")]
[XmlType("applicationCustomType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class ApplicationCustom
{
}
