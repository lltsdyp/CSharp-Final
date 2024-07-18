using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class QwenClient
    {
        private readonly string apiKey;
        private readonly string modelURL;
        private PromptRequest message;

        /// <summary>
        /// 创建一个简单的通义千问客户端
        /// </summary>
        /// <param name="apiKey">阿里云控制台中生成的API-KEY</param>
        /// <param name="systemMessage">需要传递给通义千问的系统信息，留空则不传递</param>
        /// <param name="modelURL">模型的URL，通常无需更改</param>
        public QwenClient(string apiKey,string systemMessage="", string modelURL= "https://dashscope.aliyuncs.com/api/v1/services/aigc/text-generation/generation")
        {
            this.apiKey = apiKey;
            this.modelURL = modelURL;
            if (systemMessage != "")
                this.message = new PromptRequest(systemMessage);
            else
                this.message = new PromptRequest();
        }

        /// <summary>
        /// 向Qwen发送提示词
        /// </summary>
        /// <param name="prompt">提示词</param>
        /// <returns></returns>
        public async Task<string> sendPrompt(string prompt)
        {
            //初始化调用通义大模型的客户端
            using (var client = new HttpClient())
            {
                // 创建http请求类，并进行一些必要的初始化工作
                var request = new HttpRequestMessage(HttpMethod.Post, modelURL);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // json转化的设置
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
                };

                // json消息体
                message.Add(Role.USER,prompt);
                // 转化为json字符串
                string requestStr = JsonConvert.SerializeObject(message, settings).ToLower();
                request.Content = new StringContent(requestStr, Encoding.UTF8, "application/json");

                // 发送消息
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // 将通义生成的内容转换为json格式，然后输出
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    dynamic responseAnswer = JsonConvert.DeserializeObject<dynamic>(responseMessage);

                    // 将通义灵码的输出记录到PromptRequest中
                    string responseText = responseAnswer.output.text;
                    message.Add(Role.ASSISTANT, responseText);
                    return responseText;
                }
                else
                {
                    return "ERROR!!" + response.StatusCode.ToString();
                }
            }
        }

        /// <summary>
        /// 清除记录
        /// </summary>
        public void CleanMessage()
        {
            message.input.messages = new List<Message>();
        }
    }
}
