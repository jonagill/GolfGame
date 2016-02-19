using UnityEngine;
using System.Collections.Generic;

public static class ScreenExtensions  
{
    public const float DefaultDPI = 150;

    public static float DPI
    {
        get
        {
            float dpi = Screen.dpi;
            if (dpi == 0)
            {
                dpi = DefaultDPI;
            }

            return dpi;
        }
    }

    public static float PixelsToInches(float pixels)
    {
        return pixels / DPI;
    }
}
