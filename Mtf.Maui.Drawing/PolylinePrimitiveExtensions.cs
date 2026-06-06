using Mtf.Drawing.Render;

namespace Mtf.Maui.Drawing;

public static class PolylinePrimitiveExtensions
{
    public static void Draw(this PolylinePrimitive polylinePrimitive, ICanvas canvas, Color color, float thickness = 2f)
    {
        ArgumentNullException.ThrowIfNull(polylinePrimitive);
        ArgumentNullException.ThrowIfNull(canvas);

        var points = polylinePrimitive.Polyline.Points;

        if (points.Count < 2)
        {
            return;
        }

        canvas.StrokeColor = color;
        canvas.StrokeSize = thickness;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeLineJoin = LineJoin.Round;

        for (int i = 0; i < points.Count - 1; i++)
        {
            canvas.DrawLine(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
        }
    }
}