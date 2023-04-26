using System;
using System.Collections.Generic;

namespace DesignPatterns.Prototype
{
    public class ColorPrototype
    {
        public void Debug()
        {
            ColorManager colorManager = new ColorManager();
            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            colorManager["angry"] = new Color(255, 54, 0);

            Color color1 = colorManager["red"].Clone() as Color;
            var color2 = colorManager["angry"].Clone() as Color;
            Console.ReadKey();

        }
    }
    public interface IColorProtoType
    {
        IColorProtoType Clone();
    }
    public class Color : IColorProtoType
    {
        int red, green, blue;
        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public IColorProtoType Clone()
        {
            return this.MemberwiseClone() as IColorProtoType;
        }
        public int x()
        {
            return 1;
        }
    }
    public class ColorManager
    {
        private Dictionary<string, IColorProtoType> colors = new Dictionary<string, IColorProtoType>();
        public IColorProtoType this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }

    }
}
