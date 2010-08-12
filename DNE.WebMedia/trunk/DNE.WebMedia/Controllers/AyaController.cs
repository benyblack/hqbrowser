
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

        public ActionResult SuraDetail(int id) {
            HQEntities db = new HQEntities();
            return View(db.Aya.Include("Translate").Where(x => x.SuraId == id));

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
            return new JsonResult() {Data = null,  JsonRequestBehavior= JsonRequestBehavior.AllowGet};

        }

        //GET /Page/{pageno}
        public ActionResult Page(int pageno) {
            HQEntities db = new HQEntities();
            var ps =   db.PageAyas.Include("Aya").Where(x => x.PageId == pageno);
            return View(ps);
        }

    }
}
