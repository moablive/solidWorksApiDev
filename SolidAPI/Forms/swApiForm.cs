using System;
using System.Windows.Forms;
using System.IO;

//SOLIDWORKS DLLs
using SolidWorks.Interop.sldworks;

//PROJETO
using SolidAPI.Sw;
using SolidAPI.SwFiles;
using SolidAPI.SwExport;
using SolidAPI.Menssages;


using SolidAPI.Forms.Prop;
using SolidAPI.Models;
using System.Reflection;
using System.Security.Cryptography;


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

        //swPropFile - CLASS
        SwPropFile swPropFile = new SwPropFile();

        //SldWorks - Instance
        SldWorks swApp = default(SldWorks);

        //File 
        string _file;

        #endregion

        #region Forms

        //Find DEF PEÇA
        FindProp findProp = new FindProp();

        //ALT DEF PEÇA
        AltProp altProp = new AltProp();
        
        #endregion

        public swApiForm()
        {
            InitializeComponent();
        }

        #region BTN_SOLIDWORKS
        private void btnAbrirSW_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.OpeningSolidWorks;
            try
            {
                swApp = swapi.OpenSolidWorks(chkVisivel.Checked, 31);
                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }

        private void btnFecharSw_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.ClosingSolidWorks;
            try
            {
                swapi.CloseSolidWorks();
                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }
        #endregion

        #region BTN_ARQUIVOS
        private void btnAbrir_Arquivo_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.OpeningFile;

            try
            {
                //SetFile
                _file = swFilesType.SetFile();

                //OpenFile
                swFilesType.VerifyAndOpenFile(_file, swApp);

                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }

        private void btnFechar_Arquivo_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.ClosingFile;
            try
            {
                swFilesType.CloseFile(_file, swApp);
                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }
        #endregion

        #region BTN_Export
        private void btnExportarJPG_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.ExportingJpg;

            try
            {
                //SetLocalExport
                string exportDir = swExportFileType.SetLocalExport();

                //GettFileTitle
                string gettFileTitle = swFilesType.GettFileTitle();

                //ReplaceFileExtension
                string fileJPG = swFilesType.ReplaceFileExtensionType(gettFileTitle, ".JPG");

                //model
                ModelDoc2 model = swFilesType.OpenedswModelDoc();
                
                //Convert => jpg()
                swExportFileType.JPG(fileJPG, exportDir, model);

                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }

        //TODO : Exportar PDF USING LIB SKA
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.ExportingPdf;

            try
            {
                //SetLocalExport
                string exportDir = swExportFileType.SetLocalExport();

                //GettFileTitle
                string gettFileTitle = swFilesType.GettFileTitle();

                //ReplaceFileExtension
                string filePDF = swFilesType.ReplaceFileExtensionType(gettFileTitle, ".PDF");

                string fullPath = Path.Combine(exportDir, filePDF);

                //Convert => pdf()
                swExportFileType.PDF(fullPath);

                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }

        private void btnExportarDWG_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.ExportingDwg;

            try
            {
                //SetLocalExport
                string exportDir = swExportFileType.SetLocalExport();

                //GettFileTitle
                string gettFileTitle = swFilesType.GettFileTitle();

                //GetFileType
                string type = swFilesType.GetFileType(gettFileTitle);

                //ReplaceFileExtension
                string fileDWG = swFilesType.ReplaceFileExtensionType(gettFileTitle, ".DWG");

                //DIR + fileDWG
                string fullPath = Path.Combine(exportDir, fileDWG);

                if (type == ".SLDPRT")
                {
                    swFilesType.VerifySheetMetal();

                    //Model
                    ModelDoc2 model = swFilesType.OpenedswModelDoc();

                    swExportFileType.DWG(gettFileTitle, fullPath, model);
                }
                else
                {
                    throw new Exception("Arquivo não é um .SLDPRT");

                    lbPro.Text = GlobalMessages.Empty;
                }

                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }
        #endregion

        #region BTN_PROP
        private void btnBuscaProp_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.FindPropFile;
            try
            {
                //Model
                ModelDoc2 model = swFilesType.OpenedswModelDoc();

                //DEF | NORMAL
                bool def = pecaDef.Checked;

                #region Paramentros da Peca
                string autor = swPropFile.GetProp("Autor", model, def);
                string Codigo = swPropFile.GetProp("Codigo", model, def);
                string[] pecaCompleta = { autor, Codigo };
                #endregion

                findProp.AtualizarDataGridView(pecaCompleta);

                //ShowDialog - findProp
                findProp.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }

        private void btnAltProp_Click(object sender, EventArgs e)
        {
            lbPro.Text = GlobalMessages.AltPropFile;

            try
            {
                //Model
                ModelDoc2 model = swFilesType.OpenedswModelDoc();

                //DEF | NORMAL
                bool def = pecaDef.Checked;

                //ShowDialog Autor | Codigo
                altProp.ShowDialog();
                
                //UPDATE
                swPropFile.UpdateProp("Autor", altProp.setProps.Autor, model, def);
                swPropFile.UpdateProp("Codigo", altProp.setProps.Codigo, model, def);

                //SAVE
                swPropFile.SaveProp(model);

                lbPro.Text = GlobalMessages.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbPro.Text = GlobalMessages.Empty;
            }
        }
        #endregion
    }
}