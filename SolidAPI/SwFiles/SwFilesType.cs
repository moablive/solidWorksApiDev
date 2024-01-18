//System
using System;
using System.IO;
using System.Windows.Forms;

//Project - SolidAPI
using SolidAPI.Sw;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidAPI.SwFiles
{
    public class SwFilesType : SWAPI
    {
        public string SetFile()
        {
            OpenFileDialog openFileSW = new OpenFileDialog
            {
                InitialDirectory = @"C:\models",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sldprt",
                Filter = "sldprt files (*.sldprt;*.sldasm;*.slddrw)|*.sldprt;*.sldasm;*.slddrw",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            return openFileSW.ShowDialog() == DialogResult.OK ? openFileSW.FileName : string.Empty;
        }

        public void VerifyAndOpenFile(string file, SldWorks swApp)
        {
            int err = 0, wars = 0;

            //GetFileType
            string fileType = GetFileType(file);

            //OpenFile
            if (fileType == ".SLDPRT")
            {
                swModelDoc = swApp.OpenDoc6(
                    file,
                    (int)swDocumentTypes_e.swDocPART,
                    0,
                    "",
                    ref err,
                    ref wars
                );
            }
            else if (fileType == ".SLDASM")
            {
                swModelDoc = swApp.OpenDoc6(
                    file,
                    (int)swDocumentTypes_e.swDocASSEMBLY,
                    0,
                    "",
                    ref err,
                    ref wars
                );
            }
            else if (fileType == ".SLDDRW")
            {
                swModelDoc = swApp.OpenDoc6(
                    file,
                    (int)swDocumentTypes_e.swDocDRAWING,
                    0,
                    "",
                    ref err,
                    ref wars
                );
            }

            // VALIDAR USO DA MENSAGEM
            MessageBox.Show($"----VALIDAR---- Voce ABRIU: - {GettFileTitle()}");
        }

        public string GettFileTitle()
        {
            string gettFileTitle = "";

            try
            {
                gettFileTitle = swModelDoc.GetTitle();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return gettFileTitle;
        }

        public void CloseFile(string file, SldWorks swApp)
        {
            try
            {
                swApp.CloseDoc(file);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetFileType(string file)
        {
            return Path.GetExtension(file.ToUpper());
        }

        public string ReplaceFileExtensionType(string gettFileTitle, string newExtension)
        {
            return Path.ChangeExtension(gettFileTitle.ToUpper(), newExtension);
        }

        public bool VerifySheetMetal()
        {
            Feature feat = (Feature)swModelDoc.FirstFeature();

            while (feat != null)
            {
                if (feat.GetTypeName2().ToUpper() == "SHEETMETAL")
                {
                    return true;
                }

                feat = (Feature)feat.GetNextFeature();
            }

            return false;
        }

        /// <summary>
        /// Depende de VerifyAndOpenFile
        /// </summary>
        /// <returns></returns>
        public ModelDoc2 OpenedswModelDoc()
        {
            return swModelDoc;
        }
    }
}
