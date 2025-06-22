using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class FrmProductShow : Form
    {
        public FrmProductShow()
        {
            InitializeComponent();
        }
         
        // Method แปลงจาก binary เป็น Image
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

        private void getAllProductToLV()
        {
            // Connect String เพื่อเชื่อมต่อฐานข้อมูล ตามยี่ห้อของฐานข้อมูลที่ใช้
            string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True";
            // Create connection object ไปยังฐานข้อมูลที่ต้องการ
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open(); // เปิดการเชื่อมต่อกับฐานข้อมูล

                    // SELECT, INSERT, UPDATE, DELETE
                    // สร้างคำสั่ง SQL เพื่อดึงข้อมูลจากตาราง product_tb
                    string strSQL = "SELECT proId, proName, proPrice, proQuan, proUnit, proStatus, proImage FROM product_tb";

                    // สร้าง SqlCommand เพื่อรันคำสั่ง SQL
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {
                        // สร้าง DataTable แปลงจากเป็นก้อนมาเป็นตาราง
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // ตั้งค่าทั่วไปของ ListView
                        lvAllProduct.Items.Clear(); // ล้างข้อมูลเก่าใน ListView
                        lvAllProduct.Columns.Clear(); // ล้างคอลัมน์เก่าใน ListView
                        lvAllProduct.FullRowSelect = true; // เลือกแถวทั้งหมดเมื่อคลิกที่แถวใดแถวหนึ่ง
                        lvAllProduct.View = View.Details; // ตั้งค่าให้แสดงผลแบบรายละเอียด

                        // ตั้งค่าการแสดงรูปใน ListView
                        if (lvAllProduct.SmallImageList == null)
                        {
                            lvAllProduct.SmallImageList = new ImageList();
                            lvAllProduct.SmallImageList.ImageSize = new Size(50, 30); // กำหนดขนาดของรูปภาพ
                            lvAllProduct.SmallImageList.ColorDepth = ColorDepth.Depth32Bit; // กำหนดความลึกของสี
                        }
                        lvAllProduct.SmallImageList.Images.Clear(); // ล้างรูปภาพเก่าใน ImageList

                        // กำหนดรายละเอียดของ Column ใน ListView
                        lvAllProduct.Columns.Add("รูปภาพ", 100, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("รหัสสินค้า", 100, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("ชื่อสินค้า", 200, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("ราคา", 80, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("จำนวน", 80, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("หน่วย", 80, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่
                        lvAllProduct.Columns.Add("สถานะ", 120, HorizontalAlignment.Left); // เพิ่มคอลัมน์ใหม่

                        // LOOP เพื่อเพิ่มข้อมูลจาก DataTable ลงใน ListView
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(); // สร้าง item เก็บข้อมูลแต่ละรายการ
                            Image proImage = null; // ตัวแปรสำหรับเก็บรูปภาพ
                            if (dataRow["proImage"] != DBNull.Value) 
                            {
                                byte[] imgByte = (byte[])dataRow["proImage"];
                                // แปลงข้อมูลรูปภาพจากฐานข้อมูลเป็น byte array
                                proImage = convertByteArrayToImage(imgByte); // แปลง byte array เป็น Image
                            }

                            string imagekey = null;// ตัวแปรสำหรับเก็บ key ของรูปภาพ
                            if (proImage != null)
                            {
                                imagekey = $"pro_{dataRow["proId"]}"; // สร้าง key สำหรับรูปภาพ
                                lvAllProduct.SmallImageList.Images.Add(imagekey, proImage); // เพิ่มรูปภาพลงใน ImageList
                                item.ImageKey = imagekey; // กำหนด key ของรูปภาพให้กับ item
                            }
                            else 
                            {
                                item.ImageIndex = -1;
                            }

                            //เพิ่มรายการลงใน item ตามข้อมูลใน DataRow

                            item.SubItems.Add(dataRow["proId"].ToString());
                            item.SubItems.Add(dataRow["proName"].ToString());
                            item.SubItems.Add(dataRow["proPrice"].ToString());
                            item.SubItems.Add(dataRow["proQuan"].ToString());
                            item.SubItems.Add(dataRow["proUnit"].ToString());
                            item.SubItems.Add(dataRow["proStatus"].ToString());
                         

                            // เพิ่ม item ลงใน ListView
                            lvAllProduct.Items.Add(item);


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

        // Form load ทำงานทุกครั้งที่เปิดฟอร์ม
        private void FrmProductShow_Load(object sender, EventArgs e)
        {
            // ถึงข้อมูลจาก product_tb มาแสดงใน listView
            getAllProductToLV();


        }

        private void btnFrmProductCreate_Click(object sender, EventArgs e)
        {
            //เปิดแบบ Object ใหม่ 
            FrmProductCreate frmProductCreate = new FrmProductCreate(); // สร้าง instance ของฟอร์มใหม่
            //frm.Show(); // เปิดฟอร์มแบบไม่ modal (ไม่บล็อกฟอร์มปัจจุบัน)

            //เปิดแบบ Dialog
            frmProductCreate.ShowDialog();

            getAllProductToLV(); // เรียกใช้เมธอดเพื่อดึงข้อมูลใหม่จากฐานข้อมูลและแสดงใน ListView
        }

        private void lvAllProduct_ItemActivate(object sender, EventArgs e)
        {
            // double click ที่รายการใน ListView เพื่อเปิดฟอร์มแก้ไขข้อมูล (DialogShow)
            FrmProductUpDel frmProductUpDel = new FrmProductUpDel(
                int.Parse(lvAllProduct.SelectedItems[0].SubItems[1].Text) // ดึงรหัสสินค้า (proId) จากรายการที่เลือกใน ListView

            ); // สร้าง instance ของฟอร์มแก้ไขข้อมูล
            frmProductUpDel.ShowDialog();
            getAllProductToLV();
        }
    }
}
