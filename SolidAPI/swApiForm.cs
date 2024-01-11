using System;
using System.Windows.Forms;
using SolidAPI.Classes;
using SolidAPI.SwFiles;


namespace SolidAPI
{
    public partial class swApiForm : Form
    {
        //SOLID GLOBAL
        SWAPI objsw = new SWAPI();

        //SwOpenFilesType
        SwOpenFilesType swOpenFilesType = new SwOpenFilesType();

        public swApiForm()
        {
            InitializeComponent();
        }

        private void btnAbrirSW_Click(object sender, EventArgs e)
        {
            try
            {
                objsw.AbrirSolidWorks(chkVisivel.Checked, 31);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFecharSw_Click(object sender, EventArgs e)
        {
            try
            {
                objsw.FecharSolidWorks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAbrir_Arquivo_Sldprt_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNameSLDPRT = swOpenFilesType.OpenFileSLDPRT();

                if (!string.IsNullOrEmpty(fileNameSLDPRT))
                {
                    objsw.AbrirArquivo(fileNameSLDPRT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


