//System
using System;
using System.Diagnostics;
using System.Linq;

// SolidWorks DLLs
using SolidWorks.Interop.sldworks;

namespace SolidAPI.Sw
{
    public class SWAPI
    {
        private int _pid = 0;

        public ModelDoc2 swModelDoc;

        public SldWorks OpenSolidWorks(bool Visivel, int Versao)
        {
            try
            {
                SldWorks swApp = Activator.CreateInstance(Type.GetTypeFromProgID(
                    $"SldWorks.Application.{Versao.ToString()}")
                ) as SldWorks;

                swApp.Visible = Visivel;

                _pid = swApp.GetProcessID();

                return swApp;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao abrir SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }

        public void CloseSolidWorks()
        {
            try
            {
                Process[] processos = Process.GetProcesses();
                var sldworks = processos.FirstOrDefault(x => x.Id == _pid);
                sldworks.Kill();

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Fechar SolidWorks: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}