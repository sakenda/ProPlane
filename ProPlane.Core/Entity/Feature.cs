using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProPlane.Core.Entity
{
    public class Feature
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}