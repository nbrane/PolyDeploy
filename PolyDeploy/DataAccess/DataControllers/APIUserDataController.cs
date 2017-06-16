﻿using Cantarus.Modules.PolyDeploy.DataAccess.Models;
using DotNetNuke.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cantarus.Modules.PolyDeploy.DataAccess.DataControllers
{
    internal class APIUserDataController
    {
        public void Create(APIUser apiUser)
        {
            using (IDataContext context = DataContext.Instance())
            {
                var repo = context.GetRepository<APIUser>();

                repo.Insert(apiUser);
            }
        }

        public APIUser Get(int apiUserId)
        {
            using (IDataContext context = DataContext.Instance())
            {
                var repo = context.GetRepository<APIUser>();

                return repo.GetById<int>(apiUserId);
            }
        }

        public APIUser Get(string apiKey)
        {
            using (IDataContext context = DataContext.Instance())
            {
                var repo = context.GetRepository<APIUser>();

                return repo.Find("WHERE APIKey = @0", apiKey).FirstOrDefault<APIUser>();
            }
        }

        public void Update(APIUser apiUser)
        {
            using (IDataContext context = DataContext.Instance())
            {
                var repo = context.GetRepository<APIUser>();

                repo.Update(apiUser);
            }
        }

        public void Delete(APIUser apiUser)
        {
            using (IDataContext context = DataContext.Instance())
            {
                var repo = context.GetRepository<APIUser>();

                repo.Delete(apiUser);
            }
        }
    }
}
