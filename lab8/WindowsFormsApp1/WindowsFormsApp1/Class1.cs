using System;
using System.Drawing;
using System.Windows.Forms;

interface ICircle
{
    void Draw(Graphics g);
}

// The concrete Circle class
class Circle : ICircle
{
    private int _x, _y, _radius;

    public Circle(int x, int y, int radius)
    {
        _x = x;
        _y = y;
        _radius = radius;
    }

    public void Draw(Graphics g)
    {
        g.DrawEllipse(new Pen(Color.Black), _x - _radius, _y - _radius, 2 * _radius, 2 * _radius);
    }
}

// The abstract decorator class
abstract class CircleDecorator : ICircle
{
    private ICircle _circle;

    public CircleDecorator(ICircle circle)
    {
        _circle = circle;
    }

    public virtual void Draw(Graphics g)
    {
        _circle.Draw(g);
    }
}

// The ConsoleDecorator class
class ConsoleDecorator : CircleDecorator
{
    public ConsoleDecorator(ICircle circle) : base(circle)
    {
    }

    public override void Draw(Graphics g)
    {
        base.Draw(g);
        Console.WriteLine("Drawing Circle on Console");
    }
}

// The VisualDecorator class
class VisualDecorator : CircleDecorator
{
    private Form _form;

    public VisualDecorator(ICircle circle, Form form) : base(circle)
    {
        _form = form;
    }

    public override void Draw(Graphics g)
    {
        base.Draw(g);
        g.Dispose(); // Clean up the graphics object

        // Draw the circle on the form
        using (Graphics formGraphics = _form.CreateGraphics())
        {
            base.Draw(formGraphics);
        }

        Console.WriteLine("Drawing Circle on Visual Layout");
    }
}