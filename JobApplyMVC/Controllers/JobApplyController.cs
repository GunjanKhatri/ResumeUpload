using JobApplyMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobApplyMVC.Controllers
{
    public class JobApplyController : Controller
    {
        CandidateViewModel Candidate =new CandidateViewModel();
        
        public JobApplyController()
        {
           
        }
        // GET: JobApply
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(JobCandidate jobCandidate)
        {
            var file = Request.Files[0];

            
            using (EMSEntities ems = new EMSEntities())
            {
                var fileName = ems.JobCandidates.Where(c => c.Resume == file.FileName);
                if(fileName == null || string.IsNullOrEmpty(fileName.ToString()))
                {
                    jobCandidate.Resume = file.FileName;
                   
                }
                else
                {
                    jobCandidate.Resume = file.FileName + "_new";
                }
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(jobCandidate.Resume);
                    string _path = Path.Combine(Server.MapPath("~/myData"), "0");
                    file.SaveAs(_path);
                }
                var result = ems.JobCandidates.Add(jobCandidate);
                ems.SaveChanges();

                if (result != null) return RedirectToAction("Index");

            }
            return View();
        }
    }
}