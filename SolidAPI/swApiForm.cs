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
        #region ....

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
                lbProcesso.Text = "";
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
                lbProcesso.Text = "";
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
                lbProcesso.Text = "";
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
                lbProcesso.Text = "";
            }
        }
        #endregion

        #region BTN_Export
        private void btnExportarJPG_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Exportando JPG...";
            try
            {
                //SetLocalExport
                string exportDir = swExportFileType.SetLocalExport();

                //GetOpenFile
                string getOpenFile = swFilesType.GetOpenFile(sldWorks);

                //ReplaceFileExtension
                string fileJPG = swFilesType.ReplaceFileExtension(getOpenFile, ".JPG");

                //Convert => jpg()
                swExportFileType.JPG(fileJPG, exportDir, sldWorks);

                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbProcesso.Text = "";
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            //SET LOCAL
            string exportDir = swExportFileType.SetLocalExport();

            //GET ARQUIVO ABERTO
            string getFile = swFilesType.GetOpenFile(sldWorks);

            //REPLACE
            string filePDF = getFile.ToUpper()
                .Replace(".SLDPRT", ".PDF")
                .Replace(".SLDASM", ".PDF")
                .Replace(".SLDDRW", ".PDF");

            string fullPath = Path.Combine(exportDir, filePDF);

            //Convert => pdf()
            swExportFileType.PDF(fullPath);
        }

        private void btnExportarDWG_Click(object sender, EventArgs e)
        {
            lbProcesso.Text = "Exportando DWG...";
            try
            {
                //SetLocalExport
                string exportDir = swExportFileType.SetLocalExport();

                //GetOpenFile
                string getOpenFile = swFilesType.GetOpenFile(sldWorks);

                //GetFileType
                string type = swFilesType.GetFileType(getOpenFile);

                //ReplaceFileExtension
                string fileDWG = swFilesType.ReplaceFileExtension(getOpenFile, ".DWG");

                //DIR + fileDWG
                string fullPath = Path.Combine(exportDir, fileDWG);

                if (type == ".SLDPRT")
                {
                    swFilesType.VerifySheetMetal(sldWorks);
                    swExportFileType.DWG(getOpenFile, fullPath,sldWorks);
                }
                else
                {
                    throw new Exception("Arquivo não é um desenho");
                    lbProcesso.Text = "";
                }
                
                lbProcesso.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbProcesso.Text = "";
            }
        }
        #endregion
    }
}