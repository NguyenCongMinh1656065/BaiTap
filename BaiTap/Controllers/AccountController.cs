using AutoMapper;
using BaiTap.Dto;
using BaiTap.interfaces;
using BaiTap.Models;
using BaiTap.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepisitory _accountRepository;
        private readonly IMapper _mapper;


        public AccountController(IAccountRepisitory accountRepisitory, IMapper mapper)
        {
            _accountRepository = accountRepisitory;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Account>))]
        public IActionResult GetAccounts()
        {
            var account = _mapper.Map<List<AccountDto>>(_accountRepository.GetAccounts());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(account);
        }
        [HttpGet("{accId}")]
        [ProducesResponseType(200, Type = typeof(Account))]
        public IActionResult GetAccount(int accId)
        {
            if (!_accountRepository.AccountExists(accId))
                return NotFound();
            var account = _mapper.Map<AccountDto>(_accountRepository.GetAccount(accId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(account);
        }
        [HttpPost]
        public IActionResult CreateAccount([FromQuery] int userId, [FromQuery] int catId, [FromBody] AccountDto accountCreate)
        {
            if (accountCreate == null)
                return BadRequest(ModelState);

            var accounts = _accountRepository.GetAccountTrimToUpper(accountCreate);

            if (accounts != null)
            {
                ModelState.AddModelError("", "user already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountMap = _mapper.Map<Account>(accountCreate);


            if (!_accountRepository.CreateAccount(userId, catId, accountMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{accId}")]
        public IActionResult UpdatePokemon(int accId,
            [FromQuery] int userId, [FromQuery] int catId,
            [FromBody] AccountDto updatedAccount)
        {
            if (updatedAccount == null)
                return BadRequest(ModelState);

            if (accId != updatedAccount.Id)
                return BadRequest(ModelState);

            if (!_accountRepository.AccountExists(accId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var accountMap = _mapper.Map<Account>(updatedAccount);

            if (!_accountRepository.UpdateAccount(userId, catId, accountMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteAccount(int accountId)
        {
            if (!_accountRepository.AccountExists(accountId))
            {
                return NotFound();
            }

            var accounttoDelete = _accountRepository.GetAccount(accountId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_accountRepository.DeleteAccount(accounttoDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
