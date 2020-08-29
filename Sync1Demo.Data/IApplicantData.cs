using System.Collections.Generic;
using System.Text;
using Sync1Demo.Core;

namespace Sync1Demo.Data
{

    public interface IApplicantData
    {
        IEnumerable<Applicant> GetApplicantsByName(string name);
        Applicant Add(Applicant newApplicant);
        Applicant Delete(int id);
        Applicant Update(Applicant applicant);
        Applicant GetById(int id);
        int Commit();
    }
}
