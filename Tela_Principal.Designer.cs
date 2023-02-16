
namespace HorarioSemanal
{
    partial class Tela_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.VerHorario = new System.Windows.Forms.Button();
            this.AlterarHorario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VerHorario
            // 
            this.VerHorario.Location = new System.Drawing.Point(208, 108);
            this.VerHorario.Name = "VerHorario";
            this.VerHorario.Size = new System.Drawing.Size(157, 123);
            this.VerHorario.TabIndex = 2;
            this.VerHorario.Text = "Ver Horario";
            this.VerHorario.UseVisualStyleBackColor = true;
            this.VerHorario.Click += new System.EventHandler(this.VerHorario_Click);
            // 
            // AlterarHorario
            // 
            this.AlterarHorario.Location = new System.Drawing.Point(577, 108);
            this.AlterarHorario.Name = "AlterarHorario";
            this.AlterarHorario.Size = new System.Drawing.Size(157, 123);
            this.AlterarHorario.TabIndex = 3;
            this.AlterarHorario.Text = "Alterar Horario";
            this.AlterarHorario.UseVisualStyleBackColor = true;
            this.AlterarHorario.Click += new System.EventHandler(this.AlterarHorario_Click);
            // 
            // Tela_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.AlterarHorario);
            this.Controls.Add(this.VerHorario);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tela_Principal";
            this.Text = "Tela Principal";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button VerHorario;
        private System.Windows.Forms.Button AlterarHorario;
    }
}

