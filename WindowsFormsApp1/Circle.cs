using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{

    internal class Circle
    {
        private int _level;
        private string _color;
        private bool _generation;
        private Button _button;

        public Circle(int level, string color, bool generation)
        {
            _level = level;
            _color = color;
            _generation = generation;
            _button = new Button();
            _button.Text = level.ToString();
            //_button.Location = new Point(313, 313);
            _button.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            _button.BackgroundImageLayout = ImageLayout.Stretch;
            _button.Name = "button1";
            _button.Size = new Size(36, 36);
            //_button.TabIndex = 0;
            _button.UseVisualStyleBackColor = true;
            _button.AllowDrop = true;
            _button.FlatAppearance.BorderSize = 0;
            _button.Margin = new Padding(0);
            _button.MouseDown += button_MouseDown;
            _button.DragEnter += textBox1_DragEnter;
            _button.DragDrop += textBox1_DragDrop;

            switch (color)
            {
                case "blue":
                    _button.BackgroundImage = Resource1.BlueCircle;
                    break;
                case "red":
                    _button.BackgroundImage = Resource1.RedCircle;
                    break;
                case "green":
                    _button.BackgroundImage = Resource1.GreenCircle;
                    break;
                default:
                    _button.BackgroundImage = Resource1.BlueCircle;
                    break;
            }
        }

        public void MoveCircle(int[] coordinates)
        {
            _button.Location = new Point(coordinates[0], coordinates[1]);
        }

        public Button GetButton()
        {
            return _button;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            _button.DoDragDrop(_button.Text, DragDropEffects.Copy |
               DragDropEffects.Move);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
                e.Effect = DragDropEffects.Move;
            }

            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            _button.Text = e.Data.GetData(DataFormats.Text).ToString() + "2"; //здесь поработать с числами
        }
    }
}
