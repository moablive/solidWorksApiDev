using System;
using System.Windows.Forms;


// SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidAPI.SwFiles
{
    public class SwFilesType
    { 

        #region Files SLDPRT
        public string selectFileSldprt()
        {
            OpenFileDialog openFileSW = new OpenFileDialog
            {
                InitialDirectory = @"C:\models",
                Title = "Browse SLDPRT Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sldprt",
                Filter = "sldprt files (*.sldprt)|*.sldprt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileSW.ShowDialog() == DialogResult.OK)
            {
                return openFileSW.FileName.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public void openSldprt(string CaminhoArquivo, SldWorks sldWorks)
        {
            int err = 0, wars = 0;
            
            try
            {
                ModelDoc2 swModelDoc = sldWorks.OpenDoc6(
                    CaminhoArquivo,
                    (int)swDocumentTypes_e.swDocPART,
                    0,
                    "",
                    err,
                    wars
                );

                PartDoc swpPart = (PartDoc)swModelDoc;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao abrir um arquivo no SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }
        #endregion

    }
}
