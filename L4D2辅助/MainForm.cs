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

        string JUMP = "";//内存位置，形如 client.dll+0x756DF0
        string AIR = "";//内存位置，形如 client.dll+0x6E0008

        public MainForm()
        {
            LoadAddress();
            InitializeComponent();
        }

        private void LoadAddress()
        {
            var path = @"./address.ini";

            if (!File.Exists(path)){  // 文件不存在，写入规则
                var file = File.Create(path);
                var content = "###地址值配置文件###\r\n###只在版本更新时需要更改配置文件的内容(每次版本更新游戏程序的地址值会变)\r\n###得到并修改以下两个十六进制地址值（地址值通过CE得到，方法如下：\r\n###JUMP: 这个地址内储存的值的特征是：初始值是4，在游戏的控制台输入+jump变成5，输入-jump变成4，跳的时候会在4和5之间变化\r\n###AIR：这个地址内储存的值特征是：初始是0（不跳跃的时候）。跳跃在空中时增大（一个大数），落地又变成0，走路的时候不会变。）\r\n\r\nJUMP=client.dll+0x757DF0\r\nAIR=client.dll+0x6E1008";
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
        }

        private int left4dead2PID = 0;
        void findL4D2PID(object sender, EventArgs e)
        {
            if (checkBox_LT.Checked)
            {
                int PID = m.GetProcIdFromName("left4dead2");
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
        void SUKAN()
        {
            while (true)
            {
                if (checkBox_SK.Checked)
                {
                    if (GetAsyncKeyState(Keys.X) < 0)
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
        void LIANDIAN()
        {
            while (true)
            {
                if (checkBox_LD.Checked)
                {
                    if (GetAsyncKeyState(Keys.T) < 0)
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
    }
}
