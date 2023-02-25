using SqlSugar;

namespace lib
{
    /// <summary>
    ///
    ///</summary>
    [SugarTable("txt")]
    public class Txt
    {
        /// <summary>
        /// TXTID
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 小说标题
        ///</summary>
        [SugarColumn(ColumnName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// 小说链接
        ///</summary>
        [SugarColumn(ColumnName = "Url")]
        public string Url { get; set; }

        /// <summary>
        /// 封面链接
        ///</summary>
        [SugarColumn(ColumnName = "Imgurl")]
        public string Imgurl { get; set; }

        /// <summary>
        /// 小说简介
        ///</summary>
        [SugarColumn(ColumnName = "Content")]
        public string Content { get; set; }

        /// <summary>
        /// 作者
        ///</summary>
        [SugarColumn(ColumnName = "Author")]
        public string Author { get; set; }

        /// <summary>
        /// 连载状态
        ///</summary>
        [SugarColumn(ColumnName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// 小说体量
        ///</summary>
        [SugarColumn(ColumnName = "Size")]
        public string Size { get; set; }

        /// <summary>
        /// 分类
        ///</summary>
        [SugarColumn(ColumnName = "Classifation")]
        public string Classifation { get; set; }

        /// <summary>
        /// 最新一章名称
        ///</summary>
        [SugarColumn(ColumnName = "New")]
        public string New { get; set; }

        /// <summary>
        /// 阅读人次
        ///</summary>
        [SugarColumn(ColumnName = "Watch")]
        public string Watch { get; set; }

        /// <summary>
        /// 下载URL
        ///</summary>
        [SugarColumn(ColumnName = "DownUrl")]
        public string DownUrl { get; set; }
    }
}