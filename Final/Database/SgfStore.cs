using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Final.DatabaseToken;

namespace Final.Database
{
    /// <summary>
    /// 用于程序与数据库进行通信的接口
    /// </summary>
    public class SgfStore
    {
        private string connectionString;
        public SgfStore()
        {
            connectionString 
            = $"Server={ServerName};Database={DatabaseName};User Id={UserName};Password={Password}";
        }

        /// <summary>
        /// 将sgf字符串存储到数据库中
        /// </summary>
        /// <param name="sgf"></param>
        /// <param name="AIComment"></param>
        /// <returns></returns>
        public async Task StoreSgfAsync(string sgf,string? AIComment=null)
        {
            string sqlStatement =
$@"
INSERT INTO {TableName}
VALUES
(@Name,@Sgf,@AI)
";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(sqlStatement, conn);
                command.Parameters
                    .AddRange(
                    [
                        new SqlParameter("@Name", DateTime.Now.ToString("棋局yyyy-MM-dd-HH-mm-ss")),
                        new SqlParameter("@Sgf",sgf),
                        new SqlParameter("@AI",AIComment)
                    ]);
                conn.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// 根据名称获取相关数据，null表示该条目不存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<(string,string)?> LoadGameHistoryAsync(string name)
        {
            string sqlStatement =
$@"
SELECT SgfContent,AIComment
FROM {TableName}
WHERE Name=@name
";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(sqlStatement, conn);
                command.Parameters
                    .AddWithValue("@name", name);
                conn.Open();
                using var reader=await command.ExecuteReaderAsync();
                //是否获取了值？
                if(reader.Read())
                {
                    return (reader.GetString(0), reader.GetString(1));
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 对某条记录进行重命名
        /// </summary>
        /// <param name="oldname"></param>
        /// <param name="newname"></param>
        /// <returns></returns>
        public async Task RenameRecordAsync(string oldname, string newname)
        {
            string sqlStatement =
$@"
UPDATE {TableName}
SET Name=@newname
WHERE Name=@oldname
";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(sqlStatement,conn);
                command.Parameters
                    .AddRange(
                    [
                        new SqlParameter("@oldname",oldname),
                        new SqlParameter("@newname",newname)
                    ]);
                conn.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// 获取Name的表项用以填充listBoxHistory
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetNameListAsync()
        {
            string sqlStatement =
$@"
SELECT Name
FROM {TableName}
";
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(sqlStatement, conn);
                conn.Open();
                var reader= await command.ExecuteReaderAsync();
                while(reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据名称删除棋谱
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task RemoveGameHistory(string name)
        {
            string sqlStatement =
$@"
DELETE FROM {TableName}
WHERE Name=@name
";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand command =new SqlCommand(sqlStatement, conn);
                command.Parameters
                    .AddWithValue("@name", name);
                conn.Open();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
