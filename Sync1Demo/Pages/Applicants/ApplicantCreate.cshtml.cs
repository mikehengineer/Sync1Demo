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
    public class ApplicantCreateModel : PageModel
    {
        private readonly IApplicantData applicant;
        [BindProperty] public Applicant Applicant { get; set; }

        public ApplicantCreateModel(IApplicantData applicant)
        {
            this.applicant = applicant;
        }
        public IActionResult OnGet()
        {
            Applicant = new Applicant();
            return Page();
        }

        public IActionResult OnPost()
        {
            applicant.Add(Applicant);
                applicant.Commit();
            return RedirectToPage("./ApplicantList");
        }
    }
}
