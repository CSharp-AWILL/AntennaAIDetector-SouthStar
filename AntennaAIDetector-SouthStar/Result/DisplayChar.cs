using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AqVision.Graphic.AqVision.shape;

namespace AntennaAIDetector_SouthStar.Result
{
    public class DisplayChar
    {
        public string Text { get; set; } = "";
        public Point Position { get; set; } = new Point();
        public Size Size { get; set; } = new Size();
        public Color Color { get; set; } = new Color();

        public DisplayChar()
        {
            Size = new Size(200, 200);
            Color = Color.Red;
        }

        public AqCharacter ConvertToAqCharacter()
        {
            AqCharacter aqCharacter = new AqCharacter();

            aqCharacter.AqString = Text;
            aqCharacter.LeftTopPointX = Position.X;
            aqCharacter.LeftTopPointY = Position.Y;
            aqCharacter.RightBottomPointX = Position.X + Size.Width;
            aqCharacter.RightBottomPointY = Position.Y + Size.Height;
            aqCharacter.ColorRed = Convert.ToInt32(Color.R);
            aqCharacter.ColorGreen = Convert.ToInt32(Color.G);
            aqCharacter.ColorBlue = Convert.ToInt32(Color.B);

            aqCharacter.isDragCharacter = true;
            aqCharacter.isVisible = false;

            return aqCharacter;
        }

        public void SetDisplayChar(PointF position, string text)
        {
            Text = text;
            Position = new Point(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
        }
    }
}
