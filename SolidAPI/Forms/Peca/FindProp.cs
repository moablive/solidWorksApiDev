//System
using System.Windows.Forms;

namespace SolidAPI.Forms.Prop
{
    public partial class FindProp : Form
    {
        public FindProp()
        {
            InitializeComponent();
        }

        public void AtualizarDataGridView(string[] pecaCompleta)
        {
            dgvPeca.Rows.Add(pecaCompleta);
        }
    }
}