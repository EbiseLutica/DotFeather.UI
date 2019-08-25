using System;

namespace DotFeather.UI
{
    /// <summary>
    /// 当たり判定の算出機能を提供します。
    /// </summary>
    public static class Intersects
    {
        public static bool BoxPoint(float x1, float y1, float width, float height, float x2, float y2)
            => x1 <= x2 && y1 <= y2 && x2 <= x1 + width && y2 <= y1 + height;
        
        public static bool BoxBox(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
            => Math.Abs(x2 - x1) < (width1 + width2) / 2 && Math.Abs(y2 - y1) < (height1 + height2) / 2;
    }
}