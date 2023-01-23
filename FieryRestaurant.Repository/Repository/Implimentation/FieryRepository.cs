using FieryRestaurant.Entities;
using FieryRestaurant.Repository.DataAccess;
using FieryRestaurant.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Repository.Repository.Implimentation
{
    public class FieryRepository : IFieryRepository
    {
        private readonly FieryDbContext Db;
        public FieryRepository(FieryDbContext fieryDb)
        {
            this.Db = fieryDb;
        }
        public bool AddSupplierInDb(Supplier supplier)
        {
            try
            {
                Db.supplier.Add(supplier);
                Db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new FileNotFoundException();
            }
        }

        public List<Supplier> GetSuppliersInDb()
        {
            try
            {
                List<Supplier> suppliers = Db.supplier.Include(x => x.Address).Include(x => x.Business).ToList();
                if (suppliers != null)
                {
                    return suppliers;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }
        }
    }
}
