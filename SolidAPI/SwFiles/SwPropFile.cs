//System
using System;
using System.Windows.Forms;

//SolidWorks DLLs
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidAPI.SwFiles
{
    public class SwPropFile 
    {
        public string GetProp(string propName, ModelDoc2 model, bool def)
        {
            string valor = "", resultado = "";

            ModelDocExtension swModelDocExt;
            CustomPropertyManager swCustPropMgr;

            try
            {
                swModelDocExt = model.Extension;

                if (def)
                {
                    swCustPropMgr = swModelDocExt.get_CustomPropertyManager("Valor Predeterminado");
                }
                else
                {
                    swCustPropMgr = swModelDocExt.get_CustomPropertyManager("");
                }

                swCustPropMgr.Get4(
                    propName,
                    false,
                    out resultado,
                    out valor
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valor;
        }

        public void UpdateProp(string propName, string propValue, ModelDoc2 model, bool def)
        {
            ModelDocExtension swModelDocExt;
            CustomPropertyManager swCustPropMgr;

            try
            {
                swModelDocExt = model.Extension;

                if (def)
                {
                    swCustPropMgr = swModelDocExt.get_CustomPropertyManager("Valor Predeterminado");
                }
                else
                {
                    swCustPropMgr = swModelDocExt.get_CustomPropertyManager("");
                }

                swCustPropMgr.Add3(
                    propName,
                    (int)swCustomInfoType_e.swCustomInfoText,
                    propValue,
                    (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SaveProp(ModelDoc2 model)
        {
            int Errors = 0, Warnings = 0;

            try
            {
                return model.Save3(
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    Errors,
                    Warnings
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

    }
}
