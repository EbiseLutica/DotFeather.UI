using System;
using System.Drawing;

namespace DotFeather.UI
{
    /// <summary>
    /// <see cref="DotFeather.UI"/> のユーザーインターフェイスを抽象化します。
    /// </summary>
    public abstract class UIElement
    {
        public int ZOrder { get; set; }
        public string Name { get; set; }
        public Vector Location { get; set; }
        public float Angle { get; set; }
        public Vector Scale { get; set; } = Vector.One;
        public int Width { get; set; } = 240;
        public int Height { get; set; } = 240;

        public virtual void Destroy() { }

        public virtual bool OnJudge(GameBase game)
        {
            var mouse = Input.Mouse.Position;
            if (Intersect(mouse))
            {
                if (prevMouse != mouse)
                    MouseMove?.Invoke(this);
                if (Input.Mouse.IsLeftDown)
                {
                    MouseDown?.Invoke(this);
                }
                if (Input.Mouse.IsLeftUp)
                {
                    MouseUp?.Invoke(this);
                }
                return true;
            }

            prevMouse = mouse;
            return false;
        }

        public virtual void OnUpdate(GameBase game)
        {
            if (Input.Mouse.IsLeftUp)
                isClicked = false;
        }

        private bool Intersect(Point p) => Intersects.BoxPoint(Location.X, Location.Y, Width, Height, p.X, p.Y);

        private bool PrevEnter => Intersect(prevMouse);
        private bool isClicked;
        private Point prevMouse;

        public event DFUIEventHandler Click;
        public event DFUIEventHandler MouseDown;
        public event DFUIEventHandler MouseUp;
        public event DFUIEventHandler MouseMove;
        public event DFUIEventHandler Enter;
        public event DFUIEventHandler Leave;
    }

    public delegate void DFUIEventHandler(UIElement sender);
}
