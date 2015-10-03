using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data.DataObjects
{
    public class ApplicationRefObject
    {
        public static ApplicationRefObject fromDynamic(dynamic apprefData)
        {
            ApplicationRefObject appref = new ApplicationRefObject()
            {
                Name = apprefData.name,
                Description = apprefData.description,
                Homepage = apprefData.homepage,
                IsDeleted = apprefData.deleted,
                Icon = apprefData.icon.normal
            };

            return appref;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Homepage { get; set; }
        public bool IsDeleted { get; set; }
        public string Icon { get; set; } //for now
    }
}
