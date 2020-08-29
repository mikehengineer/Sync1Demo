
using System.Collections.Generic;
using Sync1Demo.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sync1Demo.Data
{
    public class SqlApplicantData : IApplicantData
    {
        private readonly ApplicantDBContext db;

        public SqlApplicantData(ApplicantDBContext db)
        {
            this.db = db;
        }
        public Applicant Add(Applicant newApplicant)
        {
            db.Add(newApplicant);
            return newApplicant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Applicant Delete(int id)
        {
            var applicant = GetById(id);
            if(applicant != null)
            {
                db.Applicants.Remove(applicant);
            }
            return applicant;
        }

        public Applicant GetById(int id)
        {
            return db.Applicants.Find(id);
        }

        public IEnumerable<Applicant> GetApplicantsByName(string name)
        {
            var query = from a in db.Applicants
                        where a.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby a.Name
                        select a;
            return query;
        }

        public Applicant Update(Applicant applicant)
        {
            var entity = db.Applicants.Attach(applicant);
            entity.State = EntityState.Modified;
            return applicant;
        }
    }
}
