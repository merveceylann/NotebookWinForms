using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookWinForms.Entites
{
    public class MyNote
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string CustomDisplay
        {
            get { return $"{Subject} / {Description}"; }
        }
    }
}
