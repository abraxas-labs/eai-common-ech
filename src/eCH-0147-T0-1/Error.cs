// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("error")]
[XmlType("errorType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Error : FieldValueChecker<Error>
{
    private ErrorKind? _errorKind;

    [FieldRequired]
    [JsonProperty("errorKind")]
    [XmlElement("errorKind")]
    public ErrorKind? ErrorKind
    {
        get => _errorKind;
        set => CheckAndSetValue(ref _errorKind, value);
    }

    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }
}
