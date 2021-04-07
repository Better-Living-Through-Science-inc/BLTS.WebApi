using BLTS.WebApi.Models;
using System;

namespace BLTS.WebApi.DtoModels
{
    public interface IDtoEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
    }
}