using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Policy;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();

        public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !

        public PersonViewModel SelectedPerson { get; set; }
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }
       

        public MainViewModel() 
        {
            PersonsVM = new ObservableCollection<PersonViewModel>();
            foreach (Person person in personRepo.GetAll()) {
                PersonViewModel newPerson = new PersonViewModel(person); 
                PersonsVM.Add(newPerson);
            }
        }

        public void AddDefaultPerson()
        {
            Person defaultPerson = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
            PersonViewModel personViewModelPerson = new PersonViewModel(defaultPerson);
            PersonsVM.Add(personViewModelPerson);
            SelectedPerson = personViewModelPerson;
            OnPropertyChanged("SelectedPerson");
        }

        public void DeleteSelectedPerson()
        {
            if(SelectedPerson != null) {
                SelectedPerson.DeletePerson(personRepo);
                PersonsVM.Remove(SelectedPerson);
            }
        }

        public void UpdateSelectedPerson()
        {
            if (SelectedPerson != null) {
                OnPropertyChanged("SelectedPerson");
            }
        }

    }
}
