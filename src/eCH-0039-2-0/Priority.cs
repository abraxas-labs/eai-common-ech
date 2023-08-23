﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0039_2_0;

[XmlType(TypeName = "priorityType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public enum Priority
{
    undefined,
    medium,
    high
}
