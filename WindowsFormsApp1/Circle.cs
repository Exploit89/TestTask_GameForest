using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
        private string _properties;

        public event EventHandler<int> CircleTaken;

        public Circle(int level, string color, bool generation)
        {
            _level = level;
            _color = color;
            _properties = level + color;
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
            _button.MouseClick += button_MouseClick;

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

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Button GetButton()
        {
            return _button;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            _button.DoDragDrop(_properties, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            var dataLevel = e.Data.GetData(DataFormats.Text).ToString()[0];
            int currentLevel = int.Parse(dataLevel.ToString());
            int newLevel = currentLevel + 1;
            var color = e.Data.GetData(DataFormats.Text).ToString();
            string currentColor = null;

            for (int i = 1; i < color.Length; i++)
            {
                currentColor += color[i];
            }

            if (currentLevel == _level)
            {
                _button.Text = newLevel.ToString();
                _level = newLevel;
                _properties = newLevel + _color;
                CircleTaken?.Invoke(this, _button.);
            }
        }
    }
}
