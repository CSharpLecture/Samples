using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonSample
{
    class NoteViewModel : INotifyPropertyChanged
    {
        Note note;

        public NoteViewModel(Note note)
        {
            this.note = note;
            DoChange();
        }

        async Task DoChange()
        {
            await Task.Delay(5000);
            Title = "Doofkopf!";
            DueDate = DateTime.Today.AddYears(-2);
        }

        public string Title
        {
            get { return note.Title; }
            set
            {
                note.Title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string Description
        {
            get { return note.Description; }
            set
            {
                note.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public DateTime DueDate
        {
            get { return note.DueDate; }
            set
            {
                note.DueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
