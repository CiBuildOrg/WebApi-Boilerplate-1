﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;
using ServiceStack.ServiceHost;
using ServiceStack.OrmLite;

namespace WebApi.ServiceModel.Freight
{
    [Route("/freight/login", "Post")]
    public class Freight_Login : IReturn<CommonResponse>
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
    public class Freight_Login_Logic
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        public int LoginCheck(Freight_Login request) 
        {
            int Result = -1;
            try
            {
                using (var db = DbConnectionFactory.OpenDbConnection())
                {
                    Result = db.Scalar<int>(
                        "Select count(*) From Saus1 Where UserId={0} And Password={1}",
                        request.UserId,request.Password
                    );
                }
            }
            catch { throw; }
            return Result;
        }
    }
}
