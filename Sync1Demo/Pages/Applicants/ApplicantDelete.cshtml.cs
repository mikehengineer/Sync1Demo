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
    public class ApplicantDeleteModel : PageModel
    {
        private readonly IApplicantData applicantData;

        public Applicant Applicant { get; set; }
        public ApplicantDeleteModel(IApplicantData applicantData)
        {
            this.applicantData = applicantData;
        }

        public IActionResult OnGet(int applicantId)
        {
            Applicant = applicantData.GetById(applicantId);
            if (Applicant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int applicantId)
        {
            var applicant = applicantData.Delete(applicantId);
            applicantData.Commit();
            if (applicant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./ApplicantList");
        }
    }
}
