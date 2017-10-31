using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.IO;
using System.Data.SqlClient;
using System.Data.Entity;
namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {
         Db_JobPortalContext db = new Db_JobPortalContext();
        public ActionResult Index()
        {
            return View();
        }

        #region EMPLOYER LOGIN
        public ActionResult EmployerLogin()
        {
            return View();
        }

        public ActionResult Authenticate_Login(FormCollection objColl)
        {
            string UserName = objColl["txt_empUserName"];
            string Password = objColl["txt_empPassword"];
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                var Result = db.tbl_Employer.Where(x => x.Emp_UserName  == UserName && x.Emp_Password  == Password);
                if ((Result.Count()) > 0)
                {
                    System.Web.HttpContext.Current.Session["Emp_Id"] = Result.FirstOrDefault().Emp_Id;
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("EmployerLogin");
        }
        #endregion

        #region EMPLOYER REGISTRATION
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewEmployer(FormCollection objColl, HttpPostedFileBase file1)
        {
            string path = "";

            try
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    path = Path.Combine(Server.MapPath("~/LogoImage"),
                                               Path.GetFileName(file1.FileName));
                    file1.SaveAs(path);
                }

                int empid = 0;
                SqlParameter Emp_Id = new SqlParameter("@Emp_Id", empid);
                SqlParameter Emp_Name = new SqlParameter("@Emp_Name", objColl["txt_empName"]);
                SqlParameter Emp_UserName = new SqlParameter("@Emp_UserName", objColl["txt_empUserName"]);
                SqlParameter Emp_Password = new SqlParameter("@Emp_Password", objColl["txt_empPassword"]);
                SqlParameter Emp_EmailId = new SqlParameter("@Emp_EmailId", objColl["txt_empEmail"]);
                SqlParameter Emp_MobileNumber = new SqlParameter("@Emp_MobileNumber", objColl["txt_empMobile"]);
                SqlParameter Emp_Address = new SqlParameter("@Emp_Address", objColl["txt_empAddress"]);
                SqlParameter Emp_ContactPersonName = new SqlParameter("@Emp_ContactPersonName", objColl["txt_empContactPerson"]);
                SqlParameter Emp_Place = new SqlParameter("@Emp_Place", objColl["txt_empPlace"]);
                SqlParameter Emp_LogoImage = new SqlParameter("@Emp_LogoImage",file1.FileName);
                if (db.Database.ExecuteSqlCommand("sp_ManageEmployer @Emp_Id,@Emp_Name,@Emp_Address,@Emp_ContactPersonName,@Emp_EmailId,@Emp_MobileNumber,@Emp_Place,@Emp_LogoImage,@Emp_UserName,@Emp_Password", Emp_Id, Emp_Name, Emp_Address, Emp_ContactPersonName, Emp_EmailId,Emp_MobileNumber, Emp_Place, Emp_LogoImage, Emp_UserName, Emp_Password) > 0)
                    return View("RegistrationCompleted");
                else
                    return View("Error");
            }
            catch
            {
                return View("Error");
            }

        }

        #endregion

        #region EDIT PROFILE

        public ActionResult EditProfile()
        {
            int EmpId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Emp_Id"].ToString());
            var result = db.tbl_Employer.Where(x => x.Emp_Id  == EmpId).FirstOrDefault();
            Employer  emp = new Employer();
            if (result != null)
            {
                emp.Emp_Address = result.Emp_Address;
                emp.Emp_Id = result.Emp_Id;
                emp.Emp_Name = result.Emp_Name;
                emp.Emp_UserName = result.Emp_UserName;
                emp.Emp_Password = result.Emp_Password;
                emp.Emp_EmailId = result.Emp_EmailId;
                emp.Emp_MobileNumber = result.Emp_MobileNumber;
                emp.Emp_ContactPersonName = result.Emp_ContactPersonName;
                emp.Emp_Place = result.Emp_Place;
                emp.Emp_LogoImage = result.Emp_LogoImage;
            }
            return PartialView("EditProfile", emp);
        }

        [HttpPost]
        public ActionResult EditProfile(FormCollection objColl,HttpPostedFileBase file1)
        {
            string path = "";

            try
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    path = file1.FileName;
                    file1.SaveAs(Path.Combine(Server.MapPath("~/LogoImage"),
                                               Path.GetFileName(file1.FileName)));
                }
                else
                {
                    path = objColl["logoimage"];
                }

                int EmpId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Emp_Id"].ToString());
                SqlParameter Emp_Id = new SqlParameter("@Emp_Id", EmpId);
                SqlParameter Emp_Name = new SqlParameter("@Emp_Name", objColl["Emp_Name"]);
                SqlParameter Emp_Address = new SqlParameter("@Emp_Address", objColl["Emp_Address"]);
                SqlParameter Emp_ContactPersonName = new SqlParameter("@Emp_ContactPersonName", objColl["Emp_ContactPersonName"]);
                SqlParameter Emp_EmailId = new SqlParameter("@Emp_EmailId", objColl["Emp_EmailId"]);
                SqlParameter Emp_MobileNumber = new SqlParameter("@Emp_MobileNumber", objColl["Emp_MobileNumber"]);
                SqlParameter Emp_Place = new SqlParameter("@Emp_Place", objColl["Emp_Place"]);
                SqlParameter Emp_LogoImage = new SqlParameter("@Emp_LogoImage",path );
                SqlParameter Emp_UserName = new SqlParameter("@Emp_UserName", objColl["Emp_UserName"]);
                SqlParameter Emp_Password = new SqlParameter("@Emp_Password", objColl["Emp_Password"]);

                if (db.Database.ExecuteSqlCommand("sp_ManageEmployer @Emp_Id,@Emp_Name,@Emp_Address,@Emp_ContactPersonName,@Emp_EmailId,@Emp_MobileNumber,@Emp_Place,@Emp_LogoImage,@Emp_UserName,@Emp_Password", Emp_Id,Emp_Name, Emp_Address, Emp_ContactPersonName, Emp_EmailId, Emp_MobileNumber, Emp_Place, Emp_LogoImage, Emp_UserName, Emp_Password) > 0)
                {
                    TempData["Message"] = "Profile has been updated successfully.";
                    return RedirectToAction("Index", "Employer");
                }
                else
                {
                    TempData["Message"] = "Error!!! Try Again";
                    return RedirectToAction("Index", "Employer");
                }
            }
            catch
            {
                TempData["Message"] = "Error!!! Try Again";
                return RedirectToAction("Index", "Candidate");
            }

        }
        #endregion

        #region POST JOBS
        public void BindDDL_Category(int id = 0)
        {
            List<SelectListItem> ddlCategory = new List<SelectListItem>();
            List<tbl_Category> obj_Category = db.tbl_Category.ToList();
            if (id > 0)
            {
                foreach (var obj in obj_Category)
                {
                    ddlCategory.Add(new SelectListItem
                    {
                        Selected = (obj.CategoryId == id ? true : false),
                        Text = obj.CategoryName,
                        Value = obj.CategoryId.ToString()
                    });

                }
            }
            else
            {

                ddlCategory.Add(new SelectListItem
                {
                    Selected = true,
                    Text = "-- Select Category--",
                    Value = "0"

                });
                foreach (var Obj in obj_Category)
                {
                    ddlCategory.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = Obj.CategoryName,
                        Value = Obj.CategoryId.ToString()
                    });
                }
            }
            ViewBag.Category = ddlCategory;
        }

        public void BindDDL_Experience(int id = 0)
        {
            List<SelectListItem> ddlExp = new List<SelectListItem>();
            List<tbl_ExperienceLevel> obj_Exp = db.tbl_ExperienceLevel.ToList();
            if (id > 0)
            {
                foreach (var obj in obj_Exp)
                {
                    ddlExp.Add(new SelectListItem
                    {
                        Selected = (obj.ExperienceId == id ? true : false),
                        Text = obj.ExperienceLevel,
                        Value = obj.ExperienceId.ToString()
                    });

                }
            }
            else
            {

                ddlExp.Add(new SelectListItem
                {
                    Selected = true,
                    Text = "-- Select Experience Level--",
                    Value = "0"

                });
                foreach (var Obj in obj_Exp)
                {
                    ddlExp.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = Obj.ExperienceLevel,
                        Value = Obj.ExperienceId.ToString()
                    });
                }
            }
            ViewBag.Experience = ddlExp;
        }

        public void BindDDL_Location(int id = 0)
        {
            List<SelectListItem> ddlLocation = new List<SelectListItem>();
            List<tbl_Location> obj_Location = db.tbl_Location.ToList();
            if (id > 0)
            {
                foreach (var obj in obj_Location)
                {
                    ddlLocation.Add(new SelectListItem
                    {
                        Selected = (obj.LocationId == id ? true : false),
                        Text = obj.LocationName,
                        Value = obj.LocationId.ToString()
                    });

                }
            }
            else
            {

                ddlLocation.Add(new SelectListItem
                {
                    Selected = true,
                    Text = "-- Select Location--",
                    Value = "0"

                });
                foreach (var Obj in obj_Location)
                {
                    ddlLocation.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = Obj.LocationName,
                        Value = Obj.LocationId.ToString()
                    });
                }
            }
            ViewBag.Location = ddlLocation;
        }

        public ActionResult GetJobsPosted(string job_title, string skill, int cat_id, int loc_id, int exp_id)
        {
            BindDDL_Category(0);
            BindDDL_Experience(0);
            BindDDL_Location(0);
            int EmpId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Emp_Id"].ToString());
            var result = db.tbl_Jobs.Where(x => x.Job_EmployerId == EmpId).ToList();
            if (string.IsNullOrEmpty(job_title))
                result = result.Where(x => x.Job_Title.Contains(job_title)).ToList();
            if(string.IsNullOrEmpty(skill))
                result=result.Where(x=>x.Job_Description.Contains(skill)).ToList();
            if(cat_id>0)
                result=result.Where(x=>x.Job_CategoryId==cat_id).ToList();
            if(loc_id>0)
                result=result.Where(x=>x.Job_LocationId==loc_id).ToList();
            if(exp_id>0)
                result=result.Where(x=>x.Job_ExpLevelId==exp_id).ToList();

            List<Jobs> jbList = new List<Jobs>();
            foreach(var jb in result)
            {
                jbList.Add(new Jobs {
                    Job_Id=jb.Job_Id,
                    Job_Title=jb.Job_Title,
                    Job_Description=jb.Job_Description,
                    Job_Designation=jb.Job_Designation,
                    CategoryName=db.tbl_Category.Where(x=>x.CategoryId==jb.Job_CategoryId).FirstOrDefault().CategoryName,
                    LocationName=db.tbl_Location.Where(x=>x.LocationId==jb.Job_LocationId).FirstOrDefault().LocationName,
                    Experience=db.tbl_ExperienceLevel.Where(x=>x.ExperienceId==jb.Job_ExpLevelId).FirstOrDefault().ExperienceLevel,
                    Job_DateTime=jb.Job_DateTime,
                    Job_Status=jb.Job_Status
                });
            }
            return PartialView(jbList);
        }

        public ActionResult Create()
        {
            BindDDL_Category(0);
            BindDDL_Experience(0);
            BindDDL_Location(0);
            return PartialView();
        }

        public ActionResult Edit(int jobid)
        {
            var result = db.tbl_Jobs.Where(x => x.Job_Id == jobid).FirstOrDefault();
            Jobs jb = new Jobs();
            if (result != null)
            {
                jb.Job_Id = result.Job_Id;
                jb.Job_Description = result.Job_Description;
                jb.Job_Designation = result.Job_Designation;
                jb.Job_Title = result.Job_Title;
                jb.Job_CategoryId = result.Job_CategoryId;
                jb.Job_LocationId = result.Job_LocationId;
                jb.Job_ExpLevelId = result.Job_ExpLevelId;
                BindDDL_Category(Convert.ToInt32(result.Job_CategoryId));
                BindDDL_Experience(Convert.ToInt32(result.Job_LocationId));
                BindDDL_Location(Convert.ToInt32(result.Job_ExpLevelId));
            }
            return PartialView("Create",jb);
        }

        public ActionResult  SaveJob(Jobs jb)
        {
            int EmpId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Emp_Id"].ToString());
            SqlParameter Job_Id = new SqlParameter("@Job_Id", jb.Job_Id);
            SqlParameter Job_EmployerId = new SqlParameter("@Job_EmployerId", EmpId);
            SqlParameter Job_CategoryId = new SqlParameter("@Job_CategoryId", jb.Job_CategoryId);
            SqlParameter Job_LocationId = new SqlParameter("@Job_LocationId", jb.Job_LocationId);
            SqlParameter Job_ExpLevelId = new SqlParameter("@Job_ExpLevelId", jb.Job_ExpLevelId);
            SqlParameter Job_Title = new SqlParameter("@Job_Title", jb.Job_Title);
            SqlParameter Job_Designation = new SqlParameter("@Job_Designation", jb.Job_Designation);
            SqlParameter Job_Description = new SqlParameter("@Job_Description", jb.Job_Description);
            if (db.Database.ExecuteSqlCommand("sp_ManageJob @Job_Id,@Job_EmployerId,@Job_CategoryId,@Job_LocationId,@Job_ExpLevelId,@Job_Title,@Job_Designation,@Job_Description", Job_Id,Job_EmployerId, Job_CategoryId, Job_LocationId, Job_ExpLevelId, Job_Title, Job_Designation, Job_Description) > 0)
                return PartialView("AfterSaveJob");
            else
                return PartialView("Error");
        }

        public ActionResult ViewJob(int jobid)
        {
            var result = db.tbl_Jobs.Where(x => x.Job_Id == jobid).FirstOrDefault();
            Jobs jb = new Jobs();
            if (result != null)
            {
                jb.Job_Id = result.Job_Id;
                jb.Job_Description = result.Job_Description;
                jb.Job_Designation = result.Job_Designation;
                jb.Job_Title = result.Job_Title;
                jb.CategoryName  =db.tbl_Category.Where(x=>x.CategoryId == result.Job_CategoryId).FirstOrDefault().CategoryName;
                jb.LocationName= db.tbl_Location.Where(x=>x.LocationId== result.Job_LocationId).FirstOrDefault().LocationName;
                jb.Experience =db.tbl_ExperienceLevel.Where(x=>x.ExperienceId== result.Job_ExpLevelId).FirstOrDefault().ExperienceLevel;
                jb.Job_DateTime = result.Job_DateTime;
                jb.Job_Status = result.Job_Status;
                
            }
            return PartialView("JobDetails", jb);
        }

        public int DeleteJob(int jobid)
        {
            SqlParameter Job_Id = new SqlParameter("@Job_Id", jobid);
            return db.Database.ExecuteSqlCommand("sp_Delete_Job @Job_Id", Job_Id);
        }
        #endregion

        #region APPLIED CANDIDATE SECTION
        public ActionResult GetAppliedCandidates()
        {
            int EmpId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Emp_Id"].ToString());
            var lstJob = db.tbl_Jobs.Where(x => x.Job_EmployerId == EmpId).ToList().Select(y => y.Job_Id).ToList();

            var lstAppliedCandidates = db.tbl_CandidateAppliedJobs.Where(x => lstJob.Contains(x.Job_Id)).ToList();
            List<CandidateAppliedjobs> lst_cnd = new List<CandidateAppliedjobs>();
            foreach (var obj in lstAppliedCandidates)
            {
                lst_cnd.Add(new CandidateAppliedjobs
                    {
                            Cand_id=Convert.ToInt32(obj.Cand_Id),
                            Cand_JobAppliedDateTime = obj.JobAppliedDateTime,
                            Job_Id =Convert.ToInt32(obj.Job_Id),
                            Job_Title = db.tbl_Jobs.Where(x=>x.Job_Id==obj.Job_Id).FirstOrDefault().Job_Title,
                            Job_DateTime = db.tbl_Jobs.Where(x => x.Job_Id == obj.Job_Id).FirstOrDefault().Job_DateTime,
                            Cand_Name = db.tbl_Candidate.Where(x => x.Cand_Id == obj.Cand_Id).FirstOrDefault().Cand_Name,
                            Cand_HighestQualification = db.tbl_Candidate.Where(x => x.Cand_Id == obj.Cand_Id).FirstOrDefault().Cand_HighestQualification,                         
                    });
            }
          
            return PartialView(lst_cnd);
        }

        public ActionResult ViewCandidateProfile(int candid)
        {
            var result = db.tbl_Candidate.Where(x => x.Cand_Id == candid).FirstOrDefault();
            Candidate cnd = new Candidate();
                cnd.Cand_Id = result.Cand_Id;
                cnd.Cand_Name = result.Cand_Name;
                cnd.Cand_EmailId = result.Cand_EmailId;
                cnd.Cand_MobileNumber = result.Cand_MobileNumber;
                cnd.Cand_HighestQualification = result.Cand_HighestQualification;
                cnd.Cand_SkillDescription = result.Cand_SkillDescription;
                cnd.LocationName=db.tbl_Location.FirstOrDefault(x=>x.LocationId==result.Cand_LocationId).LocationName;
                cnd.ExperienceLevel=db.tbl_ExperienceLevel.FirstOrDefault(x=>x.ExperienceId==result.Cand_ExpLevelId).ExperienceLevel;
                cnd.CategoryName=db.tbl_Category.FirstOrDefault(x=>x.CategoryId==result.Cand_CategoryId).CategoryName;
                cnd.Cand_Address=result.Cand_Address;

            return PartialView(cnd);
        }

        public ActionResult ChangeCandProfileStatus(int candid,int jobid)
        {
            var result = db.tbl_EmployerManageCandidateProfile.Where(x => x.Cand_Id == candid && x.Job_Id == jobid).FirstOrDefault();
            if (result != null)
            {
                if (result.IsShortlisted == true)
                    BindDDL_Status(1);
                else
                    BindDDL_Status(0);
            }
            else
            {
                BindDDL_Status(0);
            }
            return PartialView();
        }
       
        public string UpdateCandProfileStatus(int candid,int jobid,string status)
        {
            tbl_EmployerManageCandidateProfile obj = new tbl_EmployerManageCandidateProfile();
            var result = db.tbl_EmployerManageCandidateProfile.Where(x => x.Cand_Id == candid && x.Job_Id == jobid).ToList();
            if (result.Count > 0)
            {
                obj = result.FirstOrDefault();
                if (status == "0")

                    obj.ViewedDateTime = DateTime.UtcNow;
                else
                    obj.IsShortlisted = true;
                db.Entry(obj).State = EntityState.Modified;
            }
            else
            {
                obj.Cand_Id = candid;
                obj.Job_Id = jobid;
                if (status == "0")
                    obj.ViewedDateTime = DateTime.UtcNow;
                else
                    obj.IsShortlisted = true;

                db.tbl_EmployerManageCandidateProfile.Add(obj);
            }
            try
            {
                db.SaveChanges();
                return "Successfully Updated";
            }
            catch
            {
                return "Error!!!! Try Again";
            }

        }

        public void BindDDL_Status(int id = 0)
        {
            List<SelectListItem> ddlStatus= new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem
            {
                Text = "Profile Viewed",
                Value ="0"
            });
            ddlStatus.Add(new SelectListItem
            {
                Text = "Shortlisted",
                Value = "1"
            });

            if (id == 0)
                ddlStatus[0].Selected = true;
            else if(id==1)
                ddlStatus[1].Selected = true;

            ViewBag.CandProfile_StatusId = ddlStatus;

        }
        #endregion
    }
}
