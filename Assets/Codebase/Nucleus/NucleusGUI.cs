using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Nucleus.NGUI
{
    public interface IDraggable
    {
        void EndedDrag();
    }
    public static class NucleusGUI
    {
        private static object dragging;
        private static IDraggable drag;
        public static object DraggingObject { get { return dragging; } }

        public static bool StartDrag(object ob, IDraggable drag)
        {
            if (dragging == null && drag != null)
            {
                dragging = ob;
                NucleusGUI.drag = drag;
                return true;
            }
            return false;
        }

        public static void EndDrag()
        {
            dragging = null;
            drag.EndedDrag();
            drag = null;
        }

        public static void FillRectangle(Rect pos, Color color)
        {
            Color backColor = GUI.color;
            GUI.color = color;
            GUI.DrawTexture(pos, Texture2D.whiteTexture);
            GUI.color = backColor;
        }
        public static void FillRectangle(Rect pos, Color color, float rotation)
        {
            Color backColor = GUI.color;
            GUIUtility.RotateAroundPivot(rotation, new Vector2(pos.x, pos.y));
            GUI.color = color;
            GUI.DrawTexture(pos, Texture2D.whiteTexture);
            GUI.color = backColor;
            GUI.matrix = Matrix4x4.identity;
        }

        public static void DrawTexture(Texture2D texture, Rect pos, Color color, float rotation)
        {
            Color backColor = GUI.color;
            GUIUtility.RotateAroundPivot(rotation, new Vector2(pos.x, pos.y));
            GUI.color = color;
            GUI.DrawTexture(pos, texture);
            GUI.color = backColor;
            GUI.matrix = Matrix4x4.identity;
        }

        public static Vector2 MeasureLabel(string text)
        {
            var skin = GUI.skin;
            var style = skin.label;
            GUIContent content = new GUIContent(text);
            Vector2 size = style.CalcSize(content);

            return size;
        }

        public static float LabelHeight(string text, float width)
        {
            var skin = GUI.skin;
            var style = skin.label;
            GUIContent content = new GUIContent(text);
            float h = style.CalcHeight(content, width);

            return h;
        }

        public static void Label(Rect pos, string text, int shadow, Color shadowColor)
        {
            Color back = GUI.color;
            if (shadow != 0)
            {
                Rect p = pos;
                p.x += shadow;
                p.y += shadow;
                GUI.color = shadowColor;
                GUI.Label(p, text);
                GUI.color = back;
            }
            GUI.Label(pos, text);

        }
        public static void Label(Rect pos, string text, int shadow, int outline, Color shadowColor)
        {
            Color back = GUI.color;
            if (shadow != 0)
            {
                Rect p = pos;
                p.x += shadow;
                p.y += shadow;
                GUI.color = shadowColor;
                GUI.Label(p, text);
                GUI.color = back;
            }
            if (outline != 0)
            {
                GUI.color = shadowColor;

                Rect p = pos;
                p.x += outline;
                GUI.Label(p, text);
                p = pos;
                p.x -= outline;
                GUI.Label(p, text);
                p = pos;
                p.y += outline;
                GUI.Label(p, text);
                p = pos;
                p.y -= outline;
                GUI.Label(p, text);

                GUI.color = back;
            }
            GUI.Label(pos, text);

        }
    }
}
