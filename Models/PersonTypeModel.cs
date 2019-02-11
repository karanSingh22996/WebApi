//-----------------------------------------------------------------------
// <copyright file="PersonTypeModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    public class PersonTypeModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the p.
        /// </summary>
        /// <value>
        /// The name of the p.
        /// </value>
        [Required]
        public string P_Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the p.
        /// </summary>
        /// <value>
        /// The type of the p.
        /// </value>
        [Required]
        public string P_Type { get; set; }

        /// <summary>
        /// Gets or sets the p bio.
        /// </summary>
        /// <value>
        /// The p bio.
        /// </value>
        [Required]
        public string P_Bio { get; set; }
    }
}
