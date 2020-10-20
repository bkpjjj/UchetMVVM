using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UchetMVVM.Services;

namespace UchetMVVM.ViewModels
{
    class MainWindowViewModel
    {
        public DbWorkerService DbWorkerService { get; private set; }

        public DataView Workers => DbWorkerService.Workers;

        public MainWindowViewModel()
        {
            DbWorkerService = new DbWorkerService();
        }

        public DelegateCommand SaveCommand => new DelegateCommand(() =>
        {
            DbWorkerService.Update();
        });
    }
}
