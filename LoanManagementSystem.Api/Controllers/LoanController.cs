using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.RouteConfig;
using LoanManagementSystem.Services.Loan.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Api.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LoanController : ControllerBase
    {
        
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService _loanService;

        public LoanController(ILogger<LoanController> logger,ILoanService loanService)
        {
            _loanService = loanService;
            _logger = logger;
        }

        [HttpPost(LoanEndpoints.ADD)]
        public async Task<IActionResult> Add([FromBody] LoanModel loanModel)
        {
            try
            {
                var createdLoan = await _loanService.CreateLoan(loanModel);
                return new OkObjectResult(createdLoan);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during process... Details: {ex.Message}");
                return new BadRequestObjectResult("An error occured during process...");
            }
        }

        [HttpGet(LoanEndpoints.GETLOANBYID)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var loansList = await _loanService.GetLoanById(id);
                return new OkObjectResult(loansList);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during process... Details: {ex.Message}");
                return new BadRequestObjectResult("An error occured during process...");
            }
        }

        [HttpGet(LoanEndpoints.GETALLLOANS)]
        public async Task<IActionResult> All()
        {
            try
            {
                var loansList = await _loanService.GetAllLoans();
                return new OkObjectResult(loansList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during process... Details: {ex.Message}");
                return new BadRequestObjectResult("An error occured during process...");
            }
        }

        [HttpPut(LoanEndpoints.UPDATE)]
        public async Task<IActionResult> Update([FromBody] LoanModel loanModel)
        {
            try
            {
                var createdLoan = await _loanService.UpdateLoan(loanModel);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during process... Details: {ex.Message}");
                return new BadRequestObjectResult("An error occured during process...");
            }
        }
    }
}
