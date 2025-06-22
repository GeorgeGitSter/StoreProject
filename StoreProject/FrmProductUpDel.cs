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
    public partial class FrmProductUpDel : Form
    {

        // สร้างตัวแปรเก็บ proId ที่เลือกจาก ListView
        int proId;

        // สร้างตัวแปรเก็บรูปที่แปลงเป็น byte array ลง DB
        byte[] proImage;


        public FrmProductUpDel(int proId)
        {
            InitializeComponent();
            this.proId = proId;
        }

        private Image convertByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                // อาจเกิดขึ้นถ้า byte array ไม่ใช่ข้อมูลรูปภาพที่ถูกต้อง
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                return null;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductUpDel_Load(object sender, EventArgs e)
        {
            // เอา proId ที่ส่งมาไปค้นในฐานข้อมูล แล้วเอามาแสดง เพื่อแก้ไขหรือลบข้อมูล
            // Connect String เพื่อเชื่อมต่อฐานข้อมูล ตามยี่ห้อของฐานข้อมูลที่ใช้
            string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True";
            // Create connection object ไปยังฐานข้อมูลที่ต้องการ
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open(); // เปิดการเชื่อมต่อกับฐานข้อมูล


                    // สร้างคำสั่ง SQL เพื่อดึงข้อมูลจากตาราง product_tb
                    string strSQL = "SELECT proId, proName, proPrice, proQuan, proUnit, proStatus, proImage FROM product_tb " +
                                    "WHERE proId = @proId";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {
                        // กำหนดพารามิเตอร์ proId ให้กับคำสั่ง SQL
                        //dataAdapter.SelectCommand.Parameters.AddWithValue("@proId", proId);
                        dataAdapter.SelectCommand.Parameters.Add("@proId", SqlDbType.Int).Value = proId;

                        // สร้าง DataTable แปลงจากเป็นก้อนมาเป็นตาราง
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // เอาข้อมูงขาก DataTable มาใช้โดยใส่ไว้ใน DataRow
                        DataRow row = dataTable.Rows[0];

                        // เอาข้อมูลใน DataRow มาใช้งาน
                        tbProId.Text = row["proId"].ToString();
                        tbProName.Text = row["proName"].ToString();
                        tbProPrice.Text = row["proPrice"].ToString();
                        tbProUnit.Text = row["proUnit"].ToString();
                        nudProQuan.Value = int.Parse(row["proQuan"].ToString());
                        if (row["proStatus"].ToString() == "พร้อมขาย")
                        {
                            rdoProStatusOn.Checked = true;
                        }
                        else
                        {
                            rdoProStatusOff.Checked = true;
                        }
                        // เอารูปมาแสดงใน PictureBox โดยแปลงจาก byte array เป็น Image

                        if (row["proImage"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])row["proImage"];
                            pcbProImage.Image = convertByteArrayToImage(imageBytes);
                            proImage = imageBytes; // แก้ไขตรงนี้
                        }
                        else
                        {
                            pcbProImage.Image = null;
                            proImage = null; // ไม่มีรูปจริง ๆ
                        }

                    }


                }
                catch (Exception ex)
                {
                    // ถ้าไม่สามารถเชื่อมต่อได้ ให้แสดงข้อความผิดพลาด
                    MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาลองใหม่หรือติดต่อ IT\n" + ex.Message);
                }
            }

        }

        private void btProDelete_Click(object sender, EventArgs e)
        {
            // ลบข้อมูลจากฐานข้อมูลตาม proId ที่เลือก

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
                    string strSQL = "DELETE FROM product_tb WHERE proId=@proId";

                    // กำหนดค่าให้กับ Sql Parameters และสั่งให้คำสั่ง SQL ทำงาน
                    using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                    {
                        sqlCommand.Parameters.Add("@proId", SqlDbType.Int).Value = int.Parse(tbProId.Text);

                        // รันคำสั่ง SQL
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();


                        MessageBox.Show(Text = "ลบข้อมูลสินค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close(); // ปิดหน้าต่างนี้หลังจากลบข้อมูลเรียบร้อยแล้ว
                    }

                }
                catch (Exception ex)
                {
                    // ถ้าไม่สามารถเชื่อมต่อได้ ให้แสดงข้อความผิดพลาด
                    MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาลองใหม่หรือติดต่อ IT\n" + ex.Message);
                }
            }


        }

        private void showWarningMessage(string message)
        {
            MessageBox.Show(message, "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btProUpdate_Click(object sender, EventArgs e)
        {
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
                        string strSQL = "UPDATE product_tb SET " +
                                        "proName = @proName, " +
                                        "proPrice = @proPrice, " +
                                        "proQuan = @proQuan, " +
                                        "proUnit = @proUnit, " +
                                        "proStatus = @proStatus, " +
                                        "proImage = @proImage, " +
                                        "updateAt = @updateAt " +  // อัปเดตเฉพาะ updateAt ไม่ควรเปลี่ยน createAt
                                        "WHERE proId = @proId";

                        // กำหนดค่าให้กับ Sql Parameters และสั่งให้คำสั่ง SQL ทำงาน
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.Parameters.Add("@proId", SqlDbType.Int).Value = int.Parse(tbProId.Text);
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
                            sqlCommand.Parameters.Add("@updateAt", SqlDbType.Date).Value = DateTime.Now.Date;

                            // รันคำสั่ง SQL
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();


                            MessageBox.Show(Text = "บันทึกแก้ไขข้อมูลสินค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
