// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTaskModel.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The user task model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Models
{
    using System;

    using Java.Security;

    using SQLite;

    /// <summary>
    ///     The user task model.
    /// </summary>
    [Table("UserTasks")]
    public class UserTaskModel : ICloneable, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskModel"/> class.
        /// </summary>
        public UserTaskModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskModel"/> class.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="place">
        /// The place.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        public UserTaskModel(DateTime date, string name, string description, string place, DateTime endDate)
        {
            this.Date = date;
            this.Name = name;
            this.Description = description;
            this.Place = place;
            this.EndDate = endDate;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Returns clone of this instance.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Clone()
        {
            return new UserTaskModel(this.Date, this.Name, this.Description, this.Place, this.EndDate);
        }

        /// <summary>
        /// The compare to.
        /// </summary>
        /// <param name="obj">
        /// DateInfoModel comparing object.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CompareTo(object obj)
        {
            UserTaskModel compModel = (UserTaskModel)obj;

            if (compModel == null)
            {
                return -1;
            }

            if (this.Date == compModel.Date &&
                this.Name == compModel.Name &&
                this.Description == compModel.Description &&
                this.Place == compModel.Place &&
                this.EndDate == compModel.EndDate)
            {
                return 0;
            }

            return this.Date.CompareTo(compModel.Date);
        }
    }
}