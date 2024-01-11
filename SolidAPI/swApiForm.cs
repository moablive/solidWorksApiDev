using System;
using System.Windows.Forms;

//SOLIDWORKS DLLs
using SolidWorks.Interop.sldworks;

//PROJETO
using SolidAPI.Sw;
using SolidAPI.SwFiles;

namespace SolidAPI
{
    public partial class swApiForm : Form
    {
        //SWAPI - CLASS
        SWAPI swapi = new SWAPI();

        //SldWorks - Instancia
        SldWorks sldWorks = default(SldWorks);

        //SwOpenFilesType - CLASS
        SwFilesType swOpenFilesType = new SwFilesType();

        public swApiForm()
        {
            InitializeComponent();
        }

        private void btnAbrirSW_Click(object sender, EventArgs e)
        {
            try
            {
                sldWorks = swapi.AbrirSolidWorks(chkVisivel.Checked, 31);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFecharSw_Click(object sender, EventArgs e)
        {
            try
            {
                swapi.FecharSolidWorks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAbrir_Arquivo_Sldprt_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNameSLDPRT = swOpenFilesType.selectFileSldprt();

                if (!string.IsNullOrEmpty(fileNameSLDPRT))
                {
                    swOpenFilesType.openSldprt(fileNameSLDPRT, sldWorks);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


