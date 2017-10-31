using DAL.manger;
using DAL.Models;
using webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi.Controllers
{
    [RoutePrefix("api/Home")] 
    public class HomeController : ApiController
    {
        WebAPI_SampleContext context = new WebAPI_SampleContext();
        public string Get()
        {
            return "Hello World";
        }

        #region User registration

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("userRegistration")]
        [HttpPost]
        public string userRegistration(entUserRegistration entobj)
        {
            UserManager userobj = new UserManager();
            entUserRegistration objuser = entobj;
            tbl_User tbl_obj = new tbl_User();

            tbl_obj.id= objuser.id;
            tbl_obj.name = objuser.name;
            tbl_obj.email = objuser.email;
            tbl_obj.phone = objuser.phone;
            tbl_obj.address = objuser.address;
            tbl_obj.location = objuser.location;
            tbl_obj.gender = objuser.gender;
            tbl_obj.username = objuser.username;
            tbl_obj.password = objuser.password;
            tbl_obj.createdDate = DateTime.Now;
            tbl_obj.lastModified = DateTime.Now;
            return userobj.userRegistration(tbl_obj);
        }

        #endregion

         #region All User Details

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("allUsers")]
        public List<entUserRegistration> allUsers()
        {
            UserManager uobj = new UserManager();
            List<entUserRegistration> entobj = new List<entUserRegistration>();
            List<tbl_User> tblobj = uobj.allUsers();

            foreach (var obj in tblobj)
            {
                entobj.Add(new entUserRegistration
                {
                    id = obj.id,
                    name = obj.name,
                    email = obj.email,
                    phone = obj.phone,
                    address = obj.address,
                    location = obj.location,
                    gender = obj.gender,
                    username = obj.username,
                    password = obj.password,
                    createdDate = Convert.ToDateTime(obj.createdDate).ToShortDateString(),
                    lastModified = Convert.ToDateTime(obj.lastModified).ToShortDateString(),
                    isActive = obj.isActive,
                });
            }
            return entobj;
        }
         #endregion
        #region  User Details

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("userDetailsbyid")]

        public entUserRegistration userDetailsbyid(string id)
        {
            UserManager uobj = new UserManager();
            entUserRegistration entobj = new entUserRegistration();
            tbl_User tblobj = uobj.userDetailsbyid(Convert.ToInt32(id));
                    entobj.id = tblobj.id;
                    entobj.name =  tblobj.name;
                    entobj.email =  tblobj.email;
                    entobj.phone =  tblobj.phone;
                    entobj.address =  tblobj.address;
                    entobj.location =  tblobj.location;
                    entobj.gender =  tblobj.gender;
                    entobj.username =  tblobj.username;
                    entobj.password =  tblobj.password;
                    entobj.createdDate = Convert.ToDateTime( tblobj.createdDate).ToShortDateString();
                    entobj.lastModified = Convert.ToDateTime( tblobj.lastModified).ToShortDateString();
                    entobj.isActive = tblobj.isActive;

                    return entobj;

        }
        #endregion

        #region

       
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("allUsersDetails")]
        [HttpPost]
        public List<entUserRegistration> allUsersDetails(string id = null)
        {
            UserManager mngr = new UserManager();
            List<entUserRegistration> return_List = new List<entUserRegistration>();
            List<tbl_User> tbl_obj = mngr.allUsersDetails(Convert.ToInt32(id));
            if (tbl_obj.Count != 0)
            {

                foreach (var obj in tbl_obj)
                {
                    return_List.Add(new entUserRegistration
                    {
                        id = obj.id,
                        name = obj.name,
                        email = obj.email,
                        phone = obj.phone,
                        address = obj.address,
                        location = obj.location,
                        gender = obj.gender,
                        username = obj.username,
                        password = obj.password,
                        createdDate = Convert.ToDateTime(obj.createdDate).ToShortDateString(),
                        lastModified = Convert.ToDateTime(obj.lastModified).ToShortDateString(),
                        isActive = obj.isActive,
                    });
                }
            }
            return return_List;
        }

        #endregion
      
    }
}
