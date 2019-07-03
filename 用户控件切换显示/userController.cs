        private void clickAddEvidence(object sender, EventArgs e)
        {
            UcZjtq uc = new UcZjtq();
            uc.Dock = DockStyle.Fill;
            var p = this.Parent.Parent.Controls["WinContent"].Controls;
            this.Parent.Parent.Controls["WinContent"].Controls.Clear();
            p.Add(uc);


        }
