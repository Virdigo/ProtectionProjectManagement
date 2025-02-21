using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.Services
{
    public class DoljnostiService
    {
        public List<Doljnosti> GetDoljnosti()
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                return context.Doljnosti.ToList();
            }
        }

        public void AddDoljnost(Doljnosti doljnost)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                context.Doljnosti.Add(doljnost);
                context.SaveChanges();
            }
        }

        public void EditDoljnost(Doljnosti doljnost)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var existingDoljnost = context.Doljnosti.Find(doljnost.id_doljnosti);
                if (existingDoljnost != null)
                {
                    existingDoljnost.Post = doljnost.Post;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteDoljnost(int doljnostId)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var doljnost = context.Doljnosti.Find(doljnostId);
                if (doljnost != null)
                {
                    context.Doljnosti.Remove(doljnost);
                    context.SaveChanges();
                }
            }
        }
    }
}
