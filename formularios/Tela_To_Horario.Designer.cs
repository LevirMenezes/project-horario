namespace HorarioSemanal.formularios
{
    partial class Tela_To_Horario
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
            this.HorarioPeriodo1 = new System.Windows.Forms.Button();
            this.HorarioPeriodo3 = new System.Windows.Forms.Button();
            this.HorarioPeriodo5 = new System.Windows.Forms.Button();
            this.VoltarTelaPrincipal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HorarioPeriodo1
            // 
            this.HorarioPeriodo1.Location = new System.Drawing.Point(123, 132);
            this.HorarioPeriodo1.Name = "HorarioPeriodo1";
            this.HorarioPeriodo1.Size = new System.Drawing.Size(131, 64);
            this.HorarioPeriodo1.TabIndex = 0;
            this.HorarioPeriodo1.Text = "1° Periodo";
            this.HorarioPeriodo1.UseVisualStyleBackColor = true;
            this.HorarioPeriodo1.Click += new System.EventHandler(this.HorarioPeriodo1_Click);
            // 
            // HorarioPeriodo3
            // 
            this.HorarioPeriodo3.Location = new System.Drawing.Point(291, 132);
            this.HorarioPeriodo3.Name = "HorarioPeriodo3";
            this.HorarioPeriodo3.Size = new System.Drawing.Size(131, 64);
            this.HorarioPeriodo3.TabIndex = 1;
            this.HorarioPeriodo3.Text = "3° Periodo";
            this.HorarioPeriodo3.UseVisualStyleBackColor = true;
            this.HorarioPeriodo3.Click += new System.EventHandler(this.HorarioPeriodo3_Click);
            // 
            // HorarioPeriodo5
            // 
            this.HorarioPeriodo5.Location = new System.Drawing.Point(463, 133);
            this.HorarioPeriodo5.Name = "HorarioPeriodo5";
            this.HorarioPeriodo5.Size = new System.Drawing.Size(131, 63);
            this.HorarioPeriodo5.TabIndex = 2;
            this.HorarioPeriodo5.Text = "5° Periodo";
            this.HorarioPeriodo5.UseVisualStyleBackColor = true;
            this.HorarioPeriodo5.Click += new System.EventHandler(this.HorarioPeriodo5_Click);
            // 
            // VoltarTelaPrincipal
            // 
            this.VoltarTelaPrincipal.Location = new System.Drawing.Point(488, 351);
            this.VoltarTelaPrincipal.Name = "VoltarTelaPrincipal";
            this.VoltarTelaPrincipal.Size = new System.Drawing.Size(106, 29);
            this.VoltarTelaPrincipal.TabIndex = 3;
            this.VoltarTelaPrincipal.Text = "VOLTAR";
            this.VoltarTelaPrincipal.UseVisualStyleBackColor = true;
            this.VoltarTelaPrincipal.Click += new System.EventHandler(this.VoltarTelaPrincipal_Click);
            // 
            // Tela_To_Horario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VoltarTelaPrincipal);
            this.Controls.Add(this.HorarioPeriodo5);
            this.Controls.Add(this.HorarioPeriodo3);
            this.Controls.Add(this.HorarioPeriodo1);
            this.Name = "Tela_To_Horario";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HorarioPeriodo1;
        private System.Windows.Forms.Button HorarioPeriodo3;
        private System.Windows.Forms.Button HorarioPeriodo5;
        private System.Windows.Forms.Button VoltarTelaPrincipal;
    }
}