using Nucleus.NGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ConsoleU {
    public static int Width = 120;
    public static int Height = 30;
    public static int FontSize = 16;

    private static char[,] buffer = new char[Width, Height];
    private static Font font;
    private static GUIStyle style;

    public static int Left = 0;
    public static int Top = 0;

    public static string InputString;

    public static bool KeyAvailable {
        get {
            return !string.IsNullOrEmpty(InputString);
        }
    }

    public static ConsoleKey ReadKey(bool something) {
        return (ConsoleKey)Enum.Parse(typeof(ConsoleKey), InputString);
    }

    public static void WriteLine(string value) {
        if (string.IsNullOrEmpty(value)) {
            return;
        }

        bool breaker = false;
        bool firstLine = true;
        int pos = 0;

        for (var y = 0; y < Height; y++) {
            var x = 0;
            if (firstLine) {
                x = Left;
                y = Top;
                firstLine = false;
            }

            for (; x < Width; x++) {
                var val = value[pos++];
                
                if (pos >= value.Length) {
                    breaker = true;
                    Left = x;
                    Top = y;
                    break;
                }
                else if (val == '\n') {
                    y++;
                    x = -1;
                    continue;
                }
                buffer[x, y] = val;
            }

            if (breaker) {
                break;
            }
        }
    }

    public static void Clear() {
        Left = 0;
        Top = 0;
        // disable clearing for v-sync
        //for (var x = 0; x < Width; x++) {
        //    for (var y = 0; y < Height; y++) {
        //        buffer[x, y] = ' ';
        //    }
        //}
    }

    public static void OnGUI() {
        // Load and set Font
        if (font == null) {
            font = (Font)Resources.Load("Fonts/consola", typeof(Font));

            style = new GUIStyle();
            style.font = font;
            style.fontSize = 16;
            style.normal.textColor = Color.white;
        }

        // 1 pt = 0.350mm
        // 16 pt = 5.6cm
        // 96 dpi = 243.84 dpcm
        int charWidth = FontSize / 2; // -1?
        int actualWidth = Width * charWidth;
        int actualHeight = FontSize * Height;

        NucleusGUI.FillRectangle(new Rect(0, 0, actualWidth, actualHeight), Color.black);

        for (var x = 0; x < Width; x++) {
            for (var y = 0; y < Height; y++) {
                char c = buffer[x, y];
                GUI.Label(new Rect(x * charWidth, y * FontSize, charWidth, FontSize), c.ToString(), style);
            }
        }
    }
}
