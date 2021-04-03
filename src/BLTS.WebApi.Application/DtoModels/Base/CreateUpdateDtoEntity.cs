using System;

namespace BLTS.WebApi.DtoModels
{
    /// <summary>
    /// base entity used by the repository pattern
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class CreateUpdateDtoEntity<TPrimaryKey>
    {
        protected CreateUpdateDtoEntity()
        {
            CreationTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Dto ID reference for data sync - Surrogate ID from system of record - 0 if not syncronized
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// DateTime of Creation
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
