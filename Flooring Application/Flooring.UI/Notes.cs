using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    class Notes
    {
    }
}

 //DisplayOrder
 //A new order file is created each sales day (DateTime)
 //ask for a date and then display all orders.txt files for that date
 //if a file or date != exist then display error -> return to main menu
 //if both exist print all info

//AddOrder
//Ask for Order Date, must be in future otherwise throw error
//ask for customer name, can NOT be blank,
//ask for state, if not on tax document throw error
    //however, if state added later must NOT change app code
//...

//RemoveOrder
//Ask for date & orderNumber
//if doesnt exist, throw an error
//if does exist display the order info -> prompt if user is sure
    //yes - Order to be removed from file
    //no - taken back to main menu

//         public string GetFormatedDateString(string date)
//        {
//            string result;
//            string format = "MM.dd.yyyy hh:mm tt";

//            DateTime time = DateTime.Parse(date);
//            result = time.ToString(format);
//            return result;

//        }

