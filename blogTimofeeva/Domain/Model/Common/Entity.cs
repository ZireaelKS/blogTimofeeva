using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogTimofeeva.Domain.Model.Common
{
    /// <summary>
    /// Интерфейс модели сущности
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Создание экземпляра модели сущности
        /// </summary>
        protected Entity()
        { }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public virtual long Id { get; set; }
    }
}
