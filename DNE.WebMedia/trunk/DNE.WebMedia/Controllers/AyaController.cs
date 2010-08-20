
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DNE.WebMedia.Model;
using MvcContrib.ActionResults;


namespace DNE.WebMedia.Controllers {
    public class AyaController : Controller {
        //
        // GET: /Aya/

        public ActionResult Index() {
            return View();
        }

        public ActionResult AyaDetail(int id) {
            return View(Aya.GetOne(id, true));
        }

        public ActionResult SuraAya(int sid, int aid, string type = "") {
            HQEntities db = new HQEntities();
            var a = db.Aya.Where(x => x.SuraId == sid && x.AyaId == aid);
            if (a.Count() > 0) {
                if (type == "xml") {
                    return new XmlResult(new AyaSimple(a.First()));

                } else if (type == "json") {
                    return new JsonResult() { Data = (new AyaSimple(a.First())), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                } else if (type == "") {
                    return View(a.First());

                }

            }
            return View();

        }

        public ActionResult SuraDetail(int id, string type = "", string langid = "fa") {
            HQEntities db = new HQEntities();
            var sura = db.Aya.Include("Translate").Where(x => x.SuraId == id);
            List<AyaSimple> ayas = new List<AyaSimple>();
            foreach (Aya a in sura) {
                ayas.Add(new AyaSimple(a, langid));
            }
            if (type == "xml") {
                return new XmlResult(ayas);

            } else if (type == "json") {
                return new JsonResult() { Data = ayas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return View(ayas);

        }

        public ActionResult Translate(int suraid, int ayaid, string langid = "fa") {
            HQEntities db = new HQEntities();
            var a = db.Aya.Where(x => x.AyaId == ayaid && x.SuraId == suraid);
            if (a.Count() > 0) {
                var ax = a.First();
                ax.Translate.Load();
                string t = ax.Translate.Where(z => z.LangId == langid).First().Text;
                return new JsonResult() { Data = t, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult TranslateAya(int ayaid, string langid = "fa") {
            HQEntities db = new HQEntities();
            var a = db.Aya.Where(x => x.Id == ayaid);
            if (a.Count() > 0) {
                var ax = a.First();
                ax.Translate.Load();
                string t = ax.Translate.Where(z => z.LangId == langid).First().Text;
                return new JsonResult() { Data = t, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        //GET /Page/{pageno}.{type}
        public ActionResult Page(int pageno, string type = "", string langid = "fa") {
            HQEntities db = new HQEntities();
            var ps = db.PageAyas.Include("Aya").Where(x => x.PageId == pageno);
            List<PageAyaSimple> psa = new List<PageAyaSimple>();
            foreach (PageAya item in ps) {
                psa.Add(item.ToSimple(langid));

            }
            if (type == "xml") {
                return new XmlResult(psa);

            } else if (type == "json") {
                return new JsonResult() { Data = psa, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return View(psa);
        }

        //GET /Page/{pageno}
        public ActionResult PagePartial(int pageno, string langid = "fa") {
            HQEntities db = new HQEntities();
            var ps = db.PageAyas.Include("Aya").Where(x => x.PageId == pageno);
            List<PageAyaSimple> psa = new List<PageAyaSimple>();
            foreach (PageAya item in ps) {
                psa.Add(item.ToSimple(langid));

            }
            return View(psa);
        }

        public ActionResult PageIndex() {
            HQEntities db = new HQEntities();
            var p = db.PageAyas.Select(x => new SuraIndex() {
                Sura = (db.Aya.Where(z => z.Id == z.AyaId).Take(1).FirstOrDefault().sura),
                SuraNo = x.SuraNo,
                Min = (db.PageAyas.Where(z => z.SuraNo == x.SuraNo).Min(z => z.PageId)),
                Max = (db.PageAyas.Where(z => z.SuraNo == x.SuraNo).Max(z => z.PageId))
            });
            return View(p.ToList());
        }

        public ActionResult SuraIndex() {
            HQEntities db = new HQEntities();
            var p = db.PageAyas.Select(x => new SuraIndex() {
                Sura = (db.Aya.Where(z => z.AyaId == x.AyaId).Take(1).FirstOrDefault().sura),
                SuraNo = x.SuraNo,
                Min = (db.PageAyas.Where(z => z.SuraNo == x.SuraNo).Min(z => z.PageId)),
                Max = (db.PageAyas.Where(z => z.SuraNo == x.SuraNo).Max(z => z.PageId))
            }).Distinct();
            return View(p.ToList());
        }
    }
}
