﻿using Finance.Application.AutoMapper;
using Finance.Application.UseCases.Expenses.Delete;
using Finance.Application.UseCases.Expenses.GetAll;
using Finance.Application.UseCases.Expenses.GetById;
using Finance.Application.UseCases.Expenses.Register;
using Finance.Application.UseCases.Expenses.Reports.Excel;
using Finance.Application.UseCases.Expenses.Reports.Pdf;
using Finance.Application.UseCases.Expenses.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application;
public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {

        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
    }
}
