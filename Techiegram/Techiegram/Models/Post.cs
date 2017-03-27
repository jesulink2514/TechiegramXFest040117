using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Techiegram.Models
{
    public class Post: INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public User Author { get; set; }
        public ObservableCollection<User> Likes { get; set; } = new ObservableCollection<User>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
