using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;

namespace ArchiveOrgDownloader.XmlModels
{
    [XmlRoot(ElementName = "file")]
    public class File
    {
        [XmlElement(ElementName = "format")]
        public string Format { get; set; }
        [XmlElement(ElementName = "md5")]
        public string Md5 { get; set; }
        [XmlElement(ElementName = "mtime")]
        public string Mtime { get; set; }
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "crc32")]
        public string Crc32 { get; set; }
        [XmlElement(ElementName = "sha1")]
        public string Sha1 { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "track")]
        public string Track { get; set; }
        [XmlElement(ElementName = "creator")]
        public string Creator { get; set; }
        [XmlElement(ElementName = "album")]
        public string Album { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "length")]
        public string Length { get; set; }
        [XmlElement(ElementName = "height")]
        public string Height { get; set; }
        [XmlElement(ElementName = "width")]
        public string Width { get; set; }
        [XmlElement(ElementName = "original")]
        public string Original { get; set; }
        [XmlElement(ElementName = "btih")]
        public string Btih { get; set; }
    }

    [XmlRoot(ElementName = "files")]
    public class Files
    {
        [XmlElement(ElementName = "file")]
        public List<File> File { get; set; }

        
    }

}
