
namespace SolidAPI
{
    partial class swApiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrirSW = new System.Windows.Forms.Button();
            this.chkVisivel = new System.Windows.Forms.CheckBox();
            this.btnFecharSw = new System.Windows.Forms.Button();
            this.grpBoxSW = new System.Windows.Forms.GroupBox();
            this.grpBoxArquivo = new System.Windows.Forms.GroupBox();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarJPG = new System.Windows.Forms.Button();
            this.btnFechar_Arquivo = new System.Windows.Forms.Button();
            this.btnAbrir_Arquivo = new System.Windows.Forms.Button();
            this.lbProcesso = new System.Windows.Forms.Label();
            this.grpBoxSW.SuspendLayout();
            this.grpBoxArquivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrirSW
            // 
            this.btnAbrirSW.Location = new System.Drawing.Point(20, 19);
            this.btnAbrirSW.Name = "btnAbrirSW";
            this.btnAbrirSW.Size = new System.Drawing.Size(105, 50);
            this.btnAbrirSW.TabIndex = 0;
            this.btnAbrirSW.Text = "Abrir SW (2023)";
            this.btnAbrirSW.UseVisualStyleBackColor = true;
            this.btnAbrirSW.Click += new System.EventHandler(this.btnAbrirSW_Click);
            // 
            // chkVisivel
            // 
            this.chkVisivel.AutoSize = true;
            this.chkVisivel.Location = new System.Drawing.Point(138, 71);
            this.chkVisivel.Name = "chkVisivel";
            this.chkVisivel.Size = new System.Drawing.Size(56, 17);
            this.chkVisivel.TabIndex = 1;
            this.chkVisivel.Text = "Visivel";
            this.chkVisivel.UseVisualStyleBackColor = true;
            // 
            // btnFecharSw
            // 
            this.btnFecharSw.Location = new System.Drawing.Point(20, 95);
            this.btnFecharSw.Name = "btnFecharSw";
            this.btnFecharSw.Size = new System.Drawing.Size(105, 44);
            this.btnFecharSw.TabIndex = 2;
            this.btnFecharSw.Text = "Fechar SW (2023)";
            this.btnFecharSw.UseVisualStyleBackColor = true;
            this.btnFecharSw.Click += new System.EventHandler(this.btnFecharSw_Click);
            // 
            // grpBoxSW
            // 
            this.grpBoxSW.Controls.Add(this.btnAbrirSW);
            this.grpBoxSW.Controls.Add(this.btnFecharSw);
            this.grpBoxSW.Controls.Add(this.chkVisivel);
            this.grpBoxSW.Location = new System.Drawing.Point(50, 12);
            this.grpBoxSW.Name = "grpBoxSW";
            this.grpBoxSW.Size = new System.Drawing.Size(200, 154);
            this.grpBoxSW.TabIndex = 3;
            this.grpBoxSW.TabStop = false;
            this.grpBoxSW.Text = "SW";
            // 
            // grpBoxArquivo
            // 
            this.grpBoxArquivo.Controls.Add(this.btnExportarPDF);
            this.grpBoxArquivo.Controls.Add(this.btnExportarJPG);
            this.grpBoxArquivo.Controls.Add(this.btnFechar_Arquivo);
            this.grpBoxArquivo.Controls.Add(this.btnAbrir_Arquivo);
            this.grpBoxArquivo.Location = new System.Drawing.Point(50, 205);
            this.grpBoxArquivo.Name = "grpBoxArquivo";
            this.grpBoxArquivo.Size = new System.Drawing.Size(200, 182);
            this.grpBoxArquivo.TabIndex = 4;
            this.grpBoxArquivo.TabStop = false;
            this.grpBoxArquivo.Text = "Arquivo";
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(20, 144);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(158, 32);
            this.btnExportarPDF.TabIndex = 3;
            this.btnExportarPDF.Text = "Exportar - PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarJPG
            // 
            this.btnExportarJPG.Location = new System.Drawing.Point(20, 110);
            this.btnExportarJPG.Name = "btnExportarJPG";
            this.btnExportarJPG.Size = new System.Drawing.Size(105, 32);
            this.btnExportarJPG.TabIndex = 2;
            this.btnExportarJPG.Text = "Exportar - JPG";
            this.btnExportarJPG.UseVisualStyleBackColor = true;
            this.btnExportarJPG.Click += new System.EventHandler(this.btnExportarJPG_Click);
            // 
            // btnFechar_Arquivo
            // 
            this.btnFechar_Arquivo.Location = new System.Drawing.Point(20, 72);
            this.btnFechar_Arquivo.Name = "btnFechar_Arquivo";
            this.btnFechar_Arquivo.Size = new System.Drawing.Size(105, 32);
            this.btnFechar_Arquivo.TabIndex = 1;
            this.btnFechar_Arquivo.Text = "Fechar Arquivo";
            this.btnFechar_Arquivo.UseVisualStyleBackColor = true;
            this.btnFechar_Arquivo.Click += new System.EventHandler(this.btnFechar_Arquivo_Click);
            // 
            // btnAbrir_Arquivo
            // 
            this.btnAbrir_Arquivo.Location = new System.Drawing.Point(20, 34);
            this.btnAbrir_Arquivo.Name = "btnAbrir_Arquivo";
            this.btnAbrir_Arquivo.Size = new System.Drawing.Size(105, 32);
            this.btnAbrir_Arquivo.TabIndex = 0;
            this.btnAbrir_Arquivo.Text = "Abrir Arquivo";
            this.btnAbrir_Arquivo.UseVisualStyleBackColor = true;
            this.btnAbrir_Arquivo.Click += new System.EventHandler(this.btnAbrir_Arquivo_Click);
            // 
            // lbProcesso
            // 
            this.lbProcesso.AutoSize = true;
            this.lbProcesso.Location = new System.Drawing.Point(13, 425);
            this.lbProcesso.Name = "lbProcesso";
            this.lbProcesso.Size = new System.Drawing.Size(0, 13);
            this.lbProcesso.TabIndex = 5;
            // 
            // swApiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 450);
            this.Controls.Add(this.lbProcesso);
            this.Controls.Add(this.grpBoxArquivo);
            this.Controls.Add(this.grpBoxSW);
            this.Name = "swApiForm";
            this.Text = "SW API";
            this.grpBoxSW.ResumeLayout(false);
            this.grpBoxSW.PerformLayout();
            this.grpBoxArquivo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirSW;
        private System.Windows.Forms.CheckBox chkVisivel;
        private System.Windows.Forms.Button btnFecharSw;
        private System.Windows.Forms.GroupBox grpBoxSW;
        private System.Windows.Forms.GroupBox grpBoxArquivo;
        private System.Windows.Forms.Button btnAbrir_Arquivo;
        private System.Windows.Forms.Button btnFechar_Arquivo;
        private System.Windows.Forms.Button btnExportarJPG;
        private System.Windows.Forms.Label lbProcesso;
        private System.Windows.Forms.Button btnExportarPDF;
    }
}

