using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using SolidAPI.Enums;
using SolidAPI.Sw;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

//SKA
using SWSKA;

namespace SolidAPI.SwExport
{
    public class SwExportFileType : SWAPI
    {
        //LIB SKA
        SW sw = new SW();

        public void JPG(string fileJPG, string exportDir, SldWorks sldWorks)
        {
            try
            {
                string fullPath = Path.Combine(exportDir, fileJPG);

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

        public void PDF(string fullPath)
        {
            sw._swexportaPDF(fullPath);
        }

        public void DWG(string getOpenFile, string fullPath, SldWorks sldWorks)
        {
            int err = 0, wars = 0;

            int opcoes = (int)ExportDWGOpt.ExpGeometry
                         + (int)ExportDWGOpt.ExpLibFiles
                         + (int)ExportDWGOpt.ExpBendLines;

            swModelDoc = sldWorks.OpenDoc6(
                getOpenFile,
                (int)swDocumentTypes_e.swDocPART,
                0,
                "",
                err,
                wars
            );

            PartDoc swpPart = (PartDoc)swModelDoc;

            bool resultado = swpPart.ExportToDWG(
                fullPath,
                getOpenFile, 
                (int)swExportToDWG_e.swExportToDWG_ExportSheetMetal,
                true,
                null,
                false, 
                false,
                opcoes,
                null
            );
            
            if (!resultado)
            {
                throw new Exception("Erro ao exportar arquivo");
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
