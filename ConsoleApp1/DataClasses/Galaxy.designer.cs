using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace helloworld.Lib.DataClasses
{                            
    public partial class Galaxy
    {
        private void InitPoco()
        {
            
            
                this.Stars = new BindingList<Star>();
            

        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "GalaxyId")]
        public String GalaxyId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FirstSeen")]
        public Nullable<Int32> FirstSeen { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "HaveVisited")]
        public Nullable<Boolean> HaveVisited { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Stars")]
        public BindingList<Star> Stars { get; set; }
            
        /// <summary>
        /// Find the related Stars (from the list provided) and attach them locally to the Stars list.
        /// </summary>
        public void LoadStars(IEnumerable<Star> stars)
        {
            stars.Where(whereStar => whereStar.Galaxy == this.GalaxyId)
                    .ToList()
                    .ForEach(feStar => this.Stars.Add(feStar));
        }
        

        
        
        private static string CreateGalaxyWhere(IEnumerable<Galaxy> galaxies, String forignKeyFieldName = "GalaxyId")
        {
            if (!galaxies.Any()) return "1=1";
            else 
            {
                var idList = galaxies.Select(selectGalaxy => String.Format("'{0}'", selectGalaxy.GalaxyId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
