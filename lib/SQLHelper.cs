using SqlSugar;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace lib
{
    public class SQLHelper
    {
        #region GetSqlDB

        //多库情况下使用说明：
        //如果是固定多库可以传 new SqlSugarScope(List<ConnectionConfig>,db=>{}) 文档：多租户
        //如果是不固定多库 可以看文档Saas分库

        //用单例模式
        public static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            ConnectionString = "server=localhost;Database=SpiderSharpDB;Uid=root;Pwd=0502",//连接符字串
            DbType = DbType.MySql,//数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        }, db =>
        {
            //(A)全局生效配置点，一般AOP和程序启动的配置扔这里面 ，所有上下文生效
            //调试SQL事件，可以删掉
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Debug.WriteLine(sql);//输出sql,查看执行sql 性能无影响
                                     //5.0.8.2 获取无参数化 SQL  对性能有影响，特别大的SQL参数多的，调试使用
                                     //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)
            };
            //多个配置就写下面
            //db.Ado.IsDisableMasterSlaveSeparation=true;

            //注意多租户 有几个设置几个
            //db.GetConnection(i).Aop
        });

        #endregion GetSqlDB

        public static string myMD5(string txt, int count)
        {
            byte[] sor = Encoding.UTF8.GetBytes(txt);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                strbul.Append(result[i].ToString("x3"));
            }
            string fin = strbul.ToString();
            count--;
            if (count != 0) fin = myMD5(fin, count);
            return fin;
        }
    }
}