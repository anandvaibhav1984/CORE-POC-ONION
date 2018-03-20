using cBaseQms.Core.Repositry.Repositories;
using cBaseQms.Core.Services.Models;
using FluentValidation;

namespace cBaseQMS.Api.Validatiors
{
    public class TestMasterValidator : AbstractValidator<TestMasterViewModel>
    {
        public TestMasterValidator(ITestMasterRepository testMasterRepository)
        {
            When(validateOperation, () =>
            {
                RuleFor(x => x.TestMasterName).NotEmpty().WithMessage("test Name Can't be empty");
                RuleFor(x => x.TestMasterName).Must((o, x) => { return testMasterRepository.GetCountTestMasterByName(o.TestMasterName); }).WithMessage("Test Name already exists");
            });

        }

        private bool validateOperation(TestMasterViewModel testsViewModel)
        {
            if (testsViewModel.operation.ToLower() != "delete")// || testsViewModel.Operation.ToLower() == "update" || testsViewModel.Operation.ToLower() == "move" || testsViewModel.Operation.ToLower() == "update"
            {
                return true;
            }
            else
                return false;
        }
    }
}