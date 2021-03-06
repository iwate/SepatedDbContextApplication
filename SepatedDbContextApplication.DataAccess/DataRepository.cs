﻿using SepatedDbContextApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepatedDbContextApplication.DataAccess
{
    public class DataRepository : IDataRepository, IDisposable
    {
        private DataContext Db;
        public DataRepository(DataContext db)
        {
            Db = db;
        }
        public async Task<Datum> Find(int id)
        {
            return await Db.Data.FindAsync(id);
        }

        public IEnumerable<Datum> GetAll()
        {
            return Db.Data.ToList();
        }

        public void Add(Datum datum)
        {
            Db.Data.Add(datum);
        }
        public void Update(Datum datum)
        {
            Db.Entry<Datum>(datum).State = System.Data.Entity.EntityState.Modified;
        }

        public void Remove(Datum datum)
        {
            Db.Data.Remove(datum);
        }

        public async Task Save()
        {
            await Db.SaveChangesAsync();
        }
        public async Task<bool> IsConflict(Datum datum)
        {
            return await Db.Data.FindAsync(datum.Id) != null;
        }

        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
                Db = null;
            }
        }
    }
}
