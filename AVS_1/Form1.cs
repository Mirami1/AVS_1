using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace AVS_1
{
    public partial class Form1 : Form
    {
        private Stopwatch time;
        List<ip> ipList;
        NumericUpDown[] begin, end;
        uint begIp, endIp, nIp;
        Queue<q> toAddQ;
        Thread[] allThreads;
        bool prepared;

        private void ExitButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nIp; i++)
            {
                if (allThreads[i] != null && allThreads[i].IsAlive) allThreads[i].Interrupt();
            }

            Environment.Exit(1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            toAddQ = new Queue<q>();
            ipList = new List<ip>();
            begin = new NumericUpDown[4];
            end = new NumericUpDown[4];
            for (int i = 0; i < 4; i++)
            {
                begin[i] = new NumericUpDown();
                begin[i].Size = new Size(45, 20);
                begin[i].Maximum = 255;
                begin[i].Location = new Point(134 + 51 * i, 9);
                Controls.Add(begin[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                end[i] = new NumericUpDown();
                end[i].Size = new Size(45, 20);
                end[i].Maximum = 255;
                end[i].Location = new Point(134 + 51 * i, 35);
                Controls.Add(end[i]);
            }

            begin[0].Value = 193;
            begin[1].Value = 233;
            begin[2].Value = 144;
            begin[3].Value = 0;

            end[0].Value = 193;
            end[1].Value = 233;
            end[2].Value = 147;
            end[3].Value = 255;
            IpTable.Columns.Add("Address", "IP-adress");
            IpTable.Columns.Add("Availability", "Availability");
            IpTable.Columns.Add("Dns", "Dns");

            for (int i = 0; i < 3; i++)
            {
                IpTable.Columns[i].Width = (IpTable.Width - 38) / 3;
                IpTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            prepared = false;
            time = new Stopwatch();
        }

        void dns(object i) // получаем имя хоста через днс, по списку ip-aдрессов
        {
            IPHostEntry iphe;
            try
            {
                iphe = Dns.GetHostEntry(IPAddress.Parse(ipList[(int) i].ToString()));
                ipList[(int) i].name = iphe.HostName;
            }
            catch (Exception e)
            {
                ipList[(int) i].name = e.Message;
            }

            lock (toAddQ)
            {
                toAddQ.Enqueue(new q(ipList[(int) i].name, (int) i, true));
            }
        }

        void prepareToScan() // чистим панель и блокируем кнопки
        {
            if (prepared) return;
            prepared = true;
            IpTable.Rows.Clear();
            ScanButton.Enabled = false;
            AnalyzeButton.Enabled = false;
            ipList.Clear();
            nIp = endIp - begIp + 1;
            ScanProgressBar.Maximum = (int) (2 * nIp);
            ScanProgressBar.Value = 0;
            ExitButton.Enabled = false;
            for (uint i = begIp; i <= endIp; i++)
            {
                ip tmpIp = new ip(i);
                ipList.Add(tmpIp);
                IpTable.Rows.Add(tmpIp.ToString());
            }

            foreach (Control x in Controls)
                if (x.GetType().Name == "NumericUpDown")
                    x.Enabled = false;
            UseWaitCursor = true;
            time.Reset();
            time.Start();
        }

        private void ForThreads(object sender, EventArgs e)
        {
            if (inRange() == false) return;
            prepareToScan();
            ThreadPool.QueueUserWorkItem(ForAsync);
            ThreadPool.QueueUserWorkItem(createThreads);
            ThreadPool.QueueUserWorkItem(changes);
        }

        void ForAsync(object e) //Ping
        {
            if (inRange() == false) return;
            prepareToScan();
            for (int i = 0; i < nIp; i++)
            {
                Ping p = new Ping();
                IPAddress ipa = new IPAddress(ipList[i].ipvalues);
                p.PingCompleted += PingShell;
                try
                {
                    p.SendAsync(ipa, 300, ipa);
                }
                catch (Exception z)
                {
                    lock (toAddQ)
                    {
                        toAddQ.Enqueue(new q(z.Message, i, false));
                    }
                }

                p.Dispose();
            }
        }

        private void PingShell(object sender, PingCompletedEventArgs e) //сохранение ответа
        {
            IPAddress ipAddress = e.UserState as IPAddress;
            var replyStatus = e.Reply.Status.ToString();
            for (int i = 0; i < nIp; i++)
            {
                IPAddress tmp = new IPAddress(ipList[i].ipvalues);
                if (ipAddress.Equals(tmp))
                {
                    ipList[i].status = replyStatus;
                    lock (toAddQ)
                    {
                        toAddQ.Enqueue(new q(replyStatus, i, false));
                    }
                }
            }
        }

        void changes(object t) //внесение результатов
        {
            while (ScanProgressBar.Value != ScanProgressBar.Maximum)
            {
                int tmpint = toAddQ.Count;
                if (tmpint != 0)
                {
                    q f;
                    lock (toAddQ)
                    {
                        f = toAddQ.First();
                        toAddQ.Dequeue();
                    }

                    BeginInvoke(new ThreadStart(delegate
                    {
                        IpTable.Rows[f.i].Cells[(f.first ? 2 : 1)].Value =
                            f.s + (f.first ? " " : time.Elapsed.ToString());
                        ScanProgressBar.Value++;
                    }));
                }

                Thread.Sleep(1);
            }

            ScanComplete();
        }

        void createThreads(object t)
        {
            allThreads = new Thread[nIp];
            for (int i = 0; i < nIp; i++)
            {
                allThreads[i] = new Thread(dns);
                allThreads[i].Priority = ThreadPriority.Highest;
                allThreads[i].Start(i);
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if (IpTable.SelectedCells.Count == 0)
            {
                MessageBox.Show("Cells need to be selected");
                return;
            }

            ip minIp = new ip(UInt32.MaxValue);
            ip maxIp = new ip(0);
            foreach (DataGridViewCell c in IpTable.SelectedCells)
            {
                if (c.RowIndex >= nIp) continue;
                maxIp.value = Math.Max(ipList[c.RowIndex].value, maxIp.value);
                minIp.value = Math.Min(ipList[c.RowIndex].value, minIp.value);
            }

            ip mask = new ip(minIp.Mask(maxIp.value));
            ip address = new ip(minIp.Adress(mask.value));
            ip broadcast = new ip(minIp.Broadcast(mask.value));
            AdressTextBox.Text = address.ToString();
            NetMaskTextBox.Text = mask.ToString();
            BroadcastTextBox.Text = broadcast.ToString();
        }

        private bool inRange() // проверка правильности диапазона
        {
            begIp = endIp = 0;
            for (int i = 0; i < 4; i++)
            {
                begIp = begIp * 256 + Convert.ToUInt32(begin[i].Value); //256=100000000
                endIp = endIp * 256 + Convert.ToUInt32(end[i].Value);
            }

            if (endIp < begIp)
            {
                MessageBox.Show("Неправильный диапазон ip");
                return false;
            }

            return true;
        }

        void ScanComplete()
        {
            int i, k;
            ThreadPool.GetMaxThreads(out i, out k);
            Console.WriteLine(i);
            Console.WriteLine(k);
            time.Stop();
            BeginInvoke(new ThreadStart(delegate
            {
                AnalyzeButton.Enabled = true;
                ScanButton.Enabled = true;
                UseWaitCursor = false;
                prepared = false;
                ExitButton.Enabled = true;
                foreach (Control x in Controls)
                {
                    if (x.GetType().Name == "NumericUpDown") x.Enabled = true;
                }
            }));
            MessageBox.Show("Завершено, время исполнения " + time.Elapsed);
        }


        public Form1()
        {
            InitializeComponent();
        }
    }
}