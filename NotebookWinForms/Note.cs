namespace NotebookWinForms
{
    public partial class Note : Form
    {
        private MyNote selectedNote = null;
        public Note()
        {
            InitializeComponent();
            Refresh();

        }

        public void Refresh()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = DataStore.Notes;
            listBox1.DisplayMember = "CustomDisplay";
            listBox1.ValueMember = "Id";
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {


                var addedNote = new MyNote();
                addedNote.Subject = txtNote.Text;
                addedNote.Description = richTextBox1.Text;

                var lastNote = DataStore.Notes[DataStore.Notes.Count - 1];
                addedNote.Id = lastNote.Id + 1;


                DataStore.Notes.Add(addedNote);

                Refresh();


                txtNote.Text = string.Empty;
                richTextBox1.Text = string.Empty;
            }


            //listBox1.Items.Add(addedNote);

            //listBox1.Items.Add(txtNote.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataStore.Notes.Remove(selectedNote);
            selectedNote = null;
            txtNote.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text))
            {
                selectedNote.Subject =  richTextBox1.Text;
                selectedNote.Description = txtNote.Text;

                Refresh();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedNote = (MyNote)listBox1.SelectedItem;
                richTextBox1.Text = selectedNote.Description;
                txtNote.Text = selectedNote.Subject;
            }
        }

    }
}