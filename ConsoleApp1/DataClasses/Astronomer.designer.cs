using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace helloworld.Lib.DataClasses
{                            
    public partial class Astronomer
    {
        private void InitPoco()
        {
            
            
                this.FoundBy_Stars = new BindingList<Star>();
            

        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AstronomerId")]
        public String AstronomerId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FoundBy_Stars")]
        public BindingList<Star> FoundBy_Stars { get; set; }
            
        /// <summary>
        /// Find the related Stars (from the list provided) and attach them locally to the Stars list.
        /// </summary>
        public void LoadFoundBy_Stars(IEnumerable<Star> stars)
        {
            stars.Where(whereStar => whereStar.FoundBy == this.AstronomerId)
                    .ToList()
                    .ForEach(feStar => this.FoundBy_Stars.Add(feStar));
        }
        

        
        
        private static string CreateAstronomerWhere(IEnumerable<Astronomer> astronomers, String forignKeyFieldName = "AstronomerId")
        {
            if (!astronomers.Any()) return "1=1";
            else 
            {
                var idList = astronomers.Select(selectAstronomer => String.Format("'{0}'", selectAstronomer.AstronomerId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
