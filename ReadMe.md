Íme egy tiszta, használható `README.md` az extension library-hoz (MAUI rendering + primitive drawing kontextusban):

---

````md
# Mtf.Maui.Drawing

MAUI extension library for rendering geometric primitives defined in `Mtf.Drawing.Render`.

This project provides **ICanvas-based drawing extensions** for MAUI Graphics, bridging domain-level primitives (Circle, Line, Rectangle, Text) with platform rendering.

---

## 🚀 Purpose

The goal of this library is to:

- Keep geometry/domain logic **UI-agnostic**
- Separate rendering concerns from models
- Provide clean MAUI `ICanvas` drawing extensions
- Avoid duplication of drawing logic across UI layers

---

## 📦 Supported primitives

- `CirclePrimitive`
- `LinePrimitive`
- `RectanglePrimitive`
- `TextPrimitive`

Each primitive lives in `Mtf.Drawing.Render` and is rendered via extension methods in this package.

---

## 🧱 Design principles

### 1. Separation of concerns
Geometry and rendering are separated:

- `Mtf.Drawing` → math + shapes + transformations
- `Mtf.Maui.Drawing` → MAUI rendering only

### 2. Stateless rendering
Extensions do not mutate primitives.

### 3. Minimal API surface
Each primitive exposes a single or minimal number of `Draw` overloads.

---

## 🎨 Usage

### Circle

```csharp
circle.Draw(canvas, Colors.Red);
````

With fill:

```csharp
circle.Draw(canvas, Colors.Black, Colors.Yellow);
```

---

### Rectangle

```csharp
rectangle.Draw(canvas, Colors.Blue);
```

With fill:

```csharp
rectangle.Draw(canvas, Colors.Black, Colors.LightGray);
```

---

### Line

```csharp
line.Draw(canvas, Colors.Green, 2f);
```

---

### Text

```csharp
text.Draw(canvas, Colors.White, 18f);
```

---

## 📐 Coordinate system

All primitives assume:

* Origin (0,0) is top-left
* Y axis increases downward (MAUI standard)
* Pixel-based coordinates

---

## ⚙️ Example in MAUI GraphicsView

```csharp
public class MyDrawable : IDrawable
{
    public CirclePrimitive Circle { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        Circle.Draw(canvas, Colors.Red, Colors.Transparent, 2f);
    }
}
```

---

## 🔧 Extensibility

To add a new primitive:

1. Create domain model in `Mtf.Drawing.Render`
2. Add extension in `Mtf.Maui.Drawing`
3. Implement `Draw(this ICanvas ...)`

Example pattern:

```csharp
public static class MyPrimitiveExtensions
{
    public static void Draw(this MyPrimitive primitive, ICanvas canvas, Color color)
    {
        ...
    }
}
```

---

## 🧠 Notes

* `Colors.Transparent` is used as "no fill" sentinel
* Rotation is currently logical only (not rendered unless explicitly implemented)
* Thickness applies to stroke-based rendering only

---

## 📌 Dependencies

* .NET MAUI Graphics (`Microsoft.Maui.Graphics`)
* `Mtf.Drawing`
