//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrnekToDoList.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_todo
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<short> CategoryId { get; set; }
    
        public virtual tbl_todocategory tbl_todocategory { get; set; }
    }
}
