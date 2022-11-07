namespace filmoteka1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //dodawanie do listview
        private void DodawanieDanych(string tytul, string rezyser, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] { tytul, rezyser, data, aktor});
            listView1.Items.Add(item);
        }

        private void DodawanieDanych(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }
        //koniec dodawania do listview
        //usuwanie zaznaczonych wierszy z listview
        private void UsuwanieDanych()
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }
        //przygotowywanie wierszy do zapisu do pliku
        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            foreach(ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                    linie[i] += item.SubItems[k].Text + "*";
                i++;
            }
            return linie;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
        }
        private void OdczytzPliku()
        {
            if (!File.Exists("filmy.txt"))
                return;

            string[] linie = File.ReadAllLines("filmy.txt");
            foreach(string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}