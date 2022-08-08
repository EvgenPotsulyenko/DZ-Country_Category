using DZ_linq_country.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace DZ_linq_country
{
    public partial class Form1 : Form
    {
         ApplicationDbContext db = new ApplicationDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "true";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "false";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
                if (textBox3.Text != "")
                {
                    Area at = new Area() { Name = textBox3.Text };
                    db.Areas.Add(at);
                    db.SaveChanges();
                    MessageBox.Show("Регион добавлен");
                }
                else
                {
                    MessageBox.Show("Введите значение");
                }

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
                var at = db.Areas.ToList();
                foreach (Area a in at)
                {
                    if (a.Name == textBox8.Text)
                    {
                        Country pt = new Country() { Name = textBox1.Text, square = Convert.ToInt32(textBox2.Text), AreasId = a.Id };
                        db.Сountries.Add(pt);
                        db.SaveChanges();
                        MessageBox.Show("Страна добавлена");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Введите значение");
                    }
                }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
                var at = db.Сountries.ToList();
                foreach (Country a in at)
                {
                    if (a.Name == textBox7.Text)
                    {
                        City pt = new City() { Name = textBox4.Text, capital = Convert.ToBoolean(textBox5.Text), population = Convert.ToInt32(textBox6.Text), CountryId = a.Id };
                        db.Cities.Add(pt);
                        db.SaveChanges();
                        MessageBox.Show("Город добавлен");
                        break;
                    }
                }
            //}
        }                  
        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                Category at = new Category() { Name = textBox9.Text };
                db.Categories.Add(at);
                db.SaveChanges();
                MessageBox.Show("Категория добавлена");
            }
            else
            {
                MessageBox.Show("Введите значение");
            }
        }
    }
}
