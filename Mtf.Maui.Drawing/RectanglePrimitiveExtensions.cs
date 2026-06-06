using Mtf.Drawing.Render;

namespace Mtf.Maui.Drawing;

public static class RectanglePrimitiveExtensions
{
    public static void Draw(
        this RectanglePrimitive rectanglePrimitive,
        ICanvas canvas,
        Color strokeColor,
        float strokeSize = 2f)
    {
        Draw(rectanglePrimitive, canvas, strokeColor, Colors.Transparent, strokeSize);
    }

    public static void Draw(
        this RectanglePrimitive rectanglePrimitive,
        ICanvas canvas,
        Color strokeColor,
        Color fillColor,
        float strokeSize = 2f)
    {
        ArgumentNullException.ThrowIfNull(rectanglePrimitive);
        ArgumentNullException.ThrowIfNull(canvas);

        var rect = rectanglePrimitive.Rect;
        if (fillColor != Colors.Transparent)
        {
            canvas.FillColor = fillColor;
            canvas.FillRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        canvas.StrokeColor = strokeColor;
        canvas.StrokeSize = strokeSize;

        canvas.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
    }
}