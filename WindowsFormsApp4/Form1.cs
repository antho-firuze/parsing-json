using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // nothing
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            GetRequest("http://www.infovesta.com/index2/mutualfund/SH%20/%200");
        }

        async void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        c1Editor1.Text = mycontent;
                        deserialiseJSON(mycontent);
                    }
                }
            }
        }

        private void deserialiseJSON(string strJSON) 
        {
            try
            {
                var o = JsonConvert.DeserializeObject<dynamic>(strJSON);
                
                debug("Here's our JSON object: " + o.ToString());
                return;
            }
            catch(Exception e)
            {
                debug("We had a problem: " + e.Message.ToString());
            }
        }

        private void debug(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }

        private void output(string s)
        {
            Console.WriteLine(s);
        }

    }
}
