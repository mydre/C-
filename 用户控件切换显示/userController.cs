        private void clickAddEvidence(object sender, EventArgs e)
        {
            UcZjtq uc = new UcZjtq();
            uc.Dock = DockStyle.Fill;
            var p = this.Parent.Parent.Controls["WinContent"].Controls;
            this.Parent.Parent.Controls["WinContent"].Controls.Clear();
            p.Add(uc);


        }

Panel wincontent = (Panel)Program.m_mainform.Controls["WinContent"];
SplitContainer sc = (SplitContainer)wincontent.Controls[0].Controls["splitContainer1"];
TabControl tc = (TabControl)sc.Panel1.Controls["tabControl1"];
tc.SelectedIndex = 1;