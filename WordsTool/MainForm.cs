using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordsTool
{
    public partial class MainForm : Form
    {
        string RegexStr = "^[a-zA-Z]+$";


        public MainForm()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "文本文件 (*.*)|*.*|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tbPath.Text = openFileDialog1.FileName;
        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbPath.Text))
            {
                string[] sarrs = File.ReadAllLines(tbPath.Text, Encoding.Default);

                Dictionary<string, string> allwords = new Dictionary<string, string>();
                Dictionary<string, string> notTrans = new Dictionary<string, string>();
                foreach (string srow in sarrs)
                {
                    if (!string.IsNullOrEmpty(srow))
                    {
                        string[] words = srow.Split(' ');
                        if (words != null && words.Length > 0)
                        {
                            foreach (string word in words)
                            {
                                string s = word.TrimEnd('.').TrimEnd(',').TrimEnd(';').TrimEnd('?').TrimEnd(':');
                                if (!allwords.ContainsKey(s))
                                {
                                    allwords.Add(s, s);
                                }
                            }
                        }
                    }
                }

                List<EnglishWord> listExists = new List<EnglishWord>();
                foreach (string key in allwords.Keys)
                {
                    if (dicAllwords.ContainsKey(key))
                    {
                        listExists.Add(dicAllwords[key]);
                    }
                    else if (dicAllwords.ContainsKey(key.ToLower()))
                    {
                        listExists.Add(dicAllwords[key.ToLower()]);
                    }
                    else
                    {
                        string prototype = string.Empty;
                        if (key.EndsWith("ing"))
                        {
                            prototype = GetRemoveSuffixString(key, "ing");
                        }
                        else if (key.EndsWith("s"))
                        {
                            prototype = GetRemoveSuffixString(key, "s");
                        }
                        else if (key.EndsWith("ed"))
                        {
                            prototype = GetRemoveSuffixString(key, "ed");
                        }
                        if (!string.IsNullOrEmpty(prototype)&& dicAllwords.ContainsKey(prototype))
                        {
                            listExists.Add(dicAllwords[prototype]);
                        }
                        else
                        {
                            if (Regex.IsMatch(key, RegexStr) && !notTrans.ContainsKey(key))
                            {
                                notTrans.Add(key, key);
                            }
                        }
                    }
                }

                foreach (string notexistword in notTrans.Keys)
                {
                    EnglishWord wordnoexist = new EnglishWord() { word = notexistword };
                    listExists.Add(wordnoexist);
                }

                dgvList.DataSource = listExists;
                if (cbCSV.Checked)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel File (*.xls)|*.xls";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                        OutExcel(listExists, sfd.FileName);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tbPath.Text.Trim()))
                {
                    MessageHelper.ShowError("请选择文件！");
                }
                else
                {
                    MessageHelper.ShowError("文件不存在！");
                }
            }
        }

        ///<summary>
        /// 移除前缀字符串
        ///</summary>
        ///<param name="val">原字符串</param>
        ///<param name="str">前缀字符串</param>
        ///<returns></returns>
        private string GetRemovePrefixString(string val, string str)
        {
            string strRegex = @"^(" + str + ")";
            return Regex.Replace(val, strRegex, "");
        }
        ///<summary>
        /// 移除后缀字符串
        ///</summary>
        ///<param name="val">原字符串</param>
        ///<param name="str">后缀字符串</param>
        ///<returns></returns>
        private string GetRemoveSuffixString(string val, string str)
        {
            string strRegex = @"(" + str + ")" + "$";
            return Regex.Replace(val, strRegex, "");
        }
        private void OutCSV(List<EnglishWord> list, string filepath)
        {
            if (list == null || list.Count < 0)
            {
                MessageHelper.ShowError("没有可输出内容！");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Word,Prounce_US,Prounce_UK,Trans\r\n");
            foreach (EnglishWord word in list)
            {
                sb.AppendFormat("{0},{1},{2},{3}\r\n", "\"" + word.word ?? "" + "\"", "\"" + word.prounce_us ?? "" + "\"", "\"" + word.prounce_uk ?? "" + "\"", "\"" + word.trans ?? "" + "\"");
            }
            File.WriteAllText(filepath, sb.ToString(), Encoding.UTF8);
            MessageHelper.ShowInfo("保存成功！");
        }

        private void OutExcel(List<EnglishWord> list, string filepath)
        {
            if (list == null || list.Count < 0)
            {
                MessageHelper.ShowError("没有可输出内容！");
                return;
            }
            //创建工作薄
            var workbook = new HSSFWorkbook();
            //创建表
            var table = workbook.CreateSheet("words");

            ICellStyle style = workbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;



            var row = table.CreateRow(0);
            ICell cell0 = row.CreateCell(0);
            cell0.SetCellValue("Word");
            cell0.CellStyle = style;
            ICell cell1 = row.CreateCell(1);
            cell1.SetCellValue("Prounce_US");
            cell1.CellStyle = style;
            ICell cell2 = row.CreateCell(2);
            cell2.SetCellValue("Prounce_UK");
            cell2.CellStyle = style;
            ICell cell3 = row.CreateCell(3);
            cell3.SetCellValue("Trans");
            cell3.CellStyle = style;
            table.AutoSizeColumn(0);
            //模拟20行20列数据
            for (var i = 1; i <= list.Count; i++)
            {
                table.AutoSizeColumn(i);
                row = table.CreateRow(i);
                cell0 = row.CreateCell(0);
                cell0.SetCellValue(list[i - 1].word);
                cell0.CellStyle = style;
                cell1 = row.CreateCell(1);
                cell1.SetCellValue(list[i - 1].prounce_us);
                cell1.CellStyle = style;
                cell2 = row.CreateCell(2);
                cell2.SetCellValue(list[i - 1].prounce_uk);
                cell2.CellStyle = style;
                cell3 = row.CreateCell(3);
                cell3.SetCellValue(list[i - 1].trans);
                cell3.CellStyle = style;
            }
            table.SetColumnWidth(3, 200 * 256);
            //打开xls文件，如没有则创建，如存在则在创建是不要打开该文件
            using (var fs = File.OpenWrite(filepath))
            {
                workbook.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            }
            MessageHelper.ShowInfo("保存成功！");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            InitData();
        }
        Dictionary<string, EnglishWord> dicAllwords = new Dictionary<string, EnglishWord>();
        private void InitData()
        {
            string sql = "select * from word";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<EnglishWord> list = EnglishWord.DataTableToList(dt);
                if (list != null && list.Count > 0)
                {
                    foreach (EnglishWord word in list)
                    {
                        if (word != null && !string.IsNullOrEmpty(word.word) && !dicAllwords.ContainsKey(word.word))
                        {
                            dicAllwords.Add(word.word, word);
                        }
                    }
                }
            }

        }

        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgvList.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvList.DefaultCellStyle.Font, b, e.RowBounds.Location.X, e.RowBounds.Location.Y + 4);
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/devgis/WordsTool/releases");
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/devgis/WordsTool");
        }
    }
}
