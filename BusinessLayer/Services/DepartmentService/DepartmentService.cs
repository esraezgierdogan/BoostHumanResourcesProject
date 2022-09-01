﻿using BusinessLayer.Models.VMs;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        public async Task<List<GetDepartmentsVM>> GetAllDepartments()
        {
            var departments = await departmentRepository.GetFilteredList(
                selector: x => new GetDepartmentsVM
                {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName,
                    DepartmentDescription = x.DepartmentDescription
                },
                expression: x => x.DepartmentName != null,
                orderBy: x => x.OrderBy(x => x.DepartmentName));
            return departments;
        }

        public Task<bool> Any(Expression<Func<Department, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllWhere(Expression<Func<Department, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<Department, TResult>> selector, Expression<Func<Department, bool>> expression, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = null, Func<IQueryable<Department>, IIncludableQueryable<Department, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<Department, TResult>> selector, Expression<Func<Department, bool>> expression, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = null, Func<IQueryable<Department>, IIncludableQueryable<Department, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetWhere(Expression<Func<Department, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
