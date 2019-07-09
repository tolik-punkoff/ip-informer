using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace IPInformer2
{
    public enum TrayIconType
    {
        Connecting = 0,
        NoNetwork = 1,
        OK = 2,
        Off=3,
        Panic=4,
        Warning = 5
    }
    public static class TrayIcons
    {
        private static Icon[] trayIcons = new Icon[6];

        [System.Runtime.InteropServices.DllImport("user32.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private extern static bool DestroyIcon(IntPtr handle);

        static TrayIcons()
        {
            trayIcons[(int)TrayIconType.Connecting] = Properties.Resources.ip_blue_16x16;
            trayIcons[(int)TrayIconType.NoNetwork] = Properties.Resources.ip_gray_16x16;
            trayIcons[(int)TrayIconType.OK] = Properties.Resources.ip_green_16x16;
            trayIcons[(int)TrayIconType.Off] = Properties.Resources.ip_off_16x16;
            trayIcons[(int)TrayIconType.Panic] = Properties.Resources.ip_red_16x16;
            trayIcons[(int)TrayIconType.Warning] = Properties.Resources.ip_yellow_16x16;
        }

        public static void TrayIcon(TrayIconType TargetIcon, NotifyIcon ni, bool warning)
        {
            ni.Icon=trayIcons[(int)TargetIcon];

            if (warning)
            {
                SetWarning(ni);
            }
        }

        private static void SetWarning(NotifyIcon ni)
        {
            Icon tmpIcon = ni.Icon;
            IconConverter icconv = new IconConverter();
            
            Bitmap TargetBitmap = (Bitmap)icconv.ConvertTo(tmpIcon, typeof(Bitmap));
            Bitmap OverlayBitmap = Properties.Resources.overlay;
            Bitmap ResultBitmap = new Bitmap(TargetBitmap.Width, TargetBitmap.Height,
                PixelFormat.Format32bppArgb);
            
            Graphics graph = Graphics.FromImage(ResultBitmap);
            graph.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            graph.DrawImage(TargetBitmap, 0, 0);
            graph.DrawImage(OverlayBitmap, 0, TargetBitmap.Height - OverlayBitmap.Height);

            IntPtr hIcon = ResultBitmap.GetHicon();
            tmpIcon = Icon.FromHandle(hIcon);

            ni.Icon = tmpIcon;
        }
    }
}
