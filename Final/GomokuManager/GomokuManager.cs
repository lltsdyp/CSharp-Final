using Final.Gomoku;
using System.Diagnostics;

namespace Final.GomokuManager
{
    /// <summary>
    /// 五子棋与AI交互的接口
    /// TODO:改为异步读写
    /// </summary>
    public class GomokuManager : IDisposable
    {
        // 五子棋AI程序的文件名
        private Process program;
        private Dictionary<string, string> config;

        public GomokuManager(string filename)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = filename,// 使用提供的文件名
                RedirectStandardInput = true, // 重定向标准输入
                RedirectStandardOutput = true, // 重定向标准输出
                UseShellExecute = false, // 不使用操作系统shell启动
                CreateNoWindow = true // 不创建新窗口
            };
            program = Process.Start(startInfo);

            // 下面初始化一些配置，如果没有配置文件重写功能则使用默认设置
            config = new Dictionary<string, string>
            {
                // 设置最长步时为1s
                {"timeout_turn","1000" },
                {"timeout_match","0" },
                {"max_memory","0" },
                {"time_left","2147483647" },
                {"game_type","0" },
                {"rule","1" },
            };
        }

        public void GameStart()
        {
            // 发送START消息
            string response = SendMessage("START 15");
            if (!response.Contains("OK"))
            {
                throw new InvalidProgramException($"{program.ProcessName}运行出错");
            }

            //发送INFO信息
            foreach (var item in config)
            {
                program.StandardInput.WriteLine($"INFO {item.Key} {item.Value}");
            }
            program.StandardInput.Flush();
        }

        public void GameRestart()
        {
            string response = SendMessage("RESTART");
            if (!response.Contains("OK"))
            {
                throw new InvalidProgramException($"{program.ProcessName}运行出错");
            }
        }

        /// <summary>
        /// 从AI处获取回复，一行一项
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendMessage(string message)
        {
            program.StandardInput.WriteLine(message);
            program.StandardInput.Flush();

            string line;
            do
            {
                line = program.StandardOutput.ReadLine();
            } while (line.StartsWith("DEBUG") || line.StartsWith("MESSAGE"));
            return line;
        }



        /// <summary>
        /// 向棋盘上添加棋子并通知AI
        /// </summary>
        /// <param name="point">棋子位置</param>
        /// <returns></returns>
        public PanelPoint PlacePiece(PanelPoint point)
        {
            // AI返回的应该是x,y
            var resultStr = SendMessage($"TURN {point.x},{point.y}");
            // TODO:更好地处理SUGGEST
            if (resultStr.Contains("SUGGEST"))
            {
                // 删除SUGGEST头
                resultStr = resultStr[7..];
            }
            var result = resultStr.Split(",");
            return new PanelPoint(int.Parse(result[0]), int.Parse(result[1]));
        }

        public void GameEnd()
        {
            program.StandardInput.WriteLine("END");
            program.Kill();
        }
        public void Dispose()
        {
            GameEnd();
            program?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
