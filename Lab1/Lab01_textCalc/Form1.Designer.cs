namespace Lab01_textCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.replace = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.get_by_indx = new System.Windows.Forms.Button();
            this.length = new System.Windows.Forms.Button();
            this.vowel = new System.Windows.Forms.Button();
            this.consonant = new System.Windows.Forms.Button();
            this.sentences = new System.Windows.Forms.Button();
            this.words = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(32, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(673, 43);
            this.textBox1.TabIndex = 0;
            // 
            // replace
            // 
            this.replace.Location = new System.Drawing.Point(33, 104);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(90, 63);
            this.replace.TabIndex = 1;
            this.replace.Text = "replace";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.Click += new System.EventHandler(this.replace_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(151, 104);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(90, 63);
            this.delete.TabIndex = 2;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // get_by_indx
            // 
            this.get_by_indx.Location = new System.Drawing.Point(266, 104);
            this.get_by_indx.Name = "get_by_indx";
            this.get_by_indx.Size = new System.Drawing.Size(97, 63);
            this.get_by_indx.TabIndex = 3;
            this.get_by_indx.Text = "get_by_indx";
            this.get_by_indx.UseVisualStyleBackColor = true;
            this.get_by_indx.Click += new System.EventHandler(this.get_by_indx_Click);
            // 
            // length
            // 
            this.length.Location = new System.Drawing.Point(616, 104);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(90, 63);
            this.length.TabIndex = 4;
            this.length.Text = "length";
            this.length.UseVisualStyleBackColor = true;
            this.length.Click += new System.EventHandler(this.length_Click);
            // 
            // vowel
            // 
            this.vowel.Location = new System.Drawing.Point(266, 187);
            this.vowel.Name = "vowel";
            this.vowel.Size = new System.Drawing.Size(97, 63);
            this.vowel.TabIndex = 5;
            this.vowel.Text = "vowel";
            this.vowel.UseVisualStyleBackColor = true;
            this.vowel.Click += new System.EventHandler(this.vowel_Click);
            // 
            // consonant
            // 
            this.consonant.Location = new System.Drawing.Point(387, 187);
            this.consonant.Name = "consonant";
            this.consonant.Size = new System.Drawing.Size(97, 63);
            this.consonant.TabIndex = 6;
            this.consonant.Text = "consonant";
            this.consonant.UseVisualStyleBackColor = true;
            this.consonant.Click += new System.EventHandler(this.consonant_Click);
            // 
            // sentences
            // 
            this.sentences.Location = new System.Drawing.Point(387, 104);
            this.sentences.Name = "sentences";
            this.sentences.Size = new System.Drawing.Size(90, 63);
            this.sentences.TabIndex = 7;
            this.sentences.Text = "sentences";
            this.sentences.UseVisualStyleBackColor = true;
            this.sentences.Click += new System.EventHandler(this.sentences_Click);
            // 
            // words
            // 
            this.words.Location = new System.Drawing.Point(498, 104);
            this.words.Name = "words";
            this.words.Size = new System.Drawing.Size(90, 63);
            this.words.TabIndex = 8;
            this.words.Text = "words";
            this.words.UseVisualStyleBackColor = true;
            this.words.Click += new System.EventHandler(this.words_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 63);
            this.button1.TabIndex = 9;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // equal
            // 
            this.equal.Location = new System.Drawing.Point(33, 187);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(90, 63);
            this.equal.TabIndex = 10;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = true;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 279);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.words);
            this.Controls.Add(this.sentences);
            this.Controls.Add(this.consonant);
            this.Controls.Add(this.vowel);
            this.Controls.Add(this.length);
            this.Controls.Add(this.get_by_indx);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.replace);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button replace;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button get_by_indx;
        private System.Windows.Forms.Button length;
        private System.Windows.Forms.Button vowel;
        private System.Windows.Forms.Button consonant;
        private System.Windows.Forms.Button sentences;
        private System.Windows.Forms.Button words;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button equal;
    }
}

