namespace Cancelacion_de_pasajes
{
    partial class reprogramacion
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
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt123 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_datos
            // 
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Location = new System.Drawing.Point(22, 43);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.Size = new System.Drawing.Size(949, 367);
            this.dgv_datos.TabIndex = 1;
            this.dgv_datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_datos_CellContentClick);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Enabled = false;
            this.txt_filtro.Location = new System.Drawing.Point(92, 6);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(235, 20);
            this.txt_filtro.TabIndex = 4;
            this.txt_filtro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID de cliente";
            // 
            // txt123
            // 
            this.txt123.Enabled = false;
            this.txt123.Location = new System.Drawing.Point(496, 12);
            this.txt123.Name = "txt123";
            this.txt123.Size = new System.Drawing.Size(235, 20);
            this.txt123.TabIndex = 5;
            this.txt123.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // reprogramacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.txt123);
            this.Controls.Add(this.txt_filtro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_datos);
            this.Name = "reprogramacion";
            this.Text = "reprogramacion";
            this.Load += new System.EventHandler(this.reprogramacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt123;
    }
}