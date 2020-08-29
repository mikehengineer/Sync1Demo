using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sync1Demo.Core;
using Sync1Demo.Data;

namespace Sync1Demo.Pages.Applicants
{
    public class ListModel : PageModel
    {
        private readonly IApplicantData applicantData;
        public IEnumerable<Applicant> Applicants { get; set; }


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }
        public void OnGet()
        {
            Applicants = applicantData.GetApplicantsByName(SearchTerm);
        }
    }
}
