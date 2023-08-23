﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0039_3_0;

[XmlType(TypeName = "openToThePublicType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public enum OpenToThePublic
{
    undefined,
    @public,
    not_public
}
