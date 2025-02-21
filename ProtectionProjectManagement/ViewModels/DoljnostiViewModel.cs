using ProtectionProjectManagement.DB;
using ProtectionProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.ViewModels
{
    public class DoljnostiViewModel : BaseViewModel
    {
        private DoljnostiService _doljnostiService;
        public ObservableCollection<Doljnosti> Doljnosti { get; set; }

        public DoljnostiViewModel()
        {
            _doljnostiService = new DoljnostiService();
            Doljnosti = new ObservableCollection<Doljnosti>();
            LoadDoljnosti();
        }

        public void LoadDoljnosti()
        {
            Doljnosti.Clear();
            var doljnostiList = _doljnostiService.GetDoljnosti();
            foreach (var doljnost in doljnostiList)
            {
                Doljnosti.Add(doljnost);
            }
        }


    }
}
