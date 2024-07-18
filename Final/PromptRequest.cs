using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    /// <summary>
    /// 请求格式的数据类，最终转化为json格式
    /// </summary>
    public class PromptRequest
    {
        public string model;
        public Input input;
        public PromptRequest()
        {
            this.model = "qwen-max";
            this.input= new Input();
        }
        public PromptRequest(string prompt) : this(prompt, "qwen-max") { }
        public PromptRequest(string prompt, string model)
        {
            this.model = model;
            this.input = new Input(prompt);
        }

        public void Add(Role role,string prompt)
        {
            this.input.Add(role,prompt);
        }
    }

    public class Input
    {
        public List<Message> messages;

        public Input()
        {
            this.messages = [];
        }
        public Input(string prompt)
        {
            this.messages = [new Message(Role.SYSTEM,prompt)];
        }

        public void Add(Role role,string content)
        {
            messages.Add(new Message(role,content));
        }
    }

    public enum Role
    {
        SYSTEM,
        USER,
        ASSISTANT
    }
    public class Message
    {
        public string role;
        public string content;

        public Message(Role role, string content)
        {
            this.role = role.ToString().ToLower();
            this.content = content;
        }
    }
}
