using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;


namespace DAL.manger
{
   public class UserManager
    {
       WebAPI_SampleContext context = new WebAPI_SampleContext();
       public string userRegistration(tbl_User tb_obj)
       {
           int result = 0;
           var obj_user = context.tbl_User.Where(e => e.email == tb_obj.email && e.username == tb_obj.username && e.isActive != "D").SingleOrDefault();
           if (obj_user == null)
           {
               tb_obj.isActive = "A";
               context.tbl_User.Add(tb_obj);
               result=context.SaveChanges();

           }
           else
           {
               obj_user.name = tb_obj.name;
               obj_user.email = tb_obj.email;
               obj_user.phone = tb_obj.phone;
               obj_user.address = tb_obj.address;
               obj_user.location = tb_obj.location;
               obj_user.gender = tb_obj.gender;
               obj_user.username = tb_obj.username;
               obj_user.password = tb_obj.password;
               obj_user.lastModified = DateTime.Now;
               obj_user.isActive = "A";
               context.Entry(obj_user).State = EntityState.Modified;
               result = context.SaveChanges();
           }

           if (result > 0)
           {
               return tb_obj.id.ToString();
           }
           else
           {
               return "Error";
           }
       }
       public List<tbl_User> allUsers()
       {
           return context.tbl_User.Where(e => e.isActive != "D").ToList();
       }
       public tbl_User userDetailsbyid(int id)
       {
           tbl_User tblObj = new tbl_User();
           return tblObj = context.tbl_User.Where(e => e.id == id && e.isActive != "D").SingleOrDefault();
       }
       public List<tbl_User> allUsersDetails(int id = 0)
       {
           if (id != 0)
           {
               return context.tbl_User.Where(e => e.id == id && e.isActive != "D").ToList();
           }
           else
           {
               return context.tbl_User.Where(e => e.isActive != "D").ToList();
           }
       }
    }
}
