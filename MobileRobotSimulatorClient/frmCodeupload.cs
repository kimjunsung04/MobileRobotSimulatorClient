using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class frmCodeupload : Form
    {
        public frmCodeupload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://127.0.0.1:8800");
            var request = new RestRequest("upload", Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("code", textBox1.Text, ParameterType.QueryString);
            Task<RestResponse> RestCk = client.ExecuteAsync(request);
            if (RestCk.Result.StatusDescription == "OK")
            {
                MessageBox.Show("업로드 완료");
            }
            else
            {
                MessageBox.Show("업로드 실패\n서버상태를 확인해주세요.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool baseResult = base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Tab && textBox1.Focused)// Tab키 들여쓰기 구현
            {
                int column = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(column, "    ");
                textBox1.SelectionStart = column+4;
                textBox1.ScrollToCaret();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Back))
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}
