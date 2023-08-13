using NotebookWinForms.Entites;
using System.Data;
using System.Data.SqlClient;

namespace NotebookWinForms
{
    public partial class Note : Form
    {
        private MyNote selectedNote = null;

        SqlConnection connection = new SqlConnection("server=.\\MSSQLSERVER1; database=NoteDb; integrated security=true;");
        //connection.ConnectionString = "";

        // connected - disconnected mimari
        // sql injection


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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescription.Text))
            {

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Notes(Subject,Description) values(@subject,@description)";

                command.Parameters.AddWithValue("@subject", txtSubject.Text);
                command.Parameters.AddWithValue("@description", txtDescription.Text);
                //command.Parameters.AddWithValue("@id", selectedNote.Id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //var addedNote = new MyNote();
                //addedNote.Subject = txtSubject.Text;
                //addedNote.Description = txtDescription.Text;


                //var lastNote = DataStore.Notes[DataStore.Notes.Count - 1];
                //addedNote.Id = lastNote.Id + 1;


                //DataStore.Notes.Add(addedNote);

                //Refresh();

                GetList();

                txtSubject.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }


            //listBox1.Items.Add(addedNote);

            //listBox1.Items.Add(txtNote.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //DataStore.Notes.Remove(selectedNote);
            //selectedNote = null;
            txtSubject.Text = string.Empty;
            txtDescription.Text = string.Empty;
            Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubject.Text))
            {
                //selectedNote.Subject = richTextBox1.Text;
                //selectedNote.Description = txtNote.Text;

                //Refresh();

                NoteUpdate();
                GetList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedNote = (MyNote)listBox1.SelectedItem;
                txtSubject.Text = selectedNote.Subject;
                txtDescription.Text = selectedNote.Description;
            }
        }

        public void GetList()
        {
            List<MyNote> notes = new List<MyNote>();
            
            connection.Open();
            lblConnection.Text = connection.State.ToString();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Notes";
            //command.CommandText = "select * from Notes";

            //command.ExecuteNonQuery(); //satirlarin etkilendigi insert update gibi islemler
            //command.ExecuteScalar(); //readerin maliyetinde kacmak icin

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var note = new MyNote();
                note.Id = Convert.ToInt32(reader[0]);
                note.Subject = reader[1].ToString();
                note.Description = reader[2].ToString();
                notes.Add(note);
            }

            //Thread.Sleep(3000);
            connection.Close();
            //lblConnection.Text = connection.State.ToString();

            listBox1.DataSource = null;
            listBox1.DataSource = notes;
            listBox1.DisplayMember = "CustomDisplay";
            listBox1.ValueMember = "Id";

        }
        public void NoteUpdate()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "update Notes set Subject=@subject, Description=@note where Id=@id";
            command.Parameters.AddWithValue("@subject", txtSubject.Text);
            command.Parameters.AddWithValue("@note", txtDescription.Text);
            command.Parameters.AddWithValue("@id", selectedNote.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            selectedNote.Subject = txtSubject.Text;
            selectedNote.Description = txtDescription.Text;
        }
    }
}