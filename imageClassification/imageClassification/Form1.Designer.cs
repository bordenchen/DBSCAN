using RDotNet;

namespace imageClassification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picturebox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btn_resize = new System.Windows.Forms.Button();
            this.btn_ptselect = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_crop = new System.Windows.Forms.Button();
            this.Makeselection = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_saveToFolder = new System.Windows.Forms.Button();
            this.btn_Kmeans = new System.Windows.Forms.Button();
            this.btn_land = new System.Windows.Forms.Button();
            this.btn_road = new System.Windows.Forms.Button();
            this.btn_grass = new System.Windows.Forms.Button();
            this.btn_river = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixel_select_mod = new System.Windows.Forms.ToolStripLabel();
            this.box_result = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Btn_ShowTree = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_DBSCAN = new System.Windows.Forms.Button();
            this.Btn_ShowResult = new System.Windows.Forms.Button();
            this.Btn_SqrKm = new System.Windows.Forms.Button();
            this.Btn_SqrDB = new System.Windows.Forms.Button();
            this.Btn_classified = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel1.Controls.Add(this.picturebox1);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.SplitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(780, 456);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 0;
            // 
            // picturebox1
            // 
            this.picturebox1.BackColor = System.Drawing.Color.Gainsboro;
            this.picturebox1.Location = new System.Drawing.Point(-2, 71);
            this.picturebox1.Name = "picturebox1";
            this.picturebox1.Size = new System.Drawing.Size(550, 407);
            this.picturebox1.TabIndex = 0;
            this.picturebox1.TabStop = false;
            this.picturebox1.Click += new System.EventHandler(this.picturebox1_Click);
            this.picturebox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.picturebox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.picturebox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(219, 545);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.trackBar1);
            this.tabPage1.Controls.Add(this.btn_resize);
            this.tabPage1.Controls.Add(this.btn_ptselect);
            this.tabPage1.Controls.Add(this.btn_undo);
            this.tabPage1.Controls.Add(this.btn_crop);
            this.tabPage1.Controls.Add(this.Makeselection);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(211, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tool";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(8, 350);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btn_resize
            // 
            this.btn_resize.Location = new System.Drawing.Point(3, 401);
            this.btn_resize.Name = "btn_resize";
            this.btn_resize.Size = new System.Drawing.Size(79, 23);
            this.btn_resize.TabIndex = 4;
            this.btn_resize.Text = "resize";
            this.btn_resize.UseVisualStyleBackColor = true;
            this.btn_resize.Click += new System.EventHandler(this.btn_resize_Click);
            // 
            // btn_ptselect
            // 
            this.btn_ptselect.Location = new System.Drawing.Point(88, 7);
            this.btn_ptselect.Name = "btn_ptselect";
            this.btn_ptselect.Size = new System.Drawing.Size(81, 23);
            this.btn_ptselect.TabIndex = 3;
            this.btn_ptselect.Text = "point select";
            this.btn_ptselect.UseVisualStyleBackColor = true;
            this.btn_ptselect.Click += new System.EventHandler(this.btn_ptselect_Click);
            // 
            // btn_undo
            // 
            this.btn_undo.Location = new System.Drawing.Point(88, 401);
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(81, 23);
            this.btn_undo.TabIndex = 2;
            this.btn_undo.Text = "Undo";
            this.btn_undo.UseVisualStyleBackColor = true;
            this.btn_undo.Click += new System.EventHandler(this.Btn_undo_Click);
            // 
            // btn_crop
            // 
            this.btn_crop.Location = new System.Drawing.Point(3, 35);
            this.btn_crop.Name = "btn_crop";
            this.btn_crop.Size = new System.Drawing.Size(79, 23);
            this.btn_crop.TabIndex = 1;
            this.btn_crop.Text = "Crop";
            this.btn_crop.UseVisualStyleBackColor = true;
            this.btn_crop.Click += new System.EventHandler(this.Btn_crop_Click);
            // 
            // Makeselection
            // 
            this.Makeselection.Location = new System.Drawing.Point(3, 7);
            this.Makeselection.Name = "Makeselection";
            this.Makeselection.Size = new System.Drawing.Size(79, 23);
            this.Makeselection.TabIndex = 0;
            this.Makeselection.Text = "Making Select";
            this.Makeselection.UseVisualStyleBackColor = true;
            this.Makeselection.Click += new System.EventHandler(this.Makeselection_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.Btn_classified);
            this.tabPage2.Controls.Add(this.Btn_SqrDB);
            this.tabPage2.Controls.Add(this.Btn_SqrKm);
            this.tabPage2.Controls.Add(this.Btn_ShowResult);
            this.tabPage2.Controls.Add(this.btn_DBSCAN);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Btn_ShowTree);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.btn_saveToFolder);
            this.tabPage2.Controls.Add(this.btn_Kmeans);
            this.tabPage2.Controls.Add(this.btn_land);
            this.tabPage2.Controls.Add(this.btn_road);
            this.tabPage2.Controls.Add(this.btn_grass);
            this.tabPage2.Controls.Add(this.btn_river);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(211, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "classified data";
            // 
            // btn_saveToFolder
            // 
            this.btn_saveToFolder.Location = new System.Drawing.Point(108, 6);
            this.btn_saveToFolder.Name = "btn_saveToFolder";
            this.btn_saveToFolder.Size = new System.Drawing.Size(91, 20);
            this.btn_saveToFolder.TabIndex = 5;
            this.btn_saveToFolder.Text = "save csv file ";
            this.btn_saveToFolder.UseVisualStyleBackColor = true;
            this.btn_saveToFolder.Click += new System.EventHandler(this.btn_saveToFolder_Click);
            // 
            // btn_Kmeans
            // 
            this.btn_Kmeans.Location = new System.Drawing.Point(8, 176);
            this.btn_Kmeans.Name = "btn_Kmeans";
            this.btn_Kmeans.Size = new System.Drawing.Size(94, 21);
            this.btn_Kmeans.TabIndex = 3;
            this.btn_Kmeans.Text = "Kmeans";
            this.btn_Kmeans.UseVisualStyleBackColor = true;
            this.btn_Kmeans.Click += new System.EventHandler(this.Btn_classified_Click);
            // 
            // btn_land
            // 
            this.btn_land.Location = new System.Drawing.Point(7, 84);
            this.btn_land.Name = "btn_land";
            this.btn_land.Size = new System.Drawing.Size(93, 20);
            this.btn_land.TabIndex = 0;
            this.btn_land.Text = "land";
            this.btn_land.UseVisualStyleBackColor = true;
            this.btn_land.Click += new System.EventHandler(this.Btn_land_Click);
            // 
            // btn_road
            // 
            this.btn_road.Location = new System.Drawing.Point(7, 58);
            this.btn_road.Name = "btn_road";
            this.btn_road.Size = new System.Drawing.Size(92, 20);
            this.btn_road.TabIndex = 2;
            this.btn_road.Text = "road";
            this.btn_road.UseVisualStyleBackColor = true;
            this.btn_road.Click += new System.EventHandler(this.Bt_road_Click);
            // 
            // btn_grass
            // 
            this.btn_grass.Location = new System.Drawing.Point(6, 32);
            this.btn_grass.Name = "btn_grass";
            this.btn_grass.Size = new System.Drawing.Size(92, 20);
            this.btn_grass.TabIndex = 1;
            this.btn_grass.Text = "grass";
            this.btn_grass.UseVisualStyleBackColor = true;
            this.btn_grass.Click += new System.EventHandler(this.Btn_grass_Click);
            // 
            // btn_river
            // 
            this.btn_river.Location = new System.Drawing.Point(6, 6);
            this.btn_river.Name = "btn_river";
            this.btn_river.Size = new System.Drawing.Size(92, 20);
            this.btn_river.TabIndex = 0;
            this.btn_river.Text = "river";
            this.btn_river.UseVisualStyleBackColor = true;
            this.btn_river.Click += new System.EventHandler(this.Bt_river_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(211, 519);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "pixel RGB value";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_R,
            this.col_G,
            this.col_B,
            this.col_Class});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(208, 431);
            this.dataGridView1.TabIndex = 0;
            // 
            // col_R
            // 
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.col_R.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_R.HeaderText = "R";
            this.col_R.Name = "col_R";
            // 
            // col_G
            // 
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.col_G.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_G.HeaderText = "G";
            this.col_G.Name = "col_G";
            // 
            // col_B
            // 
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.col_B.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_B.HeaderText = "B";
            this.col_B.Name = "col_B";
            // 
            // col_Class
            // 
            this.col_Class.HeaderText = "class";
            this.col_Class.Name = "col_Class";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.pixel_select_mod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.File.Image = ((System.Drawing.Image)(resources.GetObject("File.Image")));
            this.File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(38, 22);
            this.File.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pixel_select_mod
            // 
            this.pixel_select_mod.Name = "pixel_select_mod";
            this.pixel_select_mod.Size = new System.Drawing.Size(86, 22);
            this.pixel_select_mod.Text = "toolStripLabel1";
            // 
            // box_result
            // 
            this.box_result.FormattingEnabled = true;
            this.box_result.HorizontalScrollbar = true;
            this.box_result.ItemHeight = 12;
            this.box_result.Location = new System.Drawing.Point(0, 483);
            this.box_result.Name = "box_result";
            this.box_result.ScrollAlwaysVisible = true;
            this.box_result.Size = new System.Drawing.Size(777, 64);
            this.box_result.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "River",
            "Grass",
            "Road",
            "Land"});
            this.comboBox1.Location = new System.Drawing.Point(106, 336);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 20);
            this.comboBox1.TabIndex = 6;
            // 
            // Btn_ShowTree
            // 
            this.Btn_ShowTree.Location = new System.Drawing.Point(8, 150);
            this.Btn_ShowTree.Name = "Btn_ShowTree";
            this.Btn_ShowTree.Size = new System.Drawing.Size(114, 20);
            this.Btn_ShowTree.TabIndex = 7;
            this.Btn_ShowTree.Text = "show decision Tree";
            this.Btn_ShowTree.UseVisualStyleBackColor = true;
            this.Btn_ShowTree.Click += new System.EventHandler(this.Btn_ShowTree_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Layer";
            // 
            // btn_DBSCAN
            // 
            this.btn_DBSCAN.Location = new System.Drawing.Point(111, 176);
            this.btn_DBSCAN.Name = "btn_DBSCAN";
            this.btn_DBSCAN.Size = new System.Drawing.Size(94, 21);
            this.btn_DBSCAN.TabIndex = 9;
            this.btn_DBSCAN.Text = "DBSCAN";
            this.btn_DBSCAN.UseVisualStyleBackColor = true;
            this.btn_DBSCAN.Click += new System.EventHandler(this.btn_DBSCAN_Click);
            // 
            // Btn_ShowResult
            // 
            this.Btn_ShowResult.Location = new System.Drawing.Point(6, 371);
            this.Btn_ShowResult.Name = "Btn_ShowResult";
            this.Btn_ShowResult.Size = new System.Drawing.Size(94, 21);
            this.Btn_ShowResult.TabIndex = 10;
            this.Btn_ShowResult.Text = "Plot_Image";
            this.Btn_ShowResult.UseVisualStyleBackColor = true;
            this.Btn_ShowResult.Click += new System.EventHandler(this.Btn_ShowResult_Click);
            // 
            // Btn_SqrKm
            // 
            this.Btn_SqrKm.Location = new System.Drawing.Point(8, 203);
            this.Btn_SqrKm.Name = "Btn_SqrKm";
            this.Btn_SqrKm.Size = new System.Drawing.Size(94, 21);
            this.Btn_SqrKm.TabIndex = 11;
            this.Btn_SqrKm.Text = "Kmeans Sqr";
            this.Btn_SqrKm.UseVisualStyleBackColor = true;
            this.Btn_SqrKm.Click += new System.EventHandler(this.Btn_SqrKm_Click);
            // 
            // Btn_SqrDB
            // 
            this.Btn_SqrDB.Location = new System.Drawing.Point(111, 203);
            this.Btn_SqrDB.Name = "Btn_SqrDB";
            this.Btn_SqrDB.Size = new System.Drawing.Size(94, 21);
            this.Btn_SqrDB.TabIndex = 12;
            this.Btn_SqrDB.Text = "DBSCAN Sqr";
            this.Btn_SqrDB.UseVisualStyleBackColor = true;
            this.Btn_SqrDB.Click += new System.EventHandler(this.Btn_SqrDB_Click);
            // 
            // Btn_classified
            // 
            this.Btn_classified.Location = new System.Drawing.Point(8, 230);
            this.Btn_classified.Name = "Btn_classified";
            this.Btn_classified.Size = new System.Drawing.Size(94, 21);
            this.Btn_classified.TabIndex = 13;
            this.Btn_classified.Text = "Classified";
            this.Btn_classified.UseVisualStyleBackColor = true;
            this.Btn_classified.Click += new System.EventHandler(this.Btn_classified_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 546);
            this.Controls.Add(this.box_result);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox picturebox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton File;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_crop;
        private System.Windows.Forms.Button Makeselection;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_road;
        private System.Windows.Forms.Button btn_grass;
        private System.Windows.Forms.Button btn_river;
        private System.Windows.Forms.Button btn_land;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_Kmeans;
        private System.Windows.Forms.ListBox box_result;
        private System.Windows.Forms.Button btn_ptselect;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_G;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Class;
        private System.Windows.Forms.Button btn_resize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btn_saveToFolder;
        private System.Windows.Forms.ToolStripLabel pixel_select_mod;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_DBSCAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_ShowTree;
        private System.Windows.Forms.Button Btn_ShowResult;
        private System.Windows.Forms.Button Btn_SqrDB;
        private System.Windows.Forms.Button Btn_SqrKm;
        private System.Windows.Forms.Button Btn_classified;
    }
}

