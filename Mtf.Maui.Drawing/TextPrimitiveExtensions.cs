using Mtf.Drawing.Render;

namespace Mtf.Maui.Drawing;

public static class TextPrimitiveExtensions
{
    public static void Draw(this TextPrimitive textPrimitive, ICanvas canvas, Color color, float fontSize = 18)
    {
        ArgumentNullException.ThrowIfNull(textPrimitive);
        ArgumentNullException.ThrowIfNull(canvas);

        canvas.FontColor = color;
        canvas.FontSize = fontSize;

        canvas.DrawString(textPrimitive.Layout.Text, textPrimitive.Layout.Position.X, textPrimitive.Layout.Position.Y, HorizontalAlignment.Left);
    }
}