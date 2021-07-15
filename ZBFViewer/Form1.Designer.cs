namespace ZBFReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbClose = new System.Windows.Forms.Button();
            this.bRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.rbGrayScale = new System.Windows.Forms.RadioButton();
            this.rbGrayScaleInverse = new System.Windows.Forms.RadioButton();
            this.rbFalseColorInverse = new System.Windows.Forms.RadioButton();
            this.rbFalseColor = new System.Windows.Forms.RadioButton();
            this.lRunTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bFileRight_One = new System.Windows.Forms.Button();
            this.bFileLeft_One = new System.Windows.Forms.Button();
            this.bFileRight_All = new System.Windows.Forms.Button();
            this.bFileLeft_All = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbFilesRight = new System.Windows.Forms.ListBox();
            this.lbFilesLeft = new System.Windows.Forms.ListBox();
            this.tbZeroPhase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabView = new System.Windows.Forms.TabPage();
            this.label_zoomFactor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbZoom = new System.Windows.Forms.PictureBox();
            this.label_phase_min = new System.Windows.Forms.Label();
            this.label_phase_max = new System.Windows.Forms.Label();
            this.label_irradiance_max = new System.Windows.Forms.Label();
            this.label_irradiance_min = new System.Windows.Forms.Label();
            this.pbPhaseColorbar = new System.Windows.Forms.PictureBox();
            this.pbIrradianceColorbar = new System.Windows.Forms.PictureBox();
            this.label_phase_x_pos = new System.Windows.Forms.Label();
            this.label_phase_x_neg = new System.Windows.Forms.Label();
            this.label_phase_y_neg = new System.Windows.Forms.Label();
            this.label_phase_y_pos = new System.Windows.Forms.Label();
            this.label_irradiance_y_pos = new System.Windows.Forms.Label();
            this.label_irradiance_y_neg = new System.Windows.Forms.Label();
            this.label_irradiance_x_pos = new System.Windows.Forms.Label();
            this.label_irradiance_x_neg = new System.Windows.Forms.Label();
            this.lCurrentFile = new System.Windows.Forms.Label();
            this.pbIrradiance = new System.Windows.Forms.PictureBox();
            this.pbPhase = new System.Windows.Forms.PictureBox();
            this.bNext = new System.Windows.Forms.Button();
            this.bPrev = new System.Windows.Forms.Button();
            this.bView = new System.Windows.Forms.Button();
            this.bZoom = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhaseColorbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrradianceColorbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrradiance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhase)).BeginInit();
            this.SuspendLayout();
            // 
            // tbClose
            // 
            this.tbClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tbClose.Location = new System.Drawing.Point(471, 423);
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(75, 23);
            this.tbClose.TabIndex = 2;
            this.tbClose.Text = "Close";
            this.tbClose.UseVisualStyleBackColor = true;
            this.tbClose.Click += new System.EventHandler(this.tbClose_Click);
            // 
            // bRun
            // 
            this.bRun.Location = new System.Drawing.Point(616, 268);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 3;
            this.bRun.Text = "Generate";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Irradiance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Phase";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabView);
            this.tabControl1.Location = new System.Drawing.Point(28, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 370);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.rbGrayScale);
            this.tabSettings.Controls.Add(this.rbGrayScaleInverse);
            this.tabSettings.Controls.Add(this.rbFalseColorInverse);
            this.tabSettings.Controls.Add(this.rbFalseColor);
            this.tabSettings.Controls.Add(this.lRunTime);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.bRefresh);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.bFileRight_One);
            this.tabSettings.Controls.Add(this.bFileLeft_One);
            this.tabSettings.Controls.Add(this.bFileRight_All);
            this.tabSettings.Controls.Add(this.bFileLeft_All);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.lbFilesRight);
            this.tabSettings.Controls.Add(this.lbFilesLeft);
            this.tabSettings.Controls.Add(this.tbZeroPhase);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.bRun);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1126, 344);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // rbGrayScale
            // 
            this.rbGrayScale.AutoSize = true;
            this.rbGrayScale.Location = new System.Drawing.Point(60, 287);
            this.rbGrayScale.Name = "rbGrayScale";
            this.rbGrayScale.Size = new System.Drawing.Size(77, 17);
            this.rbGrayScale.TabIndex = 19;
            this.rbGrayScale.TabStop = true;
            this.rbGrayScale.Text = "Gray Scale";
            this.rbGrayScale.UseVisualStyleBackColor = true;
            this.rbGrayScale.CheckedChanged += new System.EventHandler(this.rbGrayScale_CheckedChanged);
            // 
            // rbGrayScaleInverse
            // 
            this.rbGrayScaleInverse.AutoSize = true;
            this.rbGrayScaleInverse.Location = new System.Drawing.Point(60, 309);
            this.rbGrayScaleInverse.Name = "rbGrayScaleInverse";
            this.rbGrayScaleInverse.Size = new System.Drawing.Size(115, 17);
            this.rbGrayScaleInverse.TabIndex = 18;
            this.rbGrayScaleInverse.TabStop = true;
            this.rbGrayScaleInverse.Text = "Inverse Gray Scale";
            this.rbGrayScaleInverse.UseVisualStyleBackColor = true;
            this.rbGrayScaleInverse.CheckedChanged += new System.EventHandler(this.rbGrayScaleInverse_CheckedChanged);
            // 
            // rbFalseColorInverse
            // 
            this.rbFalseColorInverse.AutoSize = true;
            this.rbFalseColorInverse.Location = new System.Drawing.Point(60, 265);
            this.rbFalseColorInverse.Name = "rbFalseColorInverse";
            this.rbFalseColorInverse.Size = new System.Drawing.Size(115, 17);
            this.rbFalseColorInverse.TabIndex = 17;
            this.rbFalseColorInverse.TabStop = true;
            this.rbFalseColorInverse.Text = "Inverse False Color";
            this.rbFalseColorInverse.UseVisualStyleBackColor = true;
            this.rbFalseColorInverse.CheckedChanged += new System.EventHandler(this.rbFalseColorInverse_CheckedChanged);
            // 
            // rbFalseColor
            // 
            this.rbFalseColor.AutoSize = true;
            this.rbFalseColor.Checked = true;
            this.rbFalseColor.Location = new System.Drawing.Point(60, 243);
            this.rbFalseColor.Name = "rbFalseColor";
            this.rbFalseColor.Size = new System.Drawing.Size(77, 17);
            this.rbFalseColor.TabIndex = 16;
            this.rbFalseColor.TabStop = true;
            this.rbFalseColor.Text = "False Color";
            this.rbFalseColor.UseVisualStyleBackColor = true;
            this.rbFalseColor.CheckedChanged += new System.EventHandler(this.rbFalseColor_CheckedChanged);
            // 
            // lRunTime
            // 
            this.lRunTime.AutoSize = true;
            this.lRunTime.Location = new System.Drawing.Point(554, 273);
            this.lRunTime.Name = "lRunTime";
            this.lRunTime.Size = new System.Drawing.Size(0, 13);
            this.lRunTime.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Run Time:";
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(237, 20);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 13;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Files to Generate";
            // 
            // bFileRight_One
            // 
            this.bFileRight_One.Location = new System.Drawing.Point(380, 77);
            this.bFileRight_One.Name = "bFileRight_One";
            this.bFileRight_One.Size = new System.Drawing.Size(30, 30);
            this.bFileRight_One.TabIndex = 11;
            this.bFileRight_One.Text = ">";
            this.bFileRight_One.UseVisualStyleBackColor = true;
            this.bFileRight_One.Click += new System.EventHandler(this.bFileRight_One_Click);
            // 
            // bFileLeft_One
            // 
            this.bFileLeft_One.Location = new System.Drawing.Point(344, 77);
            this.bFileLeft_One.Name = "bFileLeft_One";
            this.bFileLeft_One.Size = new System.Drawing.Size(30, 30);
            this.bFileLeft_One.TabIndex = 10;
            this.bFileLeft_One.Text = "<";
            this.bFileLeft_One.UseVisualStyleBackColor = true;
            this.bFileLeft_One.Click += new System.EventHandler(this.bFileLeft_One_Click);
            // 
            // bFileRight_All
            // 
            this.bFileRight_All.Location = new System.Drawing.Point(380, 158);
            this.bFileRight_All.Name = "bFileRight_All";
            this.bFileRight_All.Size = new System.Drawing.Size(30, 30);
            this.bFileRight_All.TabIndex = 9;
            this.bFileRight_All.Text = ">>";
            this.bFileRight_All.UseVisualStyleBackColor = true;
            this.bFileRight_All.Click += new System.EventHandler(this.bFileRight_All_Click);
            // 
            // bFileLeft_All
            // 
            this.bFileLeft_All.Location = new System.Drawing.Point(344, 158);
            this.bFileLeft_All.Name = "bFileLeft_All";
            this.bFileLeft_All.Size = new System.Drawing.Size(30, 30);
            this.bFileLeft_All.TabIndex = 8;
            this.bFileLeft_All.Text = "<<";
            this.bFileLeft_All.UseVisualStyleBackColor = true;
            this.bFileLeft_All.Click += new System.EventHandler(this.bFileLeft_All_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Zemax\\POP\\BEAMFILES";
            // 
            // lbFilesRight
            // 
            this.lbFilesRight.FormattingEnabled = true;
            this.lbFilesRight.Location = new System.Drawing.Point(441, 44);
            this.lbFilesRight.Name = "lbFilesRight";
            this.lbFilesRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFilesRight.Size = new System.Drawing.Size(250, 186);
            this.lbFilesRight.TabIndex = 6;
            // 
            // lbFilesLeft
            // 
            this.lbFilesLeft.FormattingEnabled = true;
            this.lbFilesLeft.Location = new System.Drawing.Point(62, 44);
            this.lbFilesLeft.Name = "lbFilesLeft";
            this.lbFilesLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFilesLeft.Size = new System.Drawing.Size(250, 186);
            this.lbFilesLeft.TabIndex = 6;
            // 
            // tbZeroPhase
            // 
            this.tbZeroPhase.Location = new System.Drawing.Point(591, 240);
            this.tbZeroPhase.Name = "tbZeroPhase";
            this.tbZeroPhase.Size = new System.Drawing.Size(100, 20);
            this.tbZeroPhase.TabIndex = 5;
            this.tbZeroPhase.Text = "0.001";
            this.tbZeroPhase.TextChanged += new System.EventHandler(this.tbZeroPhase_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zero Phase Below";
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.label_zoomFactor);
            this.tabView.Controls.Add(this.label7);
            this.tabView.Controls.Add(this.pbZoom);
            this.tabView.Controls.Add(this.label_phase_min);
            this.tabView.Controls.Add(this.label_phase_max);
            this.tabView.Controls.Add(this.label_irradiance_max);
            this.tabView.Controls.Add(this.label_irradiance_min);
            this.tabView.Controls.Add(this.pbPhaseColorbar);
            this.tabView.Controls.Add(this.pbIrradianceColorbar);
            this.tabView.Controls.Add(this.label_phase_x_pos);
            this.tabView.Controls.Add(this.label_phase_x_neg);
            this.tabView.Controls.Add(this.label_phase_y_neg);
            this.tabView.Controls.Add(this.label_phase_y_pos);
            this.tabView.Controls.Add(this.label_irradiance_y_pos);
            this.tabView.Controls.Add(this.label_irradiance_y_neg);
            this.tabView.Controls.Add(this.label_irradiance_x_pos);
            this.tabView.Controls.Add(this.label_irradiance_x_neg);
            this.tabView.Controls.Add(this.lCurrentFile);
            this.tabView.Controls.Add(this.pbIrradiance);
            this.tabView.Controls.Add(this.label2);
            this.tabView.Controls.Add(this.pbPhase);
            this.tabView.Controls.Add(this.label1);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(1126, 344);
            this.tabView.TabIndex = 0;
            this.tabView.Text = "View";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // label_zoomFactor
            // 
            this.label_zoomFactor.Location = new System.Drawing.Point(833, 312);
            this.label_zoomFactor.Name = "label_zoomFactor";
            this.label_zoomFactor.Size = new System.Drawing.Size(256, 23);
            this.label_zoomFactor.TabIndex = 25;
            this.label_zoomFactor.Text = " Zoom Factor: 1x";
            this.label_zoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(938, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Zoomed";
            // 
            // pbZoom
            // 
            this.pbZoom.BackColor = System.Drawing.Color.Transparent;
            this.pbZoom.Location = new System.Drawing.Point(833, 53);
            this.pbZoom.Name = "pbZoom";
            this.pbZoom.Size = new System.Drawing.Size(256, 256);
            this.pbZoom.TabIndex = 23;
            this.pbZoom.TabStop = false;
            // 
            // label_phase_min
            // 
            this.label_phase_min.AutoSize = true;
            this.label_phase_min.Location = new System.Drawing.Point(725, 296);
            this.label_phase_min.MinimumSize = new System.Drawing.Size(40, 0);
            this.label_phase_min.Name = "label_phase_min";
            this.label_phase_min.Size = new System.Drawing.Size(40, 13);
            this.label_phase_min.TabIndex = 22;
            this.label_phase_min.Text = "-3.14";
            this.label_phase_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_phase_min.Visible = false;
            // 
            // label_phase_max
            // 
            this.label_phase_max.AutoSize = true;
            this.label_phase_max.Location = new System.Drawing.Point(725, 53);
            this.label_phase_max.MinimumSize = new System.Drawing.Size(40, 0);
            this.label_phase_max.Name = "label_phase_max";
            this.label_phase_max.Size = new System.Drawing.Size(40, 13);
            this.label_phase_max.TabIndex = 21;
            this.label_phase_max.Text = "3.14";
            this.label_phase_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_phase_max.Visible = false;
            // 
            // label_irradiance_max
            // 
            this.label_irradiance_max.AutoSize = true;
            this.label_irradiance_max.Location = new System.Drawing.Point(326, 53);
            this.label_irradiance_max.MinimumSize = new System.Drawing.Size(40, 0);
            this.label_irradiance_max.Name = "label_irradiance_max";
            this.label_irradiance_max.Size = new System.Drawing.Size(40, 13);
            this.label_irradiance_max.TabIndex = 20;
            this.label_irradiance_max.Text = "-";
            this.label_irradiance_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_irradiance_max.Visible = false;
            // 
            // label_irradiance_min
            // 
            this.label_irradiance_min.AutoSize = true;
            this.label_irradiance_min.Location = new System.Drawing.Point(326, 296);
            this.label_irradiance_min.MinimumSize = new System.Drawing.Size(40, 0);
            this.label_irradiance_min.Name = "label_irradiance_min";
            this.label_irradiance_min.Size = new System.Drawing.Size(40, 13);
            this.label_irradiance_min.TabIndex = 19;
            this.label_irradiance_min.Text = "-";
            this.label_irradiance_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_irradiance_min.Visible = false;
            // 
            // pbPhaseColorbar
            // 
            this.pbPhaseColorbar.Location = new System.Drawing.Point(733, 69);
            this.pbPhaseColorbar.Name = "pbPhaseColorbar";
            this.pbPhaseColorbar.Size = new System.Drawing.Size(25, 224);
            this.pbPhaseColorbar.TabIndex = 18;
            this.pbPhaseColorbar.TabStop = false;
            this.pbPhaseColorbar.Visible = false;
            // 
            // pbIrradianceColorbar
            // 
            this.pbIrradianceColorbar.Image = ((System.Drawing.Image)(resources.GetObject("pbIrradianceColorbar.Image")));
            this.pbIrradianceColorbar.InitialImage = null;
            this.pbIrradianceColorbar.Location = new System.Drawing.Point(331, 69);
            this.pbIrradianceColorbar.Name = "pbIrradianceColorbar";
            this.pbIrradianceColorbar.Size = new System.Drawing.Size(25, 224);
            this.pbIrradianceColorbar.TabIndex = 17;
            this.pbIrradianceColorbar.TabStop = false;
            this.pbIrradianceColorbar.Visible = false;
            // 
            // label_phase_x_pos
            // 
            this.label_phase_x_pos.AutoSize = true;
            this.label_phase_x_pos.Location = new System.Drawing.Point(686, 321);
            this.label_phase_x_pos.Name = "label_phase_x_pos";
            this.label_phase_x_pos.Size = new System.Drawing.Size(10, 13);
            this.label_phase_x_pos.TabIndex = 16;
            this.label_phase_x_pos.Text = "-";
            // 
            // label_phase_x_neg
            // 
            this.label_phase_x_neg.AutoSize = true;
            this.label_phase_x_neg.Location = new System.Drawing.Point(465, 322);
            this.label_phase_x_neg.Name = "label_phase_x_neg";
            this.label_phase_x_neg.Size = new System.Drawing.Size(10, 13);
            this.label_phase_x_neg.TabIndex = 15;
            this.label_phase_x_neg.Text = "-";
            // 
            // label_phase_y_neg
            // 
            this.label_phase_y_neg.AutoSize = true;
            this.label_phase_y_neg.Location = new System.Drawing.Point(404, 296);
            this.label_phase_y_neg.Name = "label_phase_y_neg";
            this.label_phase_y_neg.Size = new System.Drawing.Size(10, 13);
            this.label_phase_y_neg.TabIndex = 14;
            this.label_phase_y_neg.Text = "-";
            // 
            // label_phase_y_pos
            // 
            this.label_phase_y_pos.AutoSize = true;
            this.label_phase_y_pos.Location = new System.Drawing.Point(404, 53);
            this.label_phase_y_pos.Name = "label_phase_y_pos";
            this.label_phase_y_pos.Size = new System.Drawing.Size(10, 13);
            this.label_phase_y_pos.TabIndex = 13;
            this.label_phase_y_pos.Text = "-";
            // 
            // label_irradiance_y_pos
            // 
            this.label_irradiance_y_pos.AutoSize = true;
            this.label_irradiance_y_pos.Location = new System.Drawing.Point(6, 53);
            this.label_irradiance_y_pos.Name = "label_irradiance_y_pos";
            this.label_irradiance_y_pos.Size = new System.Drawing.Size(10, 13);
            this.label_irradiance_y_pos.TabIndex = 12;
            this.label_irradiance_y_pos.Text = "-";
            // 
            // label_irradiance_y_neg
            // 
            this.label_irradiance_y_neg.AutoSize = true;
            this.label_irradiance_y_neg.Location = new System.Drawing.Point(6, 296);
            this.label_irradiance_y_neg.Name = "label_irradiance_y_neg";
            this.label_irradiance_y_neg.Size = new System.Drawing.Size(10, 13);
            this.label_irradiance_y_neg.TabIndex = 11;
            this.label_irradiance_y_neg.Text = "-";
            // 
            // label_irradiance_x_pos
            // 
            this.label_irradiance_x_pos.AutoSize = true;
            this.label_irradiance_x_pos.Location = new System.Drawing.Point(278, 323);
            this.label_irradiance_x_pos.Name = "label_irradiance_x_pos";
            this.label_irradiance_x_pos.Size = new System.Drawing.Size(10, 13);
            this.label_irradiance_x_pos.TabIndex = 10;
            this.label_irradiance_x_pos.Text = "-";
            // 
            // label_irradiance_x_neg
            // 
            this.label_irradiance_x_neg.AutoSize = true;
            this.label_irradiance_x_neg.Location = new System.Drawing.Point(53, 321);
            this.label_irradiance_x_neg.Name = "label_irradiance_x_neg";
            this.label_irradiance_x_neg.Size = new System.Drawing.Size(10, 13);
            this.label_irradiance_x_neg.TabIndex = 9;
            this.label_irradiance_x_neg.Text = "-";
            // 
            // lCurrentFile
            // 
            this.lCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCurrentFile.Location = new System.Drawing.Point(9, 8);
            this.lCurrentFile.Name = "lCurrentFile";
            this.lCurrentFile.Size = new System.Drawing.Size(746, 26);
            this.lCurrentFile.TabIndex = 8;
            this.lCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbIrradiance
            // 
            this.pbIrradiance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIrradiance.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbIrradiance.Location = new System.Drawing.Point(57, 53);
            this.pbIrradiance.Name = "pbIrradiance";
            this.pbIrradiance.Size = new System.Drawing.Size(256, 256);
            this.pbIrradiance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIrradiance.TabIndex = 0;
            this.pbIrradiance.TabStop = false;
            this.pbIrradiance.Click += new System.EventHandler(this.pbIrradiance_Click);
            this.pbIrradiance.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbIrradiance_MouseMove);
            this.pbIrradiance.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbIrradiance_MouseWheel);
            // 
            // pbPhase
            // 
            this.pbPhase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhase.Location = new System.Drawing.Point(464, 53);
            this.pbPhase.Name = "pbPhase";
            this.pbPhase.Size = new System.Drawing.Size(256, 256);
            this.pbPhase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhase.TabIndex = 1;
            this.pbPhase.TabStop = false;
            this.pbPhase.Click += new System.EventHandler(this.pbPhase_Click);
            this.pbPhase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPhase_MouseMove);
            this.pbPhase.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbPhase_MouseWheel);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(421, 423);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(23, 23);
            this.bNext.TabIndex = 7;
            this.bNext.Text = ">";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bPrev
            // 
            this.bPrev.Location = new System.Drawing.Point(371, 423);
            this.bPrev.Name = "bPrev";
            this.bPrev.Size = new System.Drawing.Size(23, 23);
            this.bPrev.TabIndex = 6;
            this.bPrev.Text = "<";
            this.bPrev.UseVisualStyleBackColor = true;
            this.bPrev.Click += new System.EventHandler(this.bPrev_Click);
            // 
            // bView
            // 
            this.bView.Location = new System.Drawing.Point(269, 423);
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(75, 23);
            this.bView.TabIndex = 7;
            this.bView.Text = "View";
            this.bView.UseVisualStyleBackColor = true;
            this.bView.Click += new System.EventHandler(this.bView_Click);
            // 
            // bZoom
            // 
            this.bZoom.Location = new System.Drawing.Point(712, 423);
            this.bZoom.Name = "bZoom";
            this.bZoom.Size = new System.Drawing.Size(75, 23);
            this.bZoom.TabIndex = 8;
            this.bZoom.Text = "Zoom";
            this.bZoom.UseVisualStyleBackColor = true;
            this.bZoom.Click += new System.EventHandler(this.bZoom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 465);
            this.Controls.Add(this.bZoom);
            this.Controls.Add(this.bView);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbClose);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.bPrev);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "ZBF Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.tabView.ResumeLayout(false);
            this.tabView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhaseColorbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrradianceColorbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrradiance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIrradiance;
        private System.Windows.Forms.PictureBox pbPhase;
        private System.Windows.Forms.Button tbClose;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bPrev;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button bView;
        private System.Windows.Forms.Button bFileRight_One;
        private System.Windows.Forms.Button bFileLeft_One;
        private System.Windows.Forms.Button bFileRight_All;
        private System.Windows.Forms.Button bFileLeft_All;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbFilesRight;
        private System.Windows.Forms.ListBox lbFilesLeft;
        private System.Windows.Forms.TextBox tbZeroPhase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lCurrentFile;
        private System.Windows.Forms.Label label_phase_x_pos;
        private System.Windows.Forms.Label label_phase_x_neg;
        private System.Windows.Forms.Label label_phase_y_neg;
        private System.Windows.Forms.Label label_phase_y_pos;
        private System.Windows.Forms.Label label_irradiance_y_pos;
        private System.Windows.Forms.Label label_irradiance_y_neg;
        private System.Windows.Forms.Label label_irradiance_x_pos;
        private System.Windows.Forms.Label label_irradiance_x_neg;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label lRunTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbIrradianceColorbar;
        private System.Windows.Forms.PictureBox pbPhaseColorbar;
        private System.Windows.Forms.Label label_phase_min;
        private System.Windows.Forms.Label label_phase_max;
        private System.Windows.Forms.Label label_irradiance_max;
        private System.Windows.Forms.Label label_irradiance_min;
        private System.Windows.Forms.RadioButton rbGrayScale;
        private System.Windows.Forms.RadioButton rbGrayScaleInverse;
        private System.Windows.Forms.RadioButton rbFalseColorInverse;
        private System.Windows.Forms.RadioButton rbFalseColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbZoom;
        private System.Windows.Forms.Label label_zoomFactor;
        private System.Windows.Forms.Button bZoom;
    }
}