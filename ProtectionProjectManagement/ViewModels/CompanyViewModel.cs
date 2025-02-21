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
    public class CompanyViewModel : BaseViewModel
    {
        public CompanyService _companyService;
        public ObservableCollection<Companies> Companies { get; set; }

        public CompanyViewModel()
        {
            _companyService = new CompanyService();
            Companies = new ObservableCollection<Companies>();
            LoadCompanies();
        }

        public void LoadCompanies()
        {
            Companies.Clear();
            var companies = _companyService.GetCompanies();
            foreach (var company in companies)
            {
                Companies.Add(company);
            }
        }
    }
}