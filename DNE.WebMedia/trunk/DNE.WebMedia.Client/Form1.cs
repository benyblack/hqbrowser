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

namespace DNE.WebMedia.Client
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//var x = (new XmlSerializer()).Deserialize("d:\1.xml")
			//XmlDocument xdoc = new XmlDocument();
			//xdoc.Load(@"d:\1.xml");
			
			//XDocument xdoc = XDocument.Load(@"d:\2.xml");
			//var x = from s in xdoc.Descendants("aya")
			//        select  s.Parent.Attribute("index").Value + "|" + s.Parent.Attribute("name").Value
			//        +  "|" + s.Attribute("index").Value + "|" + s.Attribute("text").Value;

            //string[] s = File.ReadAllLines(@"d:\turkish-ozturk.txt");
            string[] s = File.ReadAllLines(@"d:\quran-simple-clean.txt");

			string salam = "";
			HQEntities db = new HQEntities();
		   // foreach (string ix in s)
			for (int i = 1; i < s.Length+1; i++)
			{
				//salam += s[i].ToString() + "\r\n";
				//string[] z = Regex.Split(s[i],@"\|");
				//Ayeh a = new Ayeh() { SoorehId=int.Parse(z[0]),Sooreh=z[1],
				//    AyehId = int.Parse(z[2]),Ayeh1 = z[3],Persian="",English="" };
				////db.AddToAyehs(a);
                //db.InsertTranslate(i, "de", "German", "Amir Zaidan", s[i - 1]);
                db.UpdateAyehText(i, s[i - 1]);
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


	}
}
