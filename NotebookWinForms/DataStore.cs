using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotebookWinForms
{
    public class DataStore
    {
        public static AppUser AppUser = new AppUser { Id = 1, Username = "Admin", Password = "55" };

        public static List<MyNote> Notes = new List<MyNote>()
        {
            new MyNote{ Id =1, Subject ="İş", Description="Son projeyi teslim et." },
            new MyNote{ Id =2, Subject ="Eğitim", Description="Tekrar dersini izle."},
            new MyNote{ Id =3, Subject ="Ev", Description="Market alışverişi yapılacak."},

        };
    }

    public class MyNote
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        //date etc.

        public string CustomDisplay
        {
            get { return $"{Subject} / {Description}"; }
        }
    }


    public class AppUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
