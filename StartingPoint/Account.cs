using System;
using System.Collections.Generic;
using System.Text;

namespace StartingPoint
{
    public class Account
    {
        private DateTime startDate;
        private DateTime dueDate;


        public void setStartDate(DateTime startDate)
        {
            this.startDate = startDate;
        }

        public DateTime getStartDate()
        {
            return this.startDate;
        }

        public void setDueDate(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        public DateTime getDueDate()
        {
            return this.dueDate;
        }
    }
}
