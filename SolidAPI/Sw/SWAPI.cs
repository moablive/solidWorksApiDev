using System;
using System.Diagnostics;
using System.Linq;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;

namespace SolidAPI.Sw
{
    public class SWAPI
    {
        //Process SolidWorks
        private int ProcesID = 0;

        public SldWorks AbrirSolidWorks(bool Visivel, int Versao)
        {
            try
            {
                SldWorks swApp = Activator.CreateInstance(Type.GetTypeFromProgID(
                    $"SldWorks.Application.{Versao.ToString()}")
                ) as SldWorks;

                swApp.Visible = Visivel;

                ProcesID = swApp.GetProcessID();

                return swApp;
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
    
    }
}
