namespace SistemaSupermercado
{
    partial class ResumoCompra
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lstResumo = new System.Windows.Forms.ListBox();
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 46);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HelveticaNeueLT Pro 53 Ex", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "RESUMO DA COMPRA";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtResumo);
            this.panel2.Controls.Add(this.lstResumo);
            this.panel2.Location = new System.Drawing.Point(98, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 390);
            this.panel2.TabIndex = 1;
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackColor = System.Drawing.Color.Green;
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font("HelveticaNeueLT Pro 53 Ex", 9F);
            this.btnEmitir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmitir.Image = global::SistemaSupermercado.Properties.Resources.icons8_selecionado_25;
            this.btnEmitir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmitir.Location = new System.Drawing.Point(98, 461);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(238, 48);
            this.btnEmitir.TabIndex = 0;
            this.btnEmitir.Text = "EMITIR NOTA";
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("HelveticaNeueLT Pro 53 Ex", 9F);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::SistemaSupermercado.Properties.Resources.img_fechar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(340, 461);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(238, 48);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "CANCELAR COMPRA";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lstResumo
            // 
            this.lstResumo.FormattingEnabled = true;
            this.lstResumo.Location = new System.Drawing.Point(3, 3);
            this.lstResumo.Name = "lstResumo";
            this.lstResumo.Size = new System.Drawing.Size(472, 342);
            this.lstResumo.TabIndex = 0;
            // 
            // txtResumo
            // 
            this.txtResumo.Location = new System.Drawing.Point(375, 351);
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.Size = new System.Drawing.Size(100, 20);
            this.txtResumo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HelveticaNeueLT Pro 53 Ex", 9F);
            this.label2.Location = new System.Drawing.Point(229, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "TOTAL DA COMPRA:";
            // 
            // ResumoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 521);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ResumoCompra";
            this.Text = "ResumoCompra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtResumo;
        private System.Windows.Forms.ListBox lstResumo;
        private System.Windows.Forms.Label label2;
    }
}