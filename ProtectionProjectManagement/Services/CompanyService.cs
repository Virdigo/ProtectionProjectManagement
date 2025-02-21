using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProtectionProjectManagement.Services
{
    public class CompanyService
    {
        public List<Companies> GetCompanies()
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                return context.Companies.ToList();
            }
        }

        public void AddCompany(Companies company)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                context.Companies.Add(company);
                context.SaveChanges();
            }
        }

        public void EditCompany(Companies company)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var existingCompany = context.Companies.Find(company.CompanyID);
                if (existingCompany != null)
                {
                    existingCompany.CompanyName = company.CompanyName;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCompany(int companyId)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var company = context.Companies.Find(companyId);
                if (company != null)
                {
                    context.Companies.Remove(company);
                    context.SaveChanges();
                }
            }
        }
    }
}
