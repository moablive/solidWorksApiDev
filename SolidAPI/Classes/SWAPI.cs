using System;
using System.Diagnostics;
using System.Linq;

//SOLID DLLS
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidAPI.Classes
{
    class SWAPI
    {
        //DLL SOLID
        private SldWorks swApp = default(SldWorks);
        private int ProcesID = 0;

        public void AbrirSolidWorks(bool Visivel, int Versao)
        {
            try
            {
                swApp = Activator.CreateInstance(Type.GetTypeFromProgID(
                    $"SldWorks.Application.{Versao.ToString()}")
                ) as SldWorks;

                swApp.Visible = Visivel;

                ProcesID = swApp.GetProcessID();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao abrir SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }

        public void FecharSolidWorks()
        {
            try
            {
                Process[] processos = Process.GetProcesses();
                var sldworks = processos.FirstOrDefault(x => x.Id == ProcesID);
                sldworks.Kill();

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Fechar SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }

        public void AbrirArquivo(string CaminhoArquivo)
        {
            int err = 0, wars = 0;

            try
            {
                ModelDoc2 swModelDoc = swApp.OpenDoc6(
                    CaminhoArquivo,
                    (int)swDocumentTypes_e.swDocPART,
                    0,
                    "",
                    err, 
                    wars
               );

                PartDoc swpPart = (PartDoc)swModelDoc;
               // AssemblyDoc swAssmb = (AssemblyDoc)swModelDoc;
                //DrawingDoc swDraw = (DrawingDoc)swModelDoc;

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao abrir um arquivo no SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}
