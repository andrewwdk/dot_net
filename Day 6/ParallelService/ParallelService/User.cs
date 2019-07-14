using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelService
{
    public class User
    {
        const int stringLength = 30;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;

        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = MakeStandartLengthString(value);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = MakeStandartLengthString(value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = MakeStandartLengthString(value);
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = MakeStandartLengthString(value);
            }
        }

        public DateTime BirthDate { get; set; }

        public DateTime LastEntry { get; set; }

        private string MakeStandartLengthString(string initialString)
        {
            if(initialString.Length > stringLength)
            {
                return initialString.Substring(0, stringLength);
            }
            else
            {
                return initialString.PadRight(stringLength, ' ');
            }
        }

        public User(int id, string firstName, string lastName, string email, string login, DateTime birthDate, DateTime lastEntry)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            BirthDate = birthDate;
            LastEntry = lastEntry;
        }

    }
}
