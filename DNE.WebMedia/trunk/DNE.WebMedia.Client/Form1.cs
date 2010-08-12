using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace DNE.WebMedia.Client {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			//var x = (new XmlSerializer()).Deserialize("d:\1.xml")
			//XmlDocument xdoc = new XmlDocument();
			//xdoc.Load(@"d:\1.xml");

			//XDocument xdoc = XDocument.Load(@"d:\2.xml");
			//var x = from s in xdoc.Descendants("aya")
			//        select  s.Parent.Attribute("index").Value + "|" + s.Parent.Attribute("name").Value
			//        +  "|" + s.Attribute("index").Value + "|" + s.Attribute("text").Value;

			//string[] s = File.ReadAllLines(@"d:\turkish-ozturk.txt");
			string[] s = File.ReadAllLines(@"d:\yusufali.txt");

			string salam = "";
			HQEntities db = new HQEntities();
			// foreach (string ix in s)
			for (int i = 1; i < s.Length + 1; i++) {
				//salam += s[i].ToString() + "\r\n";
				//string[] z = Regex.Split(s[i],@"\|");
				//Ayeh a = new Ayeh() { SoorehId=int.Parse(z[0]),Sooreh=z[1],
				//    AyehId = int.Parse(z[2]),Ayeh1 = z[3],Persian="",English="" };
				////db.AddToAyehs(a);
				db.InsertTranslate(i, "en", "English", "Abdullah Yusufali", s[i - 1]);
				//db.UpdateAyehText(i, s[i - 1]);
				lblCount.Text = i.ToString();
				lblCount.Refresh();
				Application.DoEvents();
				//db.UpdatePersianAya(i,s[i-1]);

			}
			//try
			//{
			//    db.SaveChanges();

			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(ex.ToString());
			//}

		}

		private void button2_Click(object sender, EventArgs e) {


		}

		private void button3_Click(object sender, EventArgs e) {
            HQEntities db = new HQEntities();
			string s = File.ReadAllText(@"d:\quran.txt");
			List<string> psa = new List<string>(); //page,sura,aya
			SortedList<int, string> lstSura = new SortedList<int, string>();

			//bool loop = true;
			//int pos = 0;
			//while (loop) {

			//s = s.Substring(0, 30000);

			string splitpat = @"صفحة \(\d{1,3}\)";
			string[] sss = Regex.Split(s, splitpat);
			string pat = @"(.*?)صفحة \(\d\)";
			//MatchCollection mc = Regex.Matches(s, pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			//int xx = mc.Cast<Match>().Count();
			string lastsura = "";
			int lastsuraid = 1;
			for (int i = 1; i < sss.Length; i++) { //skip 0
				string page = sss[i];
				MatchCollection mcx = Regex.Matches(page, @"(?<aya>\{(?<suraname>.*?)/(?<ayanum>\d{1,3})\})|(?<sura>سورة (?<surtitle>.*?) \((?<suranum>\d{1,3})\))");
				string stats = "";
				for (int j = 0; j < mcx.Count; j++) {
					Match m = mcx[j];
					if (m.Groups["sura"].Captures.Count > 0) {
						lastsura = m.Groups["surtitle"].Value;
						if (!lstSura.Values.Contains(lastsura)) {
							int maxkey = 0;
							if (lstSura.Count > 0)
								maxkey = lstSura.Max(l => l.Key);

							lstSura.Add(maxkey + 1, lastsura);
							lastsuraid = maxkey + 1;
						}
						stats += string.Format("{0},0\r\n", lastsuraid.ToString());

					} else {
						stats += string.Format("{0},{1}\r\n", lastsuraid.ToString(), m.Groups["ayanum"].Value);
						string temppsa = string.Format("{0},{1},{2}", i.ToString(), lastsuraid.ToString(), m.Groups["ayanum"].Value);
						if (psa.Contains(temppsa))
							temppsa = string.Format("{0},{1},{2}", i.ToString(), lastsuraid.ToString(), (int.Parse(m.Groups["ayanum"].Value) + 1).ToString());
						psa.Add(temppsa);
                        string[] fff = Regex.Split(temppsa, ",");
                       db.InsertPageAya(i,lastsuraid,int.Parse(fff[2]));
					}


				}
				writetext(stats, i.ToString() + ".txt");
				string[] xa = Regex.Split(stats, "\r\n");
				List<string> xaa = new List<string>();
				for (int h = 0; h < xa.Length; h++) {
					if (xa[h].Trim()!="")
					 xaa.Add( i.ToString() + "," + xa[h]);
					
				}
				File.AppendAllLines(@"D:\x.txt", xaa.ToArray());
				lblCount.Text = i.ToString();
				lblCount.Refresh();
				Application.DoEvents();


			}
			//}
			string[] psaar = psa.ToArray();
			File.WriteAllLines(@"D:\Documents\Visual Studio 2010\Projects\DNE.WebMedia\DNE.WebMedia\trunk\DNE.WebMedia.Client\bin\Debug\list.txt", psaar);
			string xvc = "";
			foreach (KeyValuePair<int, string> item in lstSura) {
				xvc += string.Format("{0},{1}\r\n", item.Key, item.Value);


			}
			File.WriteAllText(@"D:\Documents\Visual Studio 2010\Projects\DNE.WebMedia\DNE.WebMedia\trunk\DNE.WebMedia.Client\bin\Debug\fehrest.txt", xvc);

		}

		void writetext(string s, string path) {
			File.WriteAllText(Path.Combine(@"D:\Documents\Visual Studio 2010\Projects\DNE.WebMedia\DNE.WebMedia\trunk\DNE.WebMedia.Client\bin\Debug\Pages", path), s);

		}

	}
}
