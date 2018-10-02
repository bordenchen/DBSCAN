using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;

namespace imageClassification
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = 0.ToString();
            pixel_select_mod.Text = "";
            btn_DBSCAN.Enabled = false;
            btn_Kmeans.Enabled = false;
            Btn_ShowResult.Enabled = false;
            Btn_ShowTree.Enabled = false;
            Btn_SqrKm.Enabled = false;
            Btn_SqrDB.Enabled = false;
            Btn_classified.Enabled = false;
        }
        private Image Img;
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        int X_coordinate;
        int Y_coordinate;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        private Size ModifiedImageSize;
        private Size OriginalImageSize;
        public bool Makingselection = false;
        public bool CreateText = false;
        public bool pt_select = false;
        string SelectImg;

        REngine en = REngine.GetInstance();
       
        class YourItem
        {
            public string messageID { get; set; }
            public string Information { get; set; }
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)

        {

            OpenFileDialog Dlg = new OpenFileDialog
            {
                Filter = "",

                Title = "Select image"
            };

            if (Dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)

            {

                Img = Image.FromFile(Dlg.FileName);
                SelectImg = Dlg.FileName;
                btn_DBSCAN.Enabled = true;
                btn_Kmeans.Enabled = true;
                Btn_ShowResult.Enabled = true;
                Btn_ShowTree.Enabled = true;
                Btn_SqrKm.Enabled = true;
                Btn_SqrDB.Enabled = true;
                Btn_classified.Enabled = true;
                //Image.FromFile(String) method creates an image from the specifed file, here dlg.Filename contains the name of the file from which to create the image

                LoadImage();

            }
        }
        private void LoadImage()

        {

            //we set the picturebox size according to image, we can get image width and height with the help of Image.Width and Image.height properties.

            int imgWidth = Img.Width;

            int imghieght = Img.Height;

            picturebox1.Width = imgWidth;
            picturebox1.Height = imghieght;

            OriginalImageSize.Width = imgWidth;
            OriginalImageSize.Height = imghieght;

            picturebox1.Image = Img;

            PictureBoxLocation();

        }
        private void PictureBoxLocation()

        {

            int _x = 0;

            int _y = 0;

            if (splitContainer1.Panel1.Width > picturebox1.Width)
            {
                _x = (splitContainer1.Panel1.Width - picturebox1.Width) / 2;
            }

            if (splitContainer1.Panel1.Height > picturebox1.Height)

            {
                _y = (splitContainer1.Panel1.Height - picturebox1.Height) / 2;
            }

            picturebox1.Location = new Point(_x, _y);
        }
        private void SplitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            PictureBoxLocation();
        }
        private void Makeselection_Click(object sender, EventArgs e)
        {
            Makingselection = true;
            picturebox1.Enabled = true;
        }
        private void Btn_crop_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(picturebox1.Image, picturebox1.Width, picturebox1.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinf image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                picturebox1.Image = _img;
                picturebox1.Width = _img.Width;
                picturebox1.Height = _img.Height;
                PictureBoxLocation();
                picturebox1.Enabled = false;
                OriginalImageSize.Width = picturebox1.Width;
                OriginalImageSize.Height = picturebox1.Height;
            }
            catch (Exception ex)
            {
            }
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                if (Makingselection)
                {

                    try
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            Cursor = Cursors.Cross;
                            cropX = e.X;
                            cropY = e.Y;

                            cropPen = new Pen(Color.Black, 1)
                            {
                                DashStyle = DashStyle.DashDotDot
                            };


                        }
                        picturebox1.Refresh();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }


        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makingselection)
            {
                Cursor = Cursors.Default;
            }

        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 4)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                if (Makingselection)
                {

                    try
                    {
                        if (picturebox1.Image == null)
                            return;


                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            picturebox1.Refresh();
                            cropWidth = e.X - cropX;
                            cropHeight = e.Y - cropY;
                            picturebox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                        }



                    }
                    catch (Exception ex)
                    {
                        //if (ex.Number == 5)
                        //    return;
                    }
                }
            }

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private double[] Get_PixelColor()
        {
            try
            {
                Bitmap default_image = new Bitmap(picturebox1.Image);
                Color pixelColor = default_image.GetPixel(X_coordinate, Y_coordinate);
                double R = Convert.ToDouble(pixelColor.R) / 257;
                double G = Convert.ToDouble(pixelColor.G) / 257;
                double B = Convert.ToDouble(pixelColor.B) / 257;
                double[] data = new double[] { R, G, B };
                return data;
            }
            catch (Exception ex)
            {

                double[] data = new double[] { 999, 999, 999 };
                return data;

            }
        }
        private void Bt_river_Click(object sender, EventArgs e)
        {

            try
            {
                double[] RGB_Data = Get_PixelColor();
                if (RGB_Data[1] == 999)
                {
                    throw new System.Exception("error while adding row to DataGridView");
                }
                else
                {
                    dataGridView1.Rows.Add(RGB_Data[0], RGB_Data[1], RGB_Data[2], "River");
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.ValueMember = "messageID";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString(),
                    messageID = "coordinate"

                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }

            //picturebox1.Image.Save(@"C:\Users\USER\Desktop\dataprocessing\river.jpg", ImageFormat.Jpeg);
        }
        private void Bt_road_Click(object sender, EventArgs e)
        {
            try
            {
                double[] RGB_Data = Get_PixelColor();
                if (RGB_Data[1] == 999)
                {
                    throw new System.Exception("error while adding row to DataGridView");
                }
                else
                {
                    dataGridView1.Rows.Add(RGB_Data[0], RGB_Data[1], RGB_Data[2], "Road");
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.ValueMember = "messageID";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString(),
                    messageID = "coordinate"

                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
            //picturebox1.Image.Save(@"C:\Users\USER\Desktop\dataprocessing\road.jpg", ImageFormat.Jpeg);
        }

        private void Btn_grass_Click(object sender, EventArgs e)
        {
            try
            {
                double[] RGB_Data = Get_PixelColor();
                if (RGB_Data[1] == 999)
                {
                    throw new System.Exception("error while adding row to DataGridView");
                }
                else
                {
                    dataGridView1.Rows.Add(RGB_Data[0], RGB_Data[1], RGB_Data[2], "Grass");
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.ValueMember = "messageID";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString(),
                    messageID = "coordinate"

                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
            //picturebox1.Image.Save(@"C:\Users\USER\Desktop\dataprocessing\grass.jpg", ImageFormat.Jpeg);
        }

        private void Btn_land_Click(object sender, EventArgs e)
        {
            try
            {
                double[] RGB_Data = Get_PixelColor();
                if (RGB_Data[1] == 999)
                {
                    throw new System.Exception("error while adding row to DataGridView");
                }
                else
                {
                    dataGridView1.Rows.Add(RGB_Data[0], RGB_Data[1], RGB_Data[2], "Land");
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.ValueMember = "messageID";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString(),
                    messageID = "coordinate"

                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
            //picturebox1.Image.Save(@"C:\Users\USER\Desktop\dataprocessing\land.jpg", ImageFormat.Jpeg);
        }

        private void Btn_undo_Click(object sender, EventArgs e)
        {
            try
            {
       
                int imgWidth = Img.Width;
                int imghieght = Img.Height;
                picturebox1.Width = imgWidth;
                picturebox1.Height = imghieght;
                OriginalImageSize.Width = picturebox1.Width;
                OriginalImageSize.Height = picturebox1.Height;
                picturebox1.Image = Img;
                PictureBoxLocation();
            }
            catch (Exception ex)
            {
                //if (ex.Number == 5)
                //    return;
            }
        }

        private void Btn_classified_Click(object sender, EventArgs e)
        {
            
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/kmeans.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";
            var ImgPath = SelectImg;
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[2] { csvPath, ImgPath };
            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now+ "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
            }
            catch(Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
            
        }

       


        private void picturebox1_Click(object sender, EventArgs e)
        {

            if (pt_select == true)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                X_coordinate = coordinates.X;
                Y_coordinate = coordinates.Y;

                box_result.DisplayMember = "Information";
                box_result.ValueMember = "messageID";
                box_result.Items.Add(new YourItem
                {
                    Information = "---" + System.DateTime.Now + "---" + Convert.ToString(coordinates),
                    messageID = "coordinate"

                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
          
            }

        }

        private void btn_ptselect_Click(object sender, EventArgs e)
        {
            pt_select = !pt_select;
            if(pt_select)
            {
                pixel_select_mod.Text = "pixel select mod on";
            }
            else
            {
                pixel_select_mod.Text = "";
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();

            ModifiedImageSize.Height = Convert.ToInt32(OriginalImageSize.Height * (trackBar1.Value * 0.1) + OriginalImageSize.Height);
            ModifiedImageSize.Width = Convert.ToInt32(OriginalImageSize.Width * (trackBar1.Value * 0.1) + OriginalImageSize.Width);



        }
        private void btn_resize_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm_source = new Bitmap(picturebox1.Image);
                // Make a bitmap for the result.
                Bitmap bm_dest = new Bitmap(Convert.ToInt32(ModifiedImageSize.Width), Convert.ToInt32(ModifiedImageSize.Height));
                // Make a Graphics object for the result Bitmap.
                Graphics gr_dest = Graphics.FromImage(bm_dest);
                // Copy the source image into the destination bitmap.
                gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height);
                // Display the result.
                picturebox1.Image = bm_dest;
                picturebox1.Width = bm_dest.Width;
                picturebox1.Height = bm_dest.Height;
                PictureBoxLocation();
            }
            catch (Exception ex)
            {

            }

        }


        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();

            }
        }
        private void btn_saveToFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string csv_File_Name = "result.csv";
                string directory = "C:/Users/USER/Desktop/dataprocessing/";
                System.IO.File.Delete(directory + csv_File_Name);
                writeCSV(dataGridView1, directory + csv_File_Name);


                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + "Successfully generate csv file"
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
            catch(Exception ex)
            {

                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }
        }

        private void btn_DBSCAN_Click(object sender, EventArgs e)
        {
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/DBSCAN.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";
            var ImgPath = SelectImg;
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[2] { csvPath, ImgPath };

            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);

                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }

            
            
        }

        private void Btn_ShowTree_Click(object sender, EventArgs e)
        {
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/plot_rule.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";           
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[1] { csvPath};
            
            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);

                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }


        }

        private void Btn_ShowResult_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/plot_cluster.R";
                var classified_data = "C:/Users/USER/Desktop/dataprocessing/classified_data.csv";
                var comboBox_Text = comboBox1.SelectedItem.ToString();
                var execution = "source('" + scriptFilePath + "')";
                var args_r = new string[1] { comboBox_Text };

                try
                {
                    if (System.IO.File.Exists(classified_data) ? true : false)
                    {
                        en.SetCommandLineArguments(args_r);
                        en.Evaluate(execution);
                        box_result.DisplayMember = "Information";
                        box_result.Items.Add(new YourItem
                        {
                            Information = System.DateTime.Now + "Success: data process"
                        });
                        box_result.SelectedIndex = box_result.Items.Count - 1;
                    }
                    else
                    {
                        box_result.DisplayMember = "Information";
                        box_result.Items.Add(new YourItem
                        {
                            Information = System.DateTime.Now + "Error: result.csv not exit"
                        });
                        box_result.SelectedIndex = box_result.Items.Count - 1;
                    }

                }
                catch (Exception ex)
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + ex.Message.ToString()
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
            }
           

        }

        private void Btn_SqrKm_Click(object sender, EventArgs e)
        {
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/kmeans_square.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";
            var ImgPath = SelectImg;
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[2] { csvPath, ImgPath };

            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);

                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }


        }

        private void Btn_SqrDB_Click(object sender, EventArgs e)
        {
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/DBSCAN_square.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";
            var ImgPath = SelectImg;
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[2] { csvPath, ImgPath };

            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            en.ClearGlobalEnvironment();
        }

        private void Btn_classified_Click_1(object sender, EventArgs e)
        {
            var scriptFilePath = "C:/Users/USER/Desktop/dataprocessing/classified.R";
            var csvPath = "C:/Users/USER/Desktop/dataprocessing/result.csv";
            var ImgPath = SelectImg;
            var execution = "source('" + scriptFilePath + "')";
            var args_r = new string[2] { csvPath, ImgPath };

            try
            {
                if (System.IO.File.Exists(csvPath) ? true : false)
                {
                    en.SetCommandLineArguments(args_r);
                    en.Evaluate(execution);
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Success: data process"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }
                else
                {
                    box_result.DisplayMember = "Information";
                    box_result.Items.Add(new YourItem
                    {
                        Information = System.DateTime.Now + "Error: result.csv not exit"
                    });
                    box_result.SelectedIndex = box_result.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                box_result.DisplayMember = "Information";
                box_result.Items.Add(new YourItem
                {
                    Information = System.DateTime.Now + ex.Message.ToString()
                });
                box_result.SelectedIndex = box_result.Items.Count - 1;
            }

        }
    }
}
