using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProjectOne
{
    [DataContract(Name = "PoUIResponseData", Namespace = "ProjectOne")]
    public class PoUIResponseData
    {
        [DataMember]
        public bool Modified { get; set; }
        [DataMember]
        public string SenderId { get; set; }
        [DataMember]
        public List<PoUIResponseDataElement> Elements { get; set; }

        public PoUIResponseData()
        {
            Elements = new List<PoUIResponseDataElement>();
        }
    }

    [DataContract(Name = "PoUIResponseDataElement", Namespace = "ProjectOne")]
    public class PoUIResponseDataElement
    {
        [DataMember]
        public string ComponentId { get; set; }
        [DataMember]
        public string HtmlContent { get; set; }

        public PoUIResponseDataElement()
        {

        }
    }
}