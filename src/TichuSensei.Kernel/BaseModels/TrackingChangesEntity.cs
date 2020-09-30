using System;

namespace TichuSensei.Kernel.BaseModels
{
    public abstract class TrackingChangesEntity
    {
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The user who created this entity.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date and time this entity was last modified.
        /// </summary>
        public DateTime? DateLastModified { get; set; }

        /// <summary>
        /// The user who modified this entity last.
        /// </summary>
        public string LastModifiedBy { get; set; }
    }
}
