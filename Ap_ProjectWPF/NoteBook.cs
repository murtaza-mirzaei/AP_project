using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap_ProjectWPF
{
    class NoteBook
    {
        private int Age;

        public int __Age
        {
            get { return Age; }
            set { Age = value; }
        }

        private string FirstName;

        public string __FirstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        private string LastName;

        public string __LastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        private string City;

        public string __City
        {
            get { return City; }
            set { City = value; }
        }



        private int x;

        public int __X
        {
            get { return x; }
            set { x = value; }
        }

        private int Y;

        public int __Y
        {
            get { return Y; }
            set { Y = value; }
        }




        public NoteBook(int Age, string FirstName, string LastName, string City, int X, int Y)
        {
            __Age = Age;
            __FirstName = FirstName;
            __LastName = LastName;
            __City = City;
            __X = X;
            __Y = Y;

        }


    }
}
