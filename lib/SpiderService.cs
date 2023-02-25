using HtmlAgilityPack;
using System.Net;

namespace lib
{
    public class SpiderService : IDownload
    {
        private string URL { get; set; }

        public SpiderService(string url)
        {
            this.URL = url;
        }

        //爬取源标题
        public string GetTitle()
        {
            HtmlWeb web = new HtmlWeb();

            HtmlDocument? htmlDoc = web.Load(URL);

            HtmlNode? node = htmlDoc.DocumentNode.SelectSingleNode("//body/div").SelectSingleNode("//a");

            return node.InnerText;
        }

        //爬取书库总页数
        public int TotalPages()
        {
            HtmlWeb web = new HtmlWeb();

            HtmlDocument? htmlDoc = web.Load(URL);

            var nodes = htmlDoc.DocumentNode
                .SelectNodes("//div")
                .Single(s => s.Attributes["class"].Value == "pages")
                .SelectNodes("a");
            string href = nodes[nodes.Count - 1].Attributes["href"].Value;
            string[] hrefFormat = href.Split('/');

            return Convert.ToInt32(hrefFormat[hrefFormat.Length - 2]);
        }

        /// <summary>
        /// 爬取某一页的小说信息，此时的URL为小说页的信息
        /// </summary>
        /// <param name="pageNum">第一页</param>
        /// <returns>当前页小说列表</returns>
        public List<TxtModel> InitPages(int pageNum)
        {
            string url = URL + $"{pageNum}/";

            HtmlWeb web = new HtmlWeb();

            HtmlDocument? htmlDoc = web.Load(url);

            List<TxtModel> txts = new List<TxtModel>();

            var nodes = htmlDoc.DocumentNode
                .SelectNodes("//body//div")
                .Where(w => w.Attributes["class"].Value == "bookinfo");

            foreach (var node in nodes)
            {
                TxtModel model = new TxtModel();
                HtmlNode? a = node.SelectSingleNode("h4/a");
                model.Url = "http://www.vbiquge.co" + a.Attributes["href"].Value;
                model.ID = a.Attributes["href"].Value.Replace("/", "").Replace(" ", "_");
                model.Title = a.InnerText;
                var divs = node.SelectNodes("div");
                model.Author = divs[0].InnerText.Replace("作者：", "");
                model.Size = divs[1].InnerText.Replace("字数：", "");
                model.Watch = divs[2].InnerText.Replace("阅读量：", "");
                model.New = divs[3].InnerText.Replace("更新到：", "");
                model.Content = divs[4].InnerText.Replace("简介：", "");
                txts.Add(model);
            }

            return txts;
        }

        //爬取小说下载页信息（状态，分类，封面，下载链接）
        public void Start(TxtModel txt)
        {
            HtmlWeb web = new HtmlWeb();

            HtmlDocument? htmlDoc = web.Load(txt.Url);

            var node = htmlDoc.DocumentNode
                .SelectSingleNode("//body/div[2]/div[1]");
            txt.Classification = node.SelectSingleNode("ol/li[2]").InnerText;
            txt.Imgurl = node.SelectSingleNode("div[1]/div[1]/img").Attributes["src"].Value;
            txt.Status = node.SelectSingleNode("div[1]/div[2]/p[1]/span[3]").InnerText;
            txt.DownUrl = "http://www.vbiquge.co" + node.SelectSingleNode("div[1]/div[2]/div/a[3]").Attributes["href"].Value;
        }

        //下载文件
        public bool DownloadFile(object model, int timeout = 2000)
        {
            TxtModel? txt = model as TxtModel;
            string Path = "E:\\Testc\\";
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            try
            {
                if (!File.Exists(Path + txt.ID + txt.Title + ".txt"))
                {
                    File.Create(Path + txt.ID + txt.Title + ".txt").Close();
                }
                WebClient webClient = new WebClient();
                webClient.Credentials = CredentialCache.DefaultCredentials;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                webClient.DownloadFile(txt.Url, Path + txt.ID + txt.Title + ".txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[×] {Path + txt.ID + txt.Title}.txt下载失败\r\n{ex.Message}");
                return false;
            }
            return true;
        }
    }
}