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
        }

        private void _startButton_MouseClick(object sender, MouseEventArgs e)
        {
            _mainMenu.Visible = false;
            _points.Visible = true;
            StartGame();
        }

        private void _gameTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartGame()
        {
            CreateTable();
            ClearTable();
            CreateStartCircles();
            //MoveStartCircles();
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

        private void MoveStartCircles()
        {
            foreach (Circle circle in _circles)
            {
                //Console.WriteLine(_table.GetCoordinates(_random.Next(0, 64)));
                circle.MoveCircle(_table.GetCoordinates(_random.Next(0, 64)));
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
    }
}
