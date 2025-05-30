using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class Feature
    {
        /// <summary>
        /// Left Side Navigation Main Menu
        /// </summary>
        public int FeatureId { get; set; }

        // Display name of the menu item
        public string FeatureName { get; set; }

        // ordering / sorting items
        public int Order { get; set; }

        // Flag for active/inactive menu items
        public bool IsActive { get; set; } = true;

        public bool IsVisible { get; set; } = true;
    }
}
