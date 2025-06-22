using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class FrmProductCreate : Form
    {

        // สร้างตัวแปรเก็บรูปที่แปลงเป็น byte array ลง DB
        byte[] proImage;



        public FrmProductCreate()
        {
            InitializeComponent();
        }

        // Method แปลงจาก binary เป็น Image
        private byte[] convertImageToByteArray(Image image, ImageFormat imageFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, imageFormat);
                return ms.ToArray();
            }
        }

        private void btProImage_Click(object sender, EventArgs e)
        {
            // open file dialog เพื่อเลือกไฟล์รูปภาพ jpg, png
            // ถ้าเลือกไฟล์ได้ ให้แสดงรูปภาพใน pcbProImage
            // แปลงเป็น byte array เก็บไว้ในตัวแปรเพื่อใช้ในการบันทึกฐานข้อมูล
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\\"; // กำหนดโฟลเดอร์เริ่มต้น Drive C
            openFileDialog.Filter = "Image Files|*.jpg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // แสดงรูปภาพใน PictureBox
                pcbProImage.Image = Image.FromFile(openFileDialog.FileName);

                // ตรวจสอบ Formant ของรูปภาพ แล้วแปลงเป็น byte array
                if (pcbProImage.Image.RawFormat == ImageFormat.Jpeg)
                {
                    proImage = convertImageToByteArray(pcbProImage.Image, ImageFormat.Jpeg);
                }
                else
                {
                    proImage = convertImageToByteArray(pcbProImage.Image, ImageFormat.Png);
                }
            }
        }

        private void tbProPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Allow control keys (e.g., backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Allow only one dot
            if (e.KeyChar == '.')
            {
                if (tb.Text.Contains("."))
                {
                    e.Handled = true; // Reject second dot
                }
                return;
            }

            // Block all other characters
            e.Handled = true;
        }

        // Method Show WarningMessage
        private void showWarningMessage(string message)
        {
            MessageBox.Show(message, "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // Validate UI Inputs (WarningDialog) แล้วเอาข้อมูลบันทึกลงฐานข้อมูล
            // เสร็จแล้วปิดหน้าจอ FrmProductCreate และกลับไปที่ FrmProductShow
            if (proImage == null)
            {
                showWarningMessage("กรุณาเลือกรูปภาพสินค้า");
            }
            else if (tbProName.Text.Length == 0)
            {
                showWarningMessage("กรุณากรอกชื่อสินค้า");
            }
            else if (tbProPrice.Text.Length == 0)
            {
                showWarningMessage("กรุณากรอกราคาสินค้า");

            }
            else if (int.Parse(nudProQuan.Value.ToString()) <= 0)
            {
                showWarningMessage("จำนวนสินค้าต้องมากกว่า 0");
            }
            else if (tbProUnit.Text.Length == 0)
            {
                showWarningMessage("ป้อนหน่วยสินค้าด้วย");
            }
            else
            {
                // บันทึกลง DB 
                // สร้าง connection string ไปยังฐานข้อมูลที่ต้องการ
                string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True";

                // Create connection object ไปยังฐานข้อมูลที่ต้องการ
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open(); // เปิดการเชื่อมต่อกับฐานข้อมูล

                        // For Insert, Update, Delete
                        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                        // สร้างคำสั่ง SQL สำหรับการเพิ่มข้อมูลสินค้าใหม่
                        string strSQL = "INSERT INTO product_tb (proName, proPrice, proQuan, proUnit, proStatus, proImage, createAt, updateAt) " +
                                        "VALUES (@proName, @proPrice, @proQuan, @proUnit, @proStatus, @proImage, @createAt, @updateAt)";

                        // กำหนดค่าให้กับ Sql Parameters และสั่งให้คำสั่ง SQL ทำงาน
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.Parameters.Add("@proName", SqlDbType.NVarChar, 300).Value = tbProName.Text;
                            sqlCommand.Parameters.Add("@proPrice", SqlDbType.Float).Value = float.Parse(tbProPrice.Text);
                            sqlCommand.Parameters.Add("@proQuan", SqlDbType.Int).Value = int.Parse(nudProQuan.Value.ToString());
                            sqlCommand.Parameters.Add("@proUnit", SqlDbType.NVarChar, 50).Value = tbProUnit.Text;
                            if (rdoProStatusOn.Checked == true)
                            {
                                sqlCommand.Parameters.Add("@proStatus", SqlDbType.NVarChar, 50).Value = "พร้อมขาย";
                            }
                            else
                            {
                                sqlCommand.Parameters.Add("@proStatus", SqlDbType.NVarChar, 50).Value = "ไม่พร้อมขาย";

                            }
                            sqlCommand.Parameters.Add("@proImage", SqlDbType.Image).Value = proImage;
                            sqlCommand.Parameters.Add("@createAt", SqlDbType.Date).Value = DateTime.Now.Date;
                            sqlCommand.Parameters.Add("@updateAt", SqlDbType.Date).Value = DateTime.Now.Date;

                            // รันคำสั่ง SQL
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();


                            MessageBox.Show(Text = "บันทึกข้อมูลสินค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                    }
                    catch (Exception ex)
                    {
                        // ถ้าไม่สามารถเชื่อมต่อได้ ให้แสดงข้อความผิดพลาด
                        MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาลองใหม่หรือติดต่อ IT\n" + ex.Message);
                    }
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // Clear
            proImage = null;
            tbProName.Clear();
            tbProPrice.Clear();
            nudProQuan.Value = 0;
            tbProUnit.Clear();
            pcbProImage.Image = null;

        }
    }
}
