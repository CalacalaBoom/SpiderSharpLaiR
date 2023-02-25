using lib;

namespace Spider.ConsoleTestc
{
    public class Program
    {
        private static void Main(string[] args)
        {
            SpiderService todo = new SpiderService("http://www.vbiquge.co/xclass/");
            Console.WriteLine($"Title:\r\n{todo.GetTitle()}\r\n");

            int totalPages = todo.TotalPages();
            Console.WriteLine($"TotalPage:\r\n{totalPages}\r\n");

            int pageNum = 1;
            List<TxtModel> txts = todo.InitPages(pageNum);
            Console.WriteLine("Page 1:");
            string ShowTxt = "";
            for (int i = 0; i < txts.Count; i++)
            {
                ShowTxt += $"{i + 1}.{txts[i].Title}({txts[i].ID}) 作者：{txts[i].Author}\r\n";
            }
            Console.WriteLine(ShowTxt);

            for (int i = 0; i < txts.Count - 1; i++)
            {
                todo.Start(txts[i]);
                Console.WriteLine($"[{txts[i].Url}]\r\n{txts[i].ID + txts[i].Title}.txt开始下载...");
                todo.DownloadFile(txts[i]);
            }
        }
    }
}