using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSample.Domain.Entities;

namespace TestSample.Persistance.Interface
{
    public interface IInsurerDao
    {
        Insurer Get(int Id);

        List<Insurer> GetAll(bool? IsActive, string Search, int Page, int NoOfRecords);

        List<Insurer> GetByName(string Name, int Id);

        List<Insurer> GetByInternalCode(string InternalCode, int Id);

        List<Insurer> GetByProductSubCategory(int ProductSubCategoryId);

        int Save(Insurer I, long CreatedOrModifiedBy);

        int Delete(int Id, long DeletedBy);
    }
}