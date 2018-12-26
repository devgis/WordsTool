using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordsTool
{
    public class MessageHelper
    {
        private static string MessageTitle = "System";

        /// <summary>
        /// Show a error message
        /// </summary>
        /// <param name="Error"></param>
        public static void ShowError(string Error)
        {
            MessageBox.Show(Error, MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show a info message
        /// </summary>
        /// <param name="Info"></param>
        public static void ShowInfo(string Info)
        {
            MessageBox.Show(Info, MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show a question when click 'Yes' Button return ture else return false
        /// </summary>
        /// <param name="Question"></param>
        /// <returns></returns>
        public static bool ShowQuestion(string Question)
        {
            if (MessageBox.Show(Question, MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
