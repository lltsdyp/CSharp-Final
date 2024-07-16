using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Resources;

namespace Final
{
    public partial class formMain : Form
    {
        // Dashscope的URI
        private const string uri = "https://dashscope.aliyuncs.com/api/v1/services/aigc/text-generation/generation";
        //api密钥
        private const string apikey = "sk-06073ad714b143829d36022210d03e33";//TODO: 更改为从文件中读取
        private QwenClient client;
        private ResourceManager pictureResources;
        public formMain()
        {
            InitializeComponent();
            pictureResources = new ResourceManager("Final.Pictures",typeof(formMain).Assembly);
        }

        // 监听按钮被按下的事件
        private async void button_Click(object sender, EventArgs e)
        {
            // 确定点击的按钮
            Button playerbtn = (Button)sender;
            if (playerbtn.BackColor != Color.White)
            {
                labelTurn.Text = "请选择可落子的位置";
                return;
            }
            var position = tableLayoutPanel1.GetPositionFromControl(playerbtn);
            int x = position.Row;
            int y = position.Column;
            playerbtn.BackColor = Color.Blue;

            // 让AI选择下棋位置
            Button aibtn;
            labelTurn.Text = "等待对手";
            bool isFirstAsk = true;
            do
            {
                string respond;
                if (isFirstAsk)
                {
                    isFirstAsk = false;
                    respond = await client.sendPrompt($"({x},{y})");
                }
                else
                    respond = await client.sendPrompt("非有效位置，请重新选择");
                if (respond.Contains("游戏结束"))
                    return;
                labelTurn.Text = respond;
                aibtn = (Button)tableLayoutPanel1.GetControlFromPosition(respond[3] - '0', respond[1] - '0');
            } while (aibtn == null || aibtn.BackColor != Color.White);
            aibtn.BackColor = Color.Red;
            labelTurn.Text = "你的回合";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // 初始化
            labelTurn.Text = "你的回合";
            string initialPrompt = "我们来下井字棋吧，每个人用（x,y）的坐标来表示落子的位置，我先来，请注意，你的回答只能是(x,y)的格式，而不要有多余的内容，而且x,y的取值均只能为0，1，2";
            client = new QwenClient(apikey, initialPrompt);
        }

        private void panel_Click(object sender, EventArgs e)
        {

        }
    }
}
