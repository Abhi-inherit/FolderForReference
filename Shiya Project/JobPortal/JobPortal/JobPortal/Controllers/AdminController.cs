using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Data.SqlClient;
using System.Data.Entity;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        Db_JobPortalContext db = new Db_JobPortalContext();
        public ActionResult  Index()
        {
            return View();
        }

        #region MANAGE CANDIDATE

        public ActionResult GetCandidateList(int cand_id, int cat_id, int exp_id, int loc_id, string cand_name, string skill)
        {
            BindDDL_Category(cat_id);
            BindDDL_Experience(exp_id);
            BindDDL_Location(loc_id);
            return PartialView("GetCandidate", GetCandidate(0, cat_id, exp_id, loc_id, cand_name, skill));
        }

        public ActionResult Get_A_CandidateDetails(int cand_id)
        {
            return PartialView("Get_A_CandidateDetails", GetCandidate(cand_id, 0,0, 0, null, null).FirstOrDefault());
        }

        public List<Candidate> GetCandidate(int cand_id,int cat_id, int exp_id, int loc_id, string cand_name, string skill)
        {
            var Result = db.tbl_Candidate.ToList();
            if (cand_id != 0)
                Result = Result.Where(x => x.Cand_Id == cand_id).ToList();
            if (cat_id != 0)
                Result = Result.Where(x => x.Cand_CategoryId  == cat_id).ToList();
            if (exp_id != 0)
                Result = Result.Where(x => x.Cand_ExpLevelId == exp_id).ToList();
            if (loc_id != 0)
                Result = Result.Where(x => x.Cand_LocationId == loc_id).ToList();
            if (!string.IsNullOrEmpty(cand_name))
                Result = Result.Where(x => x.Cand_Name.Contains(cand_name)).ToList();
            if (!string.IsNullOrEmpty(skill))
                Result = Result.Where(x => x.Cand_SkillDescription.Contains(skill)).ToList();

            List<Candidate> lst_Candidate = new List<Candidate>();
            foreach (var obj in Result)
            {
                lst_Candidate.Add(new Candidate
                {
                    Cand_Id=obj.Cand_Id,
                    Cand_Name = obj.Cand_Name,
                    Cand_EmailId = obj.Cand_EmailId,
                    Cand_MobileNumber = obj.Cand_MobileNumber,
                    Cand_HighestQualification = obj.Cand_HighestQualification,
                    Cand_SkillDescription = obj.Cand_SkillDescription,
                    LocationName=db.tbl_Location.FirstOrDefault(x=>x.LocationId==obj.Cand_LocationId).LocationName,
                    ExperienceLevel=db.tbl_ExperienceLevel.FirstOrDefault(x=>x.ExperienceId==obj.Cand_ExpLevelId).ExperienceLevel,
                    CategoryName=db.tbl_Category.FirstOrDefault(x=>x.CategoryId==obj.Cand_CategoryId).CategoryName,
                    Cand_Address=obj.Cand_Address,
                    Cand_UserName=obj.Cand_UserName,
                    Cand_Password=obj.Cand_Password 
                    
                });
            }

            return lst_Candidate;
        }

        public ActionResult GetCandidateDeleteView(int cand_id)
        {

            return PartialView("CandidateDelete", GetCandidate(cand_id,0, 0, 0, null, null).FirstOrDefault());
        }

        public int DeleteCandidate(int cand_id)
        {
            SqlParameter Cand_Id = new SqlParameter("@Cand_Id",cand_id);
            return db.Database.ExecuteSqlCommand("sp_Delete_Candidate @Cand_Id", Cand_Id);
        }

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
                    Text = "-- Select --",
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
                        Selected = (obj.ExperienceId  == id ? true : false),
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
                    Text = "-- Select --",
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
                        Selected = (obj.LocationId  == id ? true : false),
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
                    Text = "-- Select --",
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

        #endregion

        #region MANAGE EMPLOYER
        public List<Employer> GetEmployer(int empid,string EmpName,string EmpContact,string EmpStatus)
        {
            List<Employer> emp_list = new List<Employer>();
            var Result = db.tbl_Employer.ToList();
            if (empid > 0)
                Result = Result.Where(x => x.Emp_Id == empid).ToList();
            if (!string.IsNullOrEmpty(EmpName))
                Result = Result.Where(x => x.Emp_Name.Contains(EmpName)).ToList();
            if (!string.IsNullOrEmpty(EmpName))
                Result = Result.Where(x => x.Emp_ContactPersonName.Contains(EmpContact)).ToList();
            if (!string.IsNullOrEmpty(EmpStatus))
                Result = Result.Where(x => x.Emp_Status  == Convert.ToBoolean(EmpStatus)).ToList();
            foreach (var obj in Result)
            {
                emp_list.Add(new Employer 
                {
                    Emp_Id=obj.Emp_Id,
                    Emp_Address = obj.Emp_Address,
                    Emp_ContactPersonName=obj.Emp_ContactPersonName,
                    Emp_DateTime=obj.Emp_DateTime,
                    Emp_EmailId=obj.Emp_EmailId,
                    Emp_LogoImage=obj.Emp_LogoImage,
                    Emp_MobileNumber=obj.Emp_MobileNumber,
                    Emp_Name=obj.Emp_Name,
                    Emp_Place=obj.Emp_Place,
                    Emp_Status=obj.Emp_Status 
                });
            }

            return emp_list;
        }

        public ActionResult GetEmployerList(int empid, string EmpName, string EmpContact, string EmpStatus)
        {
            return PartialView("GetEmployerList", GetEmployer(0, EmpName, EmpContact, EmpStatus));
        }

        public ActionResult Get_AnEmployer(int empid)
        {
            return PartialView("Get_AnEmployer", GetEmployer(empid, null, null, null).FirstOrDefault());
        }

        public ActionResult GetEmployerDeleteView(int empid)
        {
            return PartialView("GetEmployerDelete", GetEmployer(empid, null, null, null).FirstOrDefault());
        }

        public int DeleteEmployer(int empid)
        {
            SqlParameter Emp_Id = new SqlParameter("@Emp_Id",empid);
            return db.Database.ExecuteSqlCommand("sp_Delete_Employer @Emp_Id", Emp_Id);
        }

        public ActionResult  EditEmployerStatus(int EmpId)
        {
            var result = db.tbl_Employer.Where(x => x.Emp_Id == EmpId).FirstOrDefault();
            if (result.Emp_Status == true)
                BindEmpDDL_Status(1);
            else
                BindEmpDDL_Status(0);
            return View();
        }

        public string UpdateEmployerStatus(int EmpId,bool Status)
        {
            try
            {
                tbl_Employer emp = new tbl_Employer();
                emp = db.tbl_Employer.Where(x => x.Emp_Id == EmpId).FirstOrDefault();
                emp.Emp_Status = Status;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return "1";
            }
            catch
            {
                return "Error !!!!";
            }
        }
        public void BindEmpDDL_Status(int id = 0)
        {
            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem
            {
                Text = "False",
                Value = "0"
            });
            ddlStatus.Add(new SelectListItem
            {
                Text = "True",
                Value = "1"
            });

            if (id == 0)
                ddlStatus[0].Selected = true;
            else if (id == 1)
                ddlStatus[1].Selected = true;

            ViewBag.Emp_StatusId = ddlStatus;

        }
        #endregion

        #region MANAGE JOBS
        public ActionResult GetAllJobs(string job_title, string skill, int cat_id, int loc_id, int exp_id)
        {
            BindDDL_Category(0);
            BindDDL_Experience(0);
            BindDDL_Location(0);

            var result = db.tbl_Jobs.ToList();
            if (string.IsNullOrEmpty(job_title))
                result = result.Where(x => x.Job_Title.Contains(job_title)).ToList();
            if (string.IsNullOrEmpty(skill))
                result = result.Where(x => x.Job_Description.Contains(skill)).ToList();
            if (cat_id > 0)
                result = result.Where(x => x.Job_CategoryId == cat_id).ToList();
            if (loc_id > 0)
                result = result.Where(x => x.Job_LocationId == loc_id).ToList();
            if (exp_id > 0)
                result = result.Where(x => x.Job_ExpLevelId == exp_id).ToList();

            List<Jobs> jbList = new List<Jobs>();
            foreach (var jb in result)
            {
                jbList.Add(new Jobs
                {
                    Job_Id = jb.Job_Id,
                    Job_Title = jb.Job_Title,
                    Job_Description = jb.Job_Description,
                    Job_Designation = jb.Job_Designation,
                    CategoryName = db.tbl_Category.Where(x => x.CategoryId == jb.Job_CategoryId).FirstOrDefault().CategoryName,
                    LocationName = db.tbl_Location.Where(x => x.LocationId == jb.Job_LocationId).FirstOrDefault().LocationName,
                    Experience = db.tbl_ExperienceLevel.Where(x => x.ExperienceId == jb.Job_ExpLevelId).FirstOrDefault().ExperienceLevel,
                    Job_DateTime = jb.Job_DateTime,
                    Job_Status = jb.Job_Status
                });
            }
            return PartialView(jbList);
        }

        public ActionResult EditJobStatus(int jobid)
        {
            var result = db.tbl_Jobs.Where(x => x.Job_Id == jobid).FirstOrDefault();
            if (result.Job_Status == true)
                BindJobDDL_Status(1);
            else
                BindJobDDL_Status(0);
            return PartialView();
        }
        public void BindJobDDL_Status(int id = 0)
        {
            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem
            {
                Text = "False",
                Value = "0"
            });
            ddlStatus.Add(new SelectListItem
            {
                Text = "True",
                Value = "1"
            });

            if (id == 0)
                ddlStatus[0].Selected = true;
            else if (id == 1)
                ddlStatus[1].Selected = true;

            ViewBag.Job_StatusId = ddlStatus;

        }
        public string UpdateJobStatus(int jobid, bool Status)
        {
            try
            {
                tbl_Jobs obj = new tbl_Jobs();
                obj = db.tbl_Jobs.Where(x => x.Job_Id == jobid).FirstOrDefault();
                obj.Job_Status = Status;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return "1";
            }
            catch
            {
                return "Error !!!!";
            }
        }
        #endregion
    }
}
