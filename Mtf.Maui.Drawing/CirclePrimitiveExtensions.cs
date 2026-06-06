using Mtf.Drawing.Render;

namespace Mtf.Maui.Drawing;

public static class CirclePrimitiveExtensions
{
    public static void Draw(this CirclePrimitive circlePrimitive, ICanvas canvas, Color strokeColor, float strokeSize = 1f)
    {
        circlePrimitive.Draw(canvas, strokeColor, Colors.Transparent, strokeSize);
    }

    public static void Draw(this CirclePrimitive circlePrimitive, ICanvas canvas, Color strokeColor, Color fillColor, float strokeSize = 1f)
    {
        ArgumentNullException.ThrowIfNull(circlePrimitive);
        ArgumentNullException.ThrowIfNull(canvas);

        var radius = circlePrimitive.Circle.Radius;
        var diameter = radius * 2;

        var x = circlePrimitive.Circle.Center.X - radius;
        var y = circlePrimitive.Circle.Center.Y - radius;

        if (fillColor != Colors.Transparent)
        {
            canvas.FillColor = fillColor;
            canvas.FillEllipse(x, y, diameter, diameter);
        }

        canvas.StrokeColor = strokeColor;
        canvas.StrokeSize = strokeSize;
        canvas.DrawEllipse(x, y, diameter, diameter);
    }
}