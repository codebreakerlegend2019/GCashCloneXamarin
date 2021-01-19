using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCashClone.ViewModels
{
    public class LockScreenPageViewModel : BindableBase
    {
        public bool IsBackSpaceVisible { get; set; }
        public bool IsFirstPinTaken { get; set; }
        public bool IsSecondPinTaken { get; set; }
        public bool IsThirdPinTaken { get; set; }
        public bool IsFourthPinTaken { get; set; }
        public LockScreenPageViewModel()
        {

        }

        public DelegateCommand RemovePinCommand => new DelegateCommand(() =>
        {
            OnRemovePinChange();
        });
        public DelegateCommand<string> InputCommand => new DelegateCommand<string>((string param) =>
        {
            OnPinInputChange();
        });

        private void OnPinInputChange() 
        {
            if(!IsFirstPinTaken)
            {
                IsFirstPinTaken = true;
                IsBackSpaceVisible = true;
                RaisePropertyChanged(nameof(IsBackSpaceVisible));
                RaisePropertyChanged(nameof(IsFirstPinTaken));
            }
            else if (!IsSecondPinTaken)
            {
                IsSecondPinTaken = true;
                RaisePropertyChanged(nameof(IsSecondPinTaken));
            }
            else if (!IsThirdPinTaken)
            {
                IsThirdPinTaken = true;
                RaisePropertyChanged(nameof(IsThirdPinTaken));
            }
            else if (!IsFourthPinTaken)
            {
                IsFourthPinTaken = true;
                RaisePropertyChanged(nameof(IsFourthPinTaken));
            }

        }
        private void OnRemovePinChange()
        {
            if (IsFourthPinTaken)
            {
                IsFourthPinTaken = false;
                RaisePropertyChanged(nameof(IsFourthPinTaken));
            }
            else if (IsThirdPinTaken)
            {
                IsThirdPinTaken = false;
                RaisePropertyChanged(nameof(IsThirdPinTaken));
            }
            else if (IsSecondPinTaken)
            {
                IsSecondPinTaken = false;
                RaisePropertyChanged(nameof(IsSecondPinTaken));
            }
            else if (IsFirstPinTaken)
            {
                IsFirstPinTaken = false;
                IsBackSpaceVisible = false;
                RaisePropertyChanged(nameof(IsBackSpaceVisible));
                RaisePropertyChanged(nameof(IsFirstPinTaken));
            }

        }
    }
}
