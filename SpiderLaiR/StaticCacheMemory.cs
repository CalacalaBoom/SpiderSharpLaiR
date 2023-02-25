using SpiderLaiR.Assets;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SpiderLaiR
{
    public static class StaticCacheMemory
    {
        public static ConfigModel? config { get; set; } = new ConfigModel();

        public static void OpenInBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
        }

        //文本写入内容
        public static void ToWrite(string strs)
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SpiderSharpLaiR\\config.ini", FileMode.Create, FileAccess.Write);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(strs.ToString());
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}