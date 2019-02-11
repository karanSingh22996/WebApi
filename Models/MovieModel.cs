//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// movie model is a model class for movie database
    /// </summary>
    public class MovieModel
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
        /// Gets or sets the name of the movie.
        /// </summary>
        /// <value>
        /// The name of the movie.
        /// </value>
        [Required]
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        [Required]
        public string Actor { get; set; }

        /// <summary>
        /// Gets or sets the director.
        /// </summary>
        /// <value>
        /// The director.
        /// </value>
        [Required]
        public string Director { get; set; }

        /// <summary>
        /// Gets or sets the producer.
        /// </summary>
        /// <value>
        /// The producer.
        /// </value>
        [Required]
        public string Producer { get; set; }

        /// <summary>
        /// Gets or sets the date of release.
        /// </summary>
        /// <value>
        /// The date of release.
        /// </value>
        [Required]
        public string DateOfRelease { get; set; }
    }
}
