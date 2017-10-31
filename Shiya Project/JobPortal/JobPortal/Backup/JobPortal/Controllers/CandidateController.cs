using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace JobPortal.Controllers
{
    public class CandidateController : Controller
    {
        Db_JobPortalContext db = new Db_JobPortalContext();
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome....";
            return View();
        }

        #region CANDIDATE REGISTRATION
        public ActionResult SignUp()
        {
            BindDDL_Category(0);
            BindDDL_Experience(0);
            BindDDL_Location(0);
            return View();
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

        [HttpPost]
        public ActionResult RegisterNewCandidate(FormCollection objColl, HttpPostedFileBase file1)
        {
            string path = "";
            
                try
                {
                    if (file1 != null && file1.ContentLength > 0)
                    {
                    path = Path.Combine(Server.MapPath("~/Resume"),
                                               Path.GetFileName(file1.FileName));
                    file1.SaveAs(path);
                    }

                    int candid = 0;
                    int categoryid = Convert.ToInt32(objColl["Sel_Category"]);
                    int locationid = Convert.ToInt32(objColl["Sel_Location"]);
                    int experienceid = Convert.ToInt32(objColl["Sel_Experience"]);
                    SqlParameter Cand_Id = new SqlParameter("@Cand_Id", candid);
                    SqlParameter Cand_CategoryId = new SqlParameter("@Cand_CategoryId", categoryid);
                    SqlParameter Cand_LocationId = new SqlParameter("@Cand_LocationId", locationid);
                    SqlParameter Cand_ExpLevelId = new SqlParameter("@Cand_ExpLevelId", experienceid);
                    SqlParameter Cand_Name = new SqlParameter("@Cand_Name", objColl["txt_candName"]);
                    SqlParameter Cand_UserName = new SqlParameter("@Cand_UserName", objColl["txt_candUserName"]);
                    SqlParameter Cand_Password = new SqlParameter("@Cand_Password", objColl["txt_candPassword"]);
                    SqlParameter Cand_EmailId = new SqlParameter("@Cand_EmailId", objColl["txt_candEmail"]);
                    SqlParameter Cand_MobileNumber = new SqlParameter("@Cand_MobileNumber", objColl["txt_candMobile"]);
                    SqlParameter Cand_Address = new SqlParameter("@Cand_Address", objColl["txt_candAddress"]);
                    SqlParameter Cand_HighestQualification = new SqlParameter("@Cand_HighestQualification", objColl["txt_candQualification"]);
                    SqlParameter Cand_SkillDescription = new SqlParameter("@Cand_SkillDescription", objColl["txt_candSkills"]);
                    SqlParameter Cand_Resume = new SqlParameter("@Cand_Resume", path);
                    if (db.Database.ExecuteSqlCommand("sp_ManageCandidate @Cand_Id,@Cand_CategoryId,@Cand_LocationId,@Cand_ExpLevelId,@Cand_Name,@Cand_UserName,@Cand_Password,@Cand_EmailId,@Cand_MobileNumber,@Cand_Address,@Cand_HighestQualification,@Cand_SkillDescription,@Cand_Resume", Cand_Id, Cand_CategoryId, Cand_LocationId, Cand_ExpLevelId, Cand_Name, Cand_UserName, Cand_Password, Cand_EmailId, Cand_MobileNumber, Cand_Address, Cand_HighestQualification, Cand_SkillDescription, Cand_Resume) > 0)
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

        #region CANDIDATE LOGIN
        public ActionResult CandidateLogin()
        {
            return View();
        }

        public ActionResult Authenticate_Login(FormCollection objColl)
        {
            string UserName = objColl["txt_candUserName"];
            string Password = objColl["txt_candPassword"];
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                var Result=db.tbl_Candidate.Where(x => x.Cand_UserName == UserName && x.Cand_Password == Password);
                if ((Result.Count()) > 0)
                {
                    System.Web.HttpContext.Current.Session["CandId"] = Result.FirstOrDefault().Cand_Id;;  
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("CandiateLogin");
        }
        #endregion

        #region SEARCH JOBS
        public ActionResult Candidate_SearchJobs(string cat_id, string exp_id, string loc_id, string job_title, string skill)
        {

            List<Jobs> jb = new List<Jobs>();
            var Result = db.tbl_Jobs.ToList();
            if (!string.IsNullOrEmpty(cat_id))
            {
                var cat_ids = cat_id.Split(',').Select(Int32.Parse).ToList();
                Result = Result.Where(x => cat_ids.Contains(Convert.ToInt32(x.Job_CategoryId))).ToList();
            }
            if (!string.IsNullOrEmpty(exp_id))
            {
                var exp_ids = exp_id.Split(',').Select(Int32.Parse).ToList();
                Result = Result.Where(x => exp_ids.Contains(Convert.ToInt32(x.Job_ExpLevelId))).ToList();
            }
            if (!string.IsNullOrEmpty(loc_id))
            {
                var loc_ids = loc_id.Split(',').Select(Int32.Parse).ToList();
                Result = Result.Where(x => loc_ids.Contains(Convert.ToInt32(x.Job_LocationId))).ToList();
            }
            if (!string.IsNullOrEmpty(job_title))
                Result = Result.Where(x => x.Job_Title.Contains(job_title)).ToList();


            if (!string.IsNullOrEmpty(skill))
                Result = Result.Where(x => x.Job_Description.Contains(skill)).ToList();
            foreach (var obj in Result)
            {
                jb.Add(new Jobs { Job_Id = obj.Job_Id, Job_Title = obj.Job_Title, Job_Description = obj.Job_Description });
            }
                    
            return PartialView("Candidate_SearchJobs",jb);
        }

        public string Bind_Category()
        {
            string html = "<ul><li><span>Category</span></li>";
            List<tbl_Category> obj_Category = db.tbl_Category.ToList();

            foreach (var obj in obj_Category)
            {
                html = html + "<li><div><input type='checkbox' id=Cat_" + obj.CategoryId + " value="+obj.CategoryId+">" + obj.CategoryName + "</div></li>";
            }
            return html+"</ul>";
        }
        public string Bind_Location()
        {
            string html = "<ul><li><span>Location</span></li>";
            List<tbl_Location> obj_Location = db.tbl_Location.ToList();

            foreach (var obj in obj_Location)
            {
                html = html + "<li><div><input type='checkbox' id=Loc_" + obj.LocationId  + " value="+obj.LocationId+">" + obj.LocationName  + "</div></li>";
            }
            return html + "</ul>";
        }

        public string Bind_Experience()
        {
            string html = "<ul><li><span>Experience</span></li>";
            List<tbl_ExperienceLevel> obj_Exp = db.tbl_ExperienceLevel.ToList();

            foreach (var obj in obj_Exp)
            {
                html = html + "<li><div><input type='checkbox' id=Exp_" + obj.ExperienceId + " value="+ obj.ExperienceId +">" + obj.ExperienceLevel + "</div></li>";
            }
            return html + "</ul>";
        }

        public ActionResult GetJobDetails(int jobid)
        {
            Jobs jb=new Jobs();
           var result=db.tbl_Jobs.Where(x=>x.Job_Id==jobid).FirstOrDefault();
            jb.Job_Description=result.Job_Description;
            jb.Job_Designation=result.Job_Designation;
            jb.Job_Title=result.Job_Title;
            jb.LocationName = db.tbl_Location.Where(x => x.LocationId == result.Job_LocationId).FirstOrDefault().LocationName;
            jb.CategoryName = db.tbl_Category.Where(x => x.CategoryId == result.Job_CategoryId).FirstOrDefault().CategoryName;
            jb.Experience = db.tbl_ExperienceLevel.Where(x => x.ExperienceId == result.Job_ExpLevelId).FirstOrDefault().ExperienceLevel;
            jb.EmployerName = db.tbl_Employer.Where(x => x.Emp_Id == result.Job_EmployerId).FirstOrDefault().Emp_Name;
            jb.Job_Id = result.Job_Id;
            return PartialView("JobDetails",jb);
        }

        public int ApplyJob(int JobId)
        {
            int CandId = Convert.ToInt32(System.Web.HttpContext.Current.Session["CandId"].ToString());
            if (db.tbl_CandidateAppliedJobs.Where(x => x.Cand_Id == CandId && x.Job_Id == JobId).ToList().Count > 0)
            {
                return 2;
            }
            else
            {
                SqlParameter Cand_Id = new SqlParameter("@Cand_Id", CandId);
                SqlParameter Job_Id = new SqlParameter("@Job_Id", JobId);
                return db.Database.ExecuteSqlCommand("sp_Insert_CandidateAppliedJobs @Cand_Id,@Job_Id", Cand_Id, Job_Id);
            }
        }
        #endregion

        #region EDIT PROFILE
        [HttpGet]
        public ActionResult EditProfile()
        {
            int CandId =Convert.ToInt32( System.Web.HttpContext.Current.Session["CandId"].ToString());
            var result=db.tbl_Candidate.Where(x => x.Cand_Id == CandId).FirstOrDefault();
            Candidate cnd=new Candidate();
            if (result != null)
            {
                cnd.Cand_Address = result.Cand_Address;
                cnd.Cand_Id = result.Cand_Id;
                cnd.Cand_CategoryId = result.Cand_CategoryId;
                cnd.Cand_LocationId = result.Cand_LocationId;
                cnd.Cand_ExpLevelId = result.Cand_ExpLevelId;
                cnd.Cand_Name = result.Cand_Name;
                cnd.Cand_UserName = result.Cand_UserName;
                cnd.Cand_Password = result.Cand_Password;
                cnd.Cand_EmailId = result.Cand_EmailId;
                cnd.Cand_MobileNumber = result.Cand_MobileNumber;
                cnd.Cand_HighestQualification = result.Cand_HighestQualification;
                cnd.Cand_SkillDescription = result.Cand_SkillDescription;
                cnd.Cand_Resume = result.Cand_Resume;

                BindDDL_Category(Convert.ToInt32(result.Cand_CategoryId));
                BindDDL_Experience(Convert.ToInt32(result.Cand_LocationId));
                BindDDL_Location(Convert.ToInt32(result.Cand_ExpLevelId));

            }
            return PartialView("EditProfile", cnd);
        }

        [HttpPost]
        public ActionResult  EditProfile(FormCollection objColl, HttpPostedFileBase file1)
        {
            string path = "";

            try
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    path = Path.Combine(Server.MapPath("~/Resume"),
                                               Path.GetFileName(file1.FileName));
                    file1.SaveAs(path);
                }

                int CandId = Convert.ToInt32(System.Web.HttpContext.Current.Session["CandId"].ToString());
                int categoryid = Convert.ToInt32(objColl["Sel_Category"]);
                int locationid = Convert.ToInt32(objColl["Sel_Location"]);
                int experienceid = Convert.ToInt32(objColl["Sel_Experience"]);
                SqlParameter Cand_Id = new SqlParameter("@Cand_Id", CandId);
                SqlParameter Cand_CategoryId = new SqlParameter("@Cand_CategoryId", categoryid);
                SqlParameter Cand_LocationId = new SqlParameter("@Cand_LocationId", locationid);
                SqlParameter Cand_ExpLevelId = new SqlParameter("@Cand_ExpLevelId", experienceid);
                SqlParameter Cand_Name = new SqlParameter("@Cand_Name", objColl["Cand_Name"]);
                SqlParameter Cand_UserName = new SqlParameter("@Cand_UserName", objColl["Cand_UserName"]);
                SqlParameter Cand_Password = new SqlParameter("@Cand_Password", objColl["Cand_Password"]);
                SqlParameter Cand_EmailId = new SqlParameter("@Cand_EmailId", objColl["Cand_EmailId"]);
                SqlParameter Cand_MobileNumber = new SqlParameter("@Cand_MobileNumber", objColl["Cand_MobileNumber"]);
                SqlParameter Cand_Address = new SqlParameter("@Cand_Address", objColl["Cand_Address"]);
                SqlParameter Cand_HighestQualification = new SqlParameter("@Cand_HighestQualification", objColl["Cand_HighestQualification"]);
                SqlParameter Cand_SkillDescription = new SqlParameter("@Cand_SkillDescription", objColl["Cand_SkillDescription"]);
                SqlParameter Cand_Resume = new SqlParameter("@Cand_Resume", path);
                if (db.Database.ExecuteSqlCommand("sp_ManageCandidate @Cand_Id,@Cand_CategoryId,@Cand_LocationId,@Cand_ExpLevelId,@Cand_Name,@Cand_UserName,@Cand_Password,@Cand_EmailId,@Cand_MobileNumber,@Cand_Address,@Cand_HighestQualification,@Cand_SkillDescription,@Cand_Resume", Cand_Id, Cand_CategoryId, Cand_LocationId, Cand_ExpLevelId, Cand_Name, Cand_UserName, Cand_Password, Cand_EmailId, Cand_MobileNumber, Cand_Address, Cand_HighestQualification, Cand_SkillDescription, Cand_Resume) > 0)
                {
                    TempData["Message"] = "Profile has been updated successfully.";
                    return RedirectToAction("Index","Candidate");
                }
                else
                {
                   TempData["Message"] = "Error!!! Try Again";
                   return  RedirectToAction("Index", "Candidate");
                }
            }
            catch
            {
               TempData["Message"] = "Error!!! Try Again";
               return  RedirectToAction("Index", "Candidate");
            }

        }

        #endregion

        #region PROFILE HISTORY

        public ActionResult ProfileHistory()
        {
            int CandId =Convert.ToInt32(System.Web.HttpContext.Current.Session["CandId"]);
            var result = db.tbl_EmployerManageCandidateProfile.Where(x => x.Cand_Id == CandId).ToList();
            List<CandidateProfileHistory> CndProfHistory = new List<CandidateProfileHistory>();
            foreach (var item in result)
            {
                string Message1="", Message2 = "";
                if(item.ViewedDateTime !=null)
                {
                    Message1 = "Your application has been viewed by the employer for the job: " + db.tbl_Jobs.Where(x => x.Job_Id == item.Job_Id).FirstOrDefault().Job_Title + System.Environment.NewLine;
                }
                if (item.IsShortlisted == true)
                {
                    Message2 = "Your have been shortlisted by the employer for the job: " + db.tbl_Jobs.Where(x => x.Job_Id == item.Job_Id).FirstOrDefault().Job_Title;
                }
                CndProfHistory.Add(new CandidateProfileHistory
                {
                   ProfileHistory = Message1+Message2
                });
                
            }
            return PartialView(CndProfHistory);
        }
        #endregion
    }
}
