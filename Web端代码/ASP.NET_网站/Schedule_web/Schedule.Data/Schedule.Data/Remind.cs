using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Data
{
    public class Remind
    {
        public Remind()
        {
            _id = 0;
            this.month = 1;
            this.day = 1;

        }
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _note;

        public virtual string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        private int month;

        public virtual int Month
        {
            get { return month; }
            set {
                month = value;
                if (month < 1)
                    month = 1;
                if (month > 12)
                    month = 12;
            }
        }
        private int day;

        public virtual int Day
        {
            get { return day; }
            set 
            { 
               
                day = value;
                if (day < 1)
                    day = 1;
                if (day > 31)
                    day = 31;
            }
        }
    }
}
