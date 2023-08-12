using NotebookWinForms.Entites;
using System.Data.SqlClient;

namespace NotebookWinForms
{
    public partial class Note : Form
    {
        //private MyNote selectedNote = null;

        SqlConnection connection = new SqlConnection("server=.\\MSSQLSERVER1; database=NoteDb; integrated security=true;");
        //connection.ConnectionString = "";

        List<MyNote> notesDb = new List<MyNote>();

        public Note()
        {
            InitializeComponent();
            //Refresh();
            GetList();
        }

        //public void Refresh()
        //{
        //    listBox1.DataSource = null;
        //    listBox1.DataSource = DataStore.Notes;
        //    listBox1.DisplayMember = "CustomDisplay";
        //    listBox1.ValueMember = "Id";
        //}



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

                //var lastNote = DataStore.Notes[DataStore.Notes.Count - 1];
                //addedNote.Id = lastNote.Id + 1;


                //DataStore.Notes.Add(addedNote);

                //Refresh();
                GetList();


                txtNote.Text = string.Empty;
                richTextBox1.Text = string.Empty;
            }


            //listBox1.Items.Add(addedNote);

            //listBox1.Items.Add(txtNote.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //DataStore.Notes.Remove(selectedNote);
            //selectedNote = null;
            txtNote.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text))
            {
                //selectedNote.Subject = richTextBox1.Text;
                //selectedNote.Description = txtNote.Text;

                Refresh();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //selectedNote = (MyNote)listBox1.SelectedItem;
                //richTextBox1.Text = selectedNote.Description;
                //txtNote.Text = selectedNote.Subject;
            }
        }

        private void GetList()
        {
            connection.Open();
            lblConnection.Text = connection.State.ToString();
            SqlCommand command = new SqlCommand("select * from Notes", connection);
            //command.CommandText = "select * from Notes";

            //command.ExecuteNonQuery(); //satirlarin etkilendigi insert update gibi islemler
            //command.ExecuteScalar(); //readerin maliyetinde kacmak icin

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var note = new MyNote();
                note.Subject = reader[1].ToString();
                note.Description = reader[2].ToString();
                notesDb.Add(note);
            }

            //Thread.Sleep(3000);
            connection.Close();
            //lblConnection.Text = connection.State.ToString();

            listBox1.DataSource = null;
            listBox1.DataSource = notesDb;
            listBox1.DisplayMember = "CustomDisplay";
            listBox1.ValueMember = "Id";

        }

    }
}