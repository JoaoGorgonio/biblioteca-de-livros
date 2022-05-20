namespace Livros
{
    partial class Frm_Ver_Lista
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
            this.label7 = new System.Windows.Forms.Label();
            this.lsbLivros_Visualizar = new System.Windows.Forms.ListBox();
            this.btnExcluir_Lista = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRetornar_Lista = new System.Windows.Forms.Button();
            this.btnVisualizar_Dados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Informal Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(194, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(282, 52);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tohsaka Books";
            // 
            // lsbLivros_Visualizar
            // 
            this.lsbLivros_Visualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbLivros_Visualizar.FormattingEnabled = true;
            this.lsbLivros_Visualizar.ItemHeight = 16;
            this.lsbLivros_Visualizar.Items.AddRange(new object[] {
            "Lista vazia"});
            this.lsbLivros_Visualizar.Location = new System.Drawing.Point(12, 110);
            this.lsbLivros_Visualizar.Name = "lsbLivros_Visualizar";
            this.lsbLivros_Visualizar.Size = new System.Drawing.Size(322, 276);
            this.lsbLivros_Visualizar.TabIndex = 25;
            // 
            // btnExcluir_Lista
            // 
            this.btnExcluir_Lista.BackColor = System.Drawing.Color.White;
            this.btnExcluir_Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir_Lista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.btnExcluir_Lista.Location = new System.Drawing.Point(12, 397);
            this.btnExcluir_Lista.Name = "btnExcluir_Lista";
            this.btnExcluir_Lista.Size = new System.Drawing.Size(151, 35);
            this.btnExcluir_Lista.TabIndex = 27;
            this.btnExcluir_Lista.Text = "MARCAR COMO JÁ LIDO";
            this.btnExcluir_Lista.UseVisualStyleBackColor = false;
            this.btnExcluir_Lista.Click += new System.EventHandler(this.btnExcluir_Lista_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Livros.Properties.Resources.Waver;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(355, 139);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 293);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Livros.Properties.Resources._002_1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Livros.Properties.Resources._002_1_;
            this.pictureBox1.Location = new System.Drawing.Point(96, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 75);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnRetornar_Lista
            // 
            this.btnRetornar_Lista.BackColor = System.Drawing.Color.White;
            this.btnRetornar_Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornar_Lista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.btnRetornar_Lista.Location = new System.Drawing.Point(377, 110);
            this.btnRetornar_Lista.Name = "btnRetornar_Lista";
            this.btnRetornar_Lista.Size = new System.Drawing.Size(202, 23);
            this.btnRetornar_Lista.TabIndex = 29;
            this.btnRetornar_Lista.Text = "VOLTAR";
            this.btnRetornar_Lista.UseVisualStyleBackColor = false;
            this.btnRetornar_Lista.Click += new System.EventHandler(this.btnRetornar_Lista_Click);
            // 
            // btnVisualizar_Dados
            // 
            this.btnVisualizar_Dados.BackColor = System.Drawing.Color.White;
            this.btnVisualizar_Dados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar_Dados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.btnVisualizar_Dados.Location = new System.Drawing.Point(185, 397);
            this.btnVisualizar_Dados.Name = "btnVisualizar_Dados";
            this.btnVisualizar_Dados.Size = new System.Drawing.Size(149, 35);
            this.btnVisualizar_Dados.TabIndex = 30;
            this.btnVisualizar_Dados.Text = "VER MAIS";
            this.btnVisualizar_Dados.UseVisualStyleBackColor = false;
            this.btnVisualizar_Dados.Click += new System.EventHandler(this.btnVisualizar_Dados_Click);
            // 
            // Frm_Ver_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(591, 444);
            this.Controls.Add(this.btnVisualizar_Dados);
            this.Controls.Add(this.btnRetornar_Lista);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnExcluir_Lista);
            this.Controls.Add(this.lsbLivros_Visualizar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Ver_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar lista";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lsbLivros_Visualizar;
        private System.Windows.Forms.Button btnExcluir_Lista;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRetornar_Lista;
        private System.Windows.Forms.Button btnVisualizar_Dados;
    }
}