using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ListAutoSelectTest
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<LapViewModel> _Laps;

        private LapViewModel _SelectedLap;

        private RelayCommand _AddLapCommand;

        public MainWindowViewModel()
        {
            Laps = new ObservableCollection<LapViewModel>();
        }

        public ObservableCollection<LapViewModel> Laps
        {
            get { return _Laps; }
            set
            {
                if (value != _Laps)
                {
                    _Laps = value;
                    NotifyPropertyChanged("Laps");
                }
            }
        }

        public LapViewModel SelectedLap
        {
            get { return _SelectedLap; }
            set
            {
                _SelectedLap = value;
                NotifyPropertyChanged("SelectedLap");
            }
        }

        public ICommand AddLapCommand
        {
            get
            {
                if (_AddLapCommand == null)
                    _AddLapCommand = new RelayCommand(param => AddLap(), param => true);

                return _AddLapCommand;
            }
        }

        public void AddLap()
        {
            var newLap = new UserLap { SetupSheetID = new Guid(), LapTime = TimeSpan.Zero };

            if (SelectedLap == null || SelectedLap.InLap)
            {
                var lastNonInLap = Laps.LastOrDefault(x => x.InLap == false);
                if (lastNonInLap != null)
                {
                    newLap.LapNumber = lastNonInLap.LapNumber + 1;
                }
                else
                {
                    newLap.LapNumber = Laps.Count() + 1;
                }
            }
            else
            {
                newLap.LapNumber = Laps.Count() + 1;
            }
            //bump the lap number of every lap beyond the insert point.
            for (var i = newLap.LapNumber - 1; i < Laps.Count(); i++)
            {
                Laps[i].LapNumber++;
            }
            var lvm = new LapViewModel { Lap = newLap };
            Laps.Add(lvm);
            var lastOrDefault = Laps.LastOrDefault(x => x.InLap == false);
            SelectedLap = lastOrDefault;
        }
    }
}
