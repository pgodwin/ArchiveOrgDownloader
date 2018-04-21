using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ArchiveOrgDownloader.XmlModels
{
    [XmlRoot(ElementName = "metadata")]
    public class Metadata
    {
        [XmlElement(ElementName = "identifier")]
        public string Identifier { get; set; }
        [XmlElement(ElementName = "mediatype")]
        public string Mediatype { get; set; }
        [XmlElement(ElementName = "collection")]
        public List<string> Collection { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "subject")]
        public string Subject { get; set; }
        [XmlElement(ElementName = "year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "publicdate")]
        public string Publicdate { get; set; }
        [XmlElement(ElementName = "creator")]
        public string Creator { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "coverage")]
        public string Coverage { get; set; }
        [XmlElement(ElementName = "md5s")]
        public string Md5s { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "uploader")]
        public string Uploader { get; set; }
        [XmlElement(ElementName = "addeddate")]
        public string Addeddate { get; set; }
        [XmlElement(ElementName = "adder")]
        public string Adder { get; set; }
        [XmlElement(ElementName = "pick")]
        public string Pick { get; set; }
        [XmlElement(ElementName = "updatedate")]
        public string Updatedate { get; set; }
        [XmlElement(ElementName = "updater")]
        public string Updater { get; set; }
        [XmlElement(ElementName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "venue")]
        public string Venue { get; set; }
        [XmlElement(ElementName = "discs")]
        public string Discs { get; set; }
        [XmlElement(ElementName = "has_mp3")]
        public string Has_mp3 { get; set; }
        [XmlElement(ElementName = "shndiscs")]
        public string Shndiscs { get; set; }
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "public")]
        public string Public { get; set; }
        [XmlElement(ElementName = "publisher")]
        public string Publisher { get; set; }
        [XmlElement(ElementName = "numeric_id")]
        public string Numeric_id { get; set; }
        [XmlElement(ElementName = "md5contents")]
        public string Md5contents { get; set; }
        [XmlElement(ElementName = "curation")]
        public string Curation { get; set; }
    }
}
