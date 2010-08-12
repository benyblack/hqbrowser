using System;
using System.ComponentModel;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DNE.WebMedia.Model {

    public partial class PageAya  {

        public PageAyaSimple ToSimple(string langid="fa") {
            PageAyaSimple pas = new PageAyaSimple();
            pas.AyaId = this.AyaId;
            pas.LangId = langid;
            pas.Translate = this.Aya.Translate.Where(x => x.AyaId == AyaId && x.LangId == langid).First().Text;
            pas.TextFull = this.Aya.TextFull;
            return pas;
        }
        
    }

    public class PageAyaSimple{


        public int AyaId { get; set; }
        public string TextFull { get; set; }
        public string Sura { get; set; }
        public string Translate { get; set; }
        public string LangId { get; set; }
    }
}
