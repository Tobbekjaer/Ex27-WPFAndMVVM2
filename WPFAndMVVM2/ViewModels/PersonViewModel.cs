using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        private string _firstName;
        private string _lastName;
        private int _age;
        private string _phone;

        public string FirstName
        {
            get { return _firstName; }
            set { 
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Age
        {
            get { return _age; }
            set { 
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set { 
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public PersonViewModel(Person person)
        {
            this.person = person;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Age = person.Age;
            this.Phone = person.Phone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeletePerson(PersonRepository deletePerson) 
        {
            deletePerson.Remove(person.Id);
        }


    }
}
