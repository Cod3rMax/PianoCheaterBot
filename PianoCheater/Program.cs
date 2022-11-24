using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PianoCheater.Helper;
using Console = Colorful.Console;

namespace PianoCheater
{
    internal class Program
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int x, int y);



        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys xKeys);


        static void Main(string[] args)
        {


            Display.Header.DisplayHeader();



            Helper.GetWindowRectInfo.GetRectOfTheWindow(Helper.WindowFinder.GetPianoWindow());
            Console.WriteLine("[*] => Start the Game And Hold Button (X)", Color.Orange);
            while (true)
            {
                if (GetAsyncKeyState(Keys.X) < 0)
                {
                    for (int x = 0; x < 4; x++)
                    {
                     SetCursorPos(Helper.GetWindowRectInfo.rect.Left + 68 + x * 128, GetWindowRectInfo.rect.Bottom - 380);
                        if (Functions.PianoTilesChecker.PianoLocationChecker(
                                Helper.GetWindowRectInfo.rect.Left + 68 + x * 128, GetWindowRectInfo.rect.Bottom - 420))
                        {
                            SetCursorPos(Helper.GetWindowRectInfo.rect.Left + 68 + x * 128, GetWindowRectInfo.rect.Bottom - 380);
                            Helper.MouseClickHelper.MouseClick();
                        }
                    }
                }
                Thread.Sleep(2);
            }

        }



    }
}
