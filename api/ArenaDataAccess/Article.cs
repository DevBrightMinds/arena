//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArenaDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string ArticleName { get; set; }
        public Nullable<int> IsPublished { get; set; }
        public string DateCreated { get; set; }
        public string ImageUrl { get; set; }
    }
}
