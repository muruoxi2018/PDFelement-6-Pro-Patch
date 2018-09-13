using System;
using System.Windows.Forms;
using System.Security.Principal;

namespace PDFelement_6_Pro
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            Application.EnableVisualStyles();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            Application.SetCompatibleTextRenderingDefault(false);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                Application.Run(new Form1());
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //设置运行文件
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                //如果不是管理员，则启动UAC
                System.Diagnostics.Process.Start(startInfo);
                //退出
                Application.Exit();
            }
        }
    }
}
