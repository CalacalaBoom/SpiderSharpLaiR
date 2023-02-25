using SqlSugar;

namespace lib
{
    /// <summary>
    ///
    ///</summary>
    [SugarTable("userindo")]
    public class Userindo
    {
        /// <summary>
        ///
        ///</summary>
        [SugarColumn(ColumnName = "Username", IsPrimaryKey = true)]
        public string Username { get; set; }

        /// <summary>
        ///
        ///</summary>
        [SugarColumn(ColumnName = "Password")]
        public string Password { get; set; }
    }
}