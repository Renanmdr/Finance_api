using CommomTestUtilities.Requests;
using Finance.Application.UseCases.Expenses;
using Finance.Communication.Enums;
using Finance.Exception;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        
        //Act
        var result = validator.Validate(request);

        //Assert

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void TitleEmptyErro(string title)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;
        

        //Act
        var result = validator.Validate(request);

        //Assert

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_IS_REQUIRED));
    }

    [Fact]
    public void DateFutureError()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);


        //Act
        var result = validator.Validate(request);

        //Assert

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_BE_FOR_THE_FUTURE));
    }

    [Fact]
    public void PaymentTypeIsInEnumError()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)10;


        //Act
        var result = validator.Validate(request);

        //Assert

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_IS_NOT_VALID));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    public void AmountGreaterThanZeroError(decimal amount)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;


        //Act
        var result = validator.Validate(request);

        //Assert

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
}
 