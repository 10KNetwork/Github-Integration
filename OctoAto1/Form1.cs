using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using Octokit.Internal;

namespace OctoAto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
        public async void reposhowtest()
        {
            var github = new GitHubClient(new ProductHeaderValue("OctoAto"),
                new InMemoryCredentialStore(new Credentials("594a631687ce87bf18617fab4933d7176b66b682")));
            var repos = await github.Repository.GetAllForCurrent();
            List<string> _items = new List<string>();
            foreach (var repository in repos)
            {
                    _items.Add(repository.Name);
            }
            RepoList.DataSource = _items;
        }

        public async void addcollab()
        {
            var github = new GitHubClient(new ProductHeaderValue("OctoAto"),
                new InMemoryCredentialStore(new Credentials("594a631687ce87bf18617fab4933d7176b66b682")));
            string repo = RepoList.GetItemText(RepoList.SelectedItem);
            await github.Repository.Collaborator.Add("ttatotab", repo, userName.Text);
            MessageBox.Show("Done!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reposhowtest();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcollab();
        }
    }
}
