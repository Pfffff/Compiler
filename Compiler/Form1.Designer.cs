namespace Compiler
{
    partial class Form1
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
            this.expression = new System.Windows.Forms.TextBox();
            this.parse_click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rpn = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // expression
            // 
            this.expression.Location = new System.Drawing.Point(196, 12);
            this.expression.Name = "expression";
            this.expression.Size = new System.Drawing.Size(259, 20);
            this.expression.TabIndex = 0;
            this.expression.Text = "((182+3)/5*(9810+5*6))+11*5/2";
           
            // 
            // parse_click
            // 
            this.parse_click.Location = new System.Drawing.Point(231, 57);
            this.parse_click.Name = "parse_click";
            this.parse_click.Size = new System.Drawing.Size(118, 23);
            this.parse_click.TabIndex = 1;
            this.parse_click.Text = "парсим";
            this.parse_click.UseVisualStyleBackColor = true;
            this.parse_click.Click += new System.EventHandler(this.parse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "введите выражение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "постфиксная запись:";
            // 
            // rpn
            // 
            this.rpn.AutoSize = true;
            this.rpn.Location = new System.Drawing.Point(193, 111);
            this.rpn.Name = "rpn";
            this.rpn.Size = new System.Drawing.Size(240, 13);
            this.rpn.TabIndex = 4;
            this.rpn.Text = "здесь могла бы быть ваша польская нотация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "результат:";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.result.Location = new System.Drawing.Point(231, 163);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 13);
            this.result.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 261);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rpn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parse_click);
            this.Controls.Add(this.expression);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expression;
        private System.Windows.Forms.Button parse_click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rpn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label result;
    }
}

