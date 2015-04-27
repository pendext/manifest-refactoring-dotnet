using System;
using System.Collections.Generic;
using System.Text;

namespace StartingPoint
{
    public class DateProcessor
    {
        public void saveDueDateForAccount(Account account, String date)
        {
            try
            {
                DateTime d = DateTime.Parse(date);
                account.setDueDate(d);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happened.");
            }
        }

        public void saveStartDateForAccount(Account account, String date)
        {
            try
            {
                DateTime d = DateTime.Parse(date);
                account.setStartDate(d);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happened.");
            }
        }

    }
}
