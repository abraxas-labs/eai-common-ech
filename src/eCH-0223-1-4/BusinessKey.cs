// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0223_1_4;

[XmlType(TypeName = "businessKeyType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public enum BusinessKey
{
    [XmlEnum("-")]
    keine_Dokumente,
    BRB,
    IntV,
    zk_BRB,
    Verfügung,
    allg_K,
    Rückfragen,
    Adacta_AG,
    Adacta_BRB,
    Info_an_EWA,
    Inkasso
}
