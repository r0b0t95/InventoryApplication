using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class TodoList
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> TODOLIST ATTRIBUTES

        public long reminderId { get; set; }

        public string description { get; set; }

        public State reminderState { get; set; }

        public TodoList() 
        {
            reminderState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addReminder()
        {
            bool R = false;
            return R;
        }

        public bool updateReminder()
        {
            bool R = false;
            return R;
        }

        public bool deleteReminder()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> reminders list

    }
}
