﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlexCodeSDK;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        FlexCodeSDK.FinFPReg reg;
        String template = "";
        string imgPath = "";
            
        public Form2(string rut, string name)
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox1.Text = rut;
            textBox2.Text = name;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize FlexCodeSDK for Registration
            //1. Initialize Event Handler
            reg = new FlexCodeSDK.FinFPReg();
            reg.FPSamplesNeeded += new __FinFPReg_FPSamplesNeededEventHandler(reg_FPSamplesNeeded);
            reg.FPRegistrationTemplate += new __FinFPReg_FPRegistrationTemplateEventHandler(reg_FPRegistrationTemplate);
            reg.FPRegistrationImage += new __FinFPReg_FPRegistrationImageEventHandler(reg_FPRegistrationImage);
            reg.FPRegistrationStatus += new __FinFPReg_FPRegistrationStatusEventHandler(reg_FPRegistrationStatus);

            //2. Input the activation code
            reg.AddDeviceInfo("F500E002697", "4EA84B1BCAC240B", "REKA0E0C461B7A0D2649CVKQ");
            
            //3. Define fingerprint image
            reg.PictureSampleHeight = (short)(pictureBox1.Height * 15); //FlexCodeSDK use Twips. 1 pixel = 15 twips
            reg.PictureSampleWidth = (short)(pictureBox1.Width * 15); //FlexCodeSDK use Twips. 1 pixel = 15 twips
            imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp";
            reg.PictureSamplePath = imgPath;
        }
        
        void reg_FPRegistrationStatus(RegistrationStatus Status)
        {
            if (Status== RegistrationStatus.r_OK) 
            {
                Console.Out.WriteLine(template);
                Program.ExitApplication(0);
            }
        }

        void reg_FPRegistrationImage()
        {
            pictureBox1.Load(imgPath);
            if (imgPath == AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp")
            {
                imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger4.bmp";
            }
            else
            {
                imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp";
            }
            reg.PictureSamplePath = imgPath;
        }

        void reg_FPRegistrationTemplate(string FPTemplate)
        {
            template = FPTemplate;
        }

        void reg_FPSamplesNeeded(short Samples)
        {
            label1.Text = "Samples Needed : " + Convert.ToString(Samples);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            button1.Enabled = false;
            button2.Enabled = true;
            reg.FPRegistrationStart("MySecretKey" + textBox1.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Canceled!");
            template = "";
            label1.Text = "Samples Needed : ";
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
