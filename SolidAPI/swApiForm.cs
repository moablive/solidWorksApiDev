using System;
using System.Windows.Forms;

//SOLIDWORKS DLLs
using SolidWorks.Interop.sldworks;

//PROJETO
using SolidAPI.Sw;
using SolidAPI.SwFiles;
using SolidAPI.SwExport;


using System.IO;

namespace SolidAPI
{
    public partial class swApiForm : Form
    {
        #region External & VARIABLES

        //SWAPI - CLASS
        SWAPI swapi = new SWAPI();

        //SwFiles - CLASS
        SwFilesType swFilesType = new SwFilesType();

        //SwExportFileType - CLASS
        SwExportFileType swExportFileType = new SwExportFileType();

        //SldWorks - Instance
        SldWorks sldWorks = default(SldWorks);

        //File - Var  
        string _file;
        string _fileType;
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
                sldWorks = swapi.OpenSolidWorks(chkVisivel.Checked, 31);
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
                swapi.CloseSolidWorks();
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BTN_ARQUIVOS
        private void btnAbrir_Arquivo_Click(object sender, EventArgs e)
        {
            
            sldWorks = swapi.CheckAndOpenSolidWorks();

            lbProcesso.Text = "Abrindo Arquivo...";
            try
            {
                _file = swFilesType.SetFile();
                _fileType = swFilesType.GetFileType(_file);

                if (!string.IsNullOrEmpty(_file))
                {
                    swFilesType.OpenFile(_file, _fileType, sldWorks);
                } 
                
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Arquivo_Click(object sender, EventArgs e)
        {
            sldWorks = swapi.CheckAndOpenSolidWorks();

            lbProcesso.Text = "FECHAR Arquivo...";

            try
            {
                swFilesType.CloseFile(_file, sldWorks);
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarJPG_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Exportando JPG...";
            try
            {
                //SET LOCAL
                string caminhoExportArquivo = swExportFileType.SetLocalExport();

                //GET ARQUIVO ABERTO
                string getFile = swFilesType.GetOpenFile(sldWorks);

                //REPLACE SLDPRT => JPG
                string fileJPG = getFile.ToUpper()
                    .Replace(".SLDPRT", ".JPG")
                    .Replace(".SLDASM", ".JPG")
                    .Replace(".SLDDRW", ".JPG");

                //Convert => jpg()
                swExportFileType.JPG(fileJPG, caminhoExportArquivo, sldWorks);

                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            //SET LOCAL
            string caminhoExportArquivo = swExportFileType.SetLocalExport();

            //GET SLDPRT ABERTO
            string getFile = swFilesType.GetOpenFile(sldWorks);

            //REPLACE SLDPRT => JPG
            string filePDF = getFile.ToUpper()
                .Replace(".SLDPRT", ".PDF")
                .Replace(".SLDASM", ".PDF")
                .Replace(".SLDDRW", ".PDF");

            //Export
            string fullPath = Path.Combine(caminhoExportArquivo, filePDF);

            //VERIFICAR TIPOS COMPATIVEIS
            swExportFileType.pdf(fullPath);
        }
        #endregion
    }
}


