using System.Drawing;
using System.Windows.Forms;

namespace WordScrambleApp
{
    partial class IndexForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            btnLangBG = new Button();
            btnLangEN = new Button();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblScrambledWord = new Label();
            txtGuess = new TextBox();
            btnCheck = new Button();
            btnNext = new Button();
            btnHint = new Button();
            lblHintDisplay = new Label();
            lblScore = new Label();
            lblErrors = new Label();
            lblTimerDisplay = new Label();
            prgTime = new ProgressBar();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblMistakesTitle = new Label();
            lstWrongWords = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.ForeColor = SystemColors.ControlText;
            lblTitle.Location = new Point(285, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(176, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Word Scramble";
            // 
            // btnLangBG
            // 
            btnLangBG.Location = new Point(704, 12);
            btnLangBG.Name = "btnLangBG";
            btnLangBG.Size = new Size(75, 23);
            btnLangBG.TabIndex = 1;
            btnLangBG.Text = "BG 🇧🇬";
            btnLangBG.UseVisualStyleBackColor = true;
            btnLangBG.Click += btnLangBG_Click;
            // 
            // btnLangEN
            // 
            btnLangEN.Location = new Point(704, 41);
            btnLangEN.Name = "btnLangEN";
            btnLangEN.Size = new Size(75, 23);
            btnLangEN.TabIndex = 2;
            btnLangEN.Text = "EN 🇺🇸";
            btnLangEN.UseVisualStyleBackColor = true;
            btnLangEN.Click += btnLangEN_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(294, 57);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 19);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Animals", "Jobs", "General" });
            cmbCategory.Location = new Point(376, 57);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(85, 23);
            cmbCategory.TabIndex = 4;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblScrambledWord
            // 
            lblScrambledWord.AutoSize = true;
            lblScrambledWord.Font = new Font("Segoe UI", 20F);
            lblScrambledWord.Location = new Point(353, 115);
            lblScrambledWord.Name = "lblScrambledWord";
            lblScrambledWord.Size = new Size(50, 37);
            lblScrambledWord.TabIndex = 5;
            lblScrambledWord.Text = "---";
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(278, 175);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(221, 23);
            txtGuess.TabIndex = 6;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(278, 218);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(75, 23);
            btnCheck.TabIndex = 7;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(424, 218);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnHint
            // 
            btnHint.Location = new Point(653, 111);
            btnHint.Name = "btnHint";
            btnHint.Size = new Size(75, 23);
            btnHint.TabIndex = 9;
            btnHint.Text = "Hint";
            btnHint.UseVisualStyleBackColor = true;
            btnHint.Click += btnHint_Click;
            // 
            // lblHintDisplay
            // 
            lblHintDisplay.AutoSize = true;
            lblHintDisplay.Location = new Point(634, 142);
            lblHintDisplay.Name = "lblHintDisplay";
            lblHintDisplay.Size = new Size(119, 15);
            lblHintDisplay.TabIndex = 10;
            lblHintDisplay.Text = "Hint will appear here ";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 11F);
            lblScore.Location = new Point(33, 100);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(61, 20);
            lblScore.TabIndex = 11;
            lblScore.Text = "Score: 0";
            // 
            // lblErrors
            // 
            lblErrors.AutoSize = true;
            lblErrors.Font = new Font("Segoe UI", 11F);
            lblErrors.Location = new Point(32, 137);
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(62, 20);
            lblErrors.TabIndex = 12;
            lblErrors.Text = "Errors: 0";
            // 
            // lblTimerDisplay
            // 
            lblTimerDisplay.AutoSize = true;
            lblTimerDisplay.Font = new Font("Segoe UI", 13F);
            lblTimerDisplay.Location = new Point(32, 19);
            lblTimerDisplay.Name = "lblTimerDisplay";
            lblTimerDisplay.Size = new Size(87, 25);
            lblTimerDisplay.TabIndex = 13;
            lblTimerDisplay.Text = "Time: 30s";
            // 
            // prgTime
            // 
            prgTime.Location = new Point(34, 47);
            prgTime.Maximum = 30;
            prgTime.Name = "prgTime";
            prgTime.Size = new Size(100, 23);
            prgTime.TabIndex = 14;
            prgTime.Value = 30;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // lblMistakesTitle
            // 
            lblMistakesTitle.AutoSize = true;
            lblMistakesTitle.Font = new Font("Segoe UI", 10F);
            lblMistakesTitle.Location = new Point(88, 318);
            lblMistakesTitle.Name = "lblMistakesTitle";
            lblMistakesTitle.Size = new Size(109, 19);
            lblMistakesTitle.TabIndex = 15;
            lblMistakesTitle.Text = "Mistaken words:";
            // 
            // lstWrongWords
            // 
            lstWrongWords.FormattingEnabled = true;
            lstWrongWords.Location = new Point(203, 318);
            lstWrongWords.Name = "lstWrongWords";
            lstWrongWords.Size = new Size(424, 94);
            lstWrongWords.TabIndex = 16;
            // 
            // IndexForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 516);
            Controls.Add(lstWrongWords);
            Controls.Add(lblMistakesTitle);
            Controls.Add(prgTime);
            Controls.Add(lblTimerDisplay);
            Controls.Add(lblErrors);
            Controls.Add(lblScore);
            Controls.Add(lblHintDisplay);
            Controls.Add(btnHint);
            Controls.Add(btnNext);
            Controls.Add(btnCheck);
            Controls.Add(txtGuess);
            Controls.Add(lblScrambledWord);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(btnLangEN);
            Controls.Add(btnLangBG);
            Controls.Add(lblTitle);
            Name = "IndexForm";
            Load += IndexForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnLangBG;
        private Button btnLangEN;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblScrambledWord;
        private TextBox txtGuess;
        private Button btnCheck;
        private Button btnNext;
        private Button btnHint;
        private Label lblHintDisplay;
        private Label lblScore;
        private Label lblErrors;
        private Label lblTimerDisplay;
        private ProgressBar prgTime;
        private System.Windows.Forms.Timer gameTimer;
        private Label lblMistakesTitle;
        private ListBox lstWrongWords;
    }
}