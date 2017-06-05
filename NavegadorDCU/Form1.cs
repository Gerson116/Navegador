using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorDCU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbxHistorial.Hide();

        }

        List<string> busquedas = new List<string>();
        List<string> favoritos = new List<string>();
        List<string> Historial = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bing.com/");
            webBrowser1.DocumentCompleted += WebBrowser_DocumentCompleted;
            
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Navigate("https://www.bing.com/");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null) {

                if (web.CanGoBack) {
                    web.GoBack();
                }
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null) {

                if (web.CanGoForward) {
                    web.GoForward();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Refresh();
            }
        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFV_Click(object sender, EventArgs e)
        {
            favoritos.Add(webBrowser1.Url.ToString());
            actualizarFavoritos();
        }

        private void actualizarFavoritos() {
            cbxFavorito.Items.Clear();

            foreach (string addFavo in favoritos) {
                cbxFavorito.Items.Add(addFavo);

            }
            

        }

        private void cbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {

                WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {
                    web.Navigate(cbxSearch.Text);

                    busquedas.Add(web.Url.ToString());
                    actualizarBarraBusqueda();

                    if (web != null)
                    {
                        web.Navigate(cbxSearch.Text);
                        Historial.Add(web.Url.ToString());
                        actualizarNavegador();
                    }
                }
            }
   
        }

        private void actualizarBarraBusqueda()
        {
            cbxSearch.Items.Clear();

            foreach (string busquedasRealizadas in busquedas) {
                cbxSearch.Items.Add(busquedasRealizadas);
            }
        }

        private void actualizarNavegador() {
            cbxHistorial.Items.Clear();
            foreach (string historialNavegador in Historial) {
                cbxHistorial.Items.Add(historialNavegador);
            }

        }

        private void cbxFavorito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        WebBrowser webTab = null;

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Nueva ventana";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://www.bing.com/");
            cbxSearch.Text = "https://www.bing.com/";
            webTab.DocumentCompleted += webTab_DocumentCompleted;
        }

        private void webTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webTab.DocumentTitle;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            cbxHistorial.Show();
            
             
        }
    }
}
