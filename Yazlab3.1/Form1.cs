using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

//Onur Kaplan 160202061
//Mertcan Tanser Karakuş 160202038

namespace Yazlab3._1
{
    public partial class Form1 : Form
    {
        int flag = 0;
        ArrayList images = new ArrayList();
        String imageLocation = "";
        Button btntut = new Button();
        Image tampon = null;
        Button btntampon = new Button();
        double puan = 0;
        int kilitsayisi = 0;
        double EnYuksekSkor = 0;


        public Form1()
        {
            InitializeComponent();
        }


        private void AddImagesToButtons(ArrayList images)
        {
            int i = 0;
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            arr = suffle(arr);

            foreach (Button b in panel1.Controls)
            {
                if (i < arr.Length)
                {
                    b.Image = (Image)images[arr[i]];

                    i++;

                }
            }
        }


        private int[] suffle(int[] arr)
        {
            Random rand = new Random();
            arr = arr.OrderBy(x => rand.Next()).ToArray();

            return arr;
        }

        private void cropImageTomages(Image original, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);

            Graphics graphic = Graphics.FromImage(bmp);

            graphic.DrawImage(original, 0, 0, w, h);

            graphic.Dispose();

            int movr = 0;
            int movd = 0;

            String kayit = "D:\\Sonuc\\0.bmp";
            int count = 0;

            for (int x = 0; x < 16; x++)
            {
                Bitmap piece = new Bitmap(120, 120);

                for (int i = 0; i < 120; i++)
                {
                    for (int j = 0; j < 120; j++)
                    {
                        piece.SetPixel(i, j, bmp.GetPixel(i + movr, j + movd));
                    }
                }

                images.Add(piece);

                movr += 120;

                if (movr == 480)
                {
                    movr = 0;
                    movd += 120;
                }

                kayit = kayit.Replace((count).ToString(), (count + 1).ToString());
                piece.Save(kayit);
                count++;

            }
        }

        public int CompareImages(Image Gelen, int deger)
        {
            Image tut = Gelen;
            tut.Save("D:\\Karışık\\" + deger + ".bmp");

            var dir1 = new DirectoryInfo(@"D:\\Karışık");
            FileInfo[] files1 = dir1.GetFiles(deger + ".bmp");

            var dir2 = new DirectoryInfo(@"D:\\Sonuc");
            FileInfo[] files2 = dir2.GetFiles(deger + ".bmp");
            Dictionary<string, FileInfo> files2Dict = files2.ToDictionary(f => f.Name);
            int equal = 1;

            foreach (FileInfo f1 in files1)
            {
                FileInfo f2;
                equal = deger;
                if (files2Dict.TryGetValue(f1.Name, out f2) && f1.Length == f2.Length)
                {
                    byte[] image1 = GetFileBytes(f1);
                    byte[] image2 = GetFileBytes(f2);
                    for (int i = 0; i < image1.Length; i++)
                    {
                        if (image1[i] != image2[i])
                        {
                            equal = 0;
                            break;
                        }
                    }
                }
                else
                {
                    equal = 0;
                }

            }

            return equal;
        }

        private static byte[] GetFileBytes(FileInfo f)
        {
            using (FileStream stream = f.OpenRead())
            {
                byte[] buffer = new byte[f.Length];
                stream.Read(buffer, 0, (int)f.Length);
                return buffer;
            }
        }


            public void first_compare()
            {

            int tampon = 0;
            int i;
            int degisim = 0;
            
            for (i = 1; i < 17; i++)
            {
                tampon = CompareImages(button1.Image, i);
                if (tampon == 1)
                {
                    button1.Enabled = false;
                    degisim ++;
                    puan += 6.25;
                    label2.Text = puan.ToString();
                    kilitsayisi += 1;
                    kontrol();
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button2.Image, i);
                    if (tampon == 2)
                    {
                        button2.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button3.Image, i);
                    if (tampon == 3)
                    {
                        button3.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button4.Image, i);
                    if (tampon == 4)
                    {
                        button4.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button5.Image, i);
                    if (tampon == 5)
                    {
                        button5.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button6.Image, i);
                    if (tampon == 6)
                    {
                        button6.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button7.Image, i);
                    if (tampon == 7)
                    {
                        button7.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button8.Image, i);
                    if (tampon == 8)
                    {
                        button8.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button9.Image, i);
                    if (tampon == 9)
                    {
                        button9.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button10.Image, i);
                    if (tampon == 10)
                    {
                        button10.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button11.Image, i);
                    if (tampon == 11)
                    {
                        button11.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {

                    tampon = CompareImages(button12.Image, i);
                    if (tampon == 12)
                    {
                        button12.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button13.Image, i);
                    if (tampon == 13)
                    {
                        button13.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button14.Image, i);
                    if (tampon == 14)
                    {
                        button14.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button15.Image, i);
                    if (tampon == 15)
                    {
                        button15.Enabled = false;
                        degisim ++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                tampon = 0;
                for (i = 1; i < 17; i++)
                {
                    tampon = CompareImages(button16.Image, i);
                    if (tampon == 16)
                    {
                        button16.Enabled = false;
                        degisim++;
                        puan += 6.25;
                        label2.Text = puan.ToString();
                        kilitsayisi += 1;
                        kontrol();
                    }
                }

                if (degisim >= 2)
                {
                    Mix.Enabled = false;
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }

            }

        public void dosyayazma()
        {
            string dosya_yolu = @"D:\enyüksekskor.txt";
       
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(puan);

            sw.Close();
            fs.Close();
        }

        public void dosyaokuma()
        {

            string dosya_yolu = @"D:\enyüksekskor.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();

            if(yazi == null){}

            else
            {

            while (yazi != null)
            {

                if (EnYuksekSkor < double.Parse(yazi))
                {
                    EnYuksekSkor = double.Parse(yazi);
                }
                
                    yazi = sw.ReadLine();
                               
            }

            label4.Text = EnYuksekSkor.ToString();

            }

            sw.Close();
            fs.Close();

        }

        public void compare()
        {

            int tampon = 0;
            String butontut;
            String butontampon;

            butontut = btntut.Name;
            butontampon = btntampon.Name;

            char[] ayrac = { 'n' };

            string[] parcalar = butontut.Split(ayrac);

            int sayi = int.Parse(parcalar[1]);

            for (int i = 0; i < 17; i++)
            {
                tampon = CompareImages(btntut.Image, i);
                if(tampon == sayi)
                {
                    btntut.Enabled = false;
                    puan += 5;
                    label2.Text = puan.ToString();
                    kilitsayisi += 1;
                    kontrol();
                }
            }
            if (btntut.Enabled == true)
            {
                puan -= 0.5;
                label2.Text = puan.ToString();
            }

            string[] parcalar2 = butontampon.Split(ayrac);
            int sayi2 = int.Parse(parcalar2[1]);

            for (int i = 0; i < 17; i++)
            {
                tampon = CompareImages(btntampon.Image, i);
                if (tampon == sayi2)
                {
                    btntampon.Enabled = false;
                    puan += 5;
                    label2.Text = puan.ToString();
                    kilitsayisi += 1;
                    kontrol();
                    
                }
            }
            if(btntampon.Enabled == true)
            {
                puan -= 0.5;
                label2.Text = puan.ToString();
            }

        }


            public void kontrol()
            {
            if (kilitsayisi == 16)
            {
                dosyayazma();
                dosyaokuma();

                if (puan == 100)
                {
                    MessageBox.Show("Tekte Bildin", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kazandınız", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            } 


            private void Puzzle(object sender, EventArgs e)
            {

                if (flag == 0)
                {
                    btntut = (Button)sender;
                    tampon = btntut.Image;
                    flag = 1;
                }
                else
                {

                    btntampon = (Button)sender;
                    btntut.Image = btntampon.Image;
                    btntampon.Image = tampon;
                    compare();
                    btntut = null;
                    btntampon = null;
                    tampon = null;
                    flag = 0;
           
                }
            }

            private void Mix_Click(object sender, EventArgs e)
            {
                foreach (Button b in panel1.Controls)
                    b.Enabled = true;

                Image orginal = Image.FromFile(imageLocation);
                cropImageTomages(orginal, 480, 480);

                AddImagesToButtons(images);
                first_compare();
            }

            private void Upload_Click(object sender, EventArgs e)
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Resim Dosyası |*.jpg;*.nef;*.png;*.bmp| Video|*.avi| Tüm Dosyalar |*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = dialog.FileName;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Hata", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        private void Form1_Load(object sender, EventArgs e)
        {
            dosyaokuma();
        }

        private void bosclick(object sender, EventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            button1.Image = null;
            button2.Enabled = true;
            button2.Image = null;
            button3.Enabled = true;
            button3.Image = null;
            button4.Enabled = true;
            button4.Image = null;
            button5.Enabled = true;
            button5.Image = null;
            button6.Enabled = true;
            button6.Image = null;
            button7.Enabled = true;
            button7.Image = null;
            button8.Enabled = true;
            button8.Image = null;
            button9.Enabled = true;
            button9.Image = null;
            button10.Enabled = true;
            button10.Image = null;
            button11.Enabled = true;
            button11.Image = null;
            button12.Enabled = true;
            button12.Image = null;
            button13.Enabled = true;
            button13.Image = null;
            button14.Enabled = true;
            button14.Image = null;
            button15.Enabled = true;
            button15.Image = null;
            button16.Enabled = true;
            button16.Image = null;
            Mix.Enabled = true;
            puan = 0;
            label2.Text = puan.ToString();
            kilitsayisi = 0;
        }

    }
    }
