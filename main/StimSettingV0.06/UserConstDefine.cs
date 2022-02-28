using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StimSettingV0._06
{
    public static class util
    {
        public static void SaveWindow(Window window, int dpi, string filename)
        {

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width
                (int)window.Width, //height
                dpi, //dpi x
                dpi, //dpi y
                PixelFormats.Pbgra32 // pixelformat
                );
            rtb.Render(window);

            SaveRTBAsPNG(rtb, filename);

        }

        public static void SaveCanvas(Window window, Canvas canvas, int dpi, string filename)
        {
            Size size = new Size(canvas.Width, canvas.Height);
            size = new Size(canvas.ActualWidth, canvas.ActualHeight);

            canvas.Measure(size);

            var rtb = new RenderTargetBitmap(
                (int)size.Width,//(int)window.Width, //width
                (int)size.Height,//window.Height, //height
                dpi, //dpi x
                dpi, //dpi y
                PixelFormats.Pbgra32 // pixelformat
                );
            rtb.Render(canvas);

            SaveRTBAsPNG(rtb, filename);
        }

        private static void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            //PngBitmapEncoder()用于编码可移植网络图形 (PNG) 格式图像的编码器
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));
            //Frames获取或设置图像内的各帧                //BitmapFrame由解码器返回并被编码器接受的图像数据
            //Create(Bitmapsource)  从给定的Bitmapsource创建新的BitmapFrame
            using (var stm = System.IO.File.Create(filename))
            {        //System.IO.File提供用于创建、复制、删除、移动和打开单一文件的静态方法，并协助创建 FileStream 对象
                     //Create在指定路径中创建或覆盖文件
                enc.Save(stm);
                //PngBitmapEncoder.Save(System.IO.Stream)将位图图像编码为指定的System.IO.Stream
            }
        }
    }
    public static class UserConstDefine
    {

        public const double markerCircleHeigh = 30;//标记数据点用的圈的高度
        public const double markerCircleWidth = 30;//标记数据点用的圈的宽度
                                                   //const   定义一个常量
                                                   //new  创建一个空间
    }

}
