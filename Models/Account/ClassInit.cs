﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADemo.Models.Account
{
    /// <summary>
    /// 托管服务用于初始化Admin信息
    /// </summary>
    public class ClassInit : BackgroundService
    {
        private readonly IServiceScope iServiceScope;
        public ClassInit(IServiceScopeFactory iServiceScopeFactory)
        {
            this.iServiceScope = iServiceScopeFactory.CreateScope();
        }
        public override void Dispose()
        {
            this.iServiceScope.Dispose();//释放非托管资源 
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var addClassServer = iServiceScope.ServiceProvider.GetRequiredService<InitAdmin>();
            await addClassServer.Manage();
            return;

        }
    }

}
