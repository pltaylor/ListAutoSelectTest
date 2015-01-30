using System;

namespace ListAutoSelectTest
{
    public class LapViewModel : BaseViewModel
    {
        //Add
        private bool _IsDirty;
        private bool _IsFastest;
        private UserLap _Lap;

        public LapViewModel()
        {
            IsFastest = false;
        }

        public bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                if (value != _IsDirty)
                {
                    _IsDirty = value;
                    NotifyPropertyChanged("IsDirty");
                }
            }
        }

        public bool IsFastest
        {
            get { return _IsFastest; }
            set
            {
                if (value != _IsFastest)
                {
                    _IsFastest = value;
                    NotifyPropertyChanged("IsFastest");
                }
            }
        }

        public UserLap Lap
        {
            get { return _Lap; }
            set
            {
                if (value != _Lap)
                {
                    if (_Lap != null)
                    {
                        IsDirty = true;
                    }
                    _Lap = value;
                    NotifyPropertyChanged("Lap");
                }
            }
        }

        public bool InLap
        {
            get { return Lap != null ? Lap.InLap : false; }
            set
            {
                if (Lap != null && value != Lap.InLap)
                {
                    Lap.InLap = value;
                    IsDirty = true;
                    NotifyPropertyChanged("InLap");
                }
            }
        }

        public bool OutLap
        {
            get { return Lap.OutLap; }
            set
            {
                if (value != Lap.OutLap)
                {
                    Lap.OutLap = value;
                    IsDirty = true;
                    NotifyPropertyChanged("OutLap");
                }
            }
        }

        public int LapNumber
        {
            get { return Lap.LapNumber; }
            set
            {
                if (value != Lap.LapNumber)
                {
                    Lap.LapNumber = value;
                    IsDirty = true;
                    NotifyPropertyChanged("LapNumber");
                }
            }
        }

        public double Laptime
        {
            get
            {
                if (Lap != null)
                {
                    return Lap.LapTime.TotalSeconds;
                }
                return -1.0;
            }
            set
            {
                if (Lap != null)
                {
                    Lap.LapTime = TimeSpan.FromSeconds(value);
                    IsDirty = true;
                    NotifyPropertyChanged("Laptime");
                }
            }
        }
    }
}
