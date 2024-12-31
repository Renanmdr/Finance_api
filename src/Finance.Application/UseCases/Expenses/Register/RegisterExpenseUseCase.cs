using AutoMapper;
using Finance.Communication.Requests;
using Finance.Communication.Responses;
using Finance.Domain.Entities;
using Finance.Domain.Repositories;
using Finance.Domain.Repositories.Expenses;
using Finance.Exception.ExceptionsBase;
 

namespace Finance.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        

        var entity = _mapper.Map<Expense>(request);

       await _repository.Add(entity);
       await  _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterExpenseJson>(entity);
    }

    private void Validate(RequestExpenseJson request) {

        var validator = new ExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
           
             throw new ErrorOnValidationException(errorMessages);
        }
    }
}
