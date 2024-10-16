using System;
using System.Windows.Forms;
using System.Xml;

namespace _4T_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            //vytvoření root prvku / elementu
            XmlElement root = doc.CreateElement("Osoby");
            doc.AppendChild(root);

            //vytváření uzly/ Nods
            XmlElement osoba = doc.CreateElement("Osoba");
            osoba.SetAttribute("Jmeno", "Karel");
            osoba.SetAttribute("Prijmeni", "Dvořáček");
            root.AppendChild(osoba);
            doc.Save("osoby.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("osoby.xml");
            XmlNodeList osoby = doc.SelectNodes("Osoby/Osoba");
            foreach (XmlNode uzel in osoby)
            {
                textBox1.Text = uzel.Attributes["Jmeno"].Value;
                textBox2.Text = uzel.Attributes["Prijmeni"].Value;
                //listBox.Items.Add(new Osoba(uzel.Attributes["Jmeno"].Value, uzel.Attributes["Prijmeni"].Value));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Osoby");
            doc.AppendChild(root);

            //vytvoreni prvniho uzlu
            XmlElement osoba = doc.CreateElement("Osoba");
            XmlElement jmeno = doc.CreateElement("Jmeno");
            jmeno.InnerText = "Karel";
            XmlElement prijmeni = doc.CreateElement("Prijmeni");
            prijmeni.InnerText = "Dvořáček";
            osoba.AppendChild(jmeno);
            osoba.AppendChild(prijmeni);
            osoba.SetAttribute("TypZakaznika", "Běžný zákazník");
            root.AppendChild(osoba);
            doc.Save("osoby2.xml");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("osoby2.xml");
            XmlNodeList osoby = doc.SelectNodes("Osoby/Osoba");
            foreach (XmlNode osoba in osoby)
            {
                XmlNode jmeno = osoba.SelectSingleNode("Jmeno");
                textBox3.Text = jmeno.InnerText;
                XmlNode prijmeni = osoba.SelectSingleNode("Prijmeni");
                textBox4.Text = prijmeni.InnerText;
                textBox5.Text = osoba.Attributes["TypZakaznika"].Value;
            }
        }
    }
}
