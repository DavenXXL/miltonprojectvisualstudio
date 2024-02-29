using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace miltonproject
{
    public partial class Form1 : Form
    {
        // MySql kapcsolati lista 1 elem csak a public mivolta miatt kell
        List<MySql.Data.MySqlClient.MySqlConnection> dbConnections = new List<MySql.Data.MySqlClient.MySqlConnection>();
        
        // Sql Parancsok lisája
        List<SqlCommand> sqlCommands = new List<SqlCommand>();
        
        // Felhasználók listája
        List<User> users = new List<User>();
        
        List<Conninfo> css = new List<Conninfo>();

        class Conninfo
        {
            public string Cs { get; set; }
            public Conninfo(string cs)
            {
                Cs = cs;
            }
        }
        class User
        {
            //User Tábla Id oszlop auto increment
            public int Id { get; set; }
            //User Tábla felhasználó név
            public string Nick { get; set; }
            //Profilkép byte formátum
            public byte[] Bloob { get; set; }
            public User(int id, string nick, byte[] bloob)
            {
                Id = id;
                Nick = nick;
                Bloob = bloob;
            }
        }
        class SqlCommand
        {
            //Parancs funkciójának rövid leirasa/neve
            public string Function { get; set; }
            
            //Sql parancs
            public string Code { get; set; }
            public SqlCommand(string function, string code)
            {
                Function = function;
                Code = code;
            }
        }
        
        //User tábla PIC Bloobjainak byte formátummá való konvertálása
        public Image ByteArrayToImage(byte[] data)
        {
            try {
                MemoryStream ms = new MemoryStream(data);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch {
                return null;
            }
            
        }
        public Form1(string cs)
        {
            InitializeComponent();
            var dbinit = new SqlCommand("init_create", "CREATE TABLE `USERS` ( `ID` INT(8) NOT NULL AUTO_INCREMENT , `NICK` VARCHAR(16) NOT NULL , `PASS` VARCHAR(32) NOT NULL , `PIC` LONGBLOB NULL , PRIMARY KEY (`ID`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_hungarian_ci;");
            var masterprofinit = new SqlCommand("master_insert", "INSERT INTO `USERS` (`ID`, `NICK`, `PASS`, `PIC`) VALUES (NULL, 'Master', 'fres2546', 0x89504e470d0a1a0a0000000d494844520000003000000030080300000060dc09b500000300504c544547704cbc0202da0101b50101af0101c00101980000a20707b00303980404b60909bd00005d1313c40202a70000a40d0d930101dd1616890303c802029d0000d401019308086c0606bd0b0cdc5858ea00009605059f0303a70202ab1313ba0000af0909a200005a0202a20707a50f0fe701029d0000a60808b91a1acd0c0ca30101b2121218191ad13f3fd356569f0000020101dc0404a105059e0101a30101700101a40c0cf20000a60000f10000a301019b0a0aa40303e500006e0101fd00008e0000a30000b20202e40303cb4a4abd0404fa0505d131319d0101e10505070000c20000c34c4cb50101a30909e70909c00000bf21219d0101f90c0c670202d10808b00202b61616880505ca2c2cd10b0bba1010d84d4dcc0000f90202f80000d80202c80202060606bc4242230d0d8c0303de0000eb0a0af40000ff00008b0606af28286d0202d82a2a530a0ad12222d85959aa1111eb0000c80909f72323ad0202720808440000eb6666f60f0ff90808c44141ba000000ffffd50000cc0000bb0000d20000dc0000eb0000e30000d70202c60000de0000b60101e10000c80000cf0000b80000000000ca0000bd0101cd0303ac0000b30000a90101c40000af0000f20102a20000e80000d80000a60000c20000830303f100009f0101fb0000970101e50000e50202fa0b0bf80000020606df29299d00006402024d0202f50101af1a1ac51919040c0cc30909081112ff0101ea2a2aee0000f00b0be24646e04f4fe23232d10909fb1e1e1803035e0101910000ce11117102024400007f0000512122e81717e11f1fe50c0cad0c0cdf3d3dd80c0cc80f0fc139399b19195500000d0b0c141616bf2e2e7c0202ef2020e83333d769692e0102d36363db46466d0000841515233032112425a30c0cf61616f11515e43b3bdd0b0bb91313e63d3da61a1aca09098f0b0bc11010d91f1ffc3030fd44443400007802029c0303d11a1b3b00006c2021e92020bc1c1c931a1a8c3d3d441718361818322e3077292b602525133638011a1bc34c4c2100007c1a1ac65050f42d2d4b2e30ea5454b4282896666365000000ea74524e5300fdfefcfdfe2d010203fbfe07fdfb581dfefefd7ffe37fefefefe1440fefd0b6de227496430d5c91f0ffcfef9fefe99fe86b98e4f7b9724f3fa3224ecfbb075fdaaea42fec25bfea570d33ff4b379efd9fcf2c841fba2bca6feb2f9fecbb8e098ed7fd6f8effebdf1b9e28ddefbf8fefdd752fcbff9defdfee6a4fdff01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffec62cb8d9000006004944415448c77d5605581b6718be3801820728561c0a94a6eeeeeeaeb3ceb74eba4ed8452ec45d08e412089440122030d8a0b86b816d38155aead4bdf3ed12580548df27f993fff2fd9fbcf7ddfb05005e0b3b228291ef21b6cd0880df266421da8dec8904cbb559cec862eb4084336075ec3b1f8f77b19adb01ce9f116c86981f10890498b12b7c5b40d36f1bdefa703e4020022175be364210007c7420b0fc202753d5d4f92b82ce0da1485ebbed27d98c3071d9fe23e8b8a1a8ef3a8f4d9830e1d8b1ce3f43fd569a97daacc10e0814973546f7b7c51ef8c98a03b14d8d45cb2201db45002bdd5d3356377575fd684557d78abb5be6bd8eff89876154c3e57febebcf9dbb70e15c7d7dfde4364f84669b2911c220457ba5a6adb0b0f01704c8c7eab6c0e164c72309b9ba9c8ba9ec6ecec8c8f8c18a8c8c8ff7ee8ef40c76b495d0ecb5646ca92efb4a4dcd9d9f11dca9a9b9f269d62746c34733c7337799fec1a54bcdfd519c3257d7eaeab367ce9cadae7675bd395062f0ba113e9efb20374d6565a55b32ada8e17c6d41c1c9930505b5e71bcabc359a2551d3c7bb071bb151439943ba219a249e910625a4a72740698c78092a538515af1faf2fc24424549c4086155041063331df64d2424c0659c4c17a0f1e248ca50969ffa9f13b770e92700e3c10cd4d84b45a28918b0679b26cd7cd616378b5ee09476aab6b321ac4303989cd4c84a044263b890e635ddf0d1bdd1bc876d2e243484faedab7fdcb7d581c9f8c66335353996c34287158860780efc7b85f75d894f2ade5d9099ee9399de34e06196c2e9bcd00e9ee9c0860b47f3b60f6a134c9dc8505ab801d8bbcbabf5ab4e48b323a98c4402781742a4a3a85401c9dcfe79b8b9ca2d2fc05dfecf12a3194976b5aa465209d0e226f3e0eeb3f6354c104606dadd8c93f2e5eae227b9f38612831ea5abadbffe0837c2a48754029dff11d9dcfd4f3282c46491a942a95b5e5155e46a3b4bde5565fd5100f5475147bb9bd1dfc4a09887d030a831270246619072bf1361a2aca39aa9292e2be98eb5ec5144a8e3ec6f155ff6b8b48381cce415c84a3d1e23866374377b91a766b3714e708f57a21452f7cf3e50076c072893b89c5522814121886159ce44b376e18da6141a94e735d28145228c2758eaf701af9864422a18a1048583c455c664f8fa6525391c913c8e5f2f6eb140a659de3cb1c1180952232998eb0c79750f92c99eedebdd2d225ba960e8102c6d104f2929613db6639be6c1f08a3d1e8a4a478305ec4a7ca869a2f2667266766960a2b640a052c50fe5e0a4beba63dcf8900b8d8c72f3c8a3400021e9f967c31ab4eaa944ad5ca5bc20e379980a6a11815d8e359b3fe4f8a00ec62f9a4216072b96c58a1ceba3b2088b350452bd7ebf51d4663b1be58ec208b0e983fd2ffc03cecc2b93e10e4e393e87354200bb89b0db37822110b0679a74f9fcec9c941968b651c4c96c7700822b0949aa24d499f9b6e821240b97c20bb910f82f12098aa4d7990db9a6b79e5dcff7ac5d6e888911af0d294ed8bd77bbae9b6bc9742d2d50d644b400697c9cc379dbd763fb7f5e1c367553db98fff898d6d5b302cdec4351b2da23973d10ee2ecf7a5bae8cb8dfc246e62bed674eadab5a6d6d60709de27fb9f3db93079f28a00bcf566bbf8594e39065bebdf936c7f7990ce60425ad399ab57affef530a6ef665e9e39a6aa70f5dea62cbf173c0daf4400afb6372319a522074e5970bbef715e5e4a9eb9eacacdecad5933862d09cf0f2163ccdfde6c1117281fd12f04cdbdcdfd50deed4755458ddefbebc60c45221028b7378be80c6b0da674539eb9b7f7e913f3d3de2a3e2cc0fa3b8f16193b60931c83e3f1ade292af4dd0a6a31ffd7dbb27ba0e855338c89c54f8b12ae0e18f4129a8f4240637351111248839c88520369ace13638eaba68c995844c023ea3847cca25ab482cdb52095813cd32c188591aad6100963753844e5841588611e956f510b1024f32522160e8551aa8342c71f255354722c0683c2c10a168fc77327912cd652759087afad69181aae52cb954a1947808023532ae5ea39d39c27da986ed6bcfc3ca6852f98e38460ce82a088a51e21be237f4fc6c7b01c125df09e9e7817c7e713e0c5efff015bd48d994bf915a20000000049454e44ae426082);");
            var userlister = new SqlCommand("users_select", "SELECT `ID`, `NICK`, `PIC` FROM `USERS`;");
            sqlCommands.Add(dbinit); //User tábla létrehozásának parancsa hozzáadása a listához "init_create" néven
            sqlCommands.Add(masterprofinit); //Master profil hozzáadása az USER táblához
            sqlCommands.Add(userlister); //Felhasználók lekérdezése
            css.Add(new Conninfo(cs));
            bool convalind = true; //Kapcsolat ellenőrsére hivatott boolean 

            //Kapcsolat megnyitása 
            var con = new MySqlConnection(cs); 
            try{
                con.Open(); 
            }
            catch {
                convalind = false;
                MessageBox.Show("Be kell jelentkezned!");
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            
            //Valid kapcsolat esetén kapcsolódás
            dbConnections.Add(con);
            if (convalind)
            {
                button_login.Enabled = false; //Login gomb letiltása élő kapcsolat esetén
                
                //Mysql szerver verziójának lekérdezése
                var stm = "SELECT VERSION();"; 
                var cmd = new MySqlCommand(stm, con);
                var version = cmd.ExecuteScalar().ToString();
                label_version.Text = version;
                
                //Felhasználók lekérdezése
                cmd = new MySqlCommand(sqlCommands.Find(z => z.Function.Contains("users_select")).Code.ToString(), dbConnections.First());
                try {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch{
                    try // Ha nincs USER tábla
                    {
                        //Létrehozza a táblát
                        cmd = new MySqlCommand();
                        cmd.Connection = dbConnections.First();
                        cmd.CommandText = sqlCommands.Find(z => z.Function.Contains("init_create")).Code.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Az adatbázis létrehozása sikertelen!");
                    }
                    try
                    {
                        //Feltölti az USER táblába a master profilt
                        cmd = new MySqlCommand();
                        cmd.Connection = dbConnections.First();
                        cmd.CommandText = sqlCommands.Find(z => z.Function.Contains("master_insert")).Code.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    catch {
                        MessageBox.Show("A master record nem ment fel :(");
                    }
                    this.Hide();
                    Form1 f1 = new Form1(cs);
                    f1.ShowDialog();
                }

                //Profil listázás
                int x = 0;
                int y = 0;
                int delta = 10;
                cmd = new MySqlCommand(sqlCommands.Find(z => z.Function.Contains("users_select")).Code.ToString(), dbConnections.First());
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        byte[] pic;
                        if (Convert.IsDBNull(rdr["PIC"]))
                        {
                            pic = null;   
                        }
                        else
                        {
                            pic = (byte[])rdr["PIC"];
                        }
                        var user = new User(Int32.Parse(rdr["ID"].ToString()), rdr["NICK"].ToString(), pic);
                        users.Add(user);
                        var picture = new PictureBox();
                        picture.Image = ByteArrayToImage(pic);
                        picture.Location = new Point(x, y);
                        picture.Size = new Size(50, 50);
                        int dx = picture.Width + delta;
                        var labelName = new Label();
                        labelName.AutoSize = true;
                        labelName.Location = new Point(x + dx, y);
                        labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                        labelName.Text = rdr["NICK"].ToString();
                        panel.Controls.Add(picture);
                        panel.Controls.Add(labelName);
                        int dy1 = labelName.Height;
                        int dy2 = picture.Height;
                        y += Math.Max(dy1, dy2) + delta;
                    }
                }
                listBox_profiles.BeginUpdate();
                foreach (var profile in users)
                {
                    if (!listBox_profiles.Items.Contains(profile.Nick))
                    {
                        listBox_profiles.Items.Add(profile.Nick);
                    }
                }
                listBox_profiles.EndUpdate();
            }
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        //Modify gomb megnyitja a Form3-at
        private void button_modify_Click(object sender, EventArgs e)
        {
            var nick = listBox_profiles.SelectedItem as string;   //kijelölt felhasználónév betöltése a nickbe
            if (nick == null) MessageBox.Show("Jelölj ki egy felhasználót!");
            else
            {
                int id = Int32.Parse(users.Find(x => x.Nick.Contains(nick)).Id.ToString());  //id lehívása a usersből a nick alapján
                Form3 f3 = new Form3(id, dbConnections.First()); //példányosítjuk a Form3-at, átadva neki az id-t
                f3.ShowDialog();
            }
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(css.First().Cs.ToString());
            MySqlConnection.ClearPool(dbConnections.First());
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            var cmd = new MySqlCommand();
            cmd.Connection = dbConnections.First();
            cmd.CommandText = "INSERT INTO `USERS` (`NICK`, `PASS`, `PIC`) VALUES ('NEW', 'NOPASS', 0x89504e470d0a1a0a0000000d494844520000003000000030080300000060dc09b500000300504c544547704cbc0202da0101b50101af0101c00101980000a20707b00303980404b60909bd00005d1313c40202a70000a40d0d930101dd1616890303c802029d0000d401019308086c0606bd0b0cdc5858ea00009605059f0303a70202ab1313ba0000af0909a200005a0202a20707a50f0fe701029d0000a60808b91a1acd0c0ca30101b2121218191ad13f3fd356569f0000020101dc0404a105059e0101a30101700101a40c0cf20000a60000f10000a301019b0a0aa40303e500006e0101fd00008e0000a30000b20202e40303cb4a4abd0404fa0505d131319d0101e10505070000c20000c34c4cb50101a30909e70909c00000bf21219d0101f90c0c670202d10808b00202b61616880505ca2c2cd10b0bba1010d84d4dcc0000f90202f80000d80202c80202060606bc4242230d0d8c0303de0000eb0a0af40000ff00008b0606af28286d0202d82a2a530a0ad12222d85959aa1111eb0000c80909f72323ad0202720808440000eb6666f60f0ff90808c44141ba000000ffffd50000cc0000bb0000d20000dc0000eb0000e30000d70202c60000de0000b60101e10000c80000cf0000b80000000000ca0000bd0101cd0303ac0000b30000a90101c40000af0000f20102a20000e80000d80000a60000c20000830303f100009f0101fb0000970101e50000e50202fa0b0bf80000020606df29299d00006402024d0202f50101af1a1ac51919040c0cc30909081112ff0101ea2a2aee0000f00b0be24646e04f4fe23232d10909fb1e1e1803035e0101910000ce11117102024400007f0000512122e81717e11f1fe50c0cad0c0cdf3d3dd80c0cc80f0fc139399b19195500000d0b0c141616bf2e2e7c0202ef2020e83333d769692e0102d36363db46466d0000841515233032112425a30c0cf61616f11515e43b3bdd0b0bb91313e63d3da61a1aca09098f0b0bc11010d91f1ffc3030fd44443400007802029c0303d11a1b3b00006c2021e92020bc1c1c931a1a8c3d3d441718361818322e3077292b602525133638011a1bc34c4c2100007c1a1ac65050f42d2d4b2e30ea5454b4282896666365000000ea74524e5300fdfefcfdfe2d010203fbfe07fdfb581dfefefd7ffe37fefefefe1440fefd0b6de227496430d5c91f0ffcfef9fefe99fe86b98e4f7b9724f3fa3224ecfbb075fdaaea42fec25bfea570d33ff4b379efd9fcf2c841fba2bca6feb2f9fecbb8e098ed7fd6f8effebdf1b9e28ddefbf8fefdd752fcbff9defdfee6a4fdff01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffec62cb8d9000006004944415448c77d5605581b6718be3801820728561c0a94a6eeeeeeaeb3ceb74eba4ed8452ec45d08e412089440122030d8a0b86b816d38155aead4bdf3ed12580548df27f993fff2fd9fbcf7ddfb05005e0b3b228291ef21b6cd0880df266421da8dec8904cbb559cec862eb4084336075ec3b1f8f77b19adb01ce9f116c86981f10890498b12b7c5b40d36f1bdefa703e4020022175be364210007c7420b0fc202753d5d4f92b82ce0da1485ebbed27d98c3071d9fe23e8b8a1a8ef3a8f4d9830e1d8b1ce3f43fd569a97daacc10e0814973546f7b7c51ef8c98a03b14d8d45cb2201db45002bdd5d3356377575fd684557d78abb5be6bd8eff89876154c3e57febebcf9dbb70e15c7d7dfde4364f84669b2911c220457ba5a6adb0b0f01704c8c7eab6c0e164c72309b9ba9c8ba9ec6ecec8c8f8c18a8c8c8ff7ee8ef40c76b495d0ecb5646ca92efb4a4dcd9d9f11dca9a9b9f269d62746c34733c7337799fec1a54bcdfd519c3257d7eaeab367ce9cadae7675bd395062f0ba113e9efb20374d6565a55b32ada8e17c6d41c1c9930505b5e71bcabc359a2551d3c7bb071bb151439943ba219a249e910625a4a72740698c78092a538515af1faf2fc24424549c4086155041063331df64d2424c0659c4c17a0f1e248ca50969ffa9f13b770e92700e3c10cd4d84b45a28918b0679b26cd7cd616378b5ee09476aab6b321ac4303989cd4c84a044263b890e635ddf0d1bdd1bc876d2e243484faedab7fdcb7d581c9f8c66335353996c34287158860780efc7b85f75d894f2ade5d9099ee9399de34e06196c2e9bcd00e9ee9c0860b47f3b60f6a134c9dc8505ab801d8bbcbabf5ab4e48b323a98c4402781742a4a3a85401c9dcfe79b8b9ca2d2fc05dfecf12a3194976b5aa465209d0e226f3e0eeb3f6354c104606dadd8c93f2e5eae227b9f38612831ea5abadbffe0837c2a48754029dff11d9dcfd4f3282c46491a942a95b5e5155e46a3b4bde5565fd5100f5475147bb9bd1dfc4a09887d030a831270246619072bf1361a2aca39aa9292e2be98eb5ec5144a8e3ec6f155ff6b8b48381cce415c84a3d1e23866374377b91a766b3714e708f57a21452f7cf3e50076c072893b89c5522814121886159ce44b376e18da6141a94e735d28145228c2758eaf701af9864422a18a1048583c455c664f8fa6525391c913c8e5f2f6eb140a659de3cb1c1180952232998eb0c79750f92c99eedebdd2d225ba960e8102c6d104f2929613db6639be6c1f08a3d1e8a4a478305ec4a7ca869a2f2667266766960a2b640a052c50fe5e0a4beba63dcf8900b8d8c72f3c8a3400021e9f967c31ab4eaa944ad5ca5bc20e379980a6a11815d8e359b3fe4f8a00ec62f9a4216072b96c58a1ceba3b2088b350452bd7ebf51d4663b1be58ec208b0e983fd2ffc03cecc2b93e10e4e393e87354200bb89b0db37822110b0679a74f9fcec9c941968b651c4c96c7700822b0949aa24d499f9b6e821240b97c20bb910f82f12098aa4d7990db9a6b79e5dcff7ac5d6e888911af0d294ed8bd77bbae9b6bc9742d2d50d644b400697c9cc379dbd763fb7f5e1c367553db98fff898d6d5b302cdec4351b2da23973d10ee2ecf7a5bae8cb8dfc246e62bed674eadab5a6d6d60709de27fb9f3db93079f28a00bcf566bbf8594e39065bebdf936c7f7990ce60425ad399ab57affef530a6ef665e9e39a6aa70f5dea62cbf173c0daf4400afb6372319a522074e5970bbef715e5e4a9eb9eacacdecad5933862d09cf0f2163ccdfde6c1117281fd12f04cdbdcdfd50deed4755458ddefbebc60c45221028b7378be80c6b0da674539eb9b7f7e913f3d3de2a3e2cc0fa3b8f16193b60931c83e3f1ade292af4dd0a6a31ffd7dbb27ba0e855338c89c54f8b12ae0e18f4129a8f4240637351111248839c88520369ace13638eaba68c995844c023ea3847cca25ab482cdb52095813cd32c188591aad6100963753844e5841588611e956f510b1024f32522160e8551aa8342c71f255354722c0683c2c10a168fc77327912cd652759087afad69181aae52cb954a1947808023532ae5ea39d39c27da986ed6bcfc3ca6852f98e38460ce82a088a51e21be237f4fc6c7b01c125df09e9e7817c7e713e0c5efff015bd48d994bf915a20000000049454e44ae426082);\r\n";
            cmd.ExecuteNonQuery();
        }
    }
}
