﻿using Microsoft.Extensions.DependencyInjection;
using Project.BLL.DTOClasses.Abstracts;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class ManagerService
    {
        public static IServiceCollection AddManagerService(this IServiceCollection service)
        {
            service.AddScoped(typeof(IManager<IEntity,IDTO>), typeof(BaseManager<IEntity,IDTO>));
            service.AddScoped<IAppRoleManager,AppRoleManager>();
            service.AddScoped<IAppUserManager, AppUserManager>();
            service.AddScoped<IAppUserRoleManager, AppUserRoleManager>();
            service.AddScoped<IAuthorManager, AuthorManager>();
            service.AddScoped<IBookManager, BookManager>();
            service.AddScoped<IBookShelfManager, BookShelfManager>();
            service.AddScoped<ICategoryManager, CategoryManager>(); 
            service.AddScoped<IEditorManager, EditorManager>();
            service.AddScoped<IOrderDetailManager, OrderDetailManager>();
            service.AddScoped<IOrderManager, OrderManager>();
            return service;
        }
    }
}
