using System.Windows.Forms;

namespace SolidAPI.SwFiles
{
    public class SwOpenFilesType
    {
        #region SLDPRT
        public string OpenFileSLDPRT()
        {
            OpenFileDialog openFileSW = new OpenFileDialog
            {
                InitialDirectory = @"C:\models",
                Title = "Browse SLDPRT Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sldprt",
                Filter = "sldprt files (*.sldprt)|*.sldprt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileSW.ShowDialog() == DialogResult.OK)
            {
                return openFileSW.FileName.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region OUTROTIPO

        

        #endregion
    }
}
