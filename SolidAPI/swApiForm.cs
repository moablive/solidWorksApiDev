using System;
using System.Windows.Forms;

//SOLIDWORKS DLLs
using SolidWorks.Interop.sldworks;

//PROJETO
using SolidAPI.Sw;
using SolidAPI.SwExport;
using SolidAPI.SwFiles;

namespace SolidAPI
{
    public partial class swApiForm : Form
    {
        #region External & VARIABLES
        //SWAPI - CLASS
        SWAPI swapi = new SWAPI();

        //SwExportFileType - CLASS
        SwExportFileType swExportFileType = new SwExportFileType();

        //SwOpenFilesType - CLASS
        SwFilesType swFilesType = new SwFilesType();

        //SldWorks - Instancia
        SldWorks sldWorks = default(SldWorks);

        //CAMINHO ARQUIVO SLDPRT
        string fileNameSLDPRT;
        #endregion

        public swApiForm()
        {
            InitializeComponent();
        }

        #region BTN_SOLIDWORKS
        private void btnAbrirSW_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Abrindo Solidworks...";
            try
            {
                sldWorks = swapi.AbrirSolidWorks(chkVisivel.Checked, 31);
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFecharSw_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Fechando Solidworks...";
            try
            {
                swapi.FecharSolidWorks();
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BTN_Sldprt

        private void btnAbrir_Arquivo_Sldprt_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Abrindo SLDPRT...";

            try
            {
                fileNameSLDPRT = swFilesType.SelectSldprt();

                if (!string.IsNullOrEmpty(fileNameSLDPRT))
                {
                    swFilesType.OpenSldprt(fileNameSLDPRT, sldWorks);
                } 
                
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Arquivo_Sldprt_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "FECHAR SLDPRT...";

            try
            {
                swFilesType.CloseSldprt(fileNameSLDPRT, sldWorks);
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Exportando JPG...";
            try
            {
                //SET LOCAL
                string caminhoExportArquivo = swExportFileType.SetLocalExport();

                //GET SLDPRT ABERTO
                string getFile = swFilesType.GetActiveSldprt(sldWorks);

                //REPLACE SLDPRT => JPG
                string fileSldprtJpg = getFile.ToUpper().Replace(".SLDPRT", ".JPG");

                //Convert => jpg()
                swExportFileType.JPG(fileSldprtJpg, caminhoExportArquivo, sldWorks);

                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}


