using System;
using System.IO;
using System.Windows.Forms;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidAPI.SwFiles
{
    public class SwFilesType
    {
        //ALL TYPES
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

        public void OpenFile(string file, string fileType, SldWorks sldWorks)
        {
            int err = 0, wars = 0;

            try
            {
                if (fileType == ".SLDPRT")
                {
                    ModelDoc2 swModelDoc = sldWorks.OpenDoc6(
                        file,
                        (int)swDocumentTypes_e.swDocPART,
                        0,
                        "",
                        err,
                        wars
                    );

                    PartDoc swpPart = (PartDoc)swModelDoc;
                }

                if (fileType == ".SLDASM")
                {
                    ModelDoc2 swModelDoc = sldWorks.OpenDoc6(
                        file,
                        (int)swDocumentTypes_e.swDocASSEMBLY,
                        0,
                        "",
                        err,
                        wars
                    );
                    AssemblyDoc swAsmb = (AssemblyDoc)swModelDoc;
                }

                if (fileType == ".SLDDRW")
                {
                    ModelDoc2 swModelDoc = sldWorks.OpenDoc6(
                        file,
                        (int)swDocumentTypes_e.swDocDRAWING,
                        0,
                        "",
                        err,
                        wars
                    );

                    DrawingDoc swDrw = (DrawingDoc)swModelDoc;
                }

                //ARQUIVO ABERTO
                MessageBox.Show($"VOCE ABRIU: {GetOpenFile(sldWorks)}");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao abrir um arquivo no SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }

        public string GetOpenFile(SldWorks sldWorks)
        {
            string openFile = "";

            try
            {
                ModelDoc2 swModelDoc = (ModelDoc2)sldWorks.ActiveDoc;
                openFile = swModelDoc.GetTitle();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return openFile;
        }

        public void CloseFile(string file, SldWorks sldWorks)
        {
            try
            {
                sldWorks.CloseDoc(file);
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
    }
}
