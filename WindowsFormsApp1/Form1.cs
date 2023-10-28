using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private int _startSirclesCount = 8;
        private Table _table;

        private List<Circle> _circles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void _startButton_MouseClick(object sender, MouseEventArgs e)
        {
            _mainMenu.Visible = false;
            _points.Visible = true;
        }

        private void _gameTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartGame()
        {
            CreateTable();
            ClearTable();
            CreateStartCircles();
        }

        private void CreateStartCircles()
        {
            for (int i = 0; i < _startSirclesCount; i++)
            {
                Circle circle = new Circle(1, "blue", true);
                _gameTable.Controls.Add(circle.GetButton(), _random.Next(0,8), _random.Next(0, 8));
                _circles.Add(circle);
            }
        }

        private void CreateTable()
        {
            _table = new Table();
        }

        private void ClearTable()
        {
            _table.RemoveAllObjects();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            button1.Text = e.Data.GetData(DataFormats.Text).ToString();
        }
    }
}
