using MySql.Data.MySqlClient;
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

namespace miltonproject
{
    public partial class Form3 : Form
    {
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public Image ByteArrayToImage(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch
            {
                return null;
            }

        }
        // MySql kapcsolati lista 1 elem csak a public mivolta miatt kell
        List<MySql.Data.MySqlClient.MySqlConnection> dbConnections = new List<MySql.Data.MySqlClient.MySqlConnection>();
        List<UserId> userids = new List<UserId>();
        List<PictureBox> uppics = new List<PictureBox>();
        class UserId
        {
            public int Id { get; set; }
            public UserId(int id)
            {
                Id = id;
            }
        }
        public Form3(int id, MySql.Data.MySqlClient.MySqlConnection con)
        {
            InitializeComponent();
            //Valid kapcsolat esetén kapcsolódás
            dbConnections.Add(con);
            userids.Add(new UserId(id));
            var cmd = new MySqlCommand(@"SELECT * FROM `USERS` WHERE `ID` = " + id + ";", dbConnections.First());
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                var picture = new PictureBox();
                byte[] pic;
                if (Convert.IsDBNull(rdr["PIC"]))
                {
                    pic = null;
                }
                else
                {
                    pic = (byte[])rdr["PIC"];
                }
                picture.Image = ByteArrayToImage(pic);
                username.Text = rdr["NICK"].ToString();
                password.Text = rdr["PASS"].ToString();
                picture.Size = new Size(50, 50);
                panel_current.Controls.Add(picture);
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = "UPDATE `USERS` SET `NICK` = @UserNick, `PASS` = @UserPass, `PIC` = @UserImage WHERE `USERS`.`ID` = " + userids.First().Id.ToString() + ";";
                byte[] data = ImageToByteArray(uppics.First().Image);
                var paramUserImage = new MySqlParameter("@userImage", MySqlDbType.Blob, data.Length);
                var paramUserNick = new MySqlParameter("@userNick", MySqlDbType.VarChar, data.Length);
                var paramUserPass = new MySqlParameter("@userPass", MySqlDbType.VarChar, data.Length);
                paramUserImage.Value = data;
                paramUserNick.Value = username.Text;
                paramUserPass.Value = password.Text;
                cmd.Parameters.Add(paramUserImage);
                cmd.Parameters.Add(paramUserNick);
                cmd.Parameters.Add(paramUserPass);
                cmd.Connection = dbConnections.First();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show(@"Az adatok módosítása sikertelen: " + cmd.CommandText);
            }
            this.Hide();
            this.Close();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                var picture_new = new PictureBox();
                picture_new.Image = new Bitmap(opnfd.FileName);
                picture_new.Size = new Size(50, 50);
                uppics.Add(picture_new);
                panel_new.Controls.Add(picture_new);
            }

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM `USERS` WHERE `USERS`.`ID` = " + userids.First().Id.ToString() + ";";
                cmd.Connection = dbConnections.First();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show(@"Az adatok törlése sikertelen: " + cmd.CommandText);
            }
            this.Hide();
            this.Close();

        }
    }
}
