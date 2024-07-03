using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.ComponentModel;
using Sdcb.DashScope;

namespace Final
{
    public partial class formMain : Form
    {
        // Dashscope��URI
        private const string uri = "https://dashscope.aliyuncs.com/api/v1/services/aigc/text-generation/generation";
        //api��Կ
        private const string apikey = "sk-06073ad714b143829d36022210d03e33";//TODO: ����Ϊ���ļ��ж�ȡ
        private QwenClient client;
        public formMain()
        {
            InitializeComponent();
        }

        // ������ť�����µ��¼�
        private async void button_Click(object sender, EventArgs e)
        {
            // ȷ������İ�ť
            Button playerbtn = (Button)sender;
            if (playerbtn.BackColor != Color.White)
            {
                labelTurn.Text = "��ѡ������ӵ�λ��";
                return;
            }
            var position = tableLayoutPanel1.GetPositionFromControl(playerbtn);
            int x = position.Row;
            int y = position.Column;
            playerbtn.BackColor = Color.Blue;

            // ��AIѡ������λ��
            Button aibtn;
            labelTurn.Text = "�ȴ�����";
            bool isFirstAsk = true;
            do
            {
                string respond;
                if (isFirstAsk){
                    isFirstAsk= false;
                    respond = await client.sendPrompt($"({x},{y})");
                }
                else
                    respond = await client.sendPrompt("����Чλ�ã�������ѡ��");
                if (respond.Contains("��Ϸ����"))
                    return;
                labelTurn.Text = respond;
                aibtn = (Button)tableLayoutPanel1.GetControlFromPosition(respond[3] - '0', respond[1] - '0');
            } while (aibtn==null||aibtn.BackColor != Color.White);
            aibtn.BackColor = Color.Red;
            labelTurn.Text = "��Ļغ�";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // ��ʼ��
            labelTurn.Text = "��Ļغ�";
            string initialPrompt = "�������¾�����ɣ�ÿ�����ã�x,y������������ʾ���ӵ�λ�ã�����������ע�⣬��Ļش�ֻ����(x,y)�ĸ�ʽ������Ҫ�ж�������ݣ�����x,y��ȡֵ��ֻ��Ϊ0��1��2";
            client = new QwenClient(apikey, initialPrompt);
        }
    }
}
