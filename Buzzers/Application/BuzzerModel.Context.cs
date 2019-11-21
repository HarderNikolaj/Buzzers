﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<beetail> beetails { get; set; }
        public virtual DbSet<buzz> buzzs { get; set; }
        public virtual DbSet<eyecolor> eyecolors { get; set; }
        public virtual DbSet<gender> genders { get; set; }
        public virtual DbSet<haircolor> haircolors { get; set; }
        public virtual DbSet<hivemember> hivemembers { get; set; }
        public virtual DbSet<image> images { get; set; }
        public virtual DbSet<match> matches { get; set; }
        public virtual DbSet<memberstory> memberstories { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<preference> preferences { get; set; }
        public virtual DbSet<userlogin> userlogins { get; set; }
        public virtual DbSet<usertype> usertypes { get; set; }
        public virtual DbSet<randommemberstory> randommemberstories { get; set; }
    
        public virtual ObjectResult<Nullable<bool>> CreateUserWithLogin(Nullable<int> usertypeid, Nullable<int> genderid, string firstname, string lastname, string email, Nullable<System.DateTime> birthdate, string jobtitle, string pass)
        {
            var usertypeidParameter = usertypeid.HasValue ?
                new ObjectParameter("usertypeid", usertypeid) :
                new ObjectParameter("usertypeid", typeof(int));
    
            var genderidParameter = genderid.HasValue ?
                new ObjectParameter("genderid", genderid) :
                new ObjectParameter("genderid", typeof(int));
    
            var firstnameParameter = firstname != null ?
                new ObjectParameter("firstname", firstname) :
                new ObjectParameter("firstname", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var birthdateParameter = birthdate.HasValue ?
                new ObjectParameter("birthdate", birthdate) :
                new ObjectParameter("birthdate", typeof(System.DateTime));
    
            var jobtitleParameter = jobtitle != null ?
                new ObjectParameter("jobtitle", jobtitle) :
                new ObjectParameter("jobtitle", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("CreateUserWithLogin", usertypeidParameter, genderidParameter, firstnameParameter, lastnameParameter, emailParameter, birthdateParameter, jobtitleParameter, passParameter);
        }
    
        public virtual ObjectResult<GetPotentialMatch_Result> GetPotentialMatch(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPotentialMatch_Result>("GetPotentialMatch", useridParameter);
        }
    
        public virtual ObjectResult<getmatches_Result> getmatches(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getmatches_Result>("getmatches", useridParameter);
        }
    }
}
