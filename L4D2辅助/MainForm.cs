using Memory;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace L4D2辅助
{
    public partial class MainForm : Form
    {

        public Mem m = new Mem();

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //模拟鼠标滚轮滚动操作，必须配合dwData参数
        const int MOUSEEVENTF_WHEEL = 0x0800;

        readonly string GAME_NAME = "left4dead2";

        string JUMP = "";//内存位置，形如 client.dll+0x756DF0
        string AIR = "";//内存位置，形如 client.dll+0x6E0008
        string SK_KEY = "";
        string LD_KEY = "";

        public MainForm()
        {
            LoadConfiguration();
            InitializeComponent();
        }

        private void LoadConfiguration()
        {
            var path = @"./config.ini";

            if (!File.Exists(path)){  // 文件不存在，写入规则
                var file = File.Create(path);
                var content = "###地址值配置文件###\r\n###只在版本更新时需要更改配置文件的内容(每次版本更新游戏程序的地址值会变)\r\n###得到并修改以下两个十六进制地址值（地址值通过CE得到，方法如下：\r\n###JUMP: 这个地址内储存的值的特征是：初始值是4，在游戏的控制台输入+jump变成5，输入-jump变成4，跳的时候会在4和5之间变化\r\n###AIR：这个地址内储存的值特征是：初始是0（不跳跃的时候）。跳跃在空中时增大（一个大数），落地又变成0，走路的时候不会变。）\r\n\r\nJUMP=client.dll+0x757DF0\r\nAIR=client.dll+0x6E1008\r\n其余配置请不要手动更改";
                var bytes = System.Text.Encoding.Default.GetBytes(content);
                file.Write(bytes, 0, bytes.Length);
                file.Close();
            }

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                var rLine = line.Trim();
                if (rLine.StartsWith("#")) continue;
                string[] keyAndVal = rLine.Split('=');
                if (keyAndVal.Length == 2)
                {
                    var key = keyAndVal[0].Trim();
                    var val = keyAndVal[1].Trim();
                    if (key == "JUMP")
                    {
                        JUMP = val;
                    }
                    if (key == "AIR")
                    {
                        AIR = val;
                    }
                    if (key == "SK")
                    {
                        SK_KEY = val;
                    }
                    if (key == "LD")
                    {
                        LD_KEY = val;
                    }
                }
            }
        }

        private void Init(object sender, EventArgs e)
        {
            Thread BH = new Thread(BHOP) { IsBackground = true };
            BH.Start();
            Thread SK = new Thread(SUKAN) { IsBackground = true };
            SK.Start();
            Thread LD = new Thread(LIANDIAN) { IsBackground = true };
            LD.Start();
            Thread BG = new Thread(BGFunc) { IsBackground = true };
            BG.Start();
        }

        private int left4dead2PID = 0;
        void findL4D2PID(object sender, EventArgs e)
        {
            if (checkBox_LT.Checked)
            {
                int PID = m.GetProcIdFromName(GAME_NAME);
                if (PID > 0)
                    m.OpenProcess(PID);
                left4dead2PID = PID;
                if(PID <= 0)
                    if (MessageBox.Show("请进入游戏后再勾选", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                        checkBox_LT.Checked = false;
            }
            else
            {
                if(left4dead2PID != 0)
                    m.CloseProcess();
                left4dead2PID = 0;
            }
        }

        void BGFunc()
        {
            while (true)
            {
                int PID = m.GetProcIdFromName(GAME_NAME);
                if (PID <= 0 && left4dead2PID > 0)
                {
                    left4dead2PID = 0;
                    Action<bool> AsyncUIDelegate1 = delegate (bool c) { checkBox_LT.Checked = c; };
                    checkBox_LT.Invoke(AsyncUIDelegate1, new object[] { false });
                    Action<bool> AsyncUIDelegate2 = delegate (bool c) { checkBox_SK.Checked = c; };
                    checkBox_SK.Invoke(AsyncUIDelegate2, new object[] { false });
                    Action<bool> AsyncUIDelegate3 = delegate (bool c) { checkBox_LD.Checked = c; };
                    checkBox_LD.Invoke(AsyncUIDelegate3, new object[] { false });
                }

                Thread.Sleep(3000);
            }
        }

        int lastResult;
        long groundTimeStamp;
        long airTimeStamp;
        void BHOP()
        {
            while (true)
            {
                if (checkBox_LT.Checked)
                {
                    if(left4dead2PID > 0 && !(JUMP.Equals("") || AIR.Equals("")))
                    {
                        if (GetAsyncKeyState(Keys.Space) < 0)
                        {
                            int result = m.ReadInt(AIR); 
                            if (result == 0)
                            {
                                m.WriteMemory(JUMP, "int", "5"); //4→5是起跳
                                Thread.Sleep(1);
                                m.WriteMemory(JUMP, "int", "4");
                            }


                            ////debug: 接触地面的时间
                            //result = m.ReadInt(AIR);
                            //if(result == 0 && lastResult != 0)//落地
                            //{
                            //    groundTimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                            //}
                            //if(result != 0 && lastResult == 0)//跳起
                            //{
                            //    airTimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                            //    Console.WriteLine(airTimeStamp - groundTimeStamp);  
                            //}
                            //lastResult = result;

                        }
                    }
                }
                if (left4dead2PID <= 0 || !checkBox_LT.Checked || GetAsyncKeyState(Keys.Space) >= 0) //按下空格的时候不挂起进程，挂起进程会导致不能及时执行此函数的代码而造成起跳时机不适合
                    Thread.Sleep(1); //在不按下空格时挂起防止CPU使用率过高
            }
        }

        private Keys sk_key = Keys.Z;
        private MouseButtons sk_btn;
        void SUKAN()
        {
            while (true)
            {
                if (checkBox_SK.Checked)
                {
                    if (GetAsyncKeyState(sk_key) < 0 
                        || (sk_btn == MouseButtons.XButton1 && GetAsyncKeyState(Keys.XButton1) < 0)
                        || (sk_btn == MouseButtons.XButton2 && GetAsyncKeyState(Keys.XButton2) < 0)
                        || (sk_btn == MouseButtons.Middle && GetAsyncKeyState(Keys.MButton) < 0)
                        )
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(10);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(35);
                        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 1, 0);
                        Thread.Sleep(35);
                        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -1, 0);
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(1);
            }
        }


        private Keys ld_key = Keys.X;
        private MouseButtons ld_btn;
        void LIANDIAN()
        {
            while (true)
            {
                if (checkBox_LD.Checked)
                {
                    if (GetAsyncKeyState(ld_key) < 0
                        || (ld_btn == MouseButtons.XButton1 && GetAsyncKeyState(Keys.XButton1) < 0)
                        || (ld_btn == MouseButtons.XButton2 && GetAsyncKeyState(Keys.XButton2) < 0)
                        || (ld_btn == MouseButtons.Middle && GetAsyncKeyState(Keys.MButton) < 0)
                        )
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(50);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(50);
                    }
                }
                Thread.Sleep(1);
            }
        }



        private void config_key_SK_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            config_key_SK.Text = "";
            sk_key = e.KeyCode;
            sk_btn = MouseButtons.None;
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "Key", e.KeyCode.ToString());
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "Key Event");
        }

        private void config_key_SK_Click(object sender, MouseEventArgs e)
        {
            config_key_SK.Text = "";
            sk_btn = e.Button;
            config_key_SK.Text = e.Button.ToString() + " Button";
            sk_key = Keys.None;

            //System.Console.WriteLine("Button: " + e.Button.ToString());
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event");
        }



        private void config_key_LD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            config_key_LD.Text = "";
            ld_key = e.KeyCode;
            ld_btn = MouseButtons.None;
        }

        private void config_key_LD_Click(object sender, MouseEventArgs e)
        {
            config_key_LD.Text = "";
            ld_btn = e.Button;
            config_key_LD.Text = e.Button.ToString() + " Button";
            ld_key = Keys.None;
        }

        private void bg_Click(object sender, MouseEventArgs e)
        {
            LT_spec_label.Focus();
        }
    }
}
