using System;
using System.IO;
using System.Windows.Forms;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;

namespace SolidAPI.SwExport
{
    public class SwExportFileType
    {
        public void JPG(string fileSldprtJpg, string caminhoExportArquivo, SldWorks sldWorks)
        {
            try
            {
                //CAST
                ModelDoc2 swModelDoc = (ModelDoc2)sldWorks.ActiveDoc;

                //Export
                string fullPath = Path.Combine(caminhoExportArquivo, fileSldprtJpg);

                bool resultado = swModelDoc.SaveAs(fullPath);

                if (!resultado)
                {
                    throw new Exception("Erro ao exportar arquivo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string SetLocalExport()
        {
            using (var folder = new FolderBrowserDialog())
            {
                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    return folder.SelectedPath;
                }
            }

            return string.Empty;
        }
    }
}
