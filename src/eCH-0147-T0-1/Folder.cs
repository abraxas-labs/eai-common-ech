// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("folder")]
[XmlType("folderType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Folder : FieldValueChecker<Folder>
{
    private FolderTitle[] _folderTitles;

    [FieldRequired]
    [JsonProperty("folderTitles")]
    [XmlArray("folderTitles")]
    [XmlArrayItem("folderTitle", IsNullable = false)]
    public FolderTitle[] FolderTitles
    {
        get => _folderTitles;
        set => CheckAndSetValue(ref _folderTitles, value);
    }

    [JsonProperty("documents")]
    [XmlArray("documents")]
    [XmlArrayItem("document", IsNullable = false)]
    public Document[] Documents { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom[] ApplicationCustoms { get; set; }
}
