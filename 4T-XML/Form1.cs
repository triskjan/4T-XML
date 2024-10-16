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
            //vytvoreni root (hlavniho) elementu. XML vzdy musi obsahovat jeden element
            XmlElement root = doc.CreateElement("Osoby");
            //pripojeni elementu do dokumentu
            doc.AppendChild(root);

            //vytvoreni noveho elementu pro jednu konkretni osobu
            XmlElement osoba = doc.CreateElement("Osoba");
            //nastaveni atributu pro element
            osoba.SetAttribute("Jmeno", "Karel");
            osoba.SetAttribute("Prijmeni", "Dvořáček");
            //pridani elementru Osoba dovnitr elementu Osoby
            root.AppendChild(osoba);
            //ulozeni do dokumentu
            doc.Save("osoby.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //vytvoreni nastroje pro praci s dokumentem
            XmlDocument doc = new XmlDocument();
            //nacetni dat ze souboru
            doc.Load("osoby.xml");
            //vyber vsechny elementy s nazvem Osoba a vloz je do seznamu osoby
            XmlNodeList osoby = doc.SelectNodes("Osoby/Osoba");
            //projdi vsechny osoby
            foreach (XmlNode uzel in osoby)
            {
                //vyhledej atribut s nazvem Jmeno a nacti jeho hodnotu
                textBox1.Text = uzel.Attributes["Jmeno"].Value;
                textBox2.Text = uzel.Attributes["Prijmeni"].Value;
                
                //u cyklu dava smysl pouzit nejakou kolekci
                //listBox.Items.Add(new Osoba(uzel.Attributes["Jmeno"].Value, uzel.Attributes["Prijmeni"].Value));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //vysledek ulozen v souboru osoby2.xml
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Osoby");
            doc.AppendChild(root);

            //vytvoreni prvniho uzlu
            XmlElement osoba = doc.CreateElement("Osoba");
            XmlElement jmeno = doc.CreateElement("Jmeno");
            //do elementu lze vkladat text
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
                //vybirame nod uvnitr elementu Osoba
                XmlNode jmeno = osoba.SelectSingleNode("Jmeno");
                textBox3.Text = jmeno.InnerText;
                XmlNode prijmeni = osoba.SelectSingleNode("Prijmeni");
                textBox4.Text = prijmeni.InnerText;
                textBox5.Text = osoba.Attributes["TypZakaznika"].Value;
            }
        }
    }
}
