using Mtf.Drawing.Render;

namespace Mtf.Maui.Drawing;

public static class LinePrimitiveExtensions
{
    public static void Draw(this LinePrimitive linePrimitive, ICanvas canvas, Color color, float thickness = 2f)
    {
        ArgumentNullException.ThrowIfNull(linePrimitive);
        ArgumentNullException.ThrowIfNull(canvas);

        canvas.StrokeColor = color;
        canvas.StrokeSize = thickness;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeLineJoin = LineJoin.Round;

        canvas.DrawLine(linePrimitive.Line.A.X, linePrimitive.Line.A.Y, linePrimitive.Line.B.X, linePrimitive.Line.B.Y);
    }
}