//System
using System;
using System.IO;
using System.Windows.Forms;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

//LIB SKA
using SWSKA;

//PROJECT - SolidAPI
using SolidAPI.Enums;

namespace SolidAPI.SwExport
{
    public class SwExportFileType
    {
        //LIB SKA
        SW sw = new SW();

        public void JPG(string fileJPG, string exportDir, ModelDoc2 model)
        {
            try
            {
                string fullPath = Path.Combine(exportDir, fileJPG);

                bool resultado = model.SaveAs(fullPath);

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

        ////LIB SKA
        public void PDF(string fullPath)
        {
           sw._swexportaPDF(fullPath);
        }

        public void DWG(string getOpenFile, string fullPath, ModelDoc2 model)
        {
            
            int DWGOpt = (int)ExportDWGOpt.ExpGeometry + (int)ExportDWGOpt.ExpLibFiles + (int)ExportDWGOpt.ExpBendLines;

            PartDoc swpPart = (PartDoc)model;

            bool resultado = swpPart.ExportToDWG(
                fullPath, 
                getOpenFile,
                (int)swExportToDWG_e.swExportToDWG_ExportSheetMetal, 
                true, 
                null, 
                false, 
                false,
                DWGOpt, 
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
