using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
        }

        public static void UpdateAppSettings(string chave, string valor)

        {

            // Open App.Config of executable

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);



            // Add an Application Setting.

            config.AppSettings.Settings.Remove(chave);

            config.AppSettings.Settings.Add(chave, valor);



            // Save the configuration file.

            config.Save(ConfigurationSaveMode.Modified);



            // Force a reload of a changed section.

            ConfigurationManager.RefreshSection("appSettings");

        }

         private void Configuracao_Load(object sender, EventArgs e)
        {
            SMS.Core.SMS sms = new SMS.Core.SMS();
            foreach (string porta in sms.GetPorts())
            {
                cbCOM.Items.Add(porta);
            }

           

           }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                if (cbCOM.Text != "")
                {
                    using (StreamWriter writer = new StreamWriter("porta.config", true))
                    {
                        writer.WriteLine(cbCOM.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma COM!");
                }
               

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}
