namespace capaPresentacion
{
    partial class P_SAutobuses
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_SAutobuses));
            this.asignados = new System.Windows.Forms.DataGridView();
            this.actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.asignados)).BeginInit();
            this.SuspendLayout();
            // 
            // asignados
            // 
            this.asignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.asignados.Location = new System.Drawing.Point(20, 81);
            this.asignados.Name = "asignados";
            this.asignados.RowHeadersWidth = 51;
            this.asignados.RowTemplate.Height = 24;
            this.asignados.Size = new System.Drawing.Size(776, 313);
            this.asignados.TabIndex = 0;
            this.asignados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.asignados_CellContentClick);
            // 
            // actualizar
            // 
            this.actualizar.Location = new System.Drawing.Point(317, 415);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(75, 23);
            this.actualizar.TabIndex = 1;
            this.actualizar.Text = "Actualizar";
            this.actualizar.UseVisualStyleBackColor = true;
            this.actualizar.Click += new System.EventHandler(this.actualizar_Click);
            // 
            // P_SAutobuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 477);
            this.Controls.Add(this.actualizar);
            this.Controls.Add(this.asignados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P_SAutobuses";
            this.Text = "SISBUS";
            ((System.ComponentModel.ISupportInitialize)(this.asignados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView asignados;
        private System.Windows.Forms.Button actualizar;
    }
}

