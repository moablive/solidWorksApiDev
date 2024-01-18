//System
using System;
using System.Windows.Forms;

//PROJECT - SolidAPI
using SolidAPI.Models; 

namespace SolidAPI
{
    public partial class AltProp : Form
    {
        public PecaModel setProps
        {
            get
            {
                return new PecaModel
                {
                    Autor = txtAutor.Text,
                    Codigo = txtCodigo.Text
                };
            }
        }

        public AltProp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}