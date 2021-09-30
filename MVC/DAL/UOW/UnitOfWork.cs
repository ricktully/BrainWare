using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        // ILogger logger;
        private BrainwareContext context;

        private CompanyRepository companyRepository;

        public UnitOfWork(BrainwareContext context)
        {
            //if (loggerFactory != null)
            //{
            //    //this.logger = loggerFactory.CreateLogger("DAL.UnitOfWork");
            //    //context.Database.Log = message => logger.LogInformation(message);
            //}
            this.context = context;
        }

        public CompanyRepository CompanyRepository
        {
            get
            {
                if (this.companyRepository == null)
                {
                    this.companyRepository = new CompanyRepository(context);
                }
                return companyRepository;           
             }
        }

        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
