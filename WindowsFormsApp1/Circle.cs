using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
    }
}
